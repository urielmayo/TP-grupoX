/* eslint-disable react/prop-types */
import { Link } from "react-router-dom";
import Card from "../UI/Card";

export default function TechniciansCard({ technician }) {
  return (
    <Link to={`${technician.id}`}>
      <Card>
        <div className="font-bold text-xl mb-2">
          # {technician.workerIdentificationNumber}
        </div>
        <ul className="text-gray-700 text-base">
          <li>
            {technician.name} {technician.surname}
          </li>
          <li>{technician.neighbourhoodName}</li>
        </ul>
      </Card>
    </Link>
  );
}
