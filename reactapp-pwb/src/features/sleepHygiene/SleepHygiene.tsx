import { useEffect, useState } from "react";
import { SleepHygiene } from "../../app/model/sleephygiene";
import { styled } from '@mui/material/styles';
import MuiGrid from '@mui/material/Grid';
import Divider from '@mui/material/Divider';
import agent from "../../app/api/agent";
import LoadingComponents from "../../app/layout/LoadingComponent";
import { Container } from "@mui/material";
import Footer from "../homePage/Footer";

const Grid = styled(MuiGrid)(({ theme }) => ({
    width: '100%',
    ...theme.typography.body2,
    '& [role="separator"]': {
        margin: theme.spacing(0, 2),
    },
}));

export default function Sleep() {
    const [sleep, setSleep] = useState<SleepHygiene[]>([]);
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        agent.SleepHygiene.list().then(sleep => setSleep(sleep)).finally(() => setLoading(false))
    }, [])
    if (loading) return <LoadingComponents message="Loading sleep hygiene" />
    return (
        <>
                <Container>
            {sleep.map((sleep) => (
                <Grid container key={sleep.sleepHygieneId}>
                    <Grid item xs sx={{alignContent:"center"}}>
                        <img style={{ maxWidth: '50%', alignContent: 'center' }} src={sleep.sleepingHygieneImg} alt={sleep.sleepHygieneTitle}/>
                    </Grid>
                    <Divider orientation="vertical" flexItem style={{ fontSize: 20 }}>{sleep.sleepHygieneTitle}</Divider>
                    <Grid item xs>
                        <p style={{ fontSize: 20 }}>{sleep.sleepHygieneDescription}</p>
                    </Grid>
                </Grid>
            ))}
        </Container>
        <Footer/>
        </>

        

    )

}