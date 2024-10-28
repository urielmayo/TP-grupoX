import { Link, useLoaderData } from "react-router-dom";
import { DUMMY_CONTRIBUTIONS } from "../dummy_data";
import Grid from "../components/UI/Grid";
import ContributionCard from "../components/UI/ContributionCard";

export default function ContributionListPage() {
  const contributions = useLoaderData();
  return (
    <div className="flex items-start justify-center">
      <div className="p-8 min-w-full">
        <div className="flex gap-x-3 ">
          <h1 className="text-4xl ">Mis contribuciones</h1>
          <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
          <Link
            to="new?contribution=money"
            className="hover:bg-blue-200 px-4 py-2 rounded-full align-middle text-center ring-1 hover:ring-0 ring-gray-400"
          >
            +
          </Link>
        </div>
        <hr className="my-3" />
        <Grid>
          {contributions.map((contrib) => (
            <ContributionCard key={contrib.id} contribution={contrib} />
          ))}
        </Grid>
      </div>
    </div>
  );
}

export function loader() {
  return DUMMY_CONTRIBUTIONS;
}
