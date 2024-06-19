import logo from "./logo.svg";
import "./App.css";
import Layout from "./Layout/Layout";
import { BrowserRouter } from "react-router-dom";
import { route } from "./Route";
function App() {
  return (
    <div>
      <BrowserRouter router={route}></BrowserRouter>
    </div>
  );
}

export default App;
