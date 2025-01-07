import { useLoaderData, Link } from "react-router-dom";
import { MapContainer, TileLayer, Marker } from "react-leaflet";
import { getUserData } from "../../utils/auth";
import IncidentsTable from "./IncidentsTable";
import NotificationSubscriptions from "./NotificationSubscriptions";

// TODO: mostrar si la heladera esta activa o incativa
// Mostrar la fecha de inicio de actividad de la heladera
// Agregar boton y vista para crear falla de la heladera
// opcional: enviar mail a tecnico con mailto

export default function FridgeDetail() {
  const {
    name,
    address,
    maxFoodCapacity,
    foodCapacityAvailable,
    latitud,
    longitud,
    lastFridgeIncidents,
    active,
    setUpAt,
    currentTemperature,
    subscription,
  } = useLoaderData();

  const { role } = getUserData();

  const setUpDate = new Date(setUpAt);

  return (
    <div>
      <Link to={".."} className="text-blue-700 hover:underline ml-8">
        Volver
      </Link>
      <div className="bg-white shadow-lg rounded-2xl p-8 min-w-full mt-3">
        <div className="flex gap-x-10">
          <div className="flex-1">
            <div className="flex justify-between items-baseline">
              <h1 className="text-4xl">{name}</h1>

              {(!active && (
                <div className="mb-2">
                  <span className="px-2 py-1 bg-auto text-red-500 rounded-md text-xl">
                    Esta heladera se encuentra inactiva
                  </span>
                  {role === "Admin" && (
                    <Link
                      to="visit"
                      className="bg-gray-800 hover:bg-gray-700 px-2 py-1 text-white text-xl rounded-lg mr-2"
                    >
                      Programar visita
                    </Link>
                  )}
                </div>
              )) ||
                (role === "Collaborator" && (
                  <Link
                    to="incident"
                    className="bg-red-500 hover:bg-red-600 px-2 py-1 text-white text-xl rounded-lg"
                  >
                    Reportar incidente
                  </Link>
                ))}
            </div>
            <hr className="my-4" />

            <div>
              <address className="text-xl">{address}</address>
              <p className="mt-2">
                Puesta en funcionamiento:{" "}
                {setUpDate.toLocaleDateString("es-AR")}
              </p>
              <p className="mt-2">
                Espacios disponibles: {foodCapacityAvailable}/{maxFoodCapacity}
              </p>
              <p className="mt-2">
                Ultima temperatura registrada: {currentTemperature}° C
              </p>
            </div>
            <br />
            <h1 className="text-xl mb-2">Ultimos incidentes reportados</h1>
            {(lastFridgeIncidents.length && (
              <IncidentsTable incidents={lastFridgeIncidents} />
            )) || (
              <p className="font-thin text-sm">Sin incidentes reportados</p>
            )}
            <br />
            {active && role === "Collaborator" && (
              <NotificationSubscriptions subscription={subscription} />
            )}
          </div>

          <div className="flex-shrink-0">
            <MapContainer
              center={[latitud, longitud]}
              zoom={15}
              style={{ height: "100%", width: "500px" }}
            >
              <TileLayer
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
              />
              <Marker position={[latitud, longitud]}></Marker>
            </MapContainer>
          </div>
        </div>
      </div>
    </div>
  );
}
