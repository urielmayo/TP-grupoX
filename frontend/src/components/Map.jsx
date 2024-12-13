/* eslint-disable react/prop-types */
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import { Link } from "react-router-dom";

export default function Map({ fridges }) {
  const UTN_COORDS = [-34.59887, -58.42015];
  return (
    <MapContainer
      className="z-0"
      center={UTN_COORDS}
      zoom={12}
      style={{ height: "750px", width: "100%", zIndex: 0 }}
      scrollWheelZoom={true}
    >
      <TileLayer
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
      />
      {fridges.map((fridge) => (
        <Marker key={fridge.id} position={[fridge.latitud, fridge.longitud]}>
          <Popup>
            <p>
              <Link to={`/fridges/${fridge.id}`} className="hover:underline">
                {fridge.name}
              </Link>{" "}
              <br />
              Cantidad de viandas: {fridge.maxFoodCapacity}
            </p>
          </Popup>
        </Marker>
      ))}
    </MapContainer>
  );
}
