import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import "leaflet/dist/leaflet.css";

export default function Map() {
  const position = [-34.59887, -58.42015]; // Coordenadas para centrar el mapa

  return (
    <MapContainer
      center={position}
      zoom={12}
      style={{ height: "600px", width: "100%" }}
    >
      <TileLayer
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
      />
      <Marker position={position}>
        <Popup>
          Este es un marcardor de la UTN <br /> Easily customizable.
        </Popup>
      </Marker>
    </MapContainer>
  );
}
