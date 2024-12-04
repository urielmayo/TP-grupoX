import { Form, Link, useActionData } from "react-router-dom";

import Field from "./UI/Field";
import SubmitButton from "./UI/SubmitButton";
import FormTitle from "./UI/FormTitle";
import FormError from "./UI/FormError";

export default function LoginForm() {
  const data = useActionData();

  return (
    <Form method="post">
      <FormTitle text={"Iniciar sesion"} />
      {data && (
        <FormError>
          <span className="font-medium">{data.Message}</span>
        </FormError>
      )}
      <Field
        label={"Nombre de usuario"}
        name={"userName"}
        type={"text"}
        required
      />

      <Field
        label={"Contraseña"}
        name={"password"}
        type={"password"}
        required
      />

      <div className="flex items-center justify-between">
        <a href="#" className="text-sm text-blue-600 hover:underline">
          Olvide mi contraseña
        </a>
      </div>

      <SubmitButton text={"Iniciar sesion"} />

      <p className="mt-8 text-center text-sm text-gray-600">
        Eres nuevo? Registrate{" "}
        <Link to={"/users/signup"} className="text-blue-600 hover:underline">
          aqui
        </Link>
      </p>
    </Form>
  );
}
