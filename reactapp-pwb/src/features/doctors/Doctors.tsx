import { Doctor } from "../../app/model/doctor";
import Grid from '@mui/material/Grid'; // Grid version 1
import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';
import Avatar from "@mui/material/Avatar";
import {useEffect, useState} from "react";
import Button from "@mui/material/Button";
import { NavLink } from 'react-router-dom';
import agent from "../../app/api/agent";
import AppointmentForm from "../appointments/AppointmentForm";
import { Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { Container } from "@mui/system";
const appointmentLink = [
  {title:'Make an appointment', path: '/appointmentForm'},
]
const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding:5,
    color: theme.palette.text.secondary,
    height:'120%',
    justifyContent:'center'

  }));
export default function Doctors(){
    const [doctors, setDoctors]= useState<Doctor[]>([]);
  useEffect(()=>{
    agent.Doctors.list().then(doctors=>setDoctors(doctors))
  }, [])
  

    return(
    <>
      <Grid container direction="row" justifyContent="center">
            {doctors.map((doctor)=>(
                <Grid xs={2} key={doctor.doctorId} margin={5}> 
                    <Item>
                    <Avatar src={doctor.doctorImg} sx={{height:150, width:150}} />
                    <Grid sx={{height:200}}>
                    <h4>{doctor.doctorName} {doctor.doctorSurname}</h4>
                    <p>{doctor.doctorSummary}</p>
                    </Grid>
                    </Item>
                </Grid>   
            ))}
            </Grid>
            <Grid  margin={5} >
            {appointmentLink.map(({title, path})=>(
        <Button fullWidth component={NavLink} to={path}> {title}</Button>
       ))}
      </Grid>
    </>
       
          
           
            
        
     
      



    // <Grid container direction="row" justifyContent="center"  component={Paper} sx={{display: 'flex', flexDirection: 'column', alignItems:'center', p:4, width:"50%", height:"50%"}}>
     
    //     {doctors.map((doctor)=>(
    //     <>
    //       <Avatar key={doctor.doctorId} src={doctor.doctorImg} sx={{height:150, width:150}} />
    //       <Typography margin={2} variant="h5">{doctor.doctorName} {doctor.doctorSurname}</Typography>
    //       <Typography margin={1} variant="h6">{doctor.doctorSummary}</Typography>
    //     </>
    //    ))}
      //  {appointmentLink.map(({title, path})=>(
      //   <Button fullWidth variant="outlined" component={NavLink} to={path}> {title}</Button>
      //  ))}
    
       
    // </Grid>

      // <Grid>
      //    <Grid container direction="row" justifyContent="center">
      //       {doctors.map((doctor)=>(
      //           <Grid xs={2} key={doctor.doctorId} margin={5}> 
      //               <Item>
      //               <Avatar src={doctor.doctorImg} sx={{height:150, width:150}} />
      //               <div style={{height:'40%'}}>
      //               <h4>{doctor.doctorName} {doctor.doctorSurname}</h4>
      //               <p>{doctor.doctorSummary}</p>
      //               </div>
      //               </Item>
      //           </Grid>   
      //       ))}
          
      //   {appointmentLink.map(({title, path})=>(
      //   <CardActions style={{margin:30}} key={path}>
      //       <Card sx={{width:300}}>
      //       <CardContent>
      //       <Button component={NavLink} to={path}> {title}</Button>
      //          </CardContent>
      //       </Card>
      //   </CardActions>
      //    ))}
           
        
      //   </Grid>
    
      // </Grid>
     
        
    )
}