import { useHistory } from "react-router-dom";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export const useCommonServices = () => {
  const createPaginatedPayload = (
    pageNumber,
    pageSize,
    sortColumn,
    sortDirection,
    filterField_1 = "",
    filterField_2 = "",
    filterField_3 = "",
    filterField_4 = "",
    filterField_5 = "",
    filterField_6 = ""
  ) => {
    let payload = {
      sortBy: sortColumn,
      sortType: sortDirection,
      pageNo: pageNumber,
      pageSize: pageSize,
    };
    if (filterField_1.trim().length !== 0) {
      payload = { ...payload, filterField_1: filterField_1 };
    }
    if (filterField_2.trim().length !== 0) {
      payload = { ...payload, filterField_2: filterField_2 };
    }
    if (filterField_3.trim().length !== 0) {
      payload = { ...payload, filterField_3: filterField_3 };
    }
    if (filterField_4.trim().length !== 0) {
      payload = { ...payload, filterField_4: filterField_4 };
    }
    if (filterField_5.trim().length !== 0) {
      payload = { ...payload, filterField_5: filterField_5 };
    }
    if (filterField_6.trim().length !== 0) {
      payload = { ...payload, filterField_6: filterField_6 };
    }
    return JSON.stringify(payload);
  };

  const showToastMessage = (type, message, duration = 3000) => {
    switch (type) {
      case 1:
        toast.error(message, {
          autoClose: duration,
        });
        break;
      case 2:
        toast.success(message, {
          autoClose: duration,
        });
        break;
      default:
        toast.info(message, {
          autoClose: duration,
        });
    }
  };
  return {
    createPaginatedPayload,
    showToastMessage,
  };
};

export default useCommonServices;
