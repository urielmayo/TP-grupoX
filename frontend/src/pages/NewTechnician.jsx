/* eslint-disable react-refresh/only-export-components */
import { redirect } from "react-router-dom";
import { config } from "../config";
import NewTechnician from "../components/technicians/NewTechnician";

export default function NewTechnicianPage() {
  return <NewTechnician />;
}

export async function newTechnicianAction({ request }) {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());

  const response = await fetch(`${config.BACKEND_URL}/Technician`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
    },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    const errors = await response.json();
    return errors.errors;
  }
  return redirect("..");
}
