import { Card, CardActionArea, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { Exercise } from "../../app/model/exercises";
import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';
import {Container} from '@mui/material';
import {Box} from '@mui/material'
import agent from "../../app/api/agent";
import { useParams } from "react-router-dom";


const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    height:350,
    color: theme.palette.text.secondary,
  }));
  
export default function ExercisesItems(){
  const {}=useParams<{id:string}>();
    const [exercisesItems, setExeItems]= useState<Exercise[]>([]);
    const[loading, setLoading]=useState(true);
  useEffect(()=>{

  agent.ExercisesItems.list().then(exercisesItems=>setExeItems(exercisesItems))
   .catch(error=>console.log(error))
 
    
 
  }, [])


  return(
    <Grid container direction="row" justifyContent="center"  >
    {exercisesItems.map((exercisesItems)=>(
        <Grid style={{margin:30}} key={exercisesItems.exerciseItemId}>
    
            <Card sx={{width:500}}>
                <CardMedia 
                    sx={{height:300}}
                    image={exercisesItems.exerciseItemImg}
                />
                <CardContent sx={{height:200}}>
                    <Typography variant="h4">{exercisesItems.exerciseItemTitle}</Typography>
                    <Typography>{exercisesItems.exerciseItemDescription}</Typography>
                </CardContent>
            </Card>
        </Grid>
        
    ))}
    </Grid>

    
  )
}