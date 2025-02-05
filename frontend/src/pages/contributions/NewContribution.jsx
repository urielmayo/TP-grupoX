/* eslint-disable react-refresh/only-export-components */
import { redirect, json } from "react-router-dom";
import { config } from "../../config";
import NewContribution from "../../components/Contributions/NewContribution";
import { authHeaders, extractErrors } from "../../utils/auth";

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
    headers: authHeaders(),
    body: JSON.stringify(data),
  });
  if (response.status === 500) {
    throw json({ message: "could not save event" }, { status: 500 });
  }
  if (response.status === 400) {
    const json = await response.json();
    return extractErrors(json);
  }
  return redirect("..");
}
