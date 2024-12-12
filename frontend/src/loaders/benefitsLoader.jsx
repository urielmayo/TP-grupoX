import { fetchUser } from "../utils/http";
import { config } from "../config";
import { json } from "react-router-dom";

export async function benefitsLoader() {
  const user = await fetchUser();

  try {
    const response = await fetch(`${config.BACKEND_URL}/Benefit`);

    if (!response.ok) {
      throw json(
        { title: "Error al obtener beneficios", message: response.Message },
        { status: response.status }
      );
    }
    const data = await response.json();
    const benefits = data.data.benefits;
    return { user, benefits };
  } catch (error) {
    throw json(
      {
        title: "Error inesperado",
        message: "Ocurrió un error al cargar los datos.",
      },
      { status: 500 }
    );
  }
}
