import React, { useCallback, useEffect, useState } from "react";
import useBrandInfo from '../../hooks/brand/UseBrandInfo'
import DataGrid from "../DataGrid";
import DeleteIcon from '@mui/icons-material/DeleteRounded';
import AddCircleOutlineSharpIcon from '@mui/icons-material/AddCircleOutlineSharp';
import ModeEditOutlineOutlinedIcon from '@mui/icons-material/ModeEditOutlineOutlined';
import { red } from "@mui/material/colors";
import ShowSweetAlert from "../../hooks/sweetAlert/DeleteSweetAlert";
import { Button, IconButton, Tooltip } from "@mui/material";
import BasicModal from "../Modal";
import BrandAddEdit from "./AddEdit";
import useBrandService from "../../hooks/brand/BrandServices";

function Brand() {
  const {showDeleteSweetAlert} = ShowSweetAlert();
 
  const columns = [
    {
      name: 'No',
      selector: (row, index) => (pageNumber - 1) * pageSize + index + 1,
      sortable: false,
    },
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
      cell:(row) =>{return <><Tooltip title="Delete"> <IconButton onClick={()=>showDeleteSweetAlert(row.id,deleteClick)}> <DeleteIcon   sx={{ color: red[500] }}></DeleteIcon>  </IconButton>
      </Tooltip> </>},
      ignoreRowClick: true,
    },
    {
      cell:(row) =>{return <><Tooltip title="Edit"> <IconButton onClick={()=>editClick(row.id,deleteClick)}> <ModeEditOutlineOutlinedIcon   sx={{ color: red[500] }}></ModeEditOutlineOutlinedIcon>  </IconButton>
      </Tooltip></> },
      ignoreRowClick: true,
    }
    
  ];
  
  const [pageNumber,setPageNumber]=useState(1);
  const [pageSize,setPagesize]= useState(10);
  const [sortColumn,setShortColumn]=useState('name');
  const [sortDirection,setShortDirection]=useState('asc');
  const [totalCount, setTotalCount]=useState(0);
  const [data,setData]=useState([]);
  const [showModal,setShowModal]=useState(false);
  const [isEdit,setIsEdit]= useState(false);
  const Defaultvalues= { id:0,
    name:'',
    shortname : ''}
  const [defaultData,SetDefaultData] = useState(Defaultvalues);
  const {GetBrand}= useBrandService();
  const  editClick = async (id)=> {
    setIsEdit(true);
    const data = await GetBrand(id);
     SetDefaultData(data);
    setShowModal(true);
  };
  const {data:brandinfo,fetchBrandData} = useBrandInfo(pageNumber,pageSize,sortColumn,sortDirection);
  useEffect(()=>{
    if(brandinfo!=null  && brandinfo?.isSuccess === true){
      setTotalCount(brandinfo?.data?.totalCount);
      setData(brandinfo?.data?.searchData);
    }
  },[brandinfo])
  
  const deleteClick = (id)=>{
    console.log("Delete click"+id);
    fetchBrandData();
  }

  const addBrand = ()=>{
    SetDefaultData(Defaultvalues);
    setShowModal(true);
    setIsEdit(false);
  }

  const modalSubmit = ()=>{
    console.log("Submit");
    setShowModal(false);
  }

  const modelclose =()=>{
    console.log("Close");
    setShowModal(false);
  }
  

  return (
    <div>
      <div style={{padding:'10px',float:'right'}}>
      <Button style={{backgroundColor:"#1976d2",color:"whitesmoke"}} onClick={addBrand}> Add Brand <AddCircleOutlineSharpIcon/> </Button>
      </div>
      <div>
      <DataGrid data={data} column={columns} totalRecords={totalCount} sortColumn={sortColumn} sortDirection={sortDirection} pageNumber={pageNumber} pageSize={pageSize} setPageNumber={setPageNumber} setPagesize={setPagesize} setShortColumn={setShortColumn} setShortDirection={setShortDirection}></DataGrid>
      </div>  
      <BasicModal title={"Brand"} show={showModal} children={<BrandAddEdit DefaultData={defaultData} setShowModal={setShowModal} isEdit={isEdit}></BrandAddEdit>} handleSubmit={modalSubmit} handleCloseModal={modelclose}></BasicModal>
    </div>
  );
}

export default Brand;
