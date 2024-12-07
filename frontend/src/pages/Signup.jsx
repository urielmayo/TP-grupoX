/* eslint-disable react-refresh/only-export-components */
import { redirect } from "react-router-dom";
import FormLayout from "../components/UI/form/FormLayout";
import SignupForm from "../components/SignupForm";
import { config } from "../config";

export default function SignupPage() {
  return (
    <FormLayout>
      <SignupForm />
    </FormLayout>
  );
}

export async function signupAction({ request }) {
  const form = await request.formData();
  const errors = {};

  if (form.get("password_confirmation") !== form.get("password")) {
    errors.Errors = "Las contraseñas no coinciden";
  }
  if (Object.keys(errors).length) {
    return errors;
  }

  const signupData = Object.fromEntries(form.entries());
  delete signupData["password_confirmation"];
  const colaboratorType = signupData.colaboratorType;
  delete signupData.colaboratorType;
  let url = `${config.BACKEND_URL}/Collaborator/${colaboratorType}`;
  const response = await fetch(url, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(signupData),
  });
  if (response.status === 400) {
    const data = await response.json();
    return data.Errors;
  }
  return redirect("/users/login");
}
