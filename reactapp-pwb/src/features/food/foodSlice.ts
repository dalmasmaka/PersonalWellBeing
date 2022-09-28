import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Food } from "../../app/model/food";
// import { fetchExercisesAsync } from "../exercises/exercisesSlice";

const foodAdapter=createEntityAdapter<Food>();
export const fetchFoodAsync=createAsyncThunk<Food[]>(
    'food/fetchFoodAsync',
    async()=>{
        try{
            return await agent.Food.list();
        }catch(error){
            console.log(error);
        }
    }
)
export const foodSlice = createSlice({
    name:'food',
    initialState:foodAdapter.getInitialState({
        foodLoaded:false,
        status:'idle'
    }),
    reducers:{},
    extraReducers:(builder=>{
        builder.addCase(fetchFoodAsync.pending, (state)=>{
            state.status='pendingFetchFood';
        });
        builder.addCase(fetchFoodAsync.fulfilled, (state, action)=>{
            foodAdapter.setAll(state, action.payload);
            state.status='idle';
            state.foodLoaded=true;
        });
        // builder.addCase(fetchExercisesAsync.rejected, (state)=>{
        //     state.status='idle';
        // })
    })
})