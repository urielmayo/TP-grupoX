export default function ContributionCard({ contribution }) {
  return (
    <div className="max-w-sm overflow-hidden rounded-2xl shadow-lg p-4 bg-white">
      <div className="font-bold text-xl mb-2">$ {contribution.monto}</div>
      <p className="text-gray-700 text-base mb-2">
        <strong>Fecha:</strong> {contribution.fecha}
      </p>
    </div>
  );
}
