import { Button, ButtonGroup, Typography } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../app/ourApp/configureApp";
import {  increment, decrement } from "./counterSlice";
export default function AboutPage(){
    const dispatch = useAppDispatch();
    const{data,title}=useAppSelector(state=>state.counter);
    // const [validationErrors, setValidationErrors]=useState<string[]>([]);
    // function getValidationError(){
    //     agent.TestErrors.getValidationError()
    //     .then(()=>console.log('should not see this'))
    //     .catch(error => setValidationErrors(error));
    // }
   
    return(
        <>
            <Typography variant="h2">
                {title}
            </Typography>
            <Typography variant="h5">
                The data is: {data}
            </Typography>
            <ButtonGroup>
                <Button onClick={()=>dispatch(decrement(1))} variant="contained" color="error">Decrement</Button>
                <Button onClick={()=>dispatch(increment(1))} variant="contained" color="primary">Increment</Button>
                <Button onClick={()=>dispatch(increment(5))} variant="contained" color="secondary">Increment by 5</Button>
            </ButtonGroup>
        </>
        // <Container>
        //     <Typography sx={{typography:'h6'}}>Errors for testing purposes</Typography>
        //     <ButtonGroup>
        //     <Button  onClick={()=>agent.TestErrors.get400Error().catch(error => console.log(error))}>Test 400</Button>
        //         <Button  onClick={()=>agent.TestErrors.get401Error().catch(error => console.log(error))}>Test 400</Button>
        //         <Button  onClick={()=>agent.TestErrors.get404Error().catch(error => console.log(error))}>Not Found</Button>
        //         <Button  onClick={()=>agent.TestErrors.get500Error().catch(error => console.log(error))}>server Errors</Button>
        //         <Button  onClick={getValidationError}>Validation Errors</Button>
        //     </ButtonGroup>
        // {validationErrors.length > 0 &&
        // <Alert severity='error'>
        //     <AlertTitle>Validation Errors</AlertTitle>
        //     <List>
        //         {validationErrors.map(error=>(
        //             <ListItem key={error}>
        //                 <ListItemText>{error}</ListItemText>
        //             </ListItem>
        //         ))}
        //     </List>
        // </Alert>
        // }
        // </Container>
        
    )
}