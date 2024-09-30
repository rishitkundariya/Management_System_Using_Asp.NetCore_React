import useNetworkRequest from "../network/NetworkRequest";
import { API_ENDPOINTS } from "../network/EndPoints";
import useCommonServices from "../common/CommonServices";
import "react-toastify/dist/ReactToastify.css";

const useBrandService = () => {
  const { postRequest, getRequest, deleteRequest, putRequest } =
    useNetworkRequest();
  const { createPaginatedPayload, showToastMessage } = useCommonServices();
  const controllerUrl = "/Brand";

  const getPaginatedList = async (
    pageNumber,
    pageSize,
    sortColumn,
    sortDirection
  ) => {
    const url = controllerUrl + API_ENDPOINTS.BRAND_LIST;
    const payload = createPaginatedPayload(
      pageNumber,
      pageSize,
      sortColumn,
      sortDirection
    );
    try {
      return await postRequest(url, payload);
    } catch (error) {
      return null;
    }
  };

  const addBrand = async (name, shortName) => {
    const url = controllerUrl + API_ENDPOINTS.BRAND_ADD;
    const payload = { name, shortName };
    const response = await postRequest(url, payload);
    handleResponce(response);
    return;
  };

  const updateBrand = async (id, name, shortName) => {
    const url = `${controllerUrl}${API_ENDPOINTS.UPDATE_BRAND}?Id=${id}`;
    const payload = { name, shortName };
    const response = await putRequest(url, payload);
    handleResponce(response);
    return;
  };

  const deleteBrand = async (id) => {
    const url = `${controllerUrl}${API_ENDPOINTS.DELETE_BRAND}?Id=${id}`;
    const reponce = await deleteRequest(url);
    handleResponce(reponce);
    return;
  };

  const GetBrand = async (id) => {
    const url = `${controllerUrl}${API_ENDPOINTS.Get_BRAND}?Id=${id}`;
    try {
      const data = await getRequest(url);
      return data.data;
    } catch (error) {}
  };

  const handleResponce = (response) => {
    console.log(response);

    if (response?.isSuccess) {
      showToastMessage(2, response?.message, 5000);
    } else {
      showToastMessage(1, response?.message, 5000);
    }
    return;
  };

  return {
    getPaginatedList,
    addBrand,
    updateBrand,
    deleteBrand,
    GetBrand,
  };
};

export default useBrandService;
