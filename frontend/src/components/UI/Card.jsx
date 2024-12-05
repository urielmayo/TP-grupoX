/* eslint-disable react/prop-types */

export default function Card({ children }) {
  return (
    <div className=" overflow-hidden rounded-2xl shadow-lg hover:shadow-blue-300/50 p-4 bg-white group">
      {children}
    </div>
  );
}
