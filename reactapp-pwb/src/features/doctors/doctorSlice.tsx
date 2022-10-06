import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Doctor } from "../../app/model/doctor";
import { RootState } from "../../app/ourApp/configureApp";



const doctorsAdapter = createEntityAdapter<Doctor>();
export const fetchDoctorAsync = createAsyncThunk<Doctor[]>(
    'doctors/fetchDoctorAsync',
    async () => {
        try {
            return await agent.Doctors.list();
        } catch (error) {
            console.log(error);
        }
    }
)

export const doctorSlice = createSlice({
    name: 'doctors',
    initialState: doctorsAdapter.getInitialState({
        doctorsLoaded: false,
        status: 'idle'
    }),

    reducers: {
        setDoctors: (state, action) => {
            doctorsAdapter.setAll(state, action.payload)
        },
        setDoctor: (state, action) => {
            doctorsAdapter.upsertOne(state, action.payload)
        },
        removeDoctor: (state, action) => {
            doctorsAdapter.removeOne(state, action.payload);
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchDoctorAsync.pending, (state) => {
            state.status = 'pendingFetchDoctor';
        });
        builder.addCase(fetchDoctorAsync.fulfilled, (state, action) => {
            doctorsAdapter.setAll(state, action.payload);
            state.status = 'idle';
            state.doctorsLoaded = true;
        });
        builder.addCase(fetchDoctorAsync.rejected, (state) => {
            state.status = 'idle';
        })
    })
})
export const doctorSelectors = doctorsAdapter.getSelectors((state: RootState) => state.doctors);
export const { setDoctor, removeDoctor } = doctorSlice.actions;
