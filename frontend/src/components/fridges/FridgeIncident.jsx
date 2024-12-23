import { useNavigate, Form } from "react-router-dom";
import Modal from "../UI/Modal";
import FormTitle from "../UI/form/FormTitle";
import Field from "../UI/form/Field";
import SubmitButton from "../UI/form/SubmitButton";

export default function FridgeIncident() {
  const navigate = useNavigate();
  return (
    <Modal onClose={() => navigate("../")}>
      <Form method="POST">
        <FormTitle text="Reportar incidente de heladera" />
        <br />
        <Field
          label="Descripcion"
          type="textArea"
          name="description"
          placeholder="Describa con el mayor nivel de detalle cual es la falla que encuentra en la heladera"
          required
        />

        <SubmitButton text="Reportar" />
      </Form>
    </Modal>
  );
}
