import {
  useNavigate,
  useLoaderData,
  useRevalidator,
  Form,
} from "react-router-dom";
import Modal from "../UI/Modal";
import DescriptionGrid from "../UI/Description";
import { deleteTechnician } from "../../utils/http";
import { useState } from "react";
export default function TechnianDetail() {
  const [isDeleting, setIsDeleting] = useState(false);
  const [isEditing, setIsEditing] = useState(false);
  const navigate = useNavigate();
  const revalidator = useRevalidator();
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

  let content = (
    <DescriptionGrid>
      <DescriptionGrid.Item label="Nombre" value={name} editable={isEditing} />
      <DescriptionGrid.Item
        label="Apellido"
        value={surname}
        editable={isEditing}
      />
      <DescriptionGrid.Item
        label={documentTypeName}
        value={idNumber}
        editable={isEditing}
      />
      <DescriptionGrid.Item
        label="Numero de telefono"
        value={phoneNumber}
        editable={isEditing}
      />
      <DescriptionGrid.Item label="Email" value={email} editable={isEditing} />
      <DescriptionGrid.Item
        label="Barrio donde opera"
        value={neighbourhoodName}
        editable={isEditing}
      />
    </DescriptionGrid>
  );
  if (isEditing) {
    content = <Form method="PUT">{content}</Form>;
  }
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="min-w-96 min-h-48">
        <h1 className="text-xl">Tecnico # {workerIdentificationNumber}</h1>
        <hr className="my-3" />
        {content}
        <br />
        <div className="flex gap-x-3">
          {(!isEditing && (
            <>
              <button
                className="text-blue-500 hover:bg-blue-100 rounded-md p-2"
                onClick={() => setIsEditing(true)}
              >
                Editar
              </button>
              <button
                className="text-red-500 hover:bg-red-100 rounded-md p-2"
                onClick={handleDeleteTechnician}
                disabled={isDeleting}
              >
                {isDeleting ? "Borrando..." : "Borrar tecnico"}
              </button>
            </>
          )) || (
            <>
              <button
                className="text-blue-500 hover:bg-blue-100 rounded-md p-2"
                onClick={() => setIsEditing(false)}
              >
                Cancelar
              </button>
              <button className="bg-blue-500 text-white rounded-md p-2">
                Confirmar
              </button>
            </>
          )}
        </div>
      </div>
    </Modal>
  );
}
