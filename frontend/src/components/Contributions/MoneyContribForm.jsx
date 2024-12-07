/* eslint-disable react/prop-types */
import Field from "../UI/form/Field";
import SubmitButton from "../UI/form/SubmitButton";
import SelectField from "../UI/form/SelectField";
import { Form } from "react-router-dom";

export default function MoneyContribForm() {
  return (
    <Form method="post">
      <input type="hidden" name="type" value="money" />
      <Field label={"Fecha de donacion"} type={"date"} name={"date"} required />
      <Field label={"Monto"} type={"number"} name={"amount"} required />

      <SelectField label={"Recurrencia"} name={"frequency"}>
        <option value="0">No</option>
        <option value="1">Mensual</option>
        <option value="2">Trimestral</option>
        <option value="3">Anual</option>
      </SelectField>

      <SubmitButton text={"Donar"} />
    </Form>
  );
}
