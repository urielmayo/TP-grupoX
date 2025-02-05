import { authHeaders, requireAuth, requireAdmin } from "./auth";
import { config } from "../config";
import { redirect, json } from "react-router-dom";

export async function fetchUser() {
  const user = requireAuth();

  const response = await fetch(
    `${config.BACKEND_URL}/Collaborator/${user.id}`,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `bearer ${sessionStorage.getItem("jwt")}`,
      },
    }
  );
  if (response.status === 401) {
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("jwt");
    throw redirect("/users/login");
  }

  if (!response.ok) {
    const data = await response.json();
    throw json(
      {
        title: "Error interno",
        message: data.Message,
      },
      { status: response.status }
    );
  }

  const data = await response.json();
  return data.data;
}

export async function fetchNeighborhoods() {
  const response = await fetch(`${config.BACKEND_URL}/Neighborhood`);

  if (response.status === 401) {
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("jwt");
    throw redirect("/users/login");
  }

  if (!response.ok) {
    throw new Response("Failed to fetch neighborhood", {
      status: response.status,
    });
  }

  const data = await response.json();
  return data.data.neighborhoods;
}

export async function deleteTechnician(id) {
  requireAdmin();

  try {
    const response = await fetch(`${config.BACKEND_URL}/Technician/${id}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
        Authorization: `bearer ${sessionStorage.getItem("jwt")}`,
      },
    });

    if (response.status === 401) {
      sessionStorage.removeItem("user");
      sessionStorage.removeItem("jwt");
      throw redirect("/users/login");
    }

    if (!response.ok) {
      throw new Error(`Error: ${response.status} ${response.statusText}`);
    }
    return response;
  } catch (error) {
    console.error("Failed to delete technician:", error);
    throw error; // Propagamos el error para manejarlo en el componente
  }
}

export async function deleteFridge(id) {
  const response = await fetch(`${config.BACKEND_URL}/Fridge/${id}`, {
    method: "DELETE",
    headers: authHeaders(),
  });

  if (response.status === 401) {
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("jwt");
    throw redirect("/users/login");
  }

  return response;
}
