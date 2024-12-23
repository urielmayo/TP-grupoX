/* eslint-disable react-refresh/only-export-components */
import { config } from "../../config";
import { authHeaders } from "../../utils/auth";
import { json } from "react-router-dom";
import FridgeIncident from "../../components/fridges/FridgeIncident";

export default function FridgeIncidentPage() {
  return <FridgeIncident />;
}

export async function fridgeIncidentAction({ request, params }) {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());
  data["fridgeId"] = params.id;

  try {
    const response = await fetch(
      `${config.BACKEND_URL}/fridge-incident/failure`,
      {
        method: "POST",
        headers: authHeaders(),
        body: JSON.stringify(data),
      }
    );

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
