import { useNavigate, useRouteLoaderData } from "react-router-dom";
import Modal from "../UI/Modal";
import FormTitle from "../UI/form/FormTitle";
import FridgeContribForm from "../Contributions/FridgeContribForm";

export default function FridgeUpdate() {
  const navigate = useNavigate();
  const { attributes } = useRouteLoaderData("contributionDetail");
  console.log(attributes);

  return (
    <Modal onClose={() => navigate("../")}>
      <FormTitle text="Editar heladera" />
      <FridgeContribForm attributes={attributes} />
    </Modal>
  );
}
