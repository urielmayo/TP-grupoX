import { useLoaderData } from "react-router-dom";
import { useState } from "react";
import GridLayout from "../../layouts/GridLayout";
import FridgeCard from "./FridgeCard";
import EmptyGrid from "../UI/EmptyGrid";

export default function FridgesList() {
  const data = useLoaderData();
  const [searchTerm, setSearchTerm] = useState("");
  const [activeStatus, setActiveStatus] = useState("all");

  const filters = [
    {
      component: (
        <div className="flex items-center gap-2">
          <label className="font-medium">Buscar por nombre</label>
          <input
            type="text"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="px-4 py-2 border rounded-md"
          />
        </div>
      ),
      predicate: (fridge) =>
        fridge.name.toLowerCase().includes(searchTerm.toLowerCase()),
    },
    {
      component: (
        <div className="flex items-center gap-2">
          <label className="font-medium">Estado</label>
          <select
            value={activeStatus}
            onChange={(e) => setActiveStatus(e.target.value)}
            className="px-4 py-2 border rounded-md"
          >
            <option value="all">Todos</option>
            <option value="active">Activas</option>
            <option value="inactive">Inactivas</option>
          </select>
        </div>
      ),
      predicate: (fridge) =>
        activeStatus === "all" ||
        (activeStatus === "active" && fridge.active) ||
        (activeStatus === "inactive" && !fridge.active),
    },
  ];

  return (
    <GridLayout
      header={<h1 className="text-4xl">Heladeras</h1>}
      filters={filters}
      items={data}
      renderItem={(fridge) => <FridgeCard key={fridge.id} fridge={fridge} />}
      emptyItem={<EmptyGrid title="No hay heladeras" />}
    />
  );
}
