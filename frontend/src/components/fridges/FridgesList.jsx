import { useLoaderData } from "react-router-dom";
import GridLayout from "../../layouts/GridLayout";
import FridgeCard from "./FridgeCard";
import EmptyGrid from "../UI/EmptyGrid";

export default function FridgesList() {
  const data = useLoaderData();
  console.log(data);

  return (
    <GridLayout
      header={<h1 className="text-4xl">Heladeras</h1>}
      items={data}
      renderItem={(fridge) => <FridgeCard key={fridge.id} fridge={fridge} />}
      emptyItem={<EmptyGrid title="No hay heladeras" />}
    />
  );
}
