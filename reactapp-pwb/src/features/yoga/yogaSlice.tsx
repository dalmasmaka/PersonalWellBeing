import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Yoga } from "../../app/model/yoga";
import { RootState } from "../../app/ourApp/configureApp";

const yogaAdapter=createEntityAdapter<Yoga>();
export const fetchYogaAsync=createAsyncThunk<Yoga[]>(
    'yoga/fetchYogaAsync',
    async()=>{
        try{
            return await agent.YogaItems.list();
        }catch(error){
            console.log(error);
        }
    }
)
export const yogaSlice = createSlice({
    name:'yoga',
    initialState:yogaAdapter.getInitialState({
        yogaLoaded:false,
        status:'idle'
    }),
    reducers:{
        setYoga:(state, action)=>{
            yogaAdapter.setAll(state, action.payload)
        },
        setYogaItem: (state, action)=>{
            yogaAdapter.upsertOne(state, action.payload)
        },
        removeYoga:(state, action)=>{
            yogaAdapter.removeOne(state, action.payload)
        }
    },
    extraReducers:(builder=>{
        builder.addCase(fetchYogaAsync.pending, (state)=>{
            state.status='pendingFetchYoga';
        });
        builder.addCase(fetchYogaAsync.fulfilled, (state, action)=>{
            yogaAdapter.setAll(state, action.payload);
            state.status='idle';
            state.yogaLoaded=true;
        });
        builder.addCase(fetchYogaAsync.rejected, (state)=>{
            state.status='idle';
        })
    })
})
export const yogaSelector = yogaAdapter.getSelectors((state:RootState)=>state.yoga);
export const {setYogaItem, removeYoga}=yogaSlice.actions;