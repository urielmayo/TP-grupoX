import { useNavigate, useLoaderData, useRevalidator } from "react-router-dom";
import Modal from "../UI/Modal";
import DescriptionGrid from "../UI/Description";
import { deleteTechnician } from "../../utils/http";
import { useState } from "react";
export default function TechnianDetail() {
  const [isDeleting, setIsDeleting] = useState(false);
  const {
    id,
    name,
    surname,
    documentTypeName,
    idNumber,
    workerIdentificationNumber,
    phoneNumber,
    email,
    neighbourhoodName,
  } = useLoaderData();
  const navigate = useNavigate();
  const revalidator = useRevalidator();

  async function handleDeleteTechnician() {
    setIsDeleting(true);
    try {
      const response = await deleteTechnician(id);
      if (response.status === 204) {
        navigate("..");
        revalidator.revalidate();
      } else {
        const json = await response.json();
        alert(`Error al borrar: ${json.message}`);
      }
    } catch (error) {
      alert("Error de red");
    } finally {
      setIsDeleting(false);
    }
  }

  return (
    <Modal onClose={() => navigate("../")}>
      <div className="min-w-96 min-h-48">
        <h1 className="text-xl">Tecnico # {workerIdentificationNumber}</h1>
        <hr className="my-3" />
        <DescriptionGrid>
          <DescriptionGrid.Item
            label="Nombre completo"
            value={`${name} ${surname}`}
          />
          <DescriptionGrid.Item label={documentTypeName} value={idNumber} />
          <DescriptionGrid.Item
            label="Numero de telefono"
            value={phoneNumber}
          />
          <DescriptionGrid.Item label="Email" value={email} />
          <DescriptionGrid.Item
            label="Barrio donde opera"
            value={neighbourhoodName}
          />
        </DescriptionGrid>
        <br />
        <button
          className="text-red-500 hover:bg-red-200 rounded-md p-2"
          onClick={handleDeleteTechnician}
          disabled={isDeleting}
        >
          {isDeleting ? "Borrando..." : "Borrar tecnico"}
        </button>
      </div>
    </Modal>
  );
}
