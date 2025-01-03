import { useLoaderData } from "react-router-dom";
import { useState } from "react";
import BenefitCard from "./BenefitCard";
import GridLayout from "../../layouts/GridLayout";
import EmptyGrid from "../UI/EmptyGrid";

export default function BenefitList() {
  const { user, benefits } = useLoaderData();
  const [searchTerm, setSearchTerm] = useState("");

  const filters = [
    {
      component: (
        <input
          type="text"
          placeholder="Buscar por nombre..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="px-4 py-2 border rounded-md"
        />
      ),
      predicate: (benefit) =>
        benefit.description.toLowerCase().includes(searchTerm.toLowerCase()),
    },
  ];

  return (
    <GridLayout
      header={
        <>
          <h1 className="text-4xl">Beneficios</h1>
          <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
          <h1 className="text-2xl mt-2">
            Puntos acumulados: {user.accumulatedPoints}
          </h1>
        </>
      }
      filters={filters}
      items={benefits.filter((benefit) => benefit.collaboratorId !== user.id)}
      renderItem={(benfit) => <BenefitCard key={benfit.id} benefit={benfit} />}
      emptyItem={<EmptyGrid title="No hay productos" />}
    />
  );
}
