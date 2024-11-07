import { redirect, useActionData } from "react-router-dom";

import SignupForm from "../components/SignupForm";
import { config } from "../config";

export default function SignupPage() {
  return (
    <div className="flex items-center justify-center">
      <div className="w-3/4 bg-white p-8 rounded-2xl shadow-lg">
        <SignupForm />
      </div>
    </div>
  );
}

export async function action({ request }) {
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
