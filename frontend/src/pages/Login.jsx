import { redirect } from "react-router-dom";
import LoginForm from "../components/LoginForm";

export default function LoginPage() {
  return (
    <div className="flex items-center justify-center">
      <div className="w-full max-w-md bg-white p-8 rounded-2xl shadow-lg">
        <LoginForm />
      </div>
    </div>
  );
}

export async function action({ request }) {
  const form = await request.formData();
  const loginData = Object.fromEntries(form.entries());

  console.log(loginData);
  localStorage.setItem("token", 1234567);
  localStorage.setItem(
    "user",
    JSON.stringify({
      email: loginData.email,
      id: "12345abcde",
      personType: "juridica",
    })
  );
  return redirect("/");
}
