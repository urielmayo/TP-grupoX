import {
  useNavigate,
  useLoaderData,
  Form,
  useRouteLoaderData,
  useActionData,
} from "react-router-dom";
import Modal from "../UI/Modal";
import FormError from "../UI/form/FormError";
import DescriptionGrid from "../UI/Description";

export default function UpdateTechnician() {
  const navigate = useNavigate();
  const {
    name,
    surname,
    documentTypeName,
    idNumber,
    workerIdentificationNumber,
    phoneNumber,
    email,
    neighbourhoodName,
  } = useRouteLoaderData("techicianDetail");
  const neighbourhoods = useLoaderData();
  const errors = useActionData();

  const documentTypeOptions = [
    { id: "1", name: "DNI" },
    { id: "2", name: "CUIL" },
    { id: "3", name: "CUIT" },
    { id: "4", name: "Pasaporte" },
    { id: "5", name: "Libreta Cívica" },
    { id: "6", name: "Libreta de Enrolamiento" },
  ];

  return (
    <Modal onClose={() => navigate("../")}>
      <div className="min-w-96 min-h-48">
        {errors && (
          <FormError>
            <ul>
              {Object.keys(errors).map((key) =>
                errors[key].map((item) => <li key={item}>{item}</li>)
              )}
            </ul>
          </FormError>
        )}
        <h1 className="text-xl">Editar tecnico</h1>
        <hr className="my-3" />
        <Form method="PUT">
          <input
            type="hidden"
            name="workerIdentificationNumber"
            value={workerIdentificationNumber}
          />
          <DescriptionGrid>
            <DescriptionGrid.Item
              label="Nombre"
              inputName="name"
              inputType="text"
              value={name}
              editable
            />
            <DescriptionGrid.Item
              label="Apellido"
              inputName="surname"
              inputType="text"
              value={surname}
              editable
            />
            <DescriptionGrid.Item
              label="Tipo de documento"
              inputName="documentTypeId"
              inputType="select"
              value={documentTypeName}
              selectOptions={documentTypeOptions}
              editable
            />
            <DescriptionGrid.Item
              label="Numero de documento"
              inputName="idNumber"
              inputType="text"
              value={idNumber}
              editable
            />
            <DescriptionGrid.Item
              label="Numero de telefono"
              inputName="phoneNumber"
              inputType="text"
              value={phoneNumber}
              editable
            />
            <DescriptionGrid.Item
              label="Email"
              inputName="email"
              inputType="email"
              value={email}
              editable
            />
            <DescriptionGrid.Item
              label="Barrio donde opera"
              inputName="neighborhoodId"
              inputType="select"
              value={neighbourhoodName}
              selectOptions={neighbourhoods}
              editable
            />
          </DescriptionGrid>
          <br />
          <div className="flex gap-x-3">
            <button
              className="text-blue-500 hover:bg-blue-100 rounded-md p-2"
              onClick={() => navigate("../")}
            >
              Cancelar
            </button>
            <button
              className="bg-blue-500 text-white rounded-md p-2"
              type="submit"
            >
              Confirmar
            </button>
          </div>
        </Form>
      </div>
    </Modal>
  );
}
