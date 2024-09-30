import DataTable from "react-data-table-component";
import {
  forwardRef,
  memo,
  useEffect,
  useImperativeHandle,
  useState,
} from "react";
import { useLocation, useSearchParams } from "react-router-dom";
import { Forward } from "@mui/icons-material";

function DataGrid({ column, getPaginatedList }, ref) {
  column = [
    {
      name: "No",
      selector: (row, index) => (pageNumber - 1) * pageSize + index + 1,
      sortable: false,
    },
  ].concat(column);
  const [searchParams, setSearchParams] = useSearchParams();
  const [pageNumber, setPageNumber] = useState(
    searchParams.has("pageNumber") ? Number(searchParams.get("pageNumber")) : 1
  );
  const [pageSize, setPagesize] = useState(
    searchParams.has("pageSize") ? Number(searchParams.get("pageSize")) : 10
  );
  const [sortColumn, setShortColumn] = useState(
    searchParams.has("sortColumn") ? searchParams.get("sortColumn") : "No"
  );
  const [sortDirection, setShortDirection] = useState(
    searchParams.has("sortDirection")
      ? searchParams.get("sortDirection")
      : "asc"
  );
  const [totalCount, setTotalCount] = useState(0);
  const [data, setData] = useState([]);

  const DeleteRow = (id) => {
    setData(data.filter((x) => x?.id !== id));
    if (data.length === 1 && pageNumber > 1) {
      setPageNumber(1);
    }
  };
  const InsertRow = () => {
    setTotalCount((pre) => pre + 1);
  };
  const UpdateRow = (id, updatedData) => {
    setData(
      data.map((x) => {
        if (x?.id === id) {
          return { ...x, ...updatedData };
        } else {
          return x;
        }
      })
    );
  };

  useImperativeHandle(ref, () => {
    return {
      DeleteRow,
      UpdateRow,
      InsertRow,
    };
  });

  useEffect(() => {
    (async () => {
      const reponce = await getPaginatedList(
        pageNumber,
        pageSize,
        sortColumn,
        sortDirection
      );
      setTotalCount(reponce?.data?.totalCount);
      setData(reponce?.data?.searchData);
      setSearchParam();
    })();
  }, [pageNumber, pageSize, sortColumn, sortDirection]);

  const location = useLocation();
  useEffect(() => {
    if (
      searchParams.has("pageNumber") &&
      pageNumber !== searchParams.get("pageNumber")
    ) {
      console.log("params", searchParams.get("pageNumber"));
      setPageNumber(Number(searchParams.get("pageNumber")));
    }
  }, [location.search]);

  const changeCountPerPage = (newPerPage, page) => {
    if (pageSize !== newPerPage) {
      console.log("new page", newPerPage);
      console.log("current page", pageSize);
      setPagesize(newPerPage);
    }
  };
  const handlePageChange = (page) => {
    if (pageNumber !== page) {
      setPageNumber(page);
    }
  };
  const handleSort = (columnName, direction) => {
    if ((columnName?.name ?? sortColumn) !== sortColumn) {
      setShortColumn(columnName?.name ?? sortColumn);
    }
    if (direction !== sortDirection) {
      setShortDirection(direction);
    }
  };
  const setSearchParam = () => {
    setSearchParams({
      pageSize: pageSize,
      pageNumber: pageNumber,
      sortColumn: sortColumn,
      sortDirection: sortDirection,
    });
  };

  return (
    <div>
      <DataTable
        columns={column}
        data={data}
        pagination
        paginationServer
        paginationTotalRows={totalCount}
        onChangeRowsPerPage={changeCountPerPage}
        onChangePage={handlePageChange}
        page
        paginationRowsPerPageOptions={[2, 4, 8, 10, 15]}
        paginationPerPage={pageSize}
        paginationDefaultPage={pageNumber}
        defaultSortField={sortColumn}
        onSort={handleSort}
        sortFunction={(r) => r}
        defaultSortDirection={sortDirection}
      />
    </div>
  );
}
export default forwardRef(DataGrid);
