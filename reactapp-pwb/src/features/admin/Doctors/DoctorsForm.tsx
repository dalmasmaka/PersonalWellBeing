import { LoadingButton } from "@mui/lab";
import { Box, Paper, Typography, Grid, Button, FormHelperText } from "@mui/material";
import { useEffect } from "react";
import { FieldValues, useForm } from "react-hook-form";
import AppDropZone from "../../../app/components/AppDropZone";
import AppTextInput from "../../../app/components/AppTextInput";
import { Doctor } from "../../../app/model/doctor";
import { yupResolver } from '@hookform/resolvers/yup';
import { doctorsValidation } from "../validation";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import agent from "../../../app/api/agent";
import { setDoctor } from "../../doctors/doctorSlice";


interface Props {
    doctor?: Doctor;
    cancelEdit: () => void;
}

export default function DoctorsForm({ doctor, cancelEdit }: Props) {
    const { control, reset, handleSubmit, watch, formState: { isDirty, isSubmitting } } = useForm({
        resolver: yupResolver(doctorsValidation)
    });
    const watchFile = watch('file', null);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (doctor && !watchFile && !isDirty) reset(doctor);
        return () => {
            if (watchFile) URL.revokeObjectURL(watchFile.preview);
        }
    }, [doctor, reset, watchFile, isDirty])
    async function handleSubmitData(data: FieldValues) {
        try {
            let response: Doctor;
            if (doctor) {
                response = await agent.Admin.updateDoctor(data);
            }
            else {
                response = await agent.Admin.createDoctor(data);
            }
            dispatch(setDoctor(response))
            cancelEdit();
        } catch (error) {
            console.log(error);
        }
    }
    return (
        <Box component={Paper} sx={{ p: 4 }}>
            <Typography variant="h4" gutterBottom sx={{ mb: 4 }}>
                Doctor Details
            </Typography>
            <form onSubmit={handleSubmit(handleSubmitData)}>
                <Grid container spacing={3}>
                    <Grid item xs={12} sm={6}>
                        <AppTextInput control={control} name='doctorName' label='Name' />

                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <AppTextInput control={control} name='doctorSurname' label='Surname' />
                    </Grid>
                    <Grid item xs={12}>
                        <AppTextInput multiline={true} rows={4} control={control} name='doctorSummary' label='Summary' />
                    </Grid>
                    <Grid item xs={12}>
                        <Box display='flex' justifyContent='space-between' alignItems='center'>
                            <AppDropZone control={control} name='file' />
                            {watchFile ? (
                                <img src={watchFile.preview} alt="preview" style={{ maxHeight: 200 }} />
                            ) : (
                                <img src={doctor?.doctorImg} alt={doctor?.doctorName} style={{ maxHeight: 200 }} />
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