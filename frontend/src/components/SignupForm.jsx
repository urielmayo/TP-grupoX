import { useState } from "react";

import Field from "./UI/Field";
import SubmitButton from "./UI/SubmitButton";
import FormTitle from "./UI/FormTitle";

export default function SignupForm() {
  const [tipoColaborador, setTipoColaborador] = useState("humana");

  return (
    <div>
      <FormTitle text={"Formulario de Colaborador"} />
      <br />
      {/* Tipo de Colaborador */}
      <div className="mb-4">
        <label className="block text-gray-700">Tipo de Colaborador</label>
        <select
          name="colaborator-type"
          value={tipoColaborador}
          onChange={(event) => setTipoColaborador(event.target.value)}
          className="w-full px-4 py-2 mt-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
        >
          <option value="humana">Persona Humana</option>
          <option value="juridica">Persona Juridica</option>
        </select>
      </div>

      {/* Dirección */}
      <Field
        label={"Dirección"}
        name={"address"}
        type={"text"}
        placeholder={"Ingrese la dirección"}
        required
      />

      {/* Campos para Persona Humana */}
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

      {/* Campos para Persona Jurídica */}
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
    </div>
  );
}
