import { Card, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { Food } from "../../app/model/food";
import agent from "../../app/api/agent";
import LoadingComponents from "../../app/layout/LoadingComponent";
import Footer from "../homePage/Footer";
export default function NutritionFoodItems() {
    const [food, setFood] = useState<Food[]>([]);
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        agent.FoodItems.list().then(food => setFood(food)).finally(() => setLoading(false))
    }, [])
    if (loading) return <LoadingComponents message="Loading receipts" />
    return (
        <>
         <Grid container direction="row" justifyContent="center"  >
            {food.map((food) => (
                <Grid style={{ margin: 30 }} key={food.nutritionFoodItemId}>
                    <Card sx={{ width: 450 }}>
                        <CardMedia
                            sx={{ height: 300 }}
                            image={food.nutritionFoodItemImg}
                        />
                        <CardContent sx={{ height: 400 }}>
                            <Typography variant="h4">{food.nutritionFoodItemTitle}</Typography>
                            <Typography fontSize={15}>{food.nutritionFoodItemDescription}</Typography>
                        </CardContent>
                    </Card>
                </Grid>

            ))}
        </Grid>
        <Footer/>
        </>
       
    )
}