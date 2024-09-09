import { Form } from "react-router-dom";
import Field from "../UI/Field";
import SelectField from "../UI/SelectField";
import SubmitButton from "../UI/SubmitButton";

export default function DistributionContribForm() {
  return (
    <div>
      <Form method="post">
        <Field
          label={"Fecha de donacion"}
          type={"date"}
          name={"donation-date"}
          required
        />
        <SelectField label={"Heladera origen"} name={"origin-fridge-id"}>
          <option value="1">UTN - Medrano</option>
          <option value="2">UTN - Lugano</option>
          <option value="3">Parque Centenario</option>
          <option value="4">Plaza Aristobulo del Valle</option>
        </SelectField>
        <SelectField label={"Heladera destino"} name={"dest-fridge-id"}>
          <option value="1">UTN - Medrano</option>
          <option value="2">UTN - Lugano</option>
          <option value="3">Parque Centenario</option>
          <option value="4">Plaza Aristobulo del Valle</option>
        </SelectField>
        <Field
          label={"Cantidad de viandas a mover"}
          type={"number"}
          name={"lauches-count"}
        />
        <SelectField label={"Motivo"} name={"reason"}>
          <option value="1">Desperfecto en heladera</option>
          <option value="2">Falta de viandas en heladera destino</option>
        </SelectField>
        <SubmitButton text={"Donar"} />
      </Form>
    </div>
  );
}
