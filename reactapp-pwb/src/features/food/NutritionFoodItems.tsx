import { Card, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { Food } from "../../app/model/food";
import agent from "../../app/api/agent";
export default function NutritionFoodItems(){
    const [food, setFood]= useState<Food[]>([]);
    useEffect(()=>{
      agent.FoodItems.list().then(food=>setFood(food))
    }, [])
    return(
      <Grid container direction="row" justifyContent="center"  >
      {food.map((food)=>(
          <Grid style={{margin:30}}  key={food.nutritionFoodItemId}>
              <Card sx={{width:450}}>
                  <CardMedia 
                      sx={{height:300}}
                      image={food.nutritionFoodItemImg}
                  />
                  <CardContent sx={{height:400}}>
                      <Typography variant="h4">{food.nutritionFoodItemTitle}</Typography>
                      <Typography>{food.nutritionFoodItemDescription}</Typography>
                  </CardContent>
              </Card>
          </Grid>
          
      ))}
      </Grid> 
    )
}