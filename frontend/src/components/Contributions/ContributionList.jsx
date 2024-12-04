import { Link, useLoaderData } from "react-router-dom";
import Grid from "../UI/Grid";
import EmptyGrid from "../UI/EmptyGrid";
import ContributionCard from "./ContributionCard";

export default function ContributionList() {
  const data = useLoaderData();
  return (
    <div className="p-8 min-w-full">
      <div className="flex gap-x-3 ">
        <h1 className="text-4xl ">Mis contribuciones</h1>
        <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
        <Link
          to="new"
          className="hover:bg-blue-600 hover:text-white px-4 py-2 rounded-lg align-middle text-center ring-1 hover:ring-0 ring-gray-400"
        >
          +
        </Link>
      </div>
      <hr className="my-3" />
      {data.contributions.length ? (
        <Grid>
          {data.contributions.map((contrib) => (
            <ContributionCard key={contrib.id} contribution={contrib} />
          ))}
        </Grid>
      ) : (
        <EmptyGrid
          title="No cuenta con ninguna contribucion"
          text="Realice su primera contribucion"
        />
      )}
    </div>
  );
}
