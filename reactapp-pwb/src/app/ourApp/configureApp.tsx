import { configureStore } from "@reduxjs/toolkit"
import { counterSlice } from "../../features/about/counterSlice"
import { TypedUseSelectorHook, useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { exercisesSlice } from "../../features/exercises/exercisesSlice";
import { accountSlice } from "../../features/account/accountSlice";
import { appointmentSlice } from  "../../features/appointments/appointmentSlice";
// export function configureApp(){
//     return createStore(counterReducer);
// }
export const store=configureStore({
    reducer:{
        counter:counterSlice.reducer,
        exercises: exercisesSlice.reducer,
        account: accountSlice.reducer,
        appointment: appointmentSlice.reducer
    }
})
export type RootState=ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export const useAppDispatch=()=>useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState>=useSelector;