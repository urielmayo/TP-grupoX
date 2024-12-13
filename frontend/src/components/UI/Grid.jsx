/* eslint-disable react/prop-types */
export default function Grid({ columns, children }) {
  return (
    <div className={`grid lg:grid-cols-${columns} md:grid-cols-2 gap-3`}>
      {children}
    </div>
  );
}
