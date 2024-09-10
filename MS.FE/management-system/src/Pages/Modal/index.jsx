import { Button } from '@mui/material';
import React from 'react'
import Modal from 'react-bootstrap/Modal';


function BasicModal({title,show,children,handleSubmit,handleCloseModal,isFooterVisible=false}) {
  return (
    <>
      <Modal show={show} onHide={handleCloseModal} aria-labelledby="contained-modal-title-vcenter"
      centered>
        <Modal.Header closeButton>
          <Modal.Title>{title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            {children}
        </Modal.Body>
        {isFooterVisible && ( <Modal.Footer>
          <Button variant="primary" onClick={handleSubmit} style={{backgroundColor:"#1976d2",color:"whitesmoke"}} >
            Save Changes
          </Button>
        </Modal.Footer>)}
      </Modal> 
        
    </>
  )
}

export default BasicModal