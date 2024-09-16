/* eslint-disable react/prop-types */
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import "leaflet/dist/leaflet.css";

export default function Map({ fridges }) {
  return (
    <div>
      <MapContainer
        center={fridges[0].coordinates}
        zoom={12}
        style={{ height: "750px", width: "100%" }}
        scrollWheelZoom={true}
      >
        <TileLayer
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        />
        {fridges.map((fridge) => (
          <Marker key={fridge.id} position={fridge.coordinates}>
            <Popup>{fridge.name}</Popup>
          </Marker>
        ))}
      </MapContainer>
    </div>
  );
}
