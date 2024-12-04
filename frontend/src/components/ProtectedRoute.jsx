/* eslint-disable react/prop-types */
import { Navigate, useRouteLoaderData } from "react-router-dom";

export default function ProtectedRoute({ children }) {
  const user = useRouteLoaderData("root");
  console.log(user);

  if (user === null) {
    return <Navigate to="/users/login" />;
  }
  return children;
}
