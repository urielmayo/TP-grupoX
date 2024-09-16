import { useLoaderData } from "react-router-dom";

import { DUMMY_PRODUCTS } from "../dummy_data.js";
import Product from "../components/UI/Product.jsx";
import Grid from "../components/UI/Grid.jsx";

export default function RewardsListPage() {
  const products = useLoaderData();
  return (
    <div className="flex items-start justify-center">
      <div className="p-8 min-w-full">
        <div className="flex gap-x-3 items-end">
          <h1 className="text-4xl">Canjea tus puntos</h1>
          <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
          <h1 className="text-2xl">Puntos acumulados: 2500</h1>
        </div>
        <hr className="my-3" />
        <Grid>
          {products.map((prod) => (
            <Product key={prod.id} product={prod} />
          ))}
        </Grid>
      </div>
    </div>
  );
}

export function loader() {
  return DUMMY_PRODUCTS;
}
