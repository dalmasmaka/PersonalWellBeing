import { ThemeProvider} from "@emotion/react";
import {  createTheme, Grid } from "@mui/material";
import CssBaseline from "@mui/material/CssBaseline";
import { useCallback, useEffect, useState} from "react";
import Header from "./Header";
import MainMenu from "../../features/menu/MainMenu";
import TheTeam from '../../features/members/TheTeam'
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
import Dashboard from "../../features/admin/Dashboard"


function App() {
  const dispatch = useAppDispatch();
  const[loading, setLoading]=useState(true)
  const initApp = useCallback(async()=>{
    try{
      await dispatch(fetchCurrentUser())
    }
    catch(error){
      console.log(error)
    }
  },[dispatch])

 
  useEffect(()=>{
    initApp().then(()=>setLoading(false));
  }, [initApp])
  const [darkMode, setDarkMode]=useState(false);
  const paletteType=darkMode? 'dark' : 'light';
  const theme = createTheme({
    palette:{
      mode:paletteType,
      background:{
        default:paletteType==='light'? '#eaeaea' : '#121212'
      }
    }
  })
  function handleThemeChange(){
    setDarkMode(!darkMode);
  }
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
           <Route exact path="/dashboard" component={Dashboard}/>
           <Route exact path="/members" component={TheTeam}/>
           <Route exact path="/about" component={AboutPage}/>
           <Route exact path="/exercises" component={ExercisesItems}/>
           <Route exact path="/doctors"  component={Doctors}/>
           <Route exact path="/yoga" component={YogaItems} />
           <Route exact path="/food" component={NutritionFoodItems}/>
           <Route exact path="/sleep" component={Sleep}/>
           <Route exact path="/server-error" component={ServerError} />
           <Route exact path="/login" component={Login}/>
           <Route exact path="/register" component={Register} />
           <Route exact path="/appointment" component={AppointmentForm}/>
           <Route  component={NotFound}/>
       </Switch>
       </Grid>
    )}/>
   </ThemeProvider>
  );
}
export default App;