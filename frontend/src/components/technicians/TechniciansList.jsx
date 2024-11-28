import { useLoaderData } from "react-router-dom";
import Grid from "../UI/Grid";
import { Link } from "react-router-dom";
import TechniciansCard from "./TechniciansCard";
import EmptyGrid from "../UI/EmptyGrid";
export default function TechniciansList() {
  const data = { technicians: [] };
  console.log(data);

  return (
    <div className="p-8 min-w-full">
      <div className="flex gap-x-3">
        <h1 className="text-4xl">Técnicos</h1>
        <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
        <Link
          to="new"
          className="hover:bg-blue-600 hover:text-white px-4 py-2 rounded-lg align-middle text-center ring-1 hover:ring-0 ring-gray-400"
        >
          Agregar técnico
        </Link>
      </div>
      <h3 className="my-3" />
      {data.technicians.length ? (
        <Grid>
          {data.technicians.map((technician) => (
            <TechniciansCard key={technician.id} technician={technician} />
          ))}
        </Grid>
      ) : (
        <EmptyGrid
          title="No hay tecnicos registrados"
          text="Dar de alta tecnicos"
        />
      )}
    </div>
  );
}
