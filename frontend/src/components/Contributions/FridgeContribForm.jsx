import { useState } from "react";
import { Form } from "react-router-dom";
import { config } from "../../config";
import Field from "../UI/form/Field";
import SubmitButton from "../UI/form/SubmitButton";
import LocationSuggestions from "./LocationSuggestions";

export default function FridgeContribForm() {
  const [address, setAddress] = useState("");
  const [coordinates, setCoordinates] = useState({ lat: "", lng: "" });
  const [showSuggestionFields, setShowSuggestionFields] = useState(false);

  const handleChange = (e) => {
    setAddress(e.target.value);
  };

  const handleBlur = async () => {
    if (address) {
      const geocodeUrl = `https://api.opencagedata.com/geocode/v1/json?q=${encodeURIComponent(
        address
      )}&key=${config.OPEN_CAGE_API_KEY}`;
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

  const handleSuggestionSelect = (suggestion) => {
    setAddress(suggestion.fullAddress);
    setCoordinates({
      lat: suggestion.latitude.toString(),
      lng: suggestion.longitude.toString(),
    });
    setShowSuggestionFields(false);
  };

  return (
    <Form method="post">
      <input type="hidden" name="type" value="fridge" />
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
            name={"longitud"}
            type={"text"}
            value={coordinates.lng}
            readOnly
          />
        </div>
        <div>
          <Field
            label={"Latitud"}
            name={"latitud"}
            type={"text"}
            value={coordinates.lat}
            readOnly
          />
        </div>
      </div>

      <button
        type="button"
        onClick={() => setShowSuggestionFields(!showSuggestionFields)}
        className="text-blue-600 hover:underline my-2"
      >
        {showSuggestionFields ? "Ocultar sugerencias" : "Obtener sugerencias"}
      </button>

      {showSuggestionFields && (
        <LocationSuggestions
          onSelectSuggestion={handleSuggestionSelect}
          initialCoordinates={coordinates}
        />
      )}

      <Field
        label={"Cantidad maxima de viandas"}
        name={"maxFoodCapacity"}
        type={"number"}
        required
      />

      <SubmitButton text={"Cargar heladera"} />
    </Form>
  );
}
