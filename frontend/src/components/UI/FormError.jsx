/* eslint-disable react/prop-types */
export default function FormError({ children }) {
  return (
    <div
      className="p-4 mb-4 text-sm text-red-800 rounded-lg bg-red-100 my-4"
      role="alert"
    >
      {children}
    </div>
  );
}
