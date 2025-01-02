/* eslint-disable react-refresh/only-export-components */
import Reports from "../components/Reports";

export default function ReportsPage() {
  return <Reports />;
}

export async function reportsAction({ request }) {
  const formData = await request.formData();
  const data = Object.fromEntries(formData);
  console.log(data);
  return null;
}
