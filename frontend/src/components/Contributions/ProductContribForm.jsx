import { Form } from "react-router-dom";
import Field from "../UI/Field";
import SubmitButton from "../UI/SubmitButton";

export default function ProductContribForm() {
  return (
    <Form method="post">
      <Field
        label={"Nombre del producto"}
        name={"name"}
        type={"text"}
        required
      />
      <Field
        label={"Cantidad de puntos necesarios"}
        name={"points"}
        type={"number"}
        required
      />
      <Field label={"URL de la imagen"} name={"image-url"} type={"url"} />
      <SubmitButton text={"Publicar"} />
    </Form>
  );
}
