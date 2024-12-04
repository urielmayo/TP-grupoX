/* eslint-disable react/prop-types */
import { Link } from "react-router-dom";

export default function TechniciansCard({ technician }) {
  return (
    <Link to={`${technician.id}`}>
      <div className="max-w-md overflow-hidden rounded-2xl shadow-lg hover:shadow-blue-300/50 p-4 bg-white group">
        <div className="font-bold text-xl mb-2">
          # {technician.workerIdentificationNumber}
        </div>
        <ul className="text-gray-700 text-base">
          <li>
            {technician.name} {technician.surname}
          </li>
          <li>{technician.neighbourhoodName}</li>
        </ul>
      </div>
    </Link>
  );
}
