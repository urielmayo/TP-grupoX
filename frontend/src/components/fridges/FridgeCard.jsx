import { Link } from "react-router-dom";
import Card from "../UI/Card";

export default function FridgeCard({ fridge }) {
  return (
    <Link to={`${fridge.id}`}>
      <Card>
        <div className="flex justify-between items-center">
          <h1 className="text-2xl">{fridge.name}</h1>
          {!fridge.active && <p className="text-red-500">Inactiva</p>}
        </div>
        <address>{fridge.address}</address>
        <p>Capacidad maxima: {fridge.maxFoodCapacity}</p>
      </Card>
    </Link>
  );
}
