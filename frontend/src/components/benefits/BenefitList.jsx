import { useLoaderData } from "react-router-dom";
import BenefitCard from "./BenefitCard";
import GridLayout from "../../layouts/GridLayout";
import EmptyGrid from "../UI/EmptyGrid";

export default function BenefitList() {
  const { user, benefits } = useLoaderData();

  return (
    <GridLayout
      header={
        <>
          <h1 className="text-4xl">Mis contribuciones</h1>
          <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
          <h1 className="text-2xl mt-2">
            Puntos acumulados: {user.accumulatedPoints}
          </h1>
        </>
      }
      items={benefits}
      renderItem={(benfit) => <BenefitCard key={benfit.id} benefit={benfit} />}
      emptyItem={<EmptyGrid title="No hay productos" />}
    />
  );
}
