import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Grid,
  TextField,
} from "@mui/material";
import React from "react";
import { useForm } from "react-hook-form";

function BrandAddEdit() {
  const { register, handleSubmit, formState } = useForm();
  const { errors } = formState;

  const submitForm = (data) => {
    console.log(data);
  };

  return (
    <>
      <Grid container justify="center" spacing={1}>
        <Grid item md={12}>
          <Card>
            <CardHeader title="Brand Add Edit Form"></CardHeader>
            <form onSubmit={handleSubmit(submitForm)}>
              <CardContent>
                <Grid item container spacing={1} justify="center">
                  <Grid item xs={12} sm={12} md={6}>
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
                          message:
                            "Brand Name can't be greater than 50 character.",
                        },
                      })}
                    ></TextField>
                    <span className="errorMessage">
                      {errors.name?.message}{" "}
                    </span>
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
                          message:
                            "Brand short name field must contain the vlaue.",
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
                </Grid>
              </CardContent>
              <CardActions>
                <Button
                  sx={{ mx: "auto" }}
                  variant="contained"
                  color="primary"
                  type="Submit"
                >
                  REGISTER
                </Button>
              </CardActions>
            </form>
          </Card>
        </Grid>
      </Grid>
    </>
  );
}

export default BrandAddEdit;
