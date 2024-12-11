import { useState } from "react";
import Field from "../UI/form/Field";
import SubmitButton from "../UI/form/SubmitButton";
import { Form } from "react-router-dom";
import { config } from "../../config";

export default function FridgeContribForm() {
  const [address, setAddress] = useState("");
  const [coordinates, setCoordinates] = useState({ lat: "", lng: "" });
  const [suggestions, setSuggestions] = useState([]);
  const [showSuggestionFields, setShowSuggestionFields] = useState(false);
  const [suggestionInput, setSuggestionInput] = useState({
    lat: "",
    lng: "",
    radiusInKm: "",
    numberOfPoints: "",
  });

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

  const handleSuggestionInputChange = (e) => {
    const { name, value } = e.target;
    setSuggestionInput({ ...suggestionInput, [name]: value });
  };

  const fetchSuggestions = async () => {
    const { lat, lng, radiusInKm, numberOfPoints } = suggestionInput;

    if (!lat || !lng || !radiusInKm || !numberOfPoints) {
      alert("Por favor completa todos los campos de sugerencias.");
      return;
    }

    try {
      const response = await fetch(
        `${config.BACKEND_URL}/Fridge/suggested-locations`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            latitude: parseFloat(lat),
            longitude: parseFloat(lng),
            radiusInKm: parseFloat(radiusInKm),
            numberOfPoints: parseInt(numberOfPoints, 10),
          }),
        }
      );

      const data = await response.json();
      setSuggestions(data); // Asumimos que el backend retorna un array de direcciones
    } catch (error) {
      console.error("Error fetching suggestions:", error);
    }
  };

  const selectSuggestion = (suggestion) => {
    setAddress(suggestion);
    setSuggestions([]); // Limpiamos las sugerencias después de seleccionar una
    setShowSuggestionFields(false); // Ocultamos los campos de sugerencias
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

      <Field
        label={"Cantidad de viandas"}
        name={"maxFoodCapacity"}
        type={"number"}
        required
      />

      <button
        type="button"
        onClick={() => setShowSuggestionFields(!showSuggestionFields)}
        className="btn btn-secondary my-2"
      >
        {showSuggestionFields ? "Ocultar sugerencias" : "Obtener sugerencias"}
      </button>

      {showSuggestionFields && (
        <div className="grid grid-cols-2 gap-x-4">
          <Field
            label="Latitud"
            name="lat"
            type="text"
            placeholder="Latitud inicial"
            onChange={handleSuggestionInputChange}
          />
          <Field
            label="Longitud"
            name="lng"
            type="text"
            placeholder="Longitud inicial"
            onChange={handleSuggestionInputChange}
          />
          <Field
            label="Radio (km)"
            name="radiusInKm"
            type="number"
            placeholder="Radio en kilómetros"
            onChange={handleSuggestionInputChange}
          />
          <Field
            label="Número de puntos"
            name="numberOfPoints"
            type="number"
            placeholder="Cantidad de puntos"
            onChange={handleSuggestionInputChange}
          />
          <button
            type="button"
            onClick={fetchSuggestions}
            className="btn btn-primary my-2"
          >
            Buscar sugerencias
          </button>
        </div>
      )}

      {suggestions.length > 0 && (
        <ul className="suggestion-list">
          {suggestions.map((suggestion, index) => (
            <li key={index}>
              <button
                type="button"
                onClick={() => selectSuggestion(suggestion)}
                className="col-span-2 btn btn-link"
              >
                {suggestion}
              </button>
            </li>
          ))}
        </ul>
      )}

      <SubmitButton text={"Cargar heladera"} />
    </Form>
  );
}
