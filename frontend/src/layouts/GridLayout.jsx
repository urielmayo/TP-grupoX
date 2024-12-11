/* eslint-disable react/prop-types */
import Grid from "../components/UI/Grid";

export default function GridLayout({ header, items, renderItem, emptyItem }) {
  return (
    <div className="p-8 min-w-full">
      <div className="flex gap-x-3">{header}</div>
      <hr className="my-3" />
      {items.length ? (
        <Grid>{items.map((item) => renderItem(item))}</Grid>
      ) : (
        emptyItem
      )}
    </div>
  );
}
