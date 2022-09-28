import Grid from '@mui/material/Grid'; // Grid version 1
import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';
import Avatar from "@mui/material/Avatar";
import {useEffect, useState} from "react";
import { TheTeam } from "../../app/model/theteam";
import agent from '../../app/api/agent';

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding:5,
    color: theme.palette.text.secondary,
    height:'120%',
    justifyContent:'center'

  }));
export default function TeamMembers(){
    const [members, setMembers]= useState<TheTeam[]>([]);
  useEffect(()=>{
    agent.Team.list().then(members=>setMembers(members))
  }, [])

    return(
        <Grid container direction="row" justifyContent="center">
            {members.map((theMember)=>(
                <Grid xs={2} key={theMember.memberId} margin={5}> 
                    <Item>
                    <Avatar src={theMember.memberImg} sx={{height:150, width:150}} />
                    <div style={{height:'40%'}}>
                    <h4>{theMember.memberName} {theMember.memberSurname}</h4>
                    <p>{theMember.memberSummary}</p>
                    </div>
                    </Item>
                </Grid>   
            ))}
        </Grid>
    )
}