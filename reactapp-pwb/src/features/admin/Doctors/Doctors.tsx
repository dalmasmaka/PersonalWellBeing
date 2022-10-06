import { Edit, Delete } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import { Box, Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import agent from "../../../app/api/agent";
import { Doctor } from "../../../app/model/doctor";
import { useAppDispatch } from "../../../app/ourApp/configureApp";
import { removeDoctor } from "../../doctors/doctorSlice";
import DoctorsForm from "../Doctors/DoctorsForm";



export default function Doctors() {

    const [doctors, setDoctors] = useState<Doctor[]>([]);
    const dispatch = useAppDispatch();
    const [editMode, setEditMode] = useState(false);
    const [loading, setLoading] = useState(false);
    const [target, setTarget] = useState(0);
    useEffect(() => {
        agent.Doctors.list().then(doctors => setDoctors(doctors))
    }, [doctors]);
    const [selectedDoctor, setSelectedDoctor] = useState<Doctor | undefined>(undefined);
    function handleSelectDoctor(doctor: Doctor) {
        setSelectedDoctor(doctor);
        setEditMode(true);
    }

    function handleDeleteDoctor(doctorId: number) {
        setLoading(true);
        setTarget(doctorId);
        agent.Admin.deleteDoctor(doctorId)
            .then(() => dispatch(removeDoctor(doctorId)))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }



    function cancelEdit() {
        if (selectedDoctor) setSelectedDoctor(undefined);
        setEditMode(false);
    }
    if (editMode) return <DoctorsForm doctor={selectedDoctor} cancelEdit={cancelEdit} />
    return (
        <Box sx={{ width: "100%" }} >
            <Box display='flex' justifyContent='space-between' >
                <Typography sx={{ p: 2 }} variant='h4'>Doctors</Typography>
                <Button onClick={() => setEditMode(true)} sx={{ m: 2 }} size='large' variant='contained'>Create</Button>
            </Box>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 1000, justifyContent: "center" }} aria-label="simple table" >
                    <TableHead>
                        <TableRow>
                            <TableCell>ID</TableCell>
                            <TableCell align="left">Image</TableCell>
                            <TableCell align="right">Name</TableCell>
                            <TableCell align="center">Surname</TableCell>
                            <TableCell align="center">Summary</TableCell>
                            <TableCell align="right"></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {doctors.map((doctor) => (
                            <TableRow
                                key={doctor.doctorId}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >

                                <TableCell component="th" scope="row">
                                    {doctor.doctorId}
                                </TableCell>
                                <TableCell align="left">
                                    <Box display='flex' alignItems='center' key={doctor.doctorId}>
                                        <img src={doctor.doctorImg} style={{ height: 50, marginRight: 20 }} />
                                    </Box>
                                </TableCell>
                                <TableCell align="right" >{doctor.doctorName}</TableCell>
                                <TableCell align="center" >{doctor.doctorSurname}</TableCell>
                                <TableCell align="center" >{doctor.doctorSummary}</TableCell>

                                <TableCell align="right">
                                    <Button onClick={() => handleSelectDoctor(doctor)} startIcon={<Edit />} />
                                    <LoadingButton loading={loading && target === doctor.doctorId} startIcon={<Delete />} color='error'
                                        onClick={() => handleDeleteDoctor(doctor.doctorId)} />
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Box>
    )
}