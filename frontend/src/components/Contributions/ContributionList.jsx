import { Link, useLoaderData } from "react-router-dom";
import { useState } from "react";
import GridLayout from "../../layouts/GridLayout";
import EmptyGrid from "../UI/EmptyGrid";
import ContributionCard from "./ContributionCard";

export default function ContributionList() {
  const { type: userType, contributions } = useLoaderData();

  const [activeType, setActiveType] = useState("all");

  const filters = [
    {
      component: (
        <div className="flex items-center gap-2">
          <label className="font-medium">Tipo de contribucion</label>
          <select
            className="px-4 py-2 border rounded-md"
            value={activeType}
            onChange={(e) => setActiveType(e.target.value)}
          >
            <option value="all">Todos</option>
            <option value="MoneyDonation">Dinero</option>
            {userType === "HumanPerson" && (
              <option value="FoodDonation">Comida</option>
            )}
            {userType === "HumanPerson" && (
              <option value="FoodDelivery">Distribucion de viandas</option>
            )}
            {userType === "HumanPerson" && (
              <option value="VulnerablePersonCard">
                Registro persona vulnerable
              </option>
            )}
            {userType === "LegalPerson" && (
              <option value="FridgeOwner">Heladeras</option>
            )}
            {userType === "LegalPerson" && (
              <option value="Benefit">Beneficio</option>
            )}
          </select>
        </div>
      ),
      predicate: (contribution) =>
        activeType === "all" ||
        (activeType === "MoneyDonation" && contribution.type === activeType) ||
        (activeType === "VulnerablePersonCard" &&
          contribution.type === activeType) ||
        (activeType === "FoodDonation" && contribution.type === activeType) ||
        (activeType === "FoodDelivery" && contribution.type === activeType) ||
        (activeType === "FridgeOwner" && contribution.type === activeType) ||
        (activeType === "Benefit" && contribution.type === activeType),
    },
  ];

  return (
    <GridLayout
      header={
        <>
          <h1 className="text-4xl">Mis contribuciones</h1>
          <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
          <Link
            to="new"
            className="hover:bg-blue-600 hover:text-white px-4 py-2 rounded-lg align-middle text-center ring-1 hover:ring-0 ring-gray-400"
          >
            +
          </Link>
        </>
      }
      filters={filters}
      items={contributions}
      renderItem={(contribution) => (
        <ContributionCard key={contribution.id} contribution={contribution} />
      )}
      emptyItem={
        <EmptyGrid
          title="No hay contribuciones registradas"
          text="Ingresa tu primera contribucion"
        />
      }
    />
  );
}
