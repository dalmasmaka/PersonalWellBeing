import { Doctor } from "../../app/model/doctor";
import Grid from '@mui/material/Grid';
import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';
import Avatar from "@mui/material/Avatar";
import { useEffect, useState } from "react";
import Button from "@mui/material/Button";
import { NavLink } from 'react-router-dom';
import agent from "../../app/api/agent";
import Footer from "../homePage/Footer";
const appointmentLink = [
  { title: 'Make an appointment', path: '/appointmentForm' },
]
const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
  ...theme.typography.body2,
  padding: 5,
  color: theme.palette.text.secondary,
  height: '120%',
  justifyContent: 'center'

}));
export default function Doctors() {
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    agent.Doctors.list().then(doctors => setDoctors(doctors)).finally(() => setLoading(false))
  }, [])


  return (
    <>
      <Grid container direction="row" justifyContent="center">
        {doctors.map((doctor) => (
          <Grid xs={2} key={doctor.doctorId} margin={5}>
            <Item>
              <Avatar src={doctor.doctorImg} sx={{ height: 150, width: 150 }} />
              <Grid sx={{ height: 200 }}>
                <h4>{doctor.doctorName} {doctor.doctorSurname}</h4>
                <p>{doctor.doctorSummary}</p>
              </Grid>
            </Item>
          </Grid>
        ))}
      </Grid>
      <Grid margin={5} >
        {appointmentLink.map(({ title, path }) => (
          <Button fullWidth component={NavLink} to={path}> {title}</Button>
        ))}
      </Grid>
      <Footer/>
    </>

  )
}