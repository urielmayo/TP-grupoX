import { redirect, json } from "react-router-dom";

export function getUserData() {
  return JSON.parse(sessionStorage.getItem("user"));
}

export function userLoader() {
  return getUserData();
}

export function requireAuth() {
  const user = getUserData();
  if (!user) {
    throw redirect("/users/login");
  }
  return user;
}

export function requireAdmin() {
  const user = requireAuth();

  if (user.role !== "Admin") {
    throw json(
      {
        title: "Acceso indebido",
        message: "No esta permitida la accion para este rol",
      },
      { status: 403 }
    );
  }
  return user;
}

export function authHeaders() {
  return {
    "Content-Type": "application/json",
    Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
  };
}

export function extractErrors(response) {
  const allErrors = [];

  // Check if the response has an 'errors' object
  if (response.errors && typeof response.errors === "object") {
    for (const [key, value] of Object.entries(response.errors)) {
      if (Array.isArray(value)) {
        allErrors.push(...value); // Spread the array into allErrors
      } else {
        allErrors.push(value); // If it's not an array, just push the value
      }
    }
  }

  // Check if the response has an 'Errors' array
  if (Array.isArray(response.Errors)) {
    allErrors.push(...response.Errors); // Spread the Errors array into allErrors
  }

  return allErrors; // Return the combined array of errors
}
