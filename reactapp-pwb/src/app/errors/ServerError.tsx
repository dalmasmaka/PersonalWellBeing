import { Container, Paper, Typography } from "@mui/material";
import Button from "@mui/material/Button";
import Divider from "@mui/material/Divider";
import { useHistory, useLocation } from "react-router";


export default function ServerError(){
    const history = useHistory();
    const {state}=useLocation<any>();
    return(
        <Container component={Paper}>
            {state?.error ? (
                <>
                    <Typography variant='h3' color='error' gutterBottom>{state.error.title}</Typography>
                    <Divider />
                    <Typography>{state.error.detail || 'Internal server error'}</Typography>
                </>
            ) : (
                <Typography variant='h5' gutterBottom>Server Error</Typography>
            )}
            <Button onClick={() => history.push('/ ')}>Go back to the main menu</Button>
            {/* <Typography variant='h5' gutterBottom>Server Error</Typography> */}
        </Container>
    )
}