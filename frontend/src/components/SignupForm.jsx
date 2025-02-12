import { useState } from "react";
import { Form, Link, useActionData } from "react-router-dom";

import SelectField from "./UI/form/SelectField";
import Field from "./UI/form/Field";
import SubmitButton from "./UI/form/SubmitButton";
import FormTitle from "./UI/form/FormTitle";
import FormError from "./UI/form/FormError";

export default function SignupForm() {
  const [tipoColaborador, setTipoColaborador] = useState("human-person");
  const errors = useActionData();
  console.log(errors);

  return (
    <Form method="post">
      <FormTitle text={"Formulario de Colaborador"} />
      <br />

      {errors && (
        <FormError>
          <ul>
            {Object.values(errors).map((err) => (
              <li key={err}>{err}</li>
            ))}
          </ul>
        </FormError>
      )}

      <h1 className="text-xl font-bold text-gray-500 mb-4">Datos de usuario</h1>
      <div className="grid md:grid-cols-2 gap-x-3">
        <Field
          label={"Email"}
          name={"email"}
          type={"email"}
          placeholder={"user@example.com"}
          required
        />
        <Field
          label={"Nombre de usuario"}
          name={"userName"}
          type={"text"}
          placeholder={"Ingrese nombre de usuario"}
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
        <Field
          label={"Dirección"}
          name={"address"}
          type={"text"}
          placeholder={"Ingrese la dirección"}
          required={tipoColaborador === "human-person"}
        />
        <Field
          label="Telefono"
          name="phoneNumber"
          type="text"
          placeholder="Ingrese un numero de contacto"
          required
        />
      </div>

      <h1 className="text-xl font-bold text-gray-500 mb-4">
        Datos de colaborador
      </h1>
      <SelectField
        label={"Tipo de Colaborador"}
        name={"colaboratorType"}
        value={tipoColaborador}
        onChange={(event) => setTipoColaborador(event.target.value)}
      >
        <option value="human-person">Persona Humana</option>
        <option value="legal-person">Persona Juridica</option>
      </SelectField>

      {tipoColaborador === "human-person" && (
        <>
          <div className="grid grid-cols-2 gap-x-3">
            <Field
              label={"Nombre"}
              type={"text"}
              name={"name"}
              placeholder={"Ingrese el nombre"}
            />
            <Field
              label={"Apellido"}
              type={"text"}
              name={"surName"}
              placeholder={"Ingrese el apellido"}
            />
          </div>
          <Field label={"Fecha de Nacimiento"} type={"date"} name={"date"} />
        </>
      )}

      {tipoColaborador === "legal-person" && (
        <>
          <Field
            label={"Razón Social"}
            name={"businessName"}
            type={"text"}
            placeholder={"Ingrese la razón social"}
          />
          <div className="grid grid-cols-2 gap-x-3">
            <SelectField
              label={"Tipo de Organizacion"}
              name={"organizationType"}
            >
              <option value="Gubernamental">Gubernamental</option>
              <option value="ONG">ONG</option>
              <option value="Empresa">Empresa</option>
              <option value="Institución">Institución</option>
            </SelectField>
            <Field
              label={"Rubro"}
              name={"category"}
              type={"text"}
              placeholder={"Ingrese el rubro"}
            />
          </div>
        </>
      )}

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
