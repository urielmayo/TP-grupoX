/* eslint-disable react/prop-types */
import { Link } from "react-router-dom";

export default function EmptyGrid({ title, text }) {
  return (
    <div className="bg-gray-200 rounded-2xl p-8 shadow-md min-h-72">
      <h1 className="font-bold text-2xl mb-2">{title}</h1>
      {text && (
        <p>
          {text}{" "}
          <Link className="text-blue-600 hover:underline" to="new">
            aqui
          </Link>{" "}
        </p>
      )}
    </div>
  );
}
