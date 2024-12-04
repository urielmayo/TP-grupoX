import { getUserData } from "./auth";
import { config } from "../config";
import { redirect, json } from "react-router-dom";

export async function fetchUser() {
  const user = getUserData();
  if (!user) {
    throw redirect("/users/login");
  }
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
    sessionStorage.removeItem("jwt");
    sessionStorage.removeItem("user");
    throw redirect("/users/login");
  }

  const data = await response.json();
  return data.data;
}

export async function fetchContribution(id) {
  const response = await fetch(`${config.BACKEND_URL}/Contribution/${id}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `bearer ${sessionStorage.getItem("jwt")}`,
    },
  });
  if (response.status === 401) {
    throw redirect("/users/login");
  }
  const data = await response.json();
  return data.data;
}

export async function fetchFridges() {
  const response = await fetch(`${config.BACKEND_URL}/Fridge`);
  if (response.status === 401) {
    return response;
  }
  const data = await response.json();
  return data.data.fridges;
}

export async function fetchNeighborhoods() {
  const response = await fetch(`${config.BACKEND_URL}/Neighborhood`);

  if (!response.ok) {
    throw new Response("Failed to fetch neighborhood", {
      status: response.status,
    });
  }

  const data = await response.json();
  return data.data.neighborhoods;
}

export async function deleteTechnician(id) {
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

  try {
    const response = await fetch(`${config.BACKEND_URL}/Technician/${id}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
        Authorization: `bearer ${sessionStorage.getItem("jwt")}`,
      },
    });
    if (!response.ok) {
      throw new Error(`Error: ${response.status} ${response.statusText}`);
    }
    return response;
  } catch (error) {
    console.error("Failed to delete technician:", error);
    throw error; // Propagamos el error para manejarlo en el componente
  }
}
