/* eslint-disable react-refresh/only-export-components */
import {
  useNavigate,
  Form,
  useActionData,
  useLoaderData,
} from "react-router-dom";
import Modal from "../UI/Modal";
import FormTitle from "../UI/FormTitle";
import FormError from "../UI/FormError";
import SelectField from "../UI/SelectField";
import Field from "../UI/Field";
import SubmitButton from "../UI/SubmitButton";

export default function NewTechnician() {
  const neighborhoods = useLoaderData();
  console.log(neighborhoods);

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
          <Field type={"text"} name={"name"} label={"Nombre"} required />
          <Field type={"text"} name={"surname"} label={"Apellido"} required />

          <SelectField
            label={"Tipo de documento"}
            name={"documentTypeId"}
            required
          >
            <option value="1">DNI</option>
            <option value="2">CUIT</option>
            <option value="3">CUIL</option>
            <option value="4">Pasaporte</option>
            <option value="5">Libreta Cívica</option>
            <option value="6">Libreta de Enrolamiento</option>
          </SelectField>

          <Field
            label={"Número de documento"}
            type={"text"}
            name={"idNumber"}
          />

          <div className="col-span-2">
            <Field
              label={"Número de identificacion"}
              type={"text"}
              name={"workerIdentificationNumber"}
            />
          </div>

          <Field
            label={"Número de telefono"}
            type={"text"}
            name={"phoneNumber"}
          />

          <Field label={"Correo electronico"} type={"email"} name={"email"} />

          <div className="col-span-2">
            <SelectField label="Barrio" name="neighborhoodId">
              {neighborhoods.map((nbh) => (
                <option value={nbh.id} key={nbh.id}>
                  {nbh.name}
                </option>
              ))}
            </SelectField>
          </div>
        </div>
        <SubmitButton text={"Publicar"} />
      </Form>
    </Modal>
  );
}
