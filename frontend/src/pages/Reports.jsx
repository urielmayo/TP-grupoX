/* eslint-disable react-refresh/only-export-components */
import Reports from "../components/Reports";
import { config } from "../config";
import { authHeaders } from "../utils/auth";
export default function ReportsPage() {
  return <Reports />;
}

export async function reportsAction({ request }) {
  const formData = await request.formData();
  const reportType = formData.get("reportType");

  const queryParams = new URLSearchParams({
    from: formData.get("fromDate"),
    to: formData.get("toDate"),
  });

  const response = await fetch(
    `${config.BACKEND_URL}/Reports/${reportType}?${queryParams}`,
    {
      headers: authHeaders(),
    }
  );

  if (!response.ok) {
    throw new Error("Error al obtener el reporte");
  }
  const data = await response.json();

  // Convert JSON to CSV
  const headers = Object.keys(data[0]).join(",");
  const rows = data.map((row) => Object.values(row).join(","));
  const csv = [headers, ...rows].join("\n");

  // Create blob and download
  const blob = new Blob([csv], { type: "text/csv;charset=utf-8;" });
  const url = window.URL.createObjectURL(blob);
  const a = document.createElement("a");
  a.href = url;
  a.download = `reporte-${reportTypeToName(reportType)}.csv`;
  a.click();
  window.URL.revokeObjectURL(url);
  return null;
}

function reportTypeToName(reportType) {
  switch (reportType) {
    case "fridge-failures":
      return "fallos-de-heladera";
    case "fridge-movements":
      return "movimientos-de-heladera";
    case "foods-by-collaborator":
      return "viandas-por-colaborador";
  }
}
