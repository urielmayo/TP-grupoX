import { redirect } from "react-router-dom";
import { config } from "../config";

export function getUserData() {
  const user = JSON.parse(sessionStorage.getItem("user"));
  return user;
}

export function userLoader() {
  return getUserData();
}

export async function fetchUser() {
  const user = getUserData();
  const jwt = sessionStorage.getItem("jwt");
  const response = await fetch(
    `${config.BACKEND_URL}/Collaborator/${user.id}`,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `bearer ${jwt}`,
      },
    }
  );
  if (response.status === 401) {
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
