import { LoadingButton } from "@mui/lab";
import { Box, Paper, Typography, Grid, Button, FormHelperText } from "@mui/material";
import { useEffect } from "react";
import { FieldValues, useForm } from "react-hook-form";
import AppDropZone from "../../../app/components/AppDropZone";
import AppTextInput from "../../../app/components/AppTextInput";
import { yupResolver } from '@hookform/resolvers/yup';
import { yogaValidation } from "../validation";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import agent from "../../../app/api/agent";
import { Yoga } from "../../../app/model/yoga";
import { setYogaItem } from "../../yoga/yogaSlice";


interface Props {
    yoga?: Yoga;
    cancelEdit: () => void;
}
export default function YogaForm({ yoga, cancelEdit }: Props) {
    const { control, reset, handleSubmit, watch, formState: { isDirty, isSubmitting } } = useForm({
        resolver: yupResolver(yogaValidation)
    });
    const watchFile = watch('file', null);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (yoga && !watchFile && !isDirty) reset(yoga);
        return () => {
            if (watchFile) URL.revokeObjectURL(watchFile.preview);
        }
    }, [yoga, reset, watchFile, isDirty])
    async function handleSubmitData(data: FieldValues) {
        try {
            let response: Yoga;
            if (yoga) {
                response = await agent.Admin.updateYoga(data);
            }
            else {
                response = await agent.Admin.createYoga(data);
            }
            dispatch(setYogaItem(response))
            cancelEdit();
        } catch (error) {
            console.log(error);
        }
    }
    return (
        <Box component={Paper} sx={{ p: 4 }}>
            <Typography variant="h4" gutterBottom sx={{ mb: 4 }}>
                Yoga Details
            </Typography>
            <form onSubmit={handleSubmit(handleSubmitData)}>
                <Grid container spacing={3}>
                    <Grid item xs={12} sm={6}>
                        <AppTextInput control={control} name='yogaItemTitle' label='Title' />
                    </Grid>
                    <Grid item xs={12}>
                        <AppTextInput multiline={true} rows={4} control={control} name='yogaItemDescription' label='Description' />
                    </Grid>
                    <Grid item xs={12}>
                        <Box display='flex' justifyContent='space-between' alignItems='center'>
                            <AppDropZone control={control} name='file' />
                            {watchFile ? (
                                <img src={watchFile.preview} alt="preview" key={yoga?.yogaItemId} style={{ maxHeight: 200 }} />
                            ) : (
                                <img src={yoga?.yogaItemImg} style={{ maxHeight: 200 }} />
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