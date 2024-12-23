/* eslint-disable react-refresh/only-export-components */
import { redirect, json } from "react-router-dom";
import { config } from "../../config";
import UpdateTechnician from "../../components/technicians/UpdateTechnician";
import { authHeaders } from "../../utils/auth";

export default function UpdateTechnicianPage() {
  return <UpdateTechnician />;
}

export async function updateTechicianAction({ request, params }) {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());

  const response = await fetch(
    `${config.BACKEND_URL}/Technician/${params.id}`,
    {
      method: "PUT",
      headers: authHeaders(),
      body: JSON.stringify(data),
    }
  );

  if (response.status === 401) {
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("jwt");
    throw redirect("/users/login");
  }

  if (response.status === 500) {
    throw json({ message: "could not save event" }, { status: 500 });
  }
  if (!response.ok) {
    const errors = await response.json();
    console.log(errors);
    return errors.errors;
  }
  return redirect("..");
}
