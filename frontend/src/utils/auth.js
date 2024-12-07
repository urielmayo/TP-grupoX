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
  return { Authorization: `Bearer ${sessionStorage.getItem("jwt")}` };
}
