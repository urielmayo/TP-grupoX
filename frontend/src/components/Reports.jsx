import FormLayout from "./UI/form/FormLayout";
import FormTitle from "./UI/form/FormTitle";
import Field from "./UI/form/Field";
import SubmitButton from "./UI/form/SubmitButton";
import RadioGroup from "./UI/form/RadioGroup";

export default function Reports() {
  // Calculate default dates
  const today = new Date();
  const lastWeek = new Date(today);
  lastWeek.setDate(today.getDate() - 7);

  // Format dates to YYYY-MM-DD for input[type="date"]
  const formatDate = (date) => date.toISOString().split("T")[0];

  return (
    <FormLayout>
      <FormTitle text="Solicitar reporte" />
      <br />
      <div className="grid grid-cols-2 gap-x-4">
        <Field
          label="Fecha de inicio"
          type="date"
          name="startDate"
          defaultValue={formatDate(lastWeek)}
        />
        <Field
          label="Fecha de fin"
          type="date"
          name="endDate"
          defaultValue={formatDate(today)}
        />
      </div>
      <RadioGroup
        label="Tipo de reporte"
        name="reportType"
        options={[
          {
            value: "food",
            label: "Cantidad de Fallas por Heladera",
          },
          {
            value: "non-food",
            label: "Cantidad de Viandas Retiradas/Colocadas por Heladera",
          },
          {
            value: "all",
            label: "Cantidad de Viandas por colaborador",
          },
        ]}
      />
      <SubmitButton text="Solicitar" />
    </FormLayout>
  );
}
