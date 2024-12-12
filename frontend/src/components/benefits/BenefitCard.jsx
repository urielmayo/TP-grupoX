/* eslint-disable react/prop-types */
import { config } from "../../config";
import { replace, useNavigate } from "react-router-dom";

export default function BenefitCard({ benefit }) {
  const navigate = useNavigate();
  const handleClick = async () => {
    try {
      const jwt = sessionStorage.getItem("jwt"); // Obtiene el token JWT desde el sessionStorage
      if (!jwt) {
        alert("Error: No se encontró un token de autenticación.");
        return;
      }

      const response = await fetch(
        `${config.BACKEND_URL}/Collaborator/exchange-benefit`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${jwt}`, // Incluye el JWT en el header
          },
          body: JSON.stringify({ benefitId: benefit.id }), // Construye el cuerpo del POST
        }
      );

      if (!response.ok) {
        // Manejo de errores de respuesta
        const errorData = await response.json();
        alert(`Error: ${errorData.message || "No se pudo realizar el canje."}`);
        return;
      }

      // Si la respuesta fue exitosa
      alert("Producto canjeado exitosamente.");
      navigate(".", { replace: true });
    } catch (error) {
      // Manejo de errores de conexión o fetch
      alert(
        `Error: ${
          error.message || "Ocurrió un problema al intentar realizar el canje."
        }`
      );
    }
  };

  return (
    <div className="flex w-full overflow-hidden rounded-2xl shadow-lg bg-white">
      <div className="flex-1 px-6 py-4">
        <div className="font-bold text-xl mb-2">{benefit.description}</div>
        <p className="text-gray-700 text-base mb-2">
          <strong>Rubro:</strong> {benefit.category}
        </p>
        <p className="text-gray-700 text-base mb-2">
          <strong>Puntos necesarios:</strong> {benefit.requiredPoints}
        </p>
        <p className="text-gray-700 text-base mb-2">
          <strong>Empresa:</strong> {benefit.Empresa}
        </p>
        <button
          onClick={handleClick}
          className="bg-blue-600 rounded-full px-3 py-1 text-sm font-semibold text-white mt-2"
        >
          Canjear
        </button>
      </div>
      <div className="flex-shrink-0">
        <img
          className="object-contain h-full w-48"
          src={benefit.imagePath}
          alt="Imagen del beneficio"
        />
      </div>
    </div>
  );
}
