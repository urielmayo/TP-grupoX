import { redirect } from "react-router-dom";

export default function LogoutAction() {
  sessionStorage.removeItem("jwt");
  sessionStorage.removeItem("user");
  return redirect("/");
}
