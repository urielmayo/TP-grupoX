import { Form } from "react-router-dom";
import Field from "../UI/Field";
import SelectField from "../UI/SelectField";
import SubmitButton from "../UI/SubmitButton";

export default function FoodContribForm() {
  return (
    <Form method="post">
      <Field
        label={"Fecha de donacion"}
        type={"date"}
        name={"donation-date"}
        required
      />
      <Field
        label={"Comida"}
        type={"text"}
        name={"food"}
        placeholder={"Arroz con verduras"}
        required
      />
      <Field
        label={"Fecha de caducidad"}
        type={"date"}
        name={"expiration-date"}
        required
      />
      <SelectField label={"Heladera"} name={"fridge-id"}>
        <option value="1">UTN - Medrano</option>
        <option value="2">UTN - Lugano</option>
        <option value="3">Parque Centenario</option>
        <option value="4">Plaza Aristobulo del Valle</option>
      </SelectField>
      <Field
        label={"Valor energetico en Kcal."}
        type={"number"}
        name={"calories"}
      />
      <Field label={"Peso en gramos"} type={"number"} name={"weight"} />
      <SubmitButton text={"Donar"} />
    </Form>
  );
}
