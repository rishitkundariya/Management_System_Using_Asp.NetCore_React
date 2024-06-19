import {
  Route,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import { Home, Invoice, Product, UserManagement } from "./Pages";
import Layout from "./Layout/Layout";

export const route = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Layout />}>
      <Route path="" element={<Home />} />
      <Route path="product" element={<Product />} />
      <Route path="invoice" element={<Invoice />} />
      <Route path="User" element={<UserManagement />} />
    </Route>
  )
);
