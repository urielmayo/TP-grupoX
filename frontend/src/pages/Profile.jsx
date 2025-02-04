/* eslint-disable react-refresh/only-export-components */
import Profile from "../components/Profile";
import { config } from "../config";
import { authHeaders } from "../utils/auth";
import { getUserData } from "../utils/auth";
import { redirect, json } from "react-router-dom";

export default function ProfilePage() {
  return <Profile />;
}

export async function updateProfileAction({ request }) {
  const form = await request.formData();
  const profileData = Object.fromEntries(form.entries());
  const user = getUserData();

  const response = await fetch(
    `${config.BACKEND_URL}/Collaborator/${user.id}`,
    {
      method: "PUT",
      headers: authHeaders(),
      body: JSON.stringify(profileData),
    }
  );

  if (response.status === 401) {
    sessionStorage.removeItem("user");
    sessionStorage.removeItem("jwt");
    throw redirect("/users/login");
  }

  if (response.status === 400 || response.status === 422) {
    return response;
  }

  if (response.status === 500) {
    throw json({ message: "could not save event" }, { status: 500 });
  }
  // Redirect to the current page
  return redirect("/users/me");
}
