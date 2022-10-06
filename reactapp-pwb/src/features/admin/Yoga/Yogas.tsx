import { Edit, Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import agent from "../../../app/api/agent";
import { Yoga } from "../../../app/model/yoga";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import { removeYoga } from "../../yoga/yogaSlice";
import YogaForm from "./YogaForm";




export default function Yogas() {

    const [yoga, setYoga] = useState<Yoga[]>([]);
    const dispatch = useAppDispatch();
    const [editMode, setEditMode] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState(0);
    useEffect(() => {
        agent.YogaItems.list().then(yoga => setYoga(yoga))
    }, [yoga]);
    const [selectedYoga, setSelectedYoga] = useState<Yoga | undefined>(undefined);
    function handleSelectYoga(yoga: Yoga) {
        setSelectedYoga(yoga);
        setEditMode(true);
    }

    function handleDeleteYoga(yogaItemId: number) {
        setLoading(true);
        setTarget(yogaItemId);
        agent.Admin.deleteYoga(yogaItemId)
            .then(() => dispatch(removeYoga(yogaItemId)))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }
    function cancelEdit() {
        if (selectedYoga) setSelectedYoga(undefined);
        setEditMode(false);
    }
    if (editMode) return <YogaForm yoga={selectedYoga} cancelEdit={cancelEdit} />
    return (
        <Box sx={{ width: "100%" }} >
            <Box display='flex' justifyContent='space-between' >
                <Typography sx={{ p: 2 }} variant='h4'>Yoga</Typography>
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
                        {yoga.map((yoga) => (
                            <TableRow
                                key={yoga.yogaItemId}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell component="th" scope="row">
                                    {yoga.yogaItemId}
                                </TableCell>
                                <TableCell align="left">
                                    <Box display='flex' alignItems='center' key={yoga.yogaItemId}>
                                        <img src={yoga.yogaItemImg} style={{ height: 50, marginRight: 20 }} />
                                    </Box>
                                </TableCell>
                                <TableCell align="center" >{yoga.yogaItemTitle}</TableCell>
                                <TableCell align="center" >{yoga.yogaItemDescription}</TableCell>

                                <TableCell align="right">
                                    <Button onClick={() => handleSelectYoga(yoga)} startIcon={<Edit />} />
                                    <LoadingButton loading={loading && target === yoga.yogaItemId} startIcon={<Delete />} color='error'
                                        onClick={() => handleDeleteYoga(yoga.yogaItemId)} />
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Box>
    )
}