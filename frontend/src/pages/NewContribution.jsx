/* eslint-disable react-refresh/only-export-components */
import { redirect } from "react-router-dom";
import { config } from "../config";
import NewContribution from "../components/Contributions/NewContribution";

export default function NewContributionPage() {
  return <NewContribution />;
}

export async function newContribAction({ request }) {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());
  console.log(data);

  const type = data.type;
  delete data.type;

  const response = await fetch(`${config.BACKEND_URL}/Contribution/${type}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
    },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    const errors = await response.json();
    return errors.errors;
  }
  return redirect("..");
}
