import { Form } from "react-router-dom";
import Field from "../UI/Field";
import SubmitButton from "../UI/SubmitButton";

export default function ProductContribForm() {
  return (
    <Form method="post">
      <input type="hidden" name="type" value="benefit" />
      <Field
        label={"Nombre del producto"}
        name={"name"}
        type={"text"}
        required
      />
      <Field label={"Categoria"} name={"category"} type={"text"} required />
      <Field
        label={"Cantidad de puntos necesarios"}
        name={"requiredPoints"}
        type={"number"}
        required
      />
      <Field
        label={"URL de la imagen"}
        name={"image"}
        type={"file"}
        accept=".png"
      />
      <SubmitButton text={"Publicar"} />
    </Form>
  );
}
