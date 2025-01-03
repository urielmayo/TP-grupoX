import { useLoaderData, Link } from "react-router-dom";
import { useState } from "react";
import TechniciansCard from "./TechniciansCard";
import EmptyGrid from "../UI/EmptyGrid";
import GridLayout from "../../layouts/GridLayout";

export default function TechniciansList() {
  const technicians = useLoaderData();
  console.log(technicians);
  const [searchTerm, setSearchTerm] = useState("");
  const [searchId, setSearchId] = useState("");

  const filters = [
    {
      component: (
        <div className="flex items-center gap-2">
          <label className="font-medium">Nombre</label>
          <input
            type="text"
            className="border px-4 py-2 rounded-md"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
      ),
      predicate: (technician) => {
        const name =
          technician.name.toLowerCase() +
          " " +
          technician.surname.toLowerCase();
        return name.includes(searchTerm.toLowerCase());
      },
    },
    {
      component: (
        <div className="flex items-center gap-2">
          <label className="font-medium">Identificacion</label>
          <input
            type="text"
            className="border px-4 py-2 rounded-md"
            placeholder="ingresar sin '#'"
            value={searchId}
            onChange={(e) => setSearchId(e.target.value)}
          />
        </div>
      ),
      predicate: (technician) =>
        technician.workerIdentificationNumber.includes(searchId),
    },
  ];

  return (
    <GridLayout
      header={
        <>
          <h1 className="text-4xl">Tecnicos</h1>
          <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
          <Link
            to="new"
            className="hover:bg-blue-600 hover:text-white px-4 py-2 rounded-lg align-middle text-center ring-1 hover:ring-0 ring-gray-400"
          >
            Agregar técnico
          </Link>
        </>
      }
      filters={filters}
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
