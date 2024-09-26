import { redirect, useActionData } from "react-router-dom";

import SignupForm from "../components/SignupForm";

export default function SignupPage() {
  return (
    <div className="flex items-center justify-center ">
      <div className="w-full max-w-md bg-white p-8 rounded-2xl shadow-lg">
        <SignupForm />
      </div>
    </div>
  );
}

export async function action({ request }) {
  const form = await request.formData();
  const errors = {};

  if (form.get("password_confirmation") !== form.get("password")) {
    console.log("las contraseñas no coinciden");

    errors.form = "Passwords do not match";
  }
  if (Object.keys(errors).length) {
    return errors;
  }

  const signupData = Object.fromEntries(form.entries());
  delete signupData["password_confirmation"];

  localStorage.setItem("token", 1234567);
  localStorage.setItem(
    "user",
    JSON.stringify({
      email: signupData.email,
      id: "12345abcde",
      personType: signupData["colaborator-type"],
    })
  );
  return redirect("/");
}
