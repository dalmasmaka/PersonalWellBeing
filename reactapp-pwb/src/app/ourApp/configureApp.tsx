import { configureStore } from "@reduxjs/toolkit"
import { TypedUseSelectorHook, useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { exerciseSlice } from "../../features/exercises/exercisesSlice";
import { accountSlice } from "../../features/account/accountSlice";
import { appointmentSlice } from "../../features/appointments/appointmentSlice";
import { doctorSlice } from "../../features/doctors/doctorSlice";
import { foodSlice } from "../../features/food/foodSlice";
import { yogaSlice } from "../../features/yoga/yogaSlice";
import { sleepSlice } from "../../features/sleepHygiene/sleepSlice";



export const store = configureStore({
    reducer: {

        account: accountSlice.reducer,
        appointment: appointmentSlice.reducer,
        doctors: doctorSlice.reducer,
        exercises: exerciseSlice.reducer,
        food: foodSlice.reducer,
        yoga: yogaSlice.reducer,
        sleep: sleepSlice.reducer,

    }
})
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;