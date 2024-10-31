/* eslint-disable react/prop-types */
import { Link } from "react-router-dom";

export function moneyDonationMapper(type) {
  return type === "MoneyDonation"
    ? "Donacion de dinero"
    : type === "Fridge"
    ? "Heladera"
    : "Otro";
}

export default function ContributionCard({ contribution }) {
  const event = new Date(contribution.date);

  return (
    <Link to={`/users/contributions/${contribution.id}`}>
      <div className="max-w-sm overflow-hidden rounded-2xl shadow-lg p-4 bg-white">
        <span className="mb-3 font-thin">#{contribution.id}</span>
        <div className="font-bold text-xl mb-2">
          Tipo: {moneyDonationMapper(contribution.type)}
        </div>
        <p className="text-gray-700 text-base mb-2">
          <strong>Fecha:</strong> {event.toLocaleString("es-AR")}
        </p>
      </div>
    </Link>
  );
}
