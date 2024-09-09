import { useState } from "react";
import Field from "../UI/Field";
import SubmitButton from "../UI/SubmitButton";

export default function FridgeContribForm() {
  const [address, setAddress] = useState("");
  const [coordinates, setCoordinates] = useState({ lat: "", lng: "" });

  const handleChange = (e) => {
    setAddress(e.target.value);
  };

  const handleBlur = async () => {
    if (address) {
      const apiKey = "78b82ae6321045fb9cfc69c020a755b7";
      const geocodeUrl = `https://api.opencagedata.com/geocode/v1/json?q=${encodeURIComponent(
        address
      )}&key=${apiKey}`;
      setCoordinates({
        lat: "Obteniendo longitud...",
        lng: "Obteniendo latitud...",
      });
      try {
        const response = await fetch(geocodeUrl);
        const data = await response.json();

        if (data.results.length > 0) {
          const location = data.results[0].geometry;
          setCoordinates({
            lat: location.lat,
            lng: location.lng,
          });
        } else {
          console.error("Geocode error: No results found");
          setCoordinates({ lat: "", lng: "" });
        }
      } catch (error) {
        console.error("Error fetching geocode:", error);
      }
    } else {
      setCoordinates({ lat: "", lng: "" });
    }
  };
  return (
    <div>
      <Field
        label={"Nombre"}
        name={"name"}
        type={"text"}
        placeholder={"Ingresar nombre representativo"}
        required
      />
      <Field
        label={"direccion"}
        name={"address"}
        type={"text"}
        placeholder={"Ingresar direccion"}
        onChange={handleChange}
        onBlur={handleBlur}
        value={address}
        required
      />

      <div className="grid grid-cols-2 gap-x-4">
        <div>
          <Field
            label={"Longitud"}
            name={"longitude"}
            type={"text"}
            value={coordinates.lng}
            disabled
          />
        </div>
        <div>
          <Field
            label={"Latitud"}
            name={"latitude"}
            type={"text"}
            value={coordinates.lat}
            disabled
          />
        </div>
      </div>

      <Field
        label={"Cantidad de viandas"}
        name={"max-lauches-count"}
        type={"number"}
        required
      />
      <SubmitButton text={"Cargar heladera"} />
    </div>
  );
}
