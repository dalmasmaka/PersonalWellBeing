import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { SleepHygiene } from "../../app/model/sleephygiene";
import { RootState } from "../../app/ourApp/configureApp";

const sleepAdapter = createEntityAdapter<SleepHygiene>();
export const fetchSleepAsync = createAsyncThunk<SleepHygiene[]>(
    'sleep/fetchSleepAsync',
    async () => {
        try {
            return await agent.SleepHygiene.list();
        } catch (error) {
            console.log(error);
        }
    }
)
export const sleepSlice = createSlice({
    name: 'sleep',
    initialState: sleepAdapter.getInitialState({
        sleepLoaded: false,
        status: 'idle'
    }),
    reducers: {
        setSleep: (state, action) => {
            sleepAdapter.setAll(state, action.payload)
        },
        setSleepItem: (state, action) => {
            sleepAdapter.upsertOne(state, action.payload)
        },
        removeSleep: (state, action) => {
            sleepAdapter.removeOne(state, action.payload)
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchSleepAsync.pending, (state) => {
            state.status = 'pendingFetchSleep';
        });
        builder.addCase(fetchSleepAsync.fulfilled, (state, action) => {
            sleepAdapter.setAll(state, action.payload);
            state.status = 'idle';
            state.sleepLoaded = true;
        });
        builder.addCase(fetchSleepAsync.rejected, (state) => {
            state.status = 'idle';
        })
    })
})
export const sleepSelector = sleepAdapter.getSelectors((state: RootState) => state.sleep);
export const { setSleepItem, removeSleep } = sleepSlice.actions;