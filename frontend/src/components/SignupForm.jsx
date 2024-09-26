import { useState } from "react";
import { Form, Link, useActionData } from "react-router-dom";

import SelectField from "./UI/SelectField";
import Field from "./UI/Field";
import SubmitButton from "./UI/SubmitButton";
import FormTitle from "./UI/FormTitle";

export default function SignupForm() {
  const [tipoColaborador, setTipoColaborador] = useState("humana");
  const errors = useActionData();
  console.log(errors);

  return (
    <Form method="post">
      <FormTitle text={"Formulario de Colaborador"} />
      <br />

      {errors && (
        <>
          <ul>
            {Object.values(errors).map((err) => (
              <li key={err}>{err}</li>
            ))}
          </ul>
          <br />
        </>
      )}

      <SelectField
        label={"Tipo de Colaborador"}
        name={"colaborator-type"}
        value={tipoColaborador}
        onChange={(event) => setTipoColaborador(event.target.value)}
      >
        <option value="humana">Persona Humana</option>
        <option value="juridica">Persona Juridica</option>
      </SelectField>

      <Field
        label={"Dirección"}
        name={"address"}
        type={"text"}
        placeholder={"Ingrese la dirección"}
        required
      />

      {tipoColaborador === "humana" && (
        <>
          <Field
            label={"Nombre"}
            type={"text"}
            name={"name"}
            placeholder={"Ingrese el nombre"}
          />
          <Field
            label={"Apellido"}
            type={"text"}
            name={"last-name"}
            placeholder={"Ingrese el apellido"}
          />
          <Field label={"Fecha de Nacimiento"} type={"date"} name={"date"} />
        </>
      )}

      {tipoColaborador === "juridica" && (
        <>
          <Field
            label={"Razón Social"}
            type={"text"}
            placeholder={"Ingrese la razón social"}
          />
          <Field
            label={"Tipo de Organización"}
            type={"text"}
            placeholder={"Ingrese el tipo de organización"}
          />
          <Field
            label={"Rubro"}
            type={"text"}
            placeholder={"Ingrese el rubro"}
          />
        </>
      )}

      <Field
        label={"Email"}
        name={"email"}
        type={"email"}
        placeholder={"user@example.com"}
        required
      />

      <Field
        label={"Contraseña"}
        name={"password"}
        type={"password"}
        placeholder={"Ingresar contraseña"}
        required
      />

      <Field
        label={"Confirmacion de contraseña"}
        name={"password_confirmation"}
        type={"password"}
        placeholder={"Reingresar contraseña"}
        required
      />
      <SubmitButton text={"Enviar"} />

      <p className="mt-8 text-center text-sm text-gray-600">
        Ya tenes usuario? Inicia sesion{" "}
        <Link to={"/users/login"} className="text-blue-600 hover:underline">
          aqui
        </Link>
      </p>
    </Form>
  );
}
