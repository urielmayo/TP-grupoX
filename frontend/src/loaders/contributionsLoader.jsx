import { requireAuth } from "../utils/auth";
import { config } from "../config";
import { redirect, json } from "react-router-dom";

export async function contributionLoader({ params }) {
  requireAuth();

  const response = await fetch(
    `${config.BACKEND_URL}/Contribution/${params.id}`,
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
