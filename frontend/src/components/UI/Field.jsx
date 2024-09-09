export default function Field({ label, name, type, placeholder, ...props }) {
  return (
    <div className="mb-4">
      <label className="block text-gray-700">{label}</label>
      <input
        name={name}
        type={type}
        placeholder={placeholder}
        className="w-full px-4 py-2 mt-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
        {...props}
      />
    </div>
  );
}
