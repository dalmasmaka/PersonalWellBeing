import { PanoramaSharp } from "@mui/icons-material";
import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import { string } from "yup";

import agent from "../../app/api/agent";
import { Exercise, ExercisesParams } from "../../app/model/exercises";
import { RootState } from "../../app/ourApp/configureApp";

interface ExercisesState{
    exercisesLoaded:boolean;
    filtersLoaded: boolean;
    status:string;
    types:string[];
    items:string[];
    exercisesParams: ExercisesParams
}

const exercisesAdapter=createEntityAdapter<Exercise>();

function getAxiosParams(exercisesParams: ExercisesParams){
    const params=new URLSearchParams();
    params.append('pageNumber', exercisesParams.pageNumber.toString());
    params.append('pageSize', exercisesParams.pageNumber.toString());
    if(exercisesParams.types) params.append('types', exercisesParams.types.toString());
    if(exercisesParams.items) params.append('items', exercisesParams.items.toString());
    return params;
}

// export const fetchExercisesAsync=createAsyncThunk<Exercise[], void, {state:RootState}>(
//     'exercises/fetchExercisesAsync',
//     async (_, thunkAPI) => { 
//         const params=getAxiosParams(thunkAPI.getState().exercises.exercisesParams)
//         try{
//             return await agent.Exercises.list(params);
//         }catch(error){
//             console.log(error);
//         }
//     }
// )
function initParams(){
    return{
        pageNumber:1,
            pageSize:6,
            types:[],
            items:[]


    }
}
export const exercisesSlice = createSlice({
    name: 'exercises',
    initialState:exercisesAdapter.getInitialState<ExercisesState>({
        exercisesLoaded:false,
        filtersLoaded:false,
        status:'idle',
        types:[],
        items:[],
        exercisesParams:initParams()
    }), 
    reducers:{
        setExerxisesParams:(state, action)=>{
            state.exercisesLoaded=false;
            state.exercisesParams={...state.exercisesParams, ...action.payload}
        },
        resetExercisesParams:(state)=>{
            state.exercisesParams = initParams();
        }
    },
    // extraReducers:(builder=>{
    //     builder.addCase(fetchExercisesAsync.pending, (state)=>{
    //         state.status='pendingFetchExercises';
    //     });
    //     builder.addCase(fetchExercisesAsync.fulfilled,(state,action)=>{
    //         exercisesAdapter.setAll(state, action.payload);
    //         state.status = "idle";
    //         state.exercisesLoaded=true;
    //     });
    //     builder.addCase(fetchExercisesAsync.rejected, (state)=>{
    //         state.status="idle";
    //     });
    // })
})
export const exercisesSelectors = exercisesAdapter.getSelectors((state:RootState)=>state.exercises);
export const {setExerxisesParams, resetExercisesParams}=exercisesSlice.actions;
