/* eslint-disable react-refresh/only-export-components */
import { json } from "react-router-dom";
import { config } from "../../config";
import { authHeaders } from "../../utils/auth";
import FridgeVisit from "../../components/fridges/FridgeVisit";

export default function FridgeVisitPage() {
  return <FridgeVisit />;
}

export async function createFridgeVisitAction({ request }) {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());
  try {
    const response = await fetch(`${config.BACKEND_URL}/Technician/visit`, {
      method: "POST",
      headers: authHeaders(),
      body: JSON.stringify(data),
    });

    return response;
  } catch (error) {
    console.error(error);
    throw json(
      {
        title: "Error al crear visita",
        message: "No se pudo agendar la visita",
      },
      { status: 500 }
    );
  }
}
