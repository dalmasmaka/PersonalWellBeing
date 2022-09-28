import axios, {AxiosError, AxiosResponse} from 'axios';
import { toast } from 'react-toastify';
import { history } from '../..';
import { store } from '../ourApp/configureApp';

const sleep = () =>new Promise(resolve=>setTimeout(resolve, 500));

axios.defaults.baseURL='https://localhost:44339/api/';

//getting the response data and storing in response body
const responseBody=(response:AxiosResponse)=>response.data;

axios.interceptors.request.use(config => { 
    const token = store.getState().account.user?.token;
    if (token) config.headers!.Authorization = `Bearer ${token}`;
    return config;
})

axios.interceptors.response.use(async response =>{
    await sleep();
    return response;
}, (error: AxiosError) =>{
    const {data, status} = error.response as any
    switch (status) {
        case 400:
            if (data.errors) {
                const modelStateErrors: string[] = [];
                for (const key in data.errors) {
               // each one of our erros has a key 
                    if (data.errors[key]) {
                        modelStateErrors.push(data.errors[key])
                    }
                }
                throw modelStateErrors.flat();
            }
            toast.error(data.title);
            break;
        case 401:
            toast.error(data.title );
            break;
            case 404:
            toast.error(data.title);
            break;
        case 500:
            history.push({
                pathname:'/server-error',
                state:{error:data}
            });
           
            break;
        
        default:
            break;
    }
    return Promise.reject(error.response);
})

const requests = {
    get: (url: string, params?:URLSearchParams) => axios.get(url, {params}).then(responseBody),
    post: (url: string, body:{})=> axios.post(url, body).then(responseBody),
    put: (url: string, body:{})=>axios.put(url, body).then(responseBody),
    delete: (url:string)=>axios.delete(url).then(responseBody),


}
const TestErrors={
    get400Error:()=>requests.get('Buggy/bad-request'),
    get401Error:()=>requests.get('Buggy/unathorized'),
    get404Error:()=>requests.get('Buggy/not-found'),
    get500Error:()=>requests.get('Buggy/server-error'),
    getValidationError:()=>requests.get('Buggy/validation-error')
}

const MainMenu={
    list:()=>requests.get('DmenuList'),
    details:(menuListId:number)=>requests.get(`DmenuList/${menuListId}`)
}
const Exercises={
    list:()=>requests.get('Dexercises'),
    details:(exercisesId:number)=>requests.get(`Dexercises/${exercisesId}`),
   
}
const ExercisesItems={
    list:()=>requests.get('DexercisesItems'),
    details:(exerciseItemId:number)=>requests.get(`DexercisesItems/${exerciseItemId}`)
    
}
const Food={
    list:()=>requests.get('DnutritionFood'),
    details:(nutritionFoodId:number)=>requests.get(`DnutritionFood/${nutritionFoodId}`)
}
const FoodItems={
    list:()=>requests.get('DnutritionFooodItems'),
    details:(nutritionFoodItemId:number)=>requests.get(`DnutritionFood/${nutritionFoodItemId}`)
}
const Yoga={
    list:()=>requests.get('Dyoga'),
    details:(yogaId:number)=>requests.get(`Dyoga/${yogaId}`)
}
const YogaItems={
    list:()=>requests.get('DyogaItems'),
    details:(yogaItemId:number)=>requests.get(`DyogaItems/${yogaItemId}`)
}
const SleepHygiene={
    list:()=>requests.get('DsleepHygiene'),
    details:(sleepHygieneId:number)=>requests.get(`DsleepHygiene/${sleepHygieneId}`)
}
const Team={
    list:()=>requests.get('TheTeam'),
    details:(memberId:number)=>requests.get(`TheTeam/${memberId}`)
}
const Doctors={
    list:()=>requests.get('Ddoctors'),
    details:(doctorId:number)=>requests.get(`Ddoctors/${doctorId}`)
}
const Account = {
    login: (values: any) => requests.post('Account/login', values), 
    register: (values: any) => requests.post('Account/register', values),
    currentUser: () => requests.get('Account/currentUser'),
}
const Appointment ={
    makeAppointment:(values: any) => requests.post(`Dappointments`, values),
    list:()=>requests.get('Dappointments'),
    details:(appointmentId:number)=>requests.get(`Dappointments/${appointmentId}`)
}
const agent={
    MainMenu,
    Exercises,
    ExercisesItems,
    Food,
    FoodItems,
    Yoga,
    YogaItems,
    SleepHygiene,
    Team,
    Doctors,
    TestErrors,
    Account,
    Appointment
}
export default agent;