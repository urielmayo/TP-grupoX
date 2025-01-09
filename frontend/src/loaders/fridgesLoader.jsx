import { config } from "../config";
import { json, redirect } from "react-router-dom";
import { authHeaders, requireAdmin, requireAuth } from "../utils/auth";

export async function fridgesLoader() {
  try {
    const response = await fetch(`${config.BACKEND_URL}/Fridge`);
    if (response.status === 401) {
      sessionStorage.removeItem("user");
      sessionStorage.removeItem("jwt");
      throw redirect("/users/login");
    }
    const data = await response.json();
    return data.data.fridges;
  } catch (error) {
    throw json(
      {
        title: "Error inesperado",
        message: "Ocurrió un error al cargar los datos.",
      },
      { status: 500 }
    );
  }
}

export async function fridgeLoader({ params }) {
  requireAuth();
  try {
    const response = await fetch(`${config.BACKEND_URL}/Fridge/${params.id}`, {
      headers: authHeaders(),
    });
    if (response.status === 401) {
      sessionStorage.removeItem("user");
      sessionStorage.removeItem("jwt");
      throw redirect("/users/login");
    }
    const data = await response.json();
    return data.data;
  } catch (error) {
    throw json(
      {
        title: "Error inesperado",
        message: "Ocurrió un error al cargar los datos.",
      },
      { status: 500 }
    );
  }
}

export async function fridgeVisitLoader({ params }) {
  requireAdmin();
  try {
    const fridgeResponse = await fetch(
      `${config.BACKEND_URL}/Fridge/${params.id}`,
      {
        headers: authHeaders(),
      }
    );
    if (fridgeResponse.status === 401) {
      sessionStorage.removeItem("user");
      sessionStorage.removeItem("jwt");
      throw redirect("/users/login");
    }
    const fridgeJson = await fridgeResponse.json();
    const fridge = fridgeJson.data;

    const techniciansResponse = await fetch(
      `${config.BACKEND_URL}/Technician`,
      {
        headers: authHeaders(),
      }
    );

    if (!techniciansResponse.ok) {
      if (techniciansResponse.status === 401) {
        sessionStorage.removeItem("user");
        sessionStorage.removeItem("jwt");
        throw redirect("/users/login");
      }
      throw new Response("Failed to fetch technicians", {
        status: techniciansResponse.status,
      });
    }

    const techniciansJson = await techniciansResponse.json();
    const technicians = techniciansJson.data.technicians;

    return { fridge, technicians };
  } catch (error) {
    throw json(
      {
        title: "Error inesperado",
        message: "Ocurrió un error al cargar los datos.",
      },
      { status: 500 }
    );
  }
}
