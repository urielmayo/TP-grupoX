import { Form } from "react-router-dom";
import Field from "../UI/Field";
import SubmitButton from "../UI/SubmitButton";
import SelectField from "../UI/SelectField";

export default function MoneyContribForm() {
  return (
    <div>
      <Form method="post">
        <Field
          label={"Fecha de donacion"}
          type={"date"}
          name={"donation-date"}
          required
        />
        <Field label={"Monto"} type={"number"} name={"amount"} required />

        <SelectField label={"Medio de pago"} name={"payment-type"}>
          <option value="transfer">Transferencia</option>
          <option value="card">Tarjeta</option>
          <option value="cash">Efectivo</option>
        </SelectField>

        <SelectField label={"Recurrencia"} name={"recurrence"}>
          <option value="none">No</option>
          <option value="monthly">Mensual</option>
          <option value="quarterly">Trimestral</option>
          <option value="annually">Anual</option>
        </SelectField>

        <SubmitButton text={"Donar"} />
      </Form>
    </div>
  );
}
