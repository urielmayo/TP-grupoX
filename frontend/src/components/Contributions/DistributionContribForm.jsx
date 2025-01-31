import { Form, useLoaderData } from "react-router-dom";
import Field from "../UI/form/Field";
import SelectField from "../UI/form/SelectField";
import SubmitButton from "../UI/form/SubmitButton";

export default function DistributionContribForm() {
  const activeFridges = useLoaderData().filter((fridge) => fridge.active);
  return (
    <div>
      <Form method="post">
        <input type="hidden" name="type" value="food-distribution" />
        <SelectField label={"Heladera origen"} name={"originFridgeId"} required>
          {(activeFridges.length &&
            activeFridges.map((fridge) => (
              <option key={fridge.id} value={fridge.id}>
                {fridge.name}
              </option>
            ))) || <option disabled>no hay heladeras activas</option>}
        </SelectField>
        <SelectField
          label={"Heladera destino"}
          name={"destinationFridgeId"}
          required
        >
          {(activeFridges.length &&
            activeFridges.map((fridge) => (
              <option key={fridge.id} value={fridge.id}>
                {fridge.name}
              </option>
            ))) || <option disabled>no hay heladeras activas</option>}
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
