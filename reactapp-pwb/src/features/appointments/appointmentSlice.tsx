import { createAsyncThunk, isAnyOf, createSlice } from "@reduxjs/toolkit";
import { Appointment } from "../../app/model/appointment"
import { FieldValues } from "react-hook-form/dist/types";
import agent from "../../app/api/agent";
interface  AppointmentState{
    appointment: Appointment | null;
}
const initialState: AppointmentState={
    appointment:null
}
export const makeAnAppointment = createAsyncThunk<Appointment, FieldValues>(
    'Dappointments/appointment',
    async(data, thunkAPI)=>{
        try{
            const appointment = await agent.Appointment.makeAppointment(data);
            localStorage.setItem('appointment', JSON.stringify(appointment));
            return appointment;
        }catch(error:any){
            return thunkAPI.rejectWithValue({error: error.data});
        }
    },{
        condition:()=>{
            if(!localStorage.getItem('appointment')) return false;
        }
    }
)
export const appointmentSlice = createSlice({
    name:'account',
    initialState,
    reducers:{
        setAppointment: (state, action)=>{
            state.appointment=action.payload
        }
    },
    extraReducers:(builder =>{
        builder.addMatcher(isAnyOf(makeAnAppointment.fulfilled), (state, action)=>{
            state.appointment=action.payload
        });
        builder.addMatcher(isAnyOf(makeAnAppointment.rejected), (state,action)=>{
            console.log(action.payload);
        })
    })

})
export const{setAppointment}= appointmentSlice.actions;