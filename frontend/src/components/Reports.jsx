import FormLayout from "./UI/form/FormLayout";
import FormTitle from "./UI/form/FormTitle";
import Field from "./UI/form/Field";
import SubmitButton from "./UI/form/SubmitButton";
import RadioGroup from "./UI/form/RadioGroup";
import { Form } from "react-router-dom";

export default function Reports() {
  // Calculate default dates
  const today = new Date();
  const lastWeek = new Date(today);
  lastWeek.setDate(today.getDate() - 7);

  // Format dates to YYYY-MM-DD for input[type="date"]
  const formatDate = (date) => date.toISOString().split("T")[0];

  return (
    <Form method="post">
      <FormLayout>
        <FormTitle text="Solicitar reporte" />
        <br />
        <div className="grid grid-cols-2 gap-x-4">
          <Field
            label="Fecha de inicio"
            type="date"
            name="fromDate"
            defaultValue={formatDate(lastWeek)}
          />
          <Field
            label="Fecha de fin"
            type="date"
            name="toDate"
            defaultValue={formatDate(today)}
          />
        </div>
        <RadioGroup
          label="Tipo de reporte"
          name="reportType"
          options={[
            {
              value: "fridge-failures",
              label: "Cantidad de Fallas por Heladera",
            },
            {
              value: "fridge-movements",
              label: "Cantidad de Viandas Retiradas/Colocadas por Heladera",
            },
            {
              value: "foods-by-collaborator",
              label: "Cantidad de Viandas por colaborador",
            },
          ]}
        />
        <SubmitButton text="Solicitar" />
      </FormLayout>
    </Form>
  );
}
