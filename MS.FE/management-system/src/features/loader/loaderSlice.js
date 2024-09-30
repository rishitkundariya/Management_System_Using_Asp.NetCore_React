import { createSlice } from "@reduxjs/toolkit";

const loaderSlice = createSlice({
  name: "loader",
  initialState: { isloading: false },
  reducers: {
    showloader(state) {
      state.isloading = true;
    },
    hideloader(state) {
      state.isloading = false;
    },
  },
});

export const { showloader, hideloader } = loaderSlice.actions;
export default loaderSlice.reducer;
