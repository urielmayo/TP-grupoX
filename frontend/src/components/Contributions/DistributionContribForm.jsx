import { Form, useLoaderData } from "react-router-dom";
import Field from "../UI/Field";
import SelectField from "../UI/SelectField";
import SubmitButton from "../UI/SubmitButton";

export default function DistributionContribForm() {
  const fridges = useLoaderData();
  return (
    <div>
      <Form method="post">
        <input type="hidden" name="type" value="food-distribution" />
        <SelectField label={"Heladera origen"} name={"originFridgeId"}>
          {fridges.map((fridge) => (
            <option key={fridge.id} value={fridge.id}>
              {fridge.name}
            </option>
          ))}
        </SelectField>
        <SelectField label={"Heladera destino"} name={"destinationFridgeId"}>
          {fridges.map((fridge) => (
            <option key={fridge.id} value={fridge.id}>
              {fridge.name}
            </option>
          ))}
        </SelectField>
        <Field
          label={"Cantidad de viandas a mover"}
          type={"number"}
          name={"amount"}
        />
        <SelectField label={"Motivo"} name={"deliveryReasonId"}>
          <option value="1">Desperfecto en heladera</option>
          <option value="2">Falta de viandas en heladera destino</option>
        </SelectField>
        <SubmitButton text={"Donar"} />
      </Form>
    </div>
  );
}
