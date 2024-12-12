/* eslint-disable react/prop-types */
// LocationSuggestions.js
import { useState } from "react";
import Field from "../UI/form/Field";
import { config } from "../../config";

export default function LocationSuggestions({
  onSelectSuggestion,
  initialCoordinates,
}) {
  const [suggestions, setSuggestions] = useState([]);
  const [suggestionInput, setSuggestionInput] = useState({
    lat: initialCoordinates?.lat || "",
    lng: initialCoordinates?.lng || "",
    radiusInKm: "",
    numberOfPoints: "",
  });

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

  return (
    <div className="bg-slate-50 rounded-md p-4 mb-2">
      <div className="grid grid-cols-2 gap-x-4">
        <Field
          label="Latitud"
          name="lat"
          type="text"
          placeholder="Latitud inicial"
          value={suggestionInput.lat}
          onChange={handleSuggestionInputChange}
        />
        <Field
          label="Longitud"
          name="lng"
          type="text"
          placeholder="Longitud inicial"
          value={suggestionInput.lng}
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
                onClick={() =>
                  onSelectSuggestion({
                    latitude: suggestion.latitude,
                    longitude: suggestion.longitude,
                    fullAddress: suggestion.fullAddress,
                  })
                }
                className="col-span-2 btn btn-link hover:underline"
              >
                {suggestion.fullAddress}
              </button>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
