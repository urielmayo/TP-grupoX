/* eslint-disable react/prop-types */
import { useParams } from "react-router-dom";
import { useState } from "react";
import { config } from "../../config";
import { authHeaders } from "../../utils/auth";

export default function NotificationSubscriptions({ subscription }) {
  const [availableValue, setAvailableValue] = useState(
    subscription?.availableFoodsQuantity > 0
      ? subscription.availableFoodsQuantity.toString()
      : ""
  );
  const [fullValue, setFullValue] = useState(
    subscription?.fullFoodsQuantity > 0
      ? subscription.fullFoodsQuantity.toString()
      : ""
  );
  const [communicationMedia, setCommunicationMedia] = useState(
    subscription?.communicationMedia || "Mail"
  );
  const params = useParams();
  console.log(subscription);

  const isValidAvailable = availableValue !== "" && Number(availableValue) >= 0;
  const isValidFull = fullValue !== "" && Number(fullValue) >= 0;

  async function handleSubscription(type) {
    const subscriptionData = {
      availableFoodsQuantity: subscription?.availableFoodsQuantity || 0,
      fullFoodsQuantity: subscription?.fullFoodsQuantity || 0,
      incident: false,
      communicationMedia: communicationMedia,
    };

    const isCancel =
      (type === "availableFoodsQuantity" &&
        Number(availableValue) > 0 &&
        subscription?.availableFoodsQuantity > 0) ||
      (type === "fullFoodsQuantity" &&
        Number(fullValue) > 0 &&
        subscription?.fullFoodsQuantity > 0);

    if (isCancel) {
      if (type === "availableFoodsQuantity") {
        subscriptionData.availableFoodsQuantity = 0;
      } else if (type === "fullFoodsQuantity") {
        subscriptionData.fullFoodsQuantity = 0;
      }
    } else {
      switch (type) {
        case "availableFoodsQuantity":
          subscriptionData.availableFoodsQuantity = Number(availableValue);
          break;
        case "fullFoodsQuantity":
          subscriptionData.fullFoodsQuantity = Number(fullValue);
          break;
        case "incident":
          subscriptionData.incident = true;
          break;
      }
    }

    console.log(subscriptionData);
    let url = `${config.BACKEND_URL}/Fridge/subscription`;
    if (subscription === null) {
      subscriptionData.fridgeId = Number(params.id);
    } else {
      url = `${url}/${subscription.id}`;
    }

    try {
      const response = await fetch(url, {
        method: subscription === null ? "POST" : "PATCH",
        body: JSON.stringify(subscriptionData),
        headers: authHeaders(),
      });
      if (!response.ok) {
        throw new Error("Error al procesar la suscripción");
      }
      // Re-fetch data using the loader to update the page
      window.location.reload();
      return response;
    } catch (error) {
      throw new Error("Error al procesar la suscripción");
    }
  }

  return (
    <div>
      <h2 className="text-xl mb-2">Suscripciones a notificaciones</h2>

      <div className="grid grid-cols-[1fr,auto] gap-4 mt-3">
        <div className="flex items-center">Medio de comunicación</div>
        <select
          id="communicationMedia"
          value={communicationMedia}
          onChange={(e) => setCommunicationMedia(e.target.value)}
          className="border rounded-md px-2 py-1"
        >
          <option value="Mail">Correo electrónico</option>
          <option value="WhatsApp">WhatsApp</option>
          <option value="Telegram">Telegram</option>
        </select>
        <div className="flex items-center">
          Queden{" "}
          <input
            className="border rounded-sm max-w-10 mx-2"
            type="number"
            name="availableFoodsQuantity"
            value={availableValue}
            onChange={(e) => setAvailableValue(e.target.value)}
            disabled={subscription?.availableFoodsQuantity > 0}
            min="0"
          />{" "}
          viandas para que la heladera quede vacia
        </div>
        <button
          className={`px-2 py-1 rounded-md text-white ${
            isValidAvailable ? "bg-blue-600" : "bg-gray-400 cursor-not-allowed"
          }`}
          onClick={() => handleSubscription("availableFoodsQuantity")}
          disabled={!isValidAvailable}
        >
          {Number(availableValue) > 0 &&
          subscription?.availableFoodsQuantity > 0
            ? "Cancelar suscripción"
            : "Avisame"}
        </button>

        <div className="flex items-center">
          Queden{" "}
          <input
            className="border rounded-sm max-w-10 mx-2"
            type="number"
            name="fullFoodsQuantity"
            value={fullValue}
            onChange={(e) => setFullValue(e.target.value)}
            min="0"
            disabled={subscription?.fullFoodsQuantity > 0}
          />{" "}
          viandas para que la heladera se llene
        </div>
        <button
          className={`px-2 py-1 rounded-md text-white ${
            isValidFull ? "bg-blue-600" : "bg-gray-400 cursor-not-allowed"
          }`}
          onClick={() => handleSubscription("fullFoodsQuantity")}
          disabled={!isValidFull}
        >
          {Number(fullValue) > 0 && subscription?.fullFoodsQuantity > 0
            ? "Cancelar suscripción"
            : "Avisame"}
        </button>

        <div className="flex items-center">Se reporte un incidente</div>
        <button
          className="px-2 py-1 bg-blue-600 rounded-md text-white"
          onClick={() => handleSubscription("incident")}
        >
          Avisame
        </button>
      </div>
    </div>
  );
}
