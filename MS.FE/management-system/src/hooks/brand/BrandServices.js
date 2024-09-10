import useNetworkRequest from '../network/NetworkRequest';
import { API_ENDPOINTS } from '../network/EndPoints';
import useCommonServices from '../common/CommonServices'

const useBrandService = () => {
    const { postRequest, getRequest, deleteRequest, putRequest } = useNetworkRequest();
    const {createPaginatedPayload} =  useCommonServices();
    const controllerUrl = '/Brand';

    const getPaginatedList = async (pageNumber, pageSize, sortColumn, sortDirection) => {
        const url = controllerUrl + API_ENDPOINTS.BRAND_LIST;
        const payload = createPaginatedPayload(pageNumber, pageSize, sortColumn, sortDirection);
        try {
            return await postRequest(url, payload);
        } catch (error) {
            return null;
        }
    };

    const addBrand = async (name, shortName) => {
        const url = controllerUrl + API_ENDPOINTS.BRAND_ADD;
        const payload = { name:'', shortName };
        try {
            return await postRequest(url, payload);
        } catch (error) {
        }
    };

    const updateBrand = async (id, brandName, brandShortName) => {
        const url = controllerUrl + API_ENDPOINTS.BRAND_UPDATE;
        const payload = { id, brandName, brandShortName };
        try {
            return await putRequest(url, payload);
        } catch (error) {
        }
    };

    const deleteBrand = async (id) => {
        const url = controllerUrl + API_ENDPOINTS.BRAND_DELETE;
        try {
            return await deleteRequest(url, { data: { id } });
        } catch (error) {
        }
    };


    const GetBrand = async (id) => {
        const url = `${controllerUrl}${API_ENDPOINTS.Get_BRAND}?Id=${id}`;
        try {
            const data= await getRequest(url);
            return data.data;
        } catch (error) {
        }
    };

    return {
        getPaginatedList,
        addBrand,
        updateBrand,
        deleteBrand,
        GetBrand
    };
};

export default useBrandService;