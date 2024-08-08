import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import Home from "./pages/Home";
import Launches from "./pages/Launches";

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    children: [
      { index: true, element: <Home /> },
      { path: "viandas", element: <Launches /> },
    ],
  },
]);

export default function App() {
  return <RouterProvider router={router} />;
}
