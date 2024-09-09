import { redirect, Form } from "react-router-dom";

import SignupForm from "../components/SignupForm";

export default function Signup() {
  return (
    <div className="flex items-center justify-center ">
      <div className="w-full max-w-md bg-white p-8 rounded-2xl shadow-lg">
        <Form>
          <SignupForm />
        </Form>
      </div>
    </div>
  );
}

export async function SignupFormAction({ request }) {
  const data = await request.formData();

  const signupData = {
    email: data.get("email"),
    password: data.get("password"),
  };
  console.log(signupData);
  localStorage.setItem("token", 1234567);
  localStorage.setItem(
    "user",
    JSON.stringify({
      email: signupData.email,
      id: "12345abcde",
      personType: "humana",
    })
  );
  return redirect("/");
}
