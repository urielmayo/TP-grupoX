import { redirect } from "react-router-dom";

export default function LogoutAction() {
  localStorage.removeItem("token");
  localStorage.removeItem("user");
  return redirect("/");
}
