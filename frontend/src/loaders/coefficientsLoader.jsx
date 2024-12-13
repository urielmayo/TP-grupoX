import { requireAdmin, authHeaders } from "../utils/auth";
import { json, redirect } from "react-router-dom";
import { config } from "../config";

export async function coefficientsLoader() {
  requireAdmin();

  const response = await fetch(`${config.BACKEND_URL}/Coefficients`, {
    headers: authHeaders(),
  });

  if (response.status === 401) {
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("jwt");
    throw redirect("/users/login");
  }
  if (!response.ok) {
    const data = response.json();
    throw json(
      { title: "Error al obtener", message: data.Message },
      { status: response.status }
    );
  }

  const data = await response.json();
  return data.data;
}
