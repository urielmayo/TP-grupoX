/* eslint-disable react/prop-types */
import { Link } from "react-router-dom";

export default function TechniciansCard({ technician }) {
  return (
    <Link to={technician.id}>
      <div className="max-w-md overflow-hidden rounded-2xl shadow-lg p-4 bg-white">
        <div className="font-bold text-xl mb-2">{technician.name}</div>
        <p className="text-gray-700 text-base mb-2">
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Et, repellat.
          Porro placeat aliquid sunt inventore atque, magnam voluptatem optio
          temporibus totam eum laudantium ea. Odit quibusdam omnis asperiores
          laborum accusamus!
        </p>
      </div>
    </Link>
  );
}
