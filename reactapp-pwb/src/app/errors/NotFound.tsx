import {Container, Paper, Typography, Divider, Button} from "@mui/material";
import { Link } from "react-router-dom";
import { useHistory } from "react-router";
export default function NotFound(){
    const history = useHistory();
    return(
        <Container component={Paper} sx={{height:400}}>
            <Typography gutterBottom variant="h3">Oops - we couldn't find what you are looking for</Typography>
            <Divider/>
            <Button fullWidth component={Link} to={'/mainmenu'}>Go back to the main menu</Button>
        </Container>
        
    )
}