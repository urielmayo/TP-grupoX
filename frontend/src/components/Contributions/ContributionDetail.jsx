/* eslint-disable react/prop-types */
import { useLoaderData, useNavigate, useRevalidator } from "react-router-dom";
import { useRef, useState } from "react";
import Modal from "../UI/Modal";
import DescriptionGrid from "../UI/Description";
import { deleteFridge } from "../../utils/http";

export function MoneyDonation({ attributes }) {
  const donation_date = new Date(attributes.date).toLocaleDateString();
  return (
    <>
      <h1 className="text-xl">Contribución de dinero</h1>
      <hr className="my-3" />
      <DescriptionGrid>
        <DescriptionGrid.Item label="Fecha de donación" value={donation_date} />
        <DescriptionGrid.Item label="Monto" value={`$ ${attributes.amount}`} />
        <DescriptionGrid.Item label="Frecuencia" value={attributes.frequency} />
      </DescriptionGrid>
    </>
  );
}

export function FoodDonation({ attributes }) {
  const exp_date = new Date(attributes.expiration_date).toLocaleDateString();
  const status =
    attributes.status === "Requested"
      ? { name: "Pendiente", cssColor: "text-yellow-500 bg-yellow-100" }
      : attributes.status === "Done"
      ? { name: "Confirmada", cssColor: "text-emerald-500 bg-emerald-100" }
      : { name: "", cssColor: "" };

  return (
    <>
      <div className="flex justify-between items-end">
        <h1 className="text-xl">Donación de Comida</h1>
        <h1 className={`font-bold px-2 py-1 rounded-md ${status.cssColor}`}>
          {status.name}
        </h1>
      </div>
      <hr className="my-3" />
      <DescriptionGrid>
        <DescriptionGrid.Item
          label="Descripción"
          value={attributes.description}
        />
        <DescriptionGrid.Item label="Fecha de expiración" value={exp_date} />
        <DescriptionGrid.Item
          label="Valor energético"
          value={`${attributes.calories} kcal.`}
        />
        <DescriptionGrid.Item
          label="Peso en gramos"
          value={attributes.weight}
        />
      </DescriptionGrid>
    </>
  );
}

export function FridgeOwner({ attributes }) {
  const maxCapacityRef = useRef();
  const [status, setStatus] = useState(null);
  const navigate = useNavigate();
  const revalidator = useRevalidator();

  async function handleDelete() {
    try {
      const response = await deleteFridge(attributes.fridgeId);
      if (response.ok) {
        revalidator.revalidate();
        navigate("../");
      } else if (response.status === 401) {
        sessionStorage.removeItem("jwt");
        sessionStorage.removeItem("user");
        navigate("/users/login");
      }
    } catch (error) {
      console.error("Error al eliminar la heladera:", error);
    }
  }

  function handleUpdate() {
    console.log("editando");
    console.log(maxCapacityRef.current.value);
  }

  return (
    <>
      <h1 className="text-xl">Heladera</h1>
      <hr className="my-3" />
      <DescriptionGrid>
        <DescriptionGrid.Item label="Nombre" value={attributes.name} />
        <DescriptionGrid.Item label="Dirección" value={attributes.address} />
        <DescriptionGrid.Item
          label="Capacidad Máxima"
          value={attributes.capacity}
          editable={status === "editing"}
          ref={maxCapacityRef}
        />
      </DescriptionGrid>
      <br />
      <div className="flex gap-x-3 items-end">
        {status === null && (
          <>
            <button
              className="text-blue-500 hover:bg-blue-100 rounded-md p-2"
              onClick={() => setStatus("editing")}
            >
              Editar
            </button>
            <button
              className="text-red-500 hover:bg-red-100 rounded-md p-2"
              onClick={() => setStatus("deleting")}
            >
              Eliminar
            </button>
          </>
        )}
        {status === "deleting" && (
          <>
            <button
              className="text-blue-500 hover:underline rounded-md p-2"
              onClick={() => setStatus(null)}
            >
              Cancelar
            </button>
            <button
              className="text-white bg-red-500 hover:bg-red-600 rounded-md p-2"
              onClick={handleDelete}
            >
              Confirmar
            </button>
            <p className="text-">¿Esta seguro?</p>
          </>
        )}
        {status === "editing" && (
          <>
            <button
              className="text-blue-500 hover:underline rounded-md p-2"
              onClick={() => setStatus(null)}
            >
              Cancelar
            </button>
            <button
              className="bg-blue-500 text-white rounded-md p-2"
              onClick={handleUpdate}
            >
              Confirmar
            </button>
          </>
        )}
      </div>
    </>
  );
}

