import axios from "axios"
import { toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { useDispatch } from "react-redux";
import { showloader,hideloader } from "../../features/loader/loaderSlice";

const useNetworkRequest = () => {
    const dispatch = useDispatch();
    const request = axios.create({
        baseURL: process.env.REACT_APP_PROJECT_BASE_URL || 'http://localhost:5000',
        headers: {
            'Content-Type': 'application/json', // Default Content-Type for all requests
        },
    });

    const getRequest = async (url) => {
        try {
            dispatch(showloader());
            const data = await request.get(url);
            dispatch(hideloader());
            return data.data;
        } catch (error) {
            dispatch(hideloader());
            toast.error("Something went wrong", {
                autoClose: 3000,
            });
            throw error;
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
            toast.error("Something went wrong", {
                autoClose: 3000,
            });
            throw error; // Ensure the error is propagated
        }
    };

    const deleteRequest = async (url, payload) => {
        try {
            const data = await request.delete(url, { data: payload });
            return data;
        } catch (error) {
            toast.error("Something went wrong", {
                position: toast.POSITION.TOP_RIGHT,
                autoClose: 5000,
            });
            throw error; // Ensure the error is propagated
        }
    };

    const putRequest = async (url, payload) => {
        try {
            const data = await request.put(url, payload);
            return data;
        } catch (error) {
            toast.error("Something went wrong", {
                position: toast.POSITION.TOP_RIGHT,
                autoClose: 5000,
            });
            throw error; // Ensure the error is propagated
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