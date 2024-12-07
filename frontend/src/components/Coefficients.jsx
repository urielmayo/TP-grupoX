import { useLoaderData, Form, useActionData } from "react-router-dom";

import FormLayout from "./UI/form/FormLayout";
import FormTitle from "./UI/form/FormTitle";
import FormError from "./UI/form/FormError";
import Field from "./UI/form/Field";
import SubmitButton from "./UI/form/SubmitButton";

export default function Coefficients() {
  const {
    donatedPesos,
    donatedFoods,
    deliveredFoods,
    deliveredCards,
    activeFridges,
    validFrom,
    validUntil,
  } = useLoaderData().coefficients[0];
  const errors = useActionData();
  console.log(validFrom, validUntil);

  return (
    <FormLayout>
      <Form method="put">
        <FormTitle text="Carga de coeficientes" />
        <p className="font-light text-slate-600 mt-4">
          Establezca los coeficientes para la suma de puntos al realizar las
          donaciones.
          <br />
          Por ejemplo si el coeficiente de donacion es de 2, Por cada peso
          donado se reciben 2 puntos
        </p>
        <hr className="mb-4 mt-2" />

        {errors && (
          <FormError>
            <ul>
              {Object.keys(errors).map((key) =>
                errors[key].map((item) => <li key={item}>{item}</li>)
              )}
            </ul>
          </FormError>
        )}
        <div className="grid  md:grid-cols-2 gap-y-3 gap-x-4">
          <Field
            label="Donacion de Dinero"
            name="donatedPesos"
            type="number"
            step="0.1"
            required
            defaultValue={donatedPesos}
          />
          <Field
            label="Donacion de vianda"
            name="donatedFoods"
            type="number"
            step="0.1"
            required
            defaultValue={donatedFoods}
          />
          <Field
            label="Viandas distribuidas"
            name="deliveredFoods"
            type="number"
            step="0.1"
            required
            defaultValue={deliveredFoods}
          />
          <Field
            label="Tarjetas Entregadas"
            name="deliveredCards"
            type="number"
            step="0.1"
            required
            defaultValue={deliveredCards}
          />
          <div className="col-span-2">
            <Field
              label="Actividad de Heladeras"
              name="activeFridges"
              type="number"
              step="0.1"
              required
              defaultValue={activeFridges}
            />
          </div>
          <Field
            label="Valido desde"
            name="validFrom"
            type="datetime-local"
            defaultValue={new Date(validFrom).toISOString().slice(0, 16)}
            required
          />
          <Field
            label="Valido hasta"
            name="validUntil"
            type="datetime-local"
            defaultValue={new Date(validUntil).toISOString().slice(0, 16)}
            required
          />
        </div>
        <SubmitButton text="Actualizar" />
      </Form>
    </FormLayout>
  );
}
