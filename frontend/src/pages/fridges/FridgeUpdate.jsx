/* eslint-disable react-refresh/only-export-components */
import FridgeUpdate from "../../components/fridges/FridgeUpdate";
import { config } from "../../config";
import { redirect } from "react-router-dom";

export default function FridgeUpdatePage() {
  return <FridgeUpdate />;
}

export async function updateFridgeAction({ request }) {
  const formData = await request.formData();
  const data = Object.fromEntries(formData);
  const fridgeId = data.fridgeId;
  delete data.fridgeId;
  try {
    const response = await fetch(`${config.BACKEND_URL}/Fridge/${fridgeId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      if (response.status === 401) {
        sessionStorage.removeItem("jwt");
        sessionStorage.removeItem("user");
        throw new Error("Unauthorized");
      }
      throw new Error("Failed to update fridge");
    }
    return redirect("../");
  } catch (error) {
    if (error.message === "Unauthorized") {
      return redirect("/users/login");
    }
    throw error;
  }
}
