/* eslint-disable react/prop-types */
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import "leaflet/dist/leaflet.css";

export default function Map({ fridges }) {
  const UTN_COORDS = [-34.59887, -58.42015];
  return (
    <div>
      <MapContainer
        center={UTN_COORDS}
        zoom={12}
        style={{ height: "750px", width: "100%" }}
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
                {fridge.name} <br />
                Cantidad de viandas: {fridge.maxFoodCapacity}
              </p>
            </Popup>
          </Marker>
        ))}
      </MapContainer>
    </div>
  );
}
