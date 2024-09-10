import DataTable from 'react-data-table-component'
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
import DeleteIcon from '@mui/icons-material/DeleteRounded';
import { red } from '@mui/material/colors';
import { useEffect } from 'react';

function DataGrid( {data,pageNumber,pageSize,sortColumn,sortDirection, setPageNumber,setPagesize,setShortColumn,setShortDirection,totalRecords,column}) {

    const changeCountPerPage = (newPerPage, page) => {
        setPagesize(newPerPage);
      };
      const handlePageChange = (page) => {
        setPageNumber(page);
      };
      const handleSort   = (columnName, direction) => {
        if((columnName?.name ?? sortColumn )!== sortColumn ){
          setShortColumn(columnName?.name ?? sortColumn);
        }
        if(direction !== sortDirection){
          setShortDirection(direction);
        }
        
      };
      
    return (
    <div>
    <DataTable
      columns={column}
      data={data}
      pagination
      paginationServer
      paginationTotalRows={totalRecords}
      onChangeRowsPerPage={changeCountPerPage}
      onChangePage={handlePageChange}
      page
      paginationRowsPerPageOptions={[2, 4, 8, 10, 15]}
      paginationPerPage={pageSize}
      paginationDefaultPage={pageNumber}
      defaultSortField={sortColumn}
      onSort={handleSort}
      sortFunction={r => r}
      defaultSortDirection={sortDirection}
    />
    </div>
  );
}
export default DataGrid;