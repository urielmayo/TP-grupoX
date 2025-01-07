/* eslint-disable react/prop-types */
// LocationSuggestions.js
import { useState } from "react";
import Field from "../UI/form/Field";
import { config } from "../../config";

export default function LocationSuggestions({ onSelectSuggestion }) {
  const [suggestions, setSuggestions] = useState([]);
  const [suggestionInput, setSuggestionInput] = useState({
    address: "",
    radiusInKm: "",
    numberOfPoints: "",
  });
  const [coordinates, setCoordinates] = useState(null);

  const handleSuggestionInputChange = (e) => {
    const { name, value } = e.target;
    setSuggestionInput({ ...suggestionInput, [name]: value });
  };

  const handleAddressBlur = async () => {
    if (suggestionInput.address) {
      try {
        const geocodeUrl = `https://api.opencagedata.com/geocode/v1/json?q=${encodeURIComponent(
          suggestionInput.address
        )}&key=${config.OPEN_CAGE_API_KEY}`;

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
          setCoordinates(null);
        }
      } catch (error) {
        console.error("Error fetching geocode:", error);
        setCoordinates(null);
      }
    }
  };

  const fetchSuggestions = async () => {
    const { radiusInKm, numberOfPoints } = suggestionInput;

    if (!coordinates || !radiusInKm || !numberOfPoints) {
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
            latitude: parseFloat(coordinates.lat),
            longitude: parseFloat(coordinates.lng),
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
            const encodedLat = encodeURIComponent(location.latitude);
            const encodedLng = encodeURIComponent(location.longitude);
            const geocodeResponse = await fetch(
              `https://api.opencagedata.com/geocode/v1/json?q=${encodedLat}+${encodedLng}&key=${config.OPEN_CAGE_API_KEY}`
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
      <div className="grid grid-cols-1 gap-4">
        <Field
          label="Dirección"
          name="address"
          type="text"
          placeholder="Ingrese una dirección"
          value={suggestionInput.address}
          onChange={handleSuggestionInputChange}
          onBlur={handleAddressBlur}
        />
        {coordinates && (
          <div className="text-sm text-gray-600">
            Coordenadas: {coordinates.lat}, {coordinates.lng}
          </div>
        )}
        <div className="grid grid-cols-2 gap-x-4">
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
      </div>
      <button
        type="button"
        onClick={fetchSuggestions}
        className="bg-slate-200 hover:bg-slate-300 py-1 px-2 rounded-md mt-4"
      >
        Buscar
      </button>
      {suggestions.length > 0 && (
        <ul className="list-disc list-inside mt-4">
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
