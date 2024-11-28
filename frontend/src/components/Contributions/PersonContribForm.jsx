import { Form } from "react-router-dom";
import Field from "../UI/Field";
import SelectField from "../UI/SelectField";
import SubmitButton from "../UI/SubmitButton";

export default function PersonContribForm() {
  return (
    <Form method="post">
      <input type="hidden" name="type" value="person-registration" />
      <div className="grid md:grid-cols-2 gap-x-3">
        <Field label={"Nombre"} type={"text"} name={"name"} required />
        <Field label={"Apellido"} type={"text"} name={"surname"} required />
      </div>
      <Field
        label={"Fecha de nacimiento"}
        type={"date"}
        name={"birthDate"}
        required
      />
      <Field
        label={"Direccion"}
        type={"text"}
        name={"address"}
        placeholder={"En caso de no tener domicilio dejar vacio"}
      />
      <div className="grid md:grid-cols-2 gap-x-3">
        <SelectField label={"Tipo de documento"} name={"documentType"}>
          <option value="0">No cuenta</option>
          <option value="1">DNI</option>
          <option value="2">Pasaporte</option>
        </SelectField>
        <Field
          label={"Numero de documento"}
          type={"text"}
          name={"documentNumber"}
        />
      </div>
      <Field label={"Menores a cargo"} type={"number"} name={"minorsInCare"} />
      <Field
        label={"Código de tarjeta"}
        type={"text"}
        name={"cardCode"}
        placeholder={"XXXXXXXXXXXX"}
        pattern={"[0-9]{11}"}
        required
      />
      <SubmitButton text={"Registrar"} />
    </Form>
  );
}
