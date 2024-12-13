import { requireAdmin, authHeaders } from "../utils/auth";
import { config } from "../config";
import { redirect, json } from "react-router-dom";
import { fetchNeighborhoods } from "../utils/http";

export async function techniciansLoader() {
  requireAdmin();
  // Hacer la petición para obtener los técnicos
  const response = await fetch(`${config.BACKEND_URL}/Technician`, {
    headers: authHeaders(),
  });

  if (!response.ok) {
    if (response.status === 401) {
      sessionStorage.removeItem("user");
      sessionStorage.removeItem("jwt");
      throw redirect("/users/login");
    }
    throw new Response("Failed to fetch technicians", {
      status: response.status,
    });
  }

  const data = await response.json();
  return data.data.technicians;
}

export async function technicianLoader({ params }) {
  requireAdmin();

  try {
    // Hacer la petición para obtener los datos del técnico
    const response = await fetch(
      `${config.BACKEND_URL}/Technician/${params.id}`,
      {
        headers: authHeaders(),
      }
    );

    if (response.status === 401) {
      sessionStorage.removeItem("user");
      sessionStorage.removeItem("jwt");
      throw redirect("/users/login");
    }

    if (response.status === 404) {
      // Técnico no encontrado
      throw json(
        {
          title: "Técnico no encontrado",
          message: "El técnico solicitado no existe o ha sido eliminado.",
        },
        { status: 404 }
      );
    }

    if (!response.ok) {
      // Otros errores genéricos
      throw new Response("Error al obtener el técnico", {
        status: response.status,
      });
    }

    // Convertir y retornar los datos si todo está correcto
    const data = await response.json();
    return data.data;
  } catch (error) {
    if (error instanceof Response) {
      throw error;
    }
    // Manejo de errores imprevistos
    console.error("Error inesperado en technicianLoader:", error);
    throw json(
      {
        title: "Error inesperado",
        message: "Ocurrió un error al cargar los datos.",
      },
      { status: 500 }
    );
  }
}

export async function neighbourhoodsLoader() {
  requireAdmin();
  return fetchNeighborhoods();
}
