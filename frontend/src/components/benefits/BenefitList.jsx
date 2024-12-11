import { useLoaderData } from "react-router-dom";
import BenefitCard from "./BenefitCard";
import GridLayout from "../../layouts/GridLayout";
import EmptyGrid from "../UI/EmptyGrid";

export default function BenefitList() {
  const { user, rewards } = useLoaderData();
  return (
    <GridLayout
      header={
        <>
          <h1 className="text-4xl">Mis contribuciones</h1>
          <div className="min-h-10 border-t sm:border-t-0 sm:border-s border-gray-200 dark:border-neutral-700"></div>
          <h1 className="text-2xl">
            Puntos acumulados: {user.accumulatedPoints}
          </h1>
        </>
      }
      items={rewards}
      renderItem={(reward) => <BenefitCard key={reward.id} product={reward} />}
      emptyItem={<EmptyGrid title="No hay productos" />}
    />
  );
}
