import { LoadingButton } from "@mui/lab";
import { Box, Paper, Typography, Grid, Button, FormHelperText } from "@mui/material";
import { useEffect } from "react";
import { FieldValues, useForm } from "react-hook-form";
import AppDropZone from "../../../app/components/AppDropZone";
import AppTextInput from "../../../app/components/AppTextInput";
import { yupResolver } from '@hookform/resolvers/yup';
import { exercisesValidation, foodValidation } from "../validation";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import agent from "../../../app/api/agent";
import { Exercise } from "../../../app/model/exercises";
import { setExercise } from "../../exercises/exercisesSlice";
import { Food } from "../../../app/model/food";
import { setFoodItem } from "../../food/foodSlice";


interface Props {
    food?: Food;
    cancelEdit: () => void;
}
export default function FoodForm({ food, cancelEdit }: Props) {
    const { control, reset, handleSubmit, watch, formState: { isDirty, isSubmitting } } = useForm({
        resolver: yupResolver(foodValidation)
    });
    const watchFile = watch('file', null);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (food && !watchFile && !isDirty) reset(food);
        return () => {
            if (watchFile) URL.revokeObjectURL(watchFile.preview);
        }
    }, [food, reset, watchFile, isDirty])
    async function handleSubmitData(data: FieldValues) {
        try {
            let response: Food;
            if (food) {
                response = await agent.Admin.updateFood(data);
            }
            else {
                response = await agent.Admin.createFood(data);
            }
            dispatch(setFoodItem(response))
            cancelEdit();
        } catch (error) {
            console.log(error);
        }
    }
    return (
        <Box component={Paper} sx={{ p: 4 }}>
            <Typography variant="h4" gutterBottom sx={{ mb: 4 }}>
                Recipe Details
            </Typography>
            <form onSubmit={handleSubmit(handleSubmitData)}>
                <Grid container spacing={3}>
                    <Grid item xs={12} sm={6}>
                        <AppTextInput control={control} name='nutritionFoodItemTitle' label='Title' />
                    </Grid>
                    <Grid item xs={12}>
                        <AppTextInput multiline={true} rows={4} control={control} name='nutritionFoodItemDescription' label='Description' />
                    </Grid>
                    <Grid item xs={12}>
                        <Box display='flex' justifyContent='space-between' alignItems='center'>
                            <AppDropZone control={control} name='file' />
                            {watchFile ? (
                                <img src={watchFile.preview} alt="preview" key={food?.nutritionFoodItemId} style={{ maxHeight: 200 }} />
                            ) : (
                                <img src={food?.nutritionFoodItemImg} style={{ maxHeight: 200 }} />
                            )}
                        </Box>

                    </Grid>
                </Grid>
                <Box display='flex' justifyContent='space-between' sx={{ mt: 3 }}>
                    <Button onClick={cancelEdit} variant='contained' color='inherit'>Cancel</Button>
                    <LoadingButton loading={isSubmitting} type='submit' variant='contained' color='primary'>Submit</LoadingButton>
                </Box>
            </form>
        </Box>
    );

}