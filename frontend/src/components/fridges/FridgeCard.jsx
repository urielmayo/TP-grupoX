import { Link } from "react-router-dom";
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import Card from "../UI/Card";

export default function FridgeCard({ fridge }) {
  console.log(fridge);

  return (
    <Link to={`${fridge.id}`}>
      <Card>
        <h1 className="text-2xl">{fridge.name}</h1>
        <address>{fridge.address}</address>
        <p>Capacidad maxima: {fridge.maxFoodCapacity}</p>
      </Card>
    </Link>
  );
}
