import { config } from "../config";
import { json } from "react-router-dom";
import { authHeaders, requireAuth } from "../utils/auth";

export async function fridgesLoader() {
  try {
    const response = await fetch(`${config.BACKEND_URL}/Fridge`);
    if (response.status === 401) {
      return response;
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
      return response;
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
