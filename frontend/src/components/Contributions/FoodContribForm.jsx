import { Form, useLoaderData } from "react-router-dom";
import Field from "../UI/form/Field";
import SelectField from "../UI/form/SelectField";
import SubmitButton from "../UI/form/SubmitButton";

export default function FoodContribForm() {
  const activeFridges = useLoaderData().filter((fridge) => fridge.active);

  return (
    <Form method="post">
      <input type="hidden" name="type" value="food" />
      <Field
        label={"Comida"}
        type={"textArea"}
        name={"description"}
        placeholder={"Arroz con verduras"}
        required
      />
      <Field
        label={"Fecha de caducidad"}
        type={"date"}
        name={"expirationDate"}
        required
      />
      <SelectField label={"Heladera"} name={"fridgeId"} required>
        {(activeFridges.length &&
          activeFridges.map((fridge) => (
            <option key={fridge.id} value={fridge.id}>
              {fridge.name}
            </option>
          ))) || <option disabled>no hay heladeras activas</option>}
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
