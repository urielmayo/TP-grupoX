/* eslint-disable react/prop-types */
export default function Product({ product }) {
  return (
    <div className="max-w-sm overflow-hidden rounded-2xl shadow-lg bg-white">
      <img className="object-scale-down" src={product.Imagen} alt="" />
      <hr />
      <div className="px-6 py-4">
        <div className="font-bold text-xl mb-2">{product.Descripcion}</div>
        <p className="text-gray-700 text-base mb-2">
          <strong>Rubro:</strong> {product.Rubro}
        </p>
        <p className="text-gray-700 text-base mb-2">
          <strong>Puntos necesarios:</strong> {product.Puntos}
        </p>
        <p className="text-gray-700 text-base mb-2">
          <strong>Empresa:</strong> {product.Empresa}
        </p>
        <br />
        <span className="inline-block bg-blue-200 rounded-full px-3 py-1 text-sm font-semibold text-blue-600 mr-2 mb-2">
          {product.Rubro}
        </span>
        <br />
        <button className="inline-block bg-blue-600 rounded-full px-3 py-1 text-sm font-semibold text-white mr-2 mb-2">
          Canjear
        </button>
      </div>
    </div>
  );
}
