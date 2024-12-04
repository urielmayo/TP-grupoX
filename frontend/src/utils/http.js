import { getUserData } from "./auth";
import { config } from "../config";
import { redirect } from "react-router-dom";

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
    sessionStorage.removeItem("jwt");
    sessionStorage.removeItem("user");
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

export async function fetchRewards() {
  const response = await fetch(`${config.BACKEND_URL}/rewards`);
}
