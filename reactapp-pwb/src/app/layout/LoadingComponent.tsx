import { Backdrop, CircularProgress, Typography } from "@mui/material";
import { Box } from "@mui/system";

interface Props{
    message?: string;
}

export default function LoadingComponents({message='Loading...'}:Props){
    return(
        <Backdrop open={true} invisible={true}>
            <Box display='flex' justifyContent='center' alignItems='center' height='100hv'> 
                <CircularProgress size={100} color='inherit'/>
                <Typography variant="h4" sx={{justifyContent:'center', position:'fixed', top:'60%' }}>{message}</Typography>
            </Box>
        </Backdrop>
    )
}