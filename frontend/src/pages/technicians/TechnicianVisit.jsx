/* eslint-disable react-refresh/only-export-components */
import { config } from "../../config";
import { json } from "react-router-dom";
import TechnicianVisit from "../../components/technicians/TechnicianVisit";

export default function TechnicianVisitPage() {
  return <TechnicianVisit />;
}

export async function technicianVisitAction({ request, params }) {
  try {
    const formData = await request.formData();
    const dataToSend = new FormData();
    dataToSend.append("uuid", params.uuid);
    dataToSend.append("FridgeRepaired", formData.get("fridge_repaired"));
    dataToSend.append("Comment", formData.get("comment"));
    dataToSend.append("Image", formData.get("file"));

    const response = await fetch(
      `${config.BACKEND_URL}/Technician/visit/${params.uuid}`,
      {
        method: "PATCH",
        body: dataToSend,
      }
    );
    if (response.status === 204) {
      return { success: true };
    }
    if (response.status === 422) {
      const data = await response.json();
      return { success: false, message: data.Errors[0] };
    }
    throw json({ message: "Error al registrar la visita" }, { status: 500 });
  } catch (error) {
    console.error(error);
    throw json({ message: "Error al registrar la visita" }, { status: 500 });
  }
}
