/* eslint-disable react/prop-types */
import { useLoaderData, useNavigate } from "react-router-dom";
import Modal from "../UI/Modal";

function DescriptionGridItem({ label, value }) {
  return (
    <div className="flex justify-between">
      <h1 className="font-bold">{label}:</h1>
      <p>{value}</p>
    </div>
  );
}

function DescriptionGrid({ children }) {
  return <div className="grid gap-y-3">{children}</div>;
}

DescriptionGrid.Item = DescriptionGridItem;

export default function ContributionDetail() {
  const navigate = useNavigate();
  const { type, attributes } = useLoaderData();

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
  }
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="min-w-96 min-h-48">{content}</div>
    </Modal>
  );
}
