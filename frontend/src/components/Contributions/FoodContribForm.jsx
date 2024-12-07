import { Form, useLoaderData } from "react-router-dom";
import Field from "../UI/form/Field";
import SelectField from "../UI/form/SelectField";
import SubmitButton from "../UI/form/SubmitButton";

export default function FoodContribForm() {
  const fridges = useLoaderData();

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
      <SelectField label={"Heladera"} name={"fridgeId"}>
        {fridges.map((fridge) => (
          <option key={fridge.id} value={fridge.id}>
            {fridge.name}
          </option>
        ))}
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
