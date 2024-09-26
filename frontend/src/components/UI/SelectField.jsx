export default function SelectField({ label, name, children, ...props }) {
  return (
    <div className="mb-4">
      <label className="block text-gray-700">{label}</label>
      <select
        name={name}
        className="w-full px-4 py-2 mt-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
        required
        {...props}
      >
        {children}
      </select>
    </div>
  );
}
