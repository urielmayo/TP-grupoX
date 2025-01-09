/* eslint-disable react-refresh/only-export-components */
import { config } from "../../config";
import { json } from "react-router-dom";
import FridgeIncident from "../../components/fridges/FridgeIncident";

export default function FridgeIncidentPage() {
  return <FridgeIncident />;
}

export async function fridgeIncidentAction({ request, params }) {
  const formData = await request.formData();

  const dataToSend = new FormData();
  dataToSend.append("FridgeId", params.id);
  dataToSend.append("Description", formData.get("description"));
  dataToSend.append("Image", formData.get("file"));

  try {
    const response = await fetch(
      `${config.BACKEND_URL}/fridge-incident/failure`,
      {
        method: "POST",
        headers: {
          Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
        },
        body: dataToSend,
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
