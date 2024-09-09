export default function PageContent({ title, children }) {
  return (
    <div className="text-center">
      <h1 className="text-2xl">{title}</h1>
      {children}
    </div>
  );
}
