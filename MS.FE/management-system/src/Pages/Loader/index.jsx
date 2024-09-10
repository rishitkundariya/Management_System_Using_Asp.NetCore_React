import React, { useState } from 'react'
import { Bars } from 'react-loader-spinner';
import { useDispatch, useSelector } from 'react-redux';

function PageLoader() {
  const loader = useSelector((state)=> state.loader.isloading);
    return loader ? (
        <div className="loader-container">
          <Bars
            height="80"
            width="80"
            color="#1976d2"
            ariaLabel="bars-loading"
            wrapperStyle={{}}
            wrapperClass="loader"
            visible={loader}
          />
        </div>
      ) : null;
}

export default PageLoader;