export function FoodDelivery({ attributes }) {
  const status =
    attributes.status === "Requested"
      ? { name: "Pendiente", cssColor: "text-yellow-500 bg-yellow-100" }
      : attributes.status === "Done"
      ? { name: "Confirmada", cssColor: "text-emerald-500 bg-emerald-100" }
      : { name: "", cssColor: "" };

  return (
    <>
      <div className="flex justify-between items-end">
        <h1 className="text-xl">Distribucion de viandas</h1>
        <h1 className={`font-bold px-2 py-1 rounded-md ${status.cssColor}`}>
          {status.name}
        </h1>
      </div>
      <hr className="my-3" />
      <DescriptionGrid>
        <DescriptionGrid.Item
          label="Heladera origen"
          value={attributes.origin_fridge_name}
        />
        <DescriptionGrid.Item
          label="Heladera destino"
          value={attributes.destination_fridge_name}
        />
        <DescriptionGrid.Item
          label="Cantidad de viandas distribuidas"
          value={attributes.amount}
        />
        <DescriptionGrid.Item
          label="Motivo"
          value={attributes.delivery_reason}
        />
      </DescriptionGrid>
    </>
  );
}

export function VulnerablePersonCard({ attributes }) {
  return (
    <>
      <h1 className="text-xl">Registro de persona vulnerable</h1>
      <hr className="my-3" />
      <DescriptionGrid>
        <DescriptionGrid.Item label="Tarjeta" value={attributes.card} />
        <DescriptionGrid.Item
          label="Nombre"
          value={`${attributes.name} ${attributes.surname}`}
        />
        <DescriptionGrid.Item
          label="Menores a cargo"
          value={attributes.minors_in_care}
        />
        <DescriptionGrid.Item
          label={attributes.doc_type}
          value={attributes.doc_number}
        />
        <DescriptionGrid.Item
          label="Direccion"
          value={attributes.addres || "No tiene"}
        />
        <DescriptionGrid.Item
          label="Fecha de nacimiento"
          value={attributes.birthdate}
        />
      </DescriptionGrid>
    </>
  );
}

export function Benefit({ attributes }) {
  return (
    <>
      <h1 className="text-xl">Publicación de beneficio</h1>
      <hr className="my-3" />
      <DescriptionGrid>
        <DescriptionGrid.Item
          label="Descripcion"
          value={attributes.description}
        />
        <DescriptionGrid.Item label="Rubro" value={attributes.category} />
        <DescriptionGrid.Item
          label="Puntos necesarios"
          value={attributes.required_points}
        />
      </DescriptionGrid>
    </>
  );
}

export default function ContributionDetail() {
  const navigate = useNavigate();
  const { type, attributes } = useLoaderData();

  let content;
  if (type == "MoneyDonation") {
    content = <MoneyDonation attributes={attributes} />;
  } else if (type === "FridgeOwner") {
    content = <FridgeOwner attributes={attributes} />;
  } else if (type === "FoodDonation") {
    content = <FoodDonation attributes={attributes} />;
  } else if (type === "FoodDelivery") {
    content = <FoodDelivery attributes={attributes} />;
  } else if (type === "VulnerablePersonCard") {
    content = <VulnerablePersonCard attributes={attributes} />;
  } else if (type === "Benefit") {
    content = <Benefit attributes={attributes} />;
  }
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="min-w-96 min-h-48">{content}</div>
    </Modal>
  );
}
