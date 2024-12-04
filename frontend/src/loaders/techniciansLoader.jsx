import { getUserData } from "../utils/auth";
import { config } from "../config";
import { redirect, json } from "react-router-dom";

export async function techniciansLoader() {
  const user = getUserData();

  if (!user) {
    throw redirect("/users/login");
  }

  // Verificar que el usuario sea un Admin
  if (user.role !== "Admin") {
    throw json(
      {
        title: "Acceso indebido",
        message: "No esta permitida la accion para este rol",
      },
      { status: 403 }
    );
  }
  // Hacer la petición para obtener los técnicos
  const response = await fetch(`${config.BACKEND_URL}/Technician`, {
    headers: { Authorization: `Bearer ${sessionStorage.getItem("jwt")}` },
  });

  if (!response.ok) {
    throw new Response("Failed to fetch technicians", {
      status: response.status,
    });
  }

  const data = await response.json();
  return data.data.technicians;
}
