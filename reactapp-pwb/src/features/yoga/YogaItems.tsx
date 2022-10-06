import { Card, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import LoadingComponents from "../../app/layout/LoadingComponent";
import { Yoga } from "../../app/model/yoga";
import Footer from "../homePage/Footer";

export default function YogaItems() {
    const [yogaItems, setyogaItems] = useState<Yoga[]>([]);
    const [loading, setLoading]=useState(true)
    useEffect(() => {
        agent.YogaItems.list().then(yogaItems => setyogaItems(yogaItems)).finally(()=>setLoading(false))
    }, [])
    if (loading) return <LoadingComponents message="Loading yoga" />
    return (
        <>
                <Grid container direction="row" justifyContent="center"  >
            {yogaItems.map((yogaItems) => (
                <Grid style={{ margin: 30 }} key={yogaItems.yogaItemId}>
                    <Card sx={{ width: 450 }} >
                        <CardMedia
                            sx={{ height: 300 }}
                            image={yogaItems.yogaItemImg}
                        />
                        <CardContent sx={{ height: 400 }}>
                            <Typography variant="h4">{yogaItems.yogaItemTitle}</Typography>
                            <Typography>{yogaItems.yogaItemDescription}</Typography>
                        </CardContent>
                    </Card>
                </Grid>

            ))}
        </Grid>
        <Footer/>
        </>



    )
}