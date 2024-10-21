import { redirect } from "react-router-dom";

export default function LogoutAction() {
  localStorage.removeItem("jwt");
  localStorage.removeItem("user");
  return redirect("/");
}
