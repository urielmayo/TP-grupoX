import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import "leaflet/dist/leaflet.css";

export default function Map() {
  const utnMedrano = [-34.59887, -58.42015]; // Coordenadas para centrar el mapa
  const utnCampus = [-34.659702935892284, -58.468196728323214]; // Coordenadas para centrar el mapa
  const parqueCentenario = [-34.606381963412225, -58.437045036197816]; // Coordenadas para centrar el mapa
  const plazaAristobuloDelValle = [-34.6054742328525, -58.492937591704134]; // Coordenadas para centrar el mapa

  return (
    <div>
      <MapContainer
        center={utnMedrano}
        zoom={12}
        style={{ height: "750px", width: "100%" }}
        scrollWheelZoom={true}
      >
        <TileLayer
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        />
        <Marker position={utnMedrano}>
          <Popup>
            UTN <br /> sede Medrano
          </Popup>
        </Marker>
        <Marker position={utnCampus}>
          <Popup>
            UTN <br /> sede Lugano
          </Popup>
        </Marker>
        <Marker position={parqueCentenario}>
          <Popup>Parque centenario</Popup>
        </Marker>
        <Marker position={plazaAristobuloDelValle}>
          <Popup>Plaza Aristobulo del Valle</Popup>
        </Marker>
      </MapContainer>
    </div>
  );
}
