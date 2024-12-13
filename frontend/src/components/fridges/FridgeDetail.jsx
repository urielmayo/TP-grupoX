import { useLoaderData } from "react-router-dom";
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";

export default function FridgeDetail() {
  const fridge = useLoaderData();
  console.log(fridge);

  return (
    <div className="bg-white shadow-lg rounded-2xl p-8 min-w-full">
      <div className="flex">
        <div className="flex-1 mr-5">
          <h1 className="text-4xl">{fridge.name}</h1>
          <hr />
          <div>
            <address className="text-xl">{fridge.address}</address>
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
