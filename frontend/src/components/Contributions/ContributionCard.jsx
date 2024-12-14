/* eslint-disable react-refresh/only-export-components */
/* eslint-disable react/prop-types */
import { Link } from "react-router-dom";
import Card from "../UI/Card";

const moneyDonationMapper = (type) => {
  return type === "MoneyDonation"
    ? "Dinero"
    : type === "FridgeOwner"
    ? "Heladera"
    : type === "FoodDonation"
    ? "Comida"
    : type === "FoodDelivery"
    ? "Distribucion de viandas"
    : type === "VulnerablePersonCard"
    ? "Registro de persona vulnerable"
    : type === "Benefit"
    ? "Beneficio"
    : "Otro";
};

export default function ContributionCard({ contribution }) {
  const event = new Date(contribution.date);

  return (
    <Link to={`/contributions/${contribution.id}`}>
      <Card>
        <span className="mb-3 font-thin">#{contribution.id}</span>
        <div className="font-bold text-xl mb-2">
          {moneyDonationMapper(contribution.type)}
        </div>
        <p className="text-gray-700 text-base mb-2">
          <strong>Fecha:</strong> {event.toLocaleString("es-AR")}
        </p>
      </Card>
    </Link>
  );
}
