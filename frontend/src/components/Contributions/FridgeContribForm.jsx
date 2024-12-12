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
            Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
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
      const locations = data.data.locations;

      const detailedLocations = await Promise.all(
        locations.map(async (location) => {
          try {
            const geocodeResponse = await fetch(
              `https://api.opencagedata.com/geocode/v1/json?q=${location.latitude},${location.longitude}&key=${config.OPEN_CAGE_API_KEY}`
            );
            const geocodeData = await geocodeResponse.json();

            return {
              ...location,
              fullAddress:
                geocodeData.results[0]?.formatted || "Address not found",
            };
          } catch (geocodeError) {
            console.error(`Error fetching geocode for location:`, geocodeError);
            return location;
          }
        })
      );

      setSuggestions(detailedLocations);
    } catch (error) {
      console.error("Error fetching suggestions:", error);
    }
  };

  const selectSuggestion = (suggestion) => {
    setAddress(suggestion.fullAddress);
    setCoordinates({
      lat: suggestion.latitude,
      lng: suggestion.longitude,
    });
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

      <button
        type="button"
        onClick={() => setShowSuggestionFields(!showSuggestionFields)}
        className="text-blue-600 hover:underline my-2"
      >
        {showSuggestionFields ? "Ocultar sugerencias" : "Obtener sugerencias"}
      </button>

      {showSuggestionFields && (
        <div className=" bg-slate-50 rounded-md p-4 mb-2">
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
          </div>
          <button
            type="button"
            onClick={fetchSuggestions}
            className="bg-slate-200 hover:bg-slate-300 py-1 px-2 rounded-md"
          >
            Buscar
          </button>
          {suggestions.length > 0 && (
            <ul className="list-disc list-inside">
              {suggestions.map((suggestion, index) => (
                <li key={index}>
                  <button
                    type="button"
                    onClick={() => selectSuggestion(suggestion)}
                    className="col-span-2 btn btn-link hover:underline"
                  >
                    {suggestion.fullAddress}
                  </button>
                </li>
              ))}
            </ul>
          )}
        </div>
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
