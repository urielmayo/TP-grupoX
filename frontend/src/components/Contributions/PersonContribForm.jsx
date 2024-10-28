import { Form } from "react-router-dom";
import Field from "../UI/Field";
import SelectField from "../UI/SelectField";
import SubmitButton from "../UI/SubmitButton";

export default function PersonContribForm() {
  return (
    <Form method="post">
      <input type="hidden" name="type" value="person-registration" />
      <Field
        label={"Fecha de registro"}
        type={"date"}
        name={"registration-date"}
        required
      />
      <Field
        label={"Fecha de nacimiento"}
        type={"date"}
        name={"birth-date"}
        required
      />
      <Field
        label={"Direccion"}
        type={"text"}
        name={"address"}
        placeholder={"En caso de no tener domicilio dejar vacio"}
      />
      <SelectField label={"Tipo de documento"} name={"id-type"}>
        <option value="0">No cuenta</option>
        <option value="1">DNI</option>
        <option value="2">Pasaporte</option>
      </SelectField>
      <Field label={"Numero de documento"} type={"text"} name={"id"} />
      <Field
        label={"Menores a cargo"}
        type={"number"}
        name={"minors-in-charge"}
      />
      <SubmitButton text={"Registrar"} />
    </Form>
  );
}
