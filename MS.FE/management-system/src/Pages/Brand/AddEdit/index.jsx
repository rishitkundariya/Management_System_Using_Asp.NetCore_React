import { Button, Grid, TextField } from "@mui/material";
import React from "react";
import { useForm } from "react-hook-form";
import useBrandService from "../../../hooks/brand/BrandServices";
import { useSearchParams } from "react-router-dom";

function BrandAddEdit({
  DefaultData,
  isEdit = false,
  setShowModal,
  dataGridRef,
}) {
  console.log(isEdit);
  const { register, handleSubmit, formState } = useForm({
    defaultValues: { ...DefaultData },
  });
  const { errors } = formState;
  const { addBrand, updateBrand } = useBrandService();
  const [searchParams, setSearchParams] = useSearchParams();
  const submitForm = async (data) => {
    if (isEdit) {
      await updateBrand(data.id, data.name, data.shortname);
      dataGridRef.current.UpdateRow(data.id, {
        id: data.id,
        name: data.name,
        shortname: data.shortname,
      });
    } else {
      await addBrand(data.name, data.shortname);
      dataGridRef.current.InsertRow();
      if (searchParams.has("pageNumber")) {
        searchParams.set("pageNumber", 1);
        setSearchParams(searchParams);
      }
    }
    setShowModal(false);
  };
  return (
    <>
      <Grid container justify="center" spacing={1}>
        <Grid item md={12}>
          <form onSubmit={handleSubmit(submitForm)}>
            <Grid item container spacing={1} justify="center">
              <Grid item xs={12} sm={12} md={6}>
                <input type="hidden" {...register("id")}></input>
                <TextField
                  label="Brand Name"
                  variant="outlined"
                  fullWidth
                  sx={{ mb: 1 }}
                  {...register("name", {
                    required: {
                      value: true,
                      message: "Brand Name field must contain the value.",
                    },
                    maxLength: {
                      value: 50,
                      message: "Brand Name can't be greater than 50 character.",
                    },
                  })}
                ></TextField>
                <span className="errorMessage">{errors.name?.message} </span>
              </Grid>
              <Grid item xs={12} sm={12} md={6}>
                <TextField
                  label="Brand Short Name"
                  variant="outlined"
                  fullWidth
                  sx={{ mb: 1 }}
                  {...register("shortname", {
                    required: {
                      value: true,
                      message: "Brand short name field must contain the vlaue.",
                    },
                    maxLength: {
                      value: 20,
                      message: "Brand sort name can't exceed the length.",
                    },
                  })}
                ></TextField>
                <span className="errorMessage">
                  {errors.shortname?.message}{" "}
                </span>
              </Grid>

              <Grid
                item
                xs={12}
                sm={12}
                md={12}
                sx={{ display: "flex", justifyContent: "center" }}
              >
                <Button
                  sx={{ mx: "auto" }}
                  variant="contained"
                  color="primary"
                  type="submit"
                >
                  {isEdit ? "Edit" : "Add"}
                </Button>
              </Grid>
            </Grid>
          </form>
        </Grid>
      </Grid>
    </>
  );
}

export default BrandAddEdit;
