import { redirect, json } from "react-router-dom";
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

  const response = await fetch("https://localhost:7017/Collaborator/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(loginData),
  });

  if (response.status === 403 || response.status === 404) {
    return response;
  }
  if (!response.ok) {
    throw json({ message: "could not fetch events" }, { status: 500 });
  }
  const data = await response.json();
  console.log(data);

  localStorage.setItem("jwt", data.data.jwt);
  localStorage.setItem(
    "user",
    JSON.stringify({ username: loginData.userName, id: data.data.id })
  );
  return redirect("/");
}
