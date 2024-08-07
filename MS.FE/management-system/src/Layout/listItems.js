import * as React from "react";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import ListSubheader from "@mui/material/ListSubheader";
import DashboardIcon from "@mui/icons-material/Dashboard";
import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";
import PeopleIcon from "@mui/icons-material/People";
import BarChartIcon from "@mui/icons-material/BarChart";
import LayersIcon from "@mui/icons-material/Layers";
import AssignmentIcon from "@mui/icons-material/Assignment";
import { Link, NavLink } from "react-router-dom";
import { BrandingWatermark } from "@mui/icons-material";

export const mainListItems = (
  <React.Fragment>
    <ListItemButton>
      <NavLink
        to={"/"}
        className={({ isActive }) => (isActive ? "active" : "")}
        style={{
          textDecoration: "none",
          color: "black",
          padding: "5px",
          display: "flex",
          alignItems: "center",
        }}
      >
        <ListItemIcon>
          <DashboardIcon />
        </ListItemIcon>
        Dashboard
      </NavLink>
    </ListItemButton>
    <ListItemButton>
      <NavLink
        to={"product"}
        className={({ isActive }) => (isActive ? "active" : "")}
        style={{
          textDecoration: "none",
          color: "black",
          padding: "5px",
          display: "flex",
          alignItems: "center",
        }}
      >
        {" "}
        <ListItemIcon>
          <ShoppingCartIcon />
        </ListItemIcon>{" "}
        Product{" "}
      </NavLink>
    </ListItemButton>
    <ListItemButton>
      <NavLink
        to={"user"}
        className={({ isActive }) => (isActive ? "active" : "")}
        style={{
          textDecoration: "none",
          color: "black",
          padding: "5px",
          display: "flex",
          alignItems: "center",
        }}
      >
        {" "}
        <ListItemIcon>
          <PeopleIcon />
        </ListItemIcon>
        Users
      </NavLink>
    </ListItemButton>
    <ListItemButton>
      <NavLink
        to={"invoice"}
        className={({ isActive }) => (isActive ? "active" : "")}
        style={{
          textDecoration: "none",
          color: "black",
          padding: "5px",
          display: "flex",
          alignItems: "center",
        }}
      >
        <ListItemIcon>
          <BarChartIcon />
        </ListItemIcon>
        Invoice
      </NavLink>
    </ListItemButton>
    <ListItemButton>
      <NavLink
        to={"account"}
        className={({ isActive }) => (isActive ? "active" : "")}
        style={{
          textDecoration: "none",
          color: "black",
          padding: "5px",
          display: "flex",
          alignItems: "center",
        }}
      >
        <ListItemIcon>
          <LayersIcon style={{ color: "inherit" }} />
        </ListItemIcon>
        Account
      </NavLink>
    </ListItemButton>
    <ListItemButton>
      <NavLink
        to={"brand"}
        className={({ isActive }) => (isActive ? "active" : "")}
        style={{
          textDecoration: "none",
          color: "black",
          padding: "5px",
          display: "flex",
          alignItems: "center",
        }}
      >
        <ListItemIcon>
          <BrandingWatermark style={{ color: "inherit" }} />
        </ListItemIcon>
        Brand
      </NavLink>
    </ListItemButton>
  </React.Fragment>
);

export const secondaryListItems = (
  <React.Fragment>
    <ListSubheader component="div" inset>
      Saved reports
    </ListSubheader>
    <ListItemButton>
      <ListItemIcon>
        <AssignmentIcon />
      </ListItemIcon>
      <ListItemText primary="Current month" />
    </ListItemButton>
    <ListItemButton>
      <ListItemIcon>
        <AssignmentIcon />
      </ListItemIcon>
      <ListItemText primary="Last quarter" />
    </ListItemButton>
    <ListItemButton>
      <ListItemIcon>
        <AssignmentIcon />
      </ListItemIcon>
      <ListItemText primary="Year-end sale" />
    </ListItemButton>
  </React.Fragment>
);
