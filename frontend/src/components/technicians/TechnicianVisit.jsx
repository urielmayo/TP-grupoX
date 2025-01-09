import { Form, useActionData } from "react-router-dom";
import FormLayout from "../UI/form/FormLayout";
import FormTitle from "../UI/form/FormTitle";
import Field from "../UI/form/Field";
import SubmitButton from "../UI/form/SubmitButton";
import RadioGroup from "../UI/form/RadioGroup";
export default function TechnicianVisit() {
  const data = useActionData();

  console.log("data", data);
  return (
    <Form method="PATCH">
      <FormLayout>
        <FormTitle text="Registrar visita" />
        <RadioGroup
          label="¿Heladera reparada?"
          options={[
            { label: "Sí", value: true },
            { label: "No", value: false },
          ]}
          name="fridge_repaired"
          disabled={data?.success}
        />
        <Field
          label="Comentario"
          type="text"
          name="comment"
          disabled={data?.success}
        />
        <Field
          label="Imagen"
          type="file"
          name="file"
          disabled={data?.success}
        />
        {!data && <SubmitButton text="Registrar visita" />}
        {data?.success && (
          <p className="mt-4 text-green-500 text-sm">
            Visita cargada con éxito
          </p>
        )}
        {!data?.success && (
          <p className="mt-4 text-red-500 text-sm">{data?.message}</p>
        )}
      </FormLayout>
    </Form>
  );
}
