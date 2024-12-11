import { Link } from "react-router-dom";
import Card from "../UI/Card";

export default function FridgeCard({ fridge }) {
  return (
    <Link to={`${fridge.id}`}>
      <Card>
        {/* <div className="font-bold text-xl mb-2">
          # {technician.workerIdentificationNumber}
        </div>
        <ul className="text-gray-700 text-base">
          <li>
            {technician.name} {technician.surname}
          </li>
          <li>{technician.neighbourhoodName}</li>
        </ul> */}
      </Card>
    </Link>
  );
}
