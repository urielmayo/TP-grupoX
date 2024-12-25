import { Link, useLoaderData } from "react-router-dom";
import GridLayout from "../../layouts/GridLayout";
import EmptyGrid from "../UI/EmptyGrid";
import ContributionCard from "./ContributionCard";

export default function ContributionList() {
  const { contributions } = useLoaderData();
  return (
    <GridLayout
      header={
        <>
          <h1 className="text-4xl">Mis contribuciones</h1>

          <>
            <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
            <Link
              to="new"
              className="hover:bg-blue-600 hover:text-white px-4 py-2 rounded-lg align-middle text-center ring-1 hover:ring-0 ring-gray-400"
            >
              +
            </Link>
          </>
        </>
      }
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
