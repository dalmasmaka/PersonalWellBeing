import { ThemeProvider} from "@emotion/react";
import {  createTheme, Grid } from "@mui/material";
import CssBaseline from "@mui/material/CssBaseline";
import { useCallback, useEffect, useState} from "react";
import Header from "./Header";
import MainMenu from "../../features/menu/MainMenu";
import { Route,  Switch, } from "react-router-dom";
import AboutPage from "../../features/about/AboutPage";
import Doctors from "../../features/doctors/Doctors";
import NutritionFoodItems from "../../features/food/NutritionFoodItems";
import YogaItems from "../../features/yoga/YogaItems";
import Sleep from "../../features/sleepHygiene/SleepHygiene";
import { ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css'
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import { useAppDispatch } from "../ourApp/configureApp";
import { fetchCurrentUser } from "../../features/account/accountSlice";
import Login from "../../features/account/Login";
import Register from "../../features/account/Register";
import AppointmentForm from "../../features/appointments/AppointmentForm";
import HomePage from "../../features/homePage/HomePage";
import ExercisesItems from "../../features/exercises/ExercisesITems";
import Dashboard from "../../features/admin/Dashboard";
import PrivateRoute from "./PrivateRoute";
import { fetchDoctorAsync } from "../../features/doctors/doctorSlice";
import LoadingComponent from "./LoadingComponent";


function App() {
  const dispatch = useAppDispatch();
  const[loading, setLoading]=useState(true)
  const initApp = useCallback(async()=>{
    try{
      await dispatch(fetchCurrentUser())
      await dispatch(fetchDoctorAsync());
    }
    catch(error){
      console.log(error)
    }
  },[dispatch])
  useEffect(()=>{
    initApp().then(()=>setLoading(false));
  }, [initApp])
  const [darkMode, setDarkMode]=useState(false);
  //ne qofte se eshte darkmode true merre ngjyren e zeze nese jo tbardhen
  const paletteType=darkMode? 'dark' : 'light';
  const theme = createTheme({
    palette:{
      mode:paletteType,
      background:{
        //ne qofte se eshte light mode on merre ngjyren e kalter nese jo te zezen
        default:paletteType==='light'? '#eaeaea' : '#121212' 
      }
    }
  })
  function handleThemeChange(){
    setDarkMode(!darkMode);
  }
  if (loading) return <LoadingComponent message='Initialising app...' />
  return (
   <ThemeProvider theme={theme}>
    <ToastContainer position="bottom-right" hideProgressBar/>
     <CssBaseline />
     
    <Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
    <Route exact path="/" component={HomePage}/>
    <Route path={'/(.+)'} render={()=>(
       <Grid sx={{mt:4}}>
       <Switch>
       <Route exact path="/mainmenu" component={MainMenu}/>
           <PrivateRoute roles={['Admin']} path="/dashboard" component={Dashboard}/>
           <Route path="/about" component={AboutPage}/>
           <Route path="/exercises" component={ExercisesItems}/>
           <Route path="/doctors"  component={Doctors}/>
           <Route path="/yoga" component={YogaItems} />
           <Route path="/food" component={NutritionFoodItems}/>
           <Route path="/sleep" component={Sleep}/>
           <Route path="/server-error" component={ServerError} />
           <Route path="/login" component={Login}/>
           <Route path="/register" component={Register} />
           <Route path="/appointment" component={AppointmentForm}/>
           <Route  component={NotFound}/>
       </Switch>
       </Grid>
    )}/>
   </ThemeProvider>
  );
}
export default App;