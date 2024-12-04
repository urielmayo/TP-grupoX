import { getUserData } from "../utils/auth";
import { config } from "../config";
import { redirect, json } from "react-router-dom";
import { fetchNeighborhoods } from "../utils/http";

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
    if (response.status === 401) {
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
  try {
    // Hacer la petición para obtener los datos del técnico
    const response = await fetch(
      `${config.BACKEND_URL}/Technician/${params.id}`,
      {
        headers: { Authorization: `Bearer ${sessionStorage.getItem("jwt")}` },
      }
    );

    if (response.status === 401) {
      // JWT expirado o no válido
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

export async function newTechnicianLoader() {
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

  return fetchNeighborhoods();
}
