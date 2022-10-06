import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Food } from "../../app/model/food";
import { RootState } from "../../app/ourApp/configureApp";

const foodAdapter = createEntityAdapter<Food>();
export const fetchFoodAsync = createAsyncThunk<Food[]>(
    'food/fetchFoodAsync',
    async () => {
        try {
            return await agent.Food.list();
        } catch (error) {
            console.log(error);
        }
    }
)
export const foodSlice = createSlice({
    name: 'food',
    initialState: foodAdapter.getInitialState({
        foodLoaded: false,
        status: 'idle'
    }),
    reducers: {
        setFood: (state, action) => {
            foodAdapter.setAll(state, action.payload)
        },
        setFoodItem: (state, action) => {
            foodAdapter.upsertOne(state, action.payload)
        },
        removeFood: (state, action) => {
            foodAdapter.removeOne(state, action.payload)
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchFoodAsync.pending, (state) => {
            state.status = 'pendingFetchFood';
        });
        builder.addCase(fetchFoodAsync.fulfilled, (state, action) => {
            foodAdapter.setAll(state, action.payload);
            state.status = 'idle';
            state.foodLoaded = true;
        });
        builder.addCase(fetchFoodAsync.rejected, (state) => {
            state.status = 'idle';
        })
    })
})
export const foodSelector = foodAdapter.getSelectors((state: RootState) => state.food);
export const { setFoodItem, removeFood } = foodSlice.actions;