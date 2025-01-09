/* eslint-disable react/prop-types */
export default function RadioGroup({ label, name, options, defaultValue }) {
  return (
    <div className="mb-4">
      <label className="block text-gray-700 mb-2">{label}</label>
      <div className="space-y-2">
        {options.map((option, index) => (
          <label key={option.value} className="flex items-center">
            <input
              type="radio"
              name={name}
              value={option.value}
              className="mr-2"
              defaultChecked={
                defaultValue ? defaultValue === option.value : index === 0
              }
            />
            <span>{option.label}</span>
          </label>
        ))}
      </div>
    </div>
  );
}
