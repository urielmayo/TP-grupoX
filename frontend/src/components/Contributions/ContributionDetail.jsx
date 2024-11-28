import { useLoaderData, useNavigate } from "react-router-dom";
import Modal from "../UI/Modal";

export default function ContributionDetail() {
  const navigate = useNavigate();

  const contribution = useLoaderData();
  console.log(contribution);

  let content;
  if (contribution.type == "MoneyDonation") {
    content = (
      <>
        <h1 className="text-xl">Contribucion de dinero</h1>
        <hr className="my-3" />
        <div className="grid gap-y-3">
          <div className="flex gap-x-3">
            <h1 className="font-bold">Monto:</h1>
            <p>$ {contribution.attributes.Amount}</p>
          </div>
          <div className="flex gap-x-3">
            <h1 className="font-bold">Frecuencia:</h1>
            <p>{contribution.attributes.Frequency}</p>
          </div>
        </div>
      </>
    );
  } else if (contribution.type === "FridgeOwner") {
    content = (
      <>
        <h1 className="text-xl">Heladera</h1>
        <hr className="my-3" />
        <div className="grid gap-y-3">
          <div className="flex gap-x-3">
            <h1 className="font-bold">Heladera:</h1>
            <p>{contribution.attributes.Fridge}</p>
          </div>
        </div>
      </>
    );
  } else if (contribution.type === "FoodDonation") {
    content = (
      <>
        <h1 className="text-xl">Comida</h1>
        <hr className="my-3" />
        <div className="grid gap-y-3">
          <div className="flex gap-x-3">
            <h1 className="font-bold">Descripcion:</h1>
            <p>{contribution.attributes.description}</p>
          </div>
        </div>
      </>
    );
  }
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="w-96 h-48">{content}</div>
    </Modal>
  );
}
