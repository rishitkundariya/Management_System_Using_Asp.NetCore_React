import { useEffect, useState } from "react";
import useBrandService from './BrandServices'

 function  useBrandInfo (pageNumber,pageSize,sortColumn,sortDirection){
 const {getPaginatedList} = useBrandService()
 const [data,setData]=useState()
 const fetchBrandData =  async() => {
        const reponce = await getPaginatedList(pageNumber,pageSize,sortColumn,sortDirection);
        setData(reponce);
 }

 useEffect(()=>{
    fetchBrandData();
 },[pageNumber,pageSize,sortColumn,sortDirection])
 return {data,fetchBrandData};
}

export default useBrandInfo;