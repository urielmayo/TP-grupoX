import { redirect } from "react-router-dom";

export function getUserData() {
  const user = JSON.parse(localStorage.getItem("user"));
  return user;
}

export function userLoader() {
  return getUserData();
}

export async function fetchUser() {
  const user = getUserData();
  const jwt = localStorage.getItem("jwt");
  const response = await fetch(
    `https://localhost:7017/Collaborator/${user.id}`,
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
  const response = await fetch(`https://localhost:7017/Contribution/${id}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `bearer ${localStorage.getItem("jwt")}`,
    },
  });
  if (response.status === 401) {
    throw redirect("/users/login");
  }
  const data = await response.json();
  return data.data;
}
