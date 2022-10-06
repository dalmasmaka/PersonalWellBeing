import { Edit, Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import agent from "../../../app/api/agent";
import { Exercise } from "../../../app/model/exercises";
import { Food } from "../../../app/model/food";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import { removeExercise } from "../../exercises/exercisesSlice";
import { removeFood } from "../../food/foodSlice";
import ExercisesForm from "../Exercises/ExercisesForm";
import FoodForm from "../Food/FoodForm";




export default function NutritionFood() {

    const [food, setFood] = useState<Food[]>([]);
    const dispatch = useAppDispatch();
    const [editMode, setEditMode] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState(0);
    useEffect(() => {
        agent.FoodItems.list().then(food => setFood(food))
    }, [food]);
    const [selectedFood, setSelectedFood] = useState<Food | undefined>(undefined);
    function handleSelectFood(food: Food) {
        setSelectedFood(food);
        setEditMode(true);
    }

    function handleDeleteFood(nutritionFoodItemId: number) {
        setLoading(true);
        setTarget(nutritionFoodItemId);
        agent.Admin.deleteFood(nutritionFoodItemId)
            .then(() => dispatch(removeFood(nutritionFoodItemId)))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }
    function cancelEdit() {
        if (selectedFood) setSelectedFood(undefined);
        setEditMode(false);
    }
    if (editMode) return <FoodForm food={selectedFood} cancelEdit={cancelEdit} />
    return (
        <Box sx={{ width: "100%" }} >
            <Box display='flex' justifyContent='space-between' >
                <Typography sx={{ p: 2 }} variant='h4'>Recipes</Typography>
                <Button onClick={() => setEditMode(true)} sx={{ m: 2 }} size='large' variant='contained'>Create</Button>
            </Box>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 1000, justifyContent: "center" }} aria-label="simple table" >
                    <TableHead>
                        <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell align="left">Image</TableCell>
                            {/* <TableCell align="right">Name</TableCell> */}
                            <TableCell align="center">Title</TableCell>
                            <TableCell align="center">Description</TableCell>
                            <TableCell align="right"></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {food.map((food) => (
                            <TableRow
                                key={food.nutritionFoodItemId}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    {food.nutritionFoodItemId}
                                </TableCell>
                                <TableCell align="left">
                                    <Box display='flex' alignItems='center' key={food.nutritionFoodItemId}>
                                        <img src={food.nutritionFoodItemImg} style={{ height: 50, marginRight: 20 }} />
                                    </Box>
                                </TableCell>
                                {/* <TableCell align="right" >{doctor.doctorName}</TableCell> */}
                                <TableCell align="center" >{food.nutritionFoodItemTitle}</TableCell>
                                <TableCell align="center" >{food.nutritionFoodItemDescription}</TableCell>

                                <TableCell align="right">
                                    <Button onClick={() => handleSelectFood(food)} startIcon={<Edit />} />
                                    <LoadingButton loading={loading && target === food.nutritionFoodItemId} startIcon={<Delete />} color='error'
                                        onClick={() => handleDeleteFood(food.nutritionFoodItemId)} />
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Box>
    )
}