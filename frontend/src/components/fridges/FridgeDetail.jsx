import { useLoaderData, Link } from "react-router-dom";
import { MapContainer, TileLayer, Marker } from "react-leaflet";

export default function FridgeDetail() {
  const fridge = useLoaderData();
  console.log(fridge);

  return (
    <div>
      <Link to={".."} className="text-blue-700 hover:underline ml-8">
        Volver
      </Link>
      <div className="bg-white shadow-lg rounded-2xl p-8 min-w-full mt-3">
        <div className="flex gap-x-10">
          <div className="flex-1">
            <h1 className="text-4xl">{fridge.name}</h1>
            <hr className="my-4" />
            <div>
              <address className="text-xl">{fridge.address}</address>
              <p className="mt-2">Capacidad maxima: {fridge.maxFoodCapacity}</p>
            </div>
            <br />
            <h1 className="text-2xl">Avisarme cuando ...</h1>
            <ul className="list-disc list-inside mt-3">
              <li className="mb-2">
                Queden{" "}
                <input
                  className="border rounded-sm max-w-10"
                  type="number"
                  name=""
                  id=""
                />{" "}
                viandas para que la heladera quede vacia
                <button className="ml-10 px-2 py-1 bg-blue-600 rounded-md text-white">
                  Avisame
                </button>
              </li>
              <li className="mb-2">
                Queden{" "}
                <input
                  className="border rounded-sm max-w-10"
                  type="number"
                  name=""
                  id=""
                />{" "}
                viandas para que la heladera se llene
                <button className="ml-10 px-2 py-1 bg-blue-600 rounded-md text-white">
                  Avisame
                </button>
              </li>
              <li>
                La heladera tenga algun desperfecto
                <button className="ml-10 px-2 py-1 bg-blue-600 rounded-md text-white">
                  Avisame
                </button>
              </li>
            </ul>
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
    </div>
  );
}
