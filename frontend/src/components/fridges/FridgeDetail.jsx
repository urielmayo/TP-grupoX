import { useLoaderData } from "react-router-dom";
import { MapContainer, TileLayer, Marker } from "react-leaflet";

export default function FridgeDetail() {
  const fridge = useLoaderData();
  console.log(fridge);

  return (
    <div className="bg-white shadow-lg rounded-2xl p-8 min-w-full">
      <div className="flex gap-x-10">
        <div className="flex-1">
          <h1 className="text-4xl">{fridge.name}</h1>
          <hr className="my-4" />
          <div>
            <address className="text-xl">{fridge.address}</address>
            <p className="mt-2">Capacidad maxima: {fridge.maxFoodCapacity}</p>
          </div>
        </div>
        <div className="flex-1">
          <MapContainer
            center={[fridge.latitud, fridge.longitud]}
            zoom={15}
            style={{ height: "500px", width: "100%" }}
          >
            <TileLayer
              url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
              attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            />
            <Marker position={[fridge.latitud, fridge.longitud]}></Marker>
          </MapContainer>
        </div>
      </div>
    </div>
  );
}
