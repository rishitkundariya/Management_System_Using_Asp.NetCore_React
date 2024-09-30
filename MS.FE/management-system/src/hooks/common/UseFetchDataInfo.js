import { useCallback, useEffect, useState } from "react";

function UseFetchDataInfo(
  pageNumber,
  pageSize,
  sortColumn,
  sortDirection,
  getPaginatedList,
  fetchData = 0
) {
  const [data, setData] = useState({});
  const fetchBrandData = useCallback(async () => {
    const reponce = await getPaginatedList(
      pageNumber,
      pageSize,
      sortColumn,
      sortDirection
    );
    setData(reponce?.data);
  }, [pageNumber, pageSize, sortColumn, sortDirection, fetchData]);

  useEffect(() => {
    (async () => {
      await fetchBrandData();
    })();
  }, [pageNumber, pageSize, sortColumn, sortDirection, fetchBrandData]);
  return { data, fetchBrandData };
}
export default UseFetchDataInfo;
