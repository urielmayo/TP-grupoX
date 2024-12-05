import { redirect } from "react-router-dom";

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
