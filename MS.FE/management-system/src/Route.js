import {
  Route,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import { Home, Invoice, Product, UserManagement, Account } from "./Pages";
import Layout from "./Layout/Layout";
import Brand from "./Pages/Brand";

export const route = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Layout />}>
      <Route path="" element={<Home />} />
      <Route path="product" element={<Product />} />
      <Route path="invoice" element={<Invoice />} />
      <Route path="user" element={<UserManagement />} />
      <Route path="account" element={<Account />} />
      <Route path="brand" element={<Brand />} />
    </Route>
  )
);
