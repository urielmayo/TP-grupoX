export default function Grid({ children }) {
  return (
    <div className="grid lg:grid-cols-4 md:grid-cols-2 gap-3">{children}</div>
  );
}
