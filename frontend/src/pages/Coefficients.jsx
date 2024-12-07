/* eslint-disable react-refresh/only-export-components */
import { json, redirect } from "react-router-dom";
import { config } from "../config";
import Coefficients from "../components/Coefficients";

export default function CoefficientsPage() {
  return <Coefficients />;
}

export async function updateCoefficientAction({ request }) {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());

  const response = await fetch(`${config.BACKEND_URL}/Coefficients/1`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
    },
    body: JSON.stringify(data),
  });
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
