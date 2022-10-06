import { useEffect } from "react";
import { fetchDoctorAsync, doctorSelectors} from "../../features/doctors/doctorSlice";
import { useAppSelector, useAppDispatch } from "../ourApp/configureApp"


export default function useDoctors() {
    const doctors = useAppSelector(doctorSelectors.selectAll);
    const { doctorsLoaded} = useAppSelector(state => state.doctors);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (!doctorsLoaded) dispatch(fetchDoctorAsync());
    }, [doctorsLoaded, dispatch])


    return {
        doctors,
        doctorsLoaded,

    }
}