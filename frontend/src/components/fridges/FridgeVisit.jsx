import {
  useNavigate,
  useLoaderData,
  Form,
  useActionData,
  Link,
} from "react-router-dom";
import Modal from "../UI/Modal";
import FormTitle from "../UI/form/FormTitle";
import Field from "../UI/form/Field";
import SelectField from "../UI/form/SelectField";
import SubmitButton from "../UI/form/SubmitButton";

export default function FridgeVisit() {
  const navigate = useNavigate();
  const { fridge, technicians } = useLoaderData();
  const formData = useActionData();
  const uuid = formData && formData.data.linkToUpload.split("/")[3];

  return (
    <Modal onClose={() => navigate("../")}>
      <Form method="POST">
        <div className="px-32">
          <FormTitle text="Programar una visita" />
        </div>
        <input type="hidden" name="fridgeId" value={fridge.id} />
        <Field label="heladera" defaultValue={fridge.name} disabled />
        <SelectField name="technicianId" label="Técnico" required>
          {technicians.map((technician) => (
            <option value={technician.id} key={technician.id}>
              #{technician.workerIdentificationNumber} [{technician.name}{" "}
              {technician.surname}]
            </option>
          ))}
        </SelectField>
        {!formData && <SubmitButton text="Agendar" />}
        {formData && (
          <div>
            <h1 className="font-bold">{formData.message}</h1>
            <p>
              Compartir el siguiete{" "}
              <Link
                to={`/visit/${uuid}`}
                className="text-blue-600 hover:underline"
              >
                link
              </Link>{" "}
              para completar la informacion de la visita
            </p>
          </div>
        )}
      </Form>
    </Modal>
  );
}
