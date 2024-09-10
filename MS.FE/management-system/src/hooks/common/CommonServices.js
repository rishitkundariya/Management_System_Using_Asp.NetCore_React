export const useCommonServices=()=>{
 const createPaginatedPayload=(pageNumber, pageSize, sortColumn, sortDirection, filterField_1="", filterField_2="", filterField_3="", filterField_4="", filterField_5="",filterField_6="")=>
  {
    return JSON.stringify({
        sortBy:sortColumn,
        sortType:sortDirection,
        pageNo:pageNumber,
        pageSize:pageSize,
        filterField_1:filterField_1,
        filterField_2:filterField_2,
        filterField_3:filterField_3,
        filterField_4:filterField_4,
        filterField_5:filterField_5,
        filterField_6:filterField_6
    })
  }

  return {
    createPaginatedPayload
  }
}
export default useCommonServices;