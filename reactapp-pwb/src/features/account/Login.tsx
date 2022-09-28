import { LockOutlined } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import {  Checkbox, FormControlLabel, Grid, Paper, Typography } from "@mui/material";
import Avatar from "@mui/material/Avatar";
import TextField from '@mui/material/TextField';
import { Box, Container } from "@mui/system";
import { FieldValues, useForm } from "react-hook-form";
import { Link, useHistory } from "react-router-dom";
import { useAppDispatch } from "../../app/ourApp/configureApp";
import { signInUser } from "./accountSlice";

export default function Login(){
    const history = useHistory();
    const dispatch= useAppDispatch();
    const {register, handleSubmit, formState:{isSubmitting, errors, isValid}} = useForm({
        mode:'all'
    })
    async function submitForm(data: FieldValues){
       await dispatch(signInUser(data));
       history.push('/mainmenu')
    }
    return(
      <Container component={Paper} maxWidth="sm" 
      sx={{display: 'flex', flexDirection: 'column', alignItems:'center', p:4}}>
            <Avatar sx={{m:1, bgcolor: 'primary'}}>
            <LockOutlined />
            </Avatar>
            <Typography component="h1" variant="h5">
                 Sign in for
            </Typography>
            <Typography component="h1" variant="h5">
                 PersonalWellBeing
            </Typography>
            <Box component="form" onSubmit={handleSubmit(submitForm)} noValidate sx={{mt:1}}>
            <TextField
                    margin="normal"
                    fullWidth
                    label="Username"
                    autoFocus
                    {...register('username', { required: 'Username is required' })}
                    error={!!errors.username}

                    
                    
                />
                <TextField
                    margin="normal"
                    fullWidth
                    label="Password"
                    type="password"
                    {...register('password', {required:'Password is required'})}
                    error={!!errors.password}
                    helperText={errors?.password?.message}
                />
                <FormControlLabel
                    control={<Checkbox value="remember" color="primary" />}
                    label="Remember me"
                />
                <LoadingButton loading={isSubmitting}
                 type="submit" fullWidth variant="contained" sx={{mt:3, mb:2}} disabled={!isValid}>
                    Sign in
                </LoadingButton>
                <Grid container>
                  
                    <Grid item>
                        <Link to='/register'>
                            {"Don't have an account? Sign Up"}
                        </Link>
                    </Grid>
                </Grid>
            </Box>
        
      </Container>  
    );
}