import { useLoaderData, Link } from "react-router-dom";
import TechniciansCard from "./TechniciansCard";
import EmptyGrid from "../UI/EmptyGrid";
import GridLayout from "../../layouts/GridLayout";

export default function TechniciansList() {
  const technicians = useLoaderData();
  console.log(technicians);

  return (
    <GridLayout
      header={
        <>
          <h1 className="text-4xl">Tecnicos</h1>

          <>
            <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
            <Link
              to="new"
              className="hover:bg-blue-600 hover:text-white px-4 py-2 rounded-lg align-middle text-center ring-1 hover:ring-0 ring-gray-400"
            >
              Agregar técnico
            </Link>
          </>
        </>
      }
      items={technicians}
      renderItem={(technician) => (
        <TechniciansCard key={technician.id} technician={technician} />
      )}
      emptyItem={
        <EmptyGrid
          title="No hay tecnicos registrados"
          text="Dar de alta tecnicos"
        />
      }
    />
  );
}
