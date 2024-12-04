/* eslint-disable react/prop-types */
import { useLoaderData, useNavigate } from "react-router-dom";
import Modal from "../UI/Modal";
import DescriptionGrid from "../UI/Description";

export default function ContributionDetail() {
  const navigate = useNavigate();
  const { type, attributes } = useLoaderData();
  console.log(type);
  console.log(attributes);

  let content;
  if (type == "MoneyDonation") {
    const donation_date = new Date(attributes.date).toLocaleDateString();
    content = (
      <>
        <h1 className="text-xl">Contribucion de dinero</h1>
        <hr className="my-3" />
        <DescriptionGrid>
          <DescriptionGrid.Item
            label="Fecha de donacion"
            value={donation_date}
          />
          <DescriptionGrid.Item
            label="Monto"
            value={`$ ${attributes.amount}`}
          />
          <DescriptionGrid.Item
            label="Frecuencia"
            value={attributes.frequency}
          />
        </DescriptionGrid>
      </>
    );
  } else if (type === "FridgeOwner") {
    const exp_date = new Date(attributes.expiration_date).toLocaleDateString();
    content = (
      <>
        <h1 className="text-xl">Heladera</h1>
        <hr className="my-3" />
        <DescriptionGrid>
          <DescriptionGrid.Item label="Nombre" value={attributes.name} />
          <DescriptionGrid.Item label="Fecha de expiracion" value={exp_date} />
        </DescriptionGrid>
      </>
    );
  } else if (type === "FoodDonation") {
    const exp_date = new Date(attributes.expiration_date).toLocaleDateString();
    content = (
      <>
        <h1 className="text-xl">Donacion de Comida</h1>
        <hr className="my-3" />
        <DescriptionGrid>
          <DescriptionGrid.Item
            label="Descripcion"
            value={attributes.description}
          />
          <DescriptionGrid.Item label="Fecha de expiracion" value={exp_date} />
          <DescriptionGrid.Item
            label="Valor energetico"
            value={`${attributes.calories} kcal.`}
          />
          <DescriptionGrid.Item
            label="Peso en gramos"
            value={attributes.weight}
          />
        </DescriptionGrid>
      </>
    );
  } else if (type === "FoodDelivery") {
    content = (
      <>
        <h1 className="text-xl">Distribucion de viandas</h1>
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
  } else if (type === "Card") {
    content = (
      <>
        <h1 className="text-xl">Registro de persona vulnerable</h1>
        <hr className="my-3" />
        <DescriptionGrid>
          <DescriptionGrid.Item label="Nombre" value={attributes.name} />
          <DescriptionGrid.Item label="Apellido" value={attributes.surname} />
          <DescriptionGrid.Item
            label="Menores a cargo"
            value={attributes.minors_in_care}
          />
          <DescriptionGrid.Item label="Tarjeta" value={attributes.tarjeta} />
        </DescriptionGrid>
      </>
    );
  }
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="min-w-96 min-h-48">{content}</div>
    </Modal>
  );
}
