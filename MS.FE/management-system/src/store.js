import { configureStore } from "@reduxjs/toolkit";
import loaderReducer from './features/loader/loaderSlice'

const store = configureStore({
    reducer:{
        loader:loaderReducer
    }
})

export default store;