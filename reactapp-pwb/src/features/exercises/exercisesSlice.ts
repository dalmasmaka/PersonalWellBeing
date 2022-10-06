import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Exercise } from "../../app/model/exercises";
import { RootState } from "../../app/ourApp/configureApp";



const exercisesAdapter = createEntityAdapter<Exercise>();
export const fetchExercisesAsync = createAsyncThunk<Exercise[]>(
    'exercises/fetchExercisesAsync',
    async () => {
        try {
            return await agent.ExercisesItems.list();
        } catch (error) {
            console.log(error);
        }
    }
)

export const exerciseSlice = createSlice({
    name: 'exercises',
    initialState: exercisesAdapter.getInitialState({
        exercisesLoaded: false,
        status: 'idle'
    }),

    reducers: {
        setExercises: (state, action) => {
            exercisesAdapter.setAll(state, action.payload)
        },
        setExercise: (state, action) => {
            exercisesAdapter.upsertOne(state, action.payload)
        },
        removeExercise: (state, action) => {
            exercisesAdapter.removeOne(state, action.payload);
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchExercisesAsync.pending, (state) => {
            state.status = 'pendingFetchExercises';
        });
        builder.addCase(fetchExercisesAsync.fulfilled, (state, action) => {
            exercisesAdapter.setAll(state, action.payload);
            state.status = 'idle';
            state.exercisesLoaded = true;
        });
        builder.addCase(fetchExercisesAsync.rejected, (state) => {
            state.status = 'idle';
        })
    })
})
export const exerciseSelectors = exercisesAdapter.getSelectors((state: RootState) => state.exercises);
export const { setExercise, removeExercise } = exerciseSlice.actions;
