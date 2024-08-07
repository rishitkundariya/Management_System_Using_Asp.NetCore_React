import React, { useState } from "react";
import DataTable from "react-data-table-component";

function Brand() {
  const [pageNumber, setPageNumber] = useState(0);
  const [pageSize, setPagesize] = useState(2);
  const [totalCount, setTotalCount] = useState(5);
  const changeCountPerPage = (newPerPage, page) => {
    setPagesize(Number(newPerPage));
    setData(
      tempDate.filter(
        (x) =>
          x.id >= (pageNumber - 1) * newPerPage &&
          x.id < (pageNumber + 1) * newPerPage
      )
    );
    alert(pageSize);
  };
  const handlePageChange = (page) => {
    setPageNumber(page);
    setData(
      tempDate.filter(
        (x) =>
          x.id >= pageNumber * pageSize && x.id < (pageNumber + 1) * pageSize
      )
    );
  };
  const columns = [
    {
      name: "Title",
      selector: (row) => row.title,
      sortable: true,
    },
    {
      name: "Year",
      selector: (row) => row.year,
      sortable: true,
    },
  ];

  const [data, setData] = useState([
    {
      id: 0,
      title: "Beetlejuice",
      year: "1988",
    },
    {
      id: 1,
      title: "Beetlejuice",
      year: "1988",
    },
    {
      id: 2,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 3,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 4,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 5,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 6,
      title: "Ghostbusters",
      year: "1984",
    },
  ]);

  const tempDate = [
    {
      id: 0,
      title: "Beetlejuice",
      year: "1988",
    },
    {
      id: 1,
      title: "Beetlejuice",
      year: "1988",
    },
    {
      id: 2,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 3,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 4,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 5,
      title: "Ghostbusters",
      year: "1984",
    },
    {
      id: 6,
      title: "Ghostbusters",
      year: "1984",
    },
  ];
  return (
    <div>
      <DataTable
        columns={columns}
        data={data}
        pagination
        paginationServer
        paginationTotalRows={totalCount}
        onChangeRowsPerPage={changeCountPerPage}
        onChangePage={handlePageChange}
        paginationRowsPerPageOptions={[2, 4, 8, 12, 15]}
      />
    </div>
  );
}

export default Brand;
