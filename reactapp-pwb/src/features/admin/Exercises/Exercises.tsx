import { Edit, Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import agent from "../../../app/api/agent";
import { Exercise } from "../../../app/model/exercises";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import { removeExercise } from "../../exercises/exercisesSlice";
import ExercisesForm from "../Exercises/ExercisesForm";




export default function Exercises() {

    const [exercises, setExercises] = useState<Exercise[]>([]);
    const dispatch = useAppDispatch();
    const [editMode, setEditMode] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState(0);
    useEffect(() => {
        agent.ExercisesItems.list().then(exercises => setExercises(exercises))
    }, [exercises]);
    const [selectedExercises, setSelectedExercises] = useState<Exercise | undefined>(undefined);
    function handleSelectExercises(exercises: Exercise) {
        setSelectedExercises(exercises);
        setEditMode(true);
    }

    function handleDeleteExercise(exercisesId: number) {
        setLoading(true);
        setTarget(exercisesId);
        agent.Admin.deleteExercise(exercisesId)
            .then(() => dispatch(removeExercise(exercisesId)))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }



    function cancelEdit() {
        if (selectedExercises) setSelectedExercises(undefined);
        setEditMode(false);
    }
    if (editMode) return <ExercisesForm exercises={selectedExercises} cancelEdit={cancelEdit} />
    return (
        <Box sx={{ width: "100%" }} >
            <Box display='flex' justifyContent='space-between' >
                <Typography sx={{ p: 2 }} variant='h4'>Exercises</Typography>
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
                        {exercises.map((exercise) => (
                            <TableRow
                                key={exercise.exerciseItemId}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    {exercise.exerciseItemId}
                                </TableCell>
                                <TableCell align="left">
                                    <Box display='flex' alignItems='center' key={exercise.exerciseItemId}>
                                        <img src={exercise.exerciseItemImg} style={{ height: 50, marginRight: 20 }} />
                                    </Box>
                                </TableCell>
                                {/* <TableCell align="right" >{doctor.doctorName}</TableCell> */}
                                <TableCell align="center" >{exercise.exerciseItemTitle}</TableCell>
                                <TableCell align="center" >{exercise.exerciseItemDescription}</TableCell>

                                <TableCell align="right">
                                    <Button onClick={() => handleSelectExercises(exercise)} startIcon={<Edit />} />
                                    <LoadingButton loading={loading && target === exercise.exerciseItemId} startIcon={<Delete />} color='error'
                                        onClick={() => handleDeleteExercise(exercise.exerciseItemId)} />
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Box>
    )
}