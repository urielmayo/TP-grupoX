import { Navigate, useRouteLoaderData, Outlet } from "react-router-dom";

export default function ProtectedRoute() {
  const user = useRouteLoaderData("root");
  if (user === null) {
    return <Navigate to="/users/login" />;
  }
  return <Outlet />;
}
