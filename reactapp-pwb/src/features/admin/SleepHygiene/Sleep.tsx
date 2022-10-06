import { Edit, Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import agent from "../../../app/api/agent";
import { SleepHygiene } from "../../../app/model/sleephygiene";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import { removeSleep } from "../../sleepHygiene/sleepSlice";
import SleepForm from "./SleepForm";



export default function Sleep() {

    const [sleep, setSleep] = useState<SleepHygiene[]>([]);
    const dispatch = useAppDispatch();
    const [editMode, setEditMode] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState(0);
    useEffect(() => {
        agent.SleepHygiene.list().then(sleep => setSleep(sleep))
    }, [sleep]);
    const [selectedSleep, setSelectedSleep] = useState<SleepHygiene | undefined>(undefined);
    function handleSelectSleep(sleep: SleepHygiene) {
        setSelectedSleep(sleep);
        setEditMode(true);
    }

    function handleDeleteSleep(sleepHygieneId: number) {
        setLoading(true);
        setTarget(sleepHygieneId);
        agent.Admin.deleteSleep(sleepHygieneId)
            .then(() => dispatch(removeSleep(sleepHygieneId)))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }
    function cancelEdit() {
        if (selectedSleep) setSelectedSleep(undefined);
        setEditMode(false);
    }
    if (editMode) return <SleepForm sleep={selectedSleep} cancelEdit={cancelEdit} />
    return (
        <Box sx={{ width: "100%" }} >
            <Box display='flex' justifyContent='space-between' >
                <Typography sx={{ p: 2 }} variant='h4'>Sleep Hygiene</Typography>
                <Button onClick={() => setEditMode(true)} sx={{ m: 2 }} size='large' variant='contained'>Create</Button>
            </Box>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 1000, justifyContent: "center" }} aria-label="simple table" >
                    <TableHead>
                        <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell align="left">Image</TableCell>
                            <TableCell align="center">Title</TableCell>
                            <TableCell align="center">Description</TableCell>
                            <TableCell align="right"></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {sleep.map((sleep) => (
                            <TableRow
                                key={sleep.sleepHygieneId}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    {sleep.sleepHygieneId}
                                </TableCell>
                                <TableCell align="left">
                                    <Box display='flex' alignItems='center' key={sleep.sleepHygieneId}>
                                        <img src={sleep.sleepingHygieneImg} style={{ height: 50, marginRight: 20 }} />
                                    </Box>
                                </TableCell>
                                <TableCell align="center" >{sleep.sleepHygieneTitle}</TableCell>
                                <TableCell align="center" >{sleep.sleepHygieneDescription}</TableCell>

                                <TableCell align="right">
                                    <Button onClick={() => handleSelectSleep(sleep)} startIcon={<Edit />} />
                                    <LoadingButton loading={loading && target === sleep.sleepHygieneId} startIcon={<Delete />} color='error'
                                        onClick={() => handleDeleteSleep(sleep.sleepHygieneId)} />
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Box>
    )
}