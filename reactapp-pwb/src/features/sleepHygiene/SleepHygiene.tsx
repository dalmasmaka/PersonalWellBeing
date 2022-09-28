import { useEffect, useState } from "react";
import { SleepHygiene } from "../../app/model/sleephygiene";
import { styled } from '@mui/material/styles';
import MuiGrid from '@mui/material/Grid';
import Divider from '@mui/material/Divider';
import agent from "../../app/api/agent";

const Grid = styled(MuiGrid)(({ theme }) => ({
    width: '100%',
    ...theme.typography.body2,
    '& [role="separator"]': {
      margin: theme.spacing(0, 2),
    },
  }));

export default function Sleep(){
    const[sleep, setSleep]=useState<SleepHygiene[]>([]);
    useEffect(()=>{
        agent.SleepHygiene.list().then(sleep=>setSleep(sleep))
    },[])
    return(
        <div style={{margin:30}}>
        {sleep.map((sleep)=>(
            <Grid container key={sleep.sleepHygieneId}>
                <Grid item xs >
                    <img style={{maxWidth:'50%', alignContent:'center'}} src={sleep.sleepingHygieneImg} />
                </Grid>
                <Divider orientation="vertical" flexItem style={{fontSize:20}}>{sleep.sleepHygieneTitle}</Divider>
                <Grid item xs>
                    <p style={{fontSize:20}}>{sleep.sleepHygieneDescription}</p>
                </Grid>
            </Grid>
        ))}
        </div>

    )

}