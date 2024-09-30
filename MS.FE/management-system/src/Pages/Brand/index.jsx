import React, { useRef, useState } from "react";
import DataGrid from "../DataGrid";
import DeleteIcon from "@mui/icons-material/DeleteRounded";
import AddCircleOutlineSharpIcon from "@mui/icons-material/AddCircleOutlineSharp";
import ModeEditOutlineOutlinedIcon from "@mui/icons-material/ModeEditOutlineOutlined";
import { red } from "@mui/material/colors";
import ShowSweetAlert from "../../hooks/sweetAlert/DeleteSweetAlert";
import { Button, IconButton, Tooltip } from "@mui/material";
import BasicModal from "../Modal";
import BrandAddEdit from "./AddEdit";
import useBrandService from "../../hooks/brand/BrandServices";
import { useSearchParams } from "react-router-dom";

function Brand() {
  const { showDeleteSweetAlert } = ShowSweetAlert();
  const { deleteBrand } = useBrandService();
  const [searchParams, setSearchParams] = useSearchParams();
  const columns = [
    {
      name: "Name",
      selector: (row) => row.name,
      sortable: true,
    },
    {
      name: "Short Name",
      selector: (row) => row.shortname,
      sortable: true,
    },
    {
      cell: (row) => {
        return (
          <>
            <Tooltip title="Delete">
              {" "}
              <IconButton
                onClick={() => showDeleteSweetAlert(row.id, deleteClick)}
              >
                {" "}
                <DeleteIcon sx={{ color: red[500] }}></DeleteIcon>{" "}
              </IconButton>
            </Tooltip>{" "}
          </>
        );
      },
      ignoreRowClick: true,
    },
    {
      cell: (row) => {
        return (
          <>
            <Tooltip title="Edit">
              {" "}
              <IconButton onClick={() => editClick(row.id, deleteClick)}>
                {" "}
                <ModeEditOutlineOutlinedIcon
                  sx={{ color: red[500] }}
                ></ModeEditOutlineOutlinedIcon>{" "}
              </IconButton>
            </Tooltip>
          </>
        );
      },
      ignoreRowClick: true,
    },
  ];
  const dataGridRef = useRef();
  const [showModal, setShowModal] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const Defaultvalues = { id: 0, name: "", shortname: "" };
  const [defaultData, SetDefaultData] = useState(Defaultvalues);
  const { GetBrand, getPaginatedList } = useBrandService();

  const editClick = async (id) => {
    setIsEdit(true);
    const data = await GetBrand(id);
    SetDefaultData(data);
    setShowModal(true);
  };

  const deleteClick = async (id) => {
    await deleteBrand(id);
    dataGridRef.current.DeleteRow(id);
  };

  const addBrand = () => {
    SetDefaultData(Defaultvalues);
    setShowModal(true);
    setIsEdit(false);
  };

  const modalSubmit = () => {
    setShowModal(false);
  };

  const modelclose = () => {
    setShowModal(false);
  };

  return (
    <div>
      <div style={{ padding: "10px", float: "right" }}>
        <Button
          style={{ backgroundColor: "#1976d2", color: "whitesmoke" }}
          onClick={addBrand}
        >
          {" "}
          Add Brand <AddCircleOutlineSharpIcon />{" "}
        </Button>
      </div>
      <div>
        <DataGrid
          column={columns}
          ref={dataGridRef}
          getPaginatedList={getPaginatedList}
        ></DataGrid>
      </div>
      <BasicModal
        title={"Brand"}
        show={showModal}
        children={
          <BrandAddEdit
            DefaultData={defaultData}
            setShowModal={setShowModal}
            isEdit={isEdit}
            dataGridRef={dataGridRef}
          ></BrandAddEdit>
        }
        handleSubmit={modalSubmit}
        handleCloseModal={modelclose}
      ></BasicModal>
    </div>
  );
}

export default Brand;
