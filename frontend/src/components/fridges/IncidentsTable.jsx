/* eslint-disable react/prop-types */

function translateIncidentType(incidentType) {
  console.log(incidentType);
  console.log(incidentType === "FridgeFailure");

  if (incidentType === "FridgeFailure") {
    return "Falla";
  }
}

export default function IncidentsTable({ incidents }) {
  console.log(incidents);

  return (
    <table className="table-fixed border-collapse ">
      <thead>
        <tr>
          <th className="ring-1 ring-gray-200 rounded-tl-lg bg-gray-200">
            Fecha
          </th>
          <th className="bg-gray-200 ring-1 ring-gray-200">Tipo</th>
          <th className="rounded-tr-lg bg-gray-200 ring-1 ring-gray-200">
            Descripcion
          </th>
        </tr>
      </thead>
      <tbody>
        {incidents.map((incident) => (
          <tr key={incident.id}>
            <td className="border py-1 px-10">
              {new Date(incident.date).toLocaleDateString("es-AR")}
            </td>
            <td className="border py-1 px-10 ">
              {translateIncidentType(incident.type)}
            </td>
            <td className="border py-1 px-10">{incident.description}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
