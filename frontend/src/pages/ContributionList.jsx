import { Link, Outlet, useRouteLoaderData } from "react-router-dom";
import Grid from "../components/UI/Grid";
import ContributionCard from "../components/UI/ContributionCard";

export default function ContributionListPage() {
  const data = useRouteLoaderData("profile");
  console.log(data);

  return (
    <div className="flex items-start justify-center">
      <Outlet />
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
          <div className="bg-gray-200 rounded-2xl p-4 shadow-md min-h-72">
            <h1 className="font-bold text-2xl mb-2">
              No cuenta con ninguna contribucion
            </h1>
            <p>
              Realice su primera contribucion{" "}
              <Link className="text-blue-600 hover:underline" to={"new"}>
                aqui
              </Link>{" "}
            </p>
          </div>
        )}
      </div>
    </div>
  );
}
