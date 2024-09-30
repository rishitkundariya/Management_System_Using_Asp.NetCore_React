import axios from "axios";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useDispatch } from "react-redux";
import { showloader, hideloader } from "../../features/loader/loaderSlice";
import { ErrorRounded } from "@mui/icons-material";

const useNetworkRequest = () => {
  const dispatch = useDispatch();

  const request = axios.create({
    baseURL: process.env.REACT_APP_PROJECT_BASE_URL || "http://localhost:5000",
    headers: {
      "Content-Type": "application/json", // Default Content-Type for all requests
    },
  });
  request.interceptors.response.use(
    (res) => res,
    (err) => {
      if (axios.isAxiosError(err)) {
        if (err?.code === "ERR_NETWORK") {
          toast.error("Network Error, Something went wrong at server", {
            autoClose: 3000,
          });
        }
        return err;
      }
    }
  );

  const getRequest = async (url) => {
    try {
      dispatch(showloader());
      const data = await request.get(url);
      dispatch(hideloader());
      return data.data;
    } catch (error) {
      dispatch(hideloader());
      return error;
    }
  };

  const postRequest = async (url, payload) => {
    try {
      dispatch(showloader());
      const data = await request.post(url, payload);
      dispatch(hideloader());
      return data.data;
    } catch (error) {
      dispatch(hideloader());
      return error;
    }
  };

  const deleteRequest = async (url) => {
    try {
      dispatch(showloader());
      const data = await request.delete(url);
      dispatch(hideloader());
      return data.data;
    } catch (error) {
      dispatch(hideloader());
      return error;
    }
  };

  const putRequest = async (url, payload) => {
    try {
      dispatch(showloader());
      const data = await request.put(url, payload);
      dispatch(hideloader());
      return data.data;
    } catch (error) {
      dispatch(hideloader());
      return error;
    }
  };

  return {
    getRequest,
    postRequest,
    deleteRequest,
    putRequest,
  };
};

export default useNetworkRequest;
