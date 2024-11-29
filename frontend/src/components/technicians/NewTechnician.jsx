/* eslint-disable react-refresh/only-export-components */
import { useNavigate, Form, useActionData, redirect } from "react-router-dom";
import Modal from "../UI/Modal";
import FormTitle from "../UI/FormTitle";
import FormError from "../UI/FormError";
import SelectField from "../UI/SelectField";
import Field from "../UI/Field";
import { config } from "../../config";

export default function NewTechnician() {
  const navigate = useNavigate();
  const errors = useActionData();

  return (
    <Modal onClose={() => navigate("..")}>
      <Form method="post">
        <FormTitle text="Formulario de alta de tecnico" />

        {(errors && (
          <FormError>
            <ul>
              {Object.keys(errors).map((key) =>
                errors[key].map((item) => <li key={item}>{item}</li>)
              )}
            </ul>
          </FormError>
        )) || <br />}

        <div className="grid md:grid-cols-2 gap-x-3">
          <Field type={"text"} name={"name"} label={"Nombre"} />
          <Field type={"text"} name={"surname"} label={"Apellido"} />
          <SelectField
            label={"Tipo de documento"}
            name={"documentTypeId"}
            required
          >
            <option value="DNI">DNI</option>
            <option value="CUIT">CUIT</option>
            <option value="CUIL">CUIL</option>
            <option value="Pasaporte">Pasaporte</option>
            <option value="Libreta Cívica">Libreta Cívica</option>
            <option value="Libreta de Enrolamiento">
              Libreta de Enrolamiento
            </option>
          </SelectField>
          <Field
            label={"Numero de documento"}
            type={"text"}
            name={"documentNumber"}
          />
          <Field
            label={"Numero de Contacto"}
            type={"text"}
            name={"phoneNumber"}
          />
        </div>
      </Form>
    </Modal>
  );
}

export async function newTechnicianAction({ request }) {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());
  console.log(data);

  const response = await fetch(`${config.BACKEND_URL}/Technician`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
    },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    const errors = await response.json();
    return errors.errors;
  }
  return redirect("..");
}
