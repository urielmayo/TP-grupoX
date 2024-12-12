/* eslint-disable react-refresh/only-export-components */
import { config } from "../../config";
import BulkContributions from "../../components/Contributions/BulkContributions";

export default function BulkContributionsPage() {
  return <BulkContributions />;
}

export async function bulkContribAction({ request }) {
  const formData = await request.formData();
  const file = formData.get("file");

  if (!file.name) {
    return { error: "Debe seleccionar un archivo." };
  }

  try {
    const uploadResponse = await fetch(
      `${config.BACKEND_URL}/Collaborator/process-file`,
      {
        headers: { Authorization: `Bearer ${sessionStorage.getItem("jwt")}` },
        method: "POST",
        body: formData,
      }
    );

    if (!uploadResponse.ok) {
      const errorData = await uploadResponse.json();
      return { error: errorData.message || "Error al subir el archivo." };
    }

    const responseData = await uploadResponse.json();
    return responseData;
  } catch (error) {
    console.error("Error al subir el archivo:", error);
    return {
      error: "No se pudo procesar la solicitud. Intente nuevamente más tarde.",
    };
  }
}
