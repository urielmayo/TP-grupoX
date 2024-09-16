import { useLoaderData } from "react-router-dom";

import Map from "../components/Map";
import { DUMMY_LOCATIONS } from "../dummy_data";

export default function HomePage() {
  const fridges = useLoaderData();

  return (
    <div className="flex items-start justify-center">
      <div className="bg-white shadow-lg rounded-2xl p-8 min-w-full text-center">
        <h1 className="text-4xl font-bold text-gray-800 mb-4">
          Si<small className="text-gray-600">stema para la </small>M
          <small className="text-gray-600">ejora del</small> A
          <small className="text-gray-600">cceso</small> A
          <small className="text-gray-600">
            limentario en Contextos de Vulnerabilidad Socioeconómica
          </small>
        </h1>
        <p className="text-gray-600">
          SiMAA es una plataforma innovadora diseñada para optimizar la gestión
          de información y análisis de datos en tiempo real. Con un enfoque en
          la eficiencia y la facilidad de uso, SIMAA proporciona herramientas
          poderosas para la toma de decisiones estratégicas en diversas
          industrias.
        </p>

        <br />
        <Map fridges={fridges} />
      </div>
    </div>
  );
}

export function loader() {
  return DUMMY_LOCATIONS;
}
