/* eslint-disable react/prop-types */

export default function Card({ children }) {
  return (
    <div className=" overflow-hidden rounded-2xl shadow-sm hover:shadow-lg hover:shadow-gray-500/50 p-4 bg-white group">
      {children}
    </div>
  );
}
