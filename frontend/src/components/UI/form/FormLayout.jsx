export default function FormLayout({ children }) {
  return (
    <div className="flex items-center justify-center">
      <div className="w-3/4 bg-white p-8 rounded-2xl shadow-lg">{children}</div>
    </div>
  );
}
