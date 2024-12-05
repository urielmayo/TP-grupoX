/* eslint-disable react/prop-types */
function DescriptionGridItem({
  label,
  value,
  editable,
  inputName,
  inputType,
  selectOptions,
}) {
  let content;
  if (!editable) {
    content = <p>{value}</p>;
  } else {
    if (inputType !== "select") {
      content = (
        <input
          className="border rounded-md px-1"
          type={inputType}
          defaultValue={value}
        />
      );
    }
  }

  return (
    <div className="flex justify-between">
      <h1 className="font-bold">{label}:</h1>
      {content}
    </div>
  );
}

export default function DescriptionGrid({ children }) {
  return <div className="grid gap-y-3">{children}</div>;
}
DescriptionGrid.Item = DescriptionGridItem;
