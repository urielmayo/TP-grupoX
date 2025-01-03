/* eslint-disable react/prop-types */
import Grid from "../components/UI/Grid";
import { useState, useEffect } from "react";

export default function GridLayout({
  header,
  items,
  renderItem,
  emptyItem,
  filters,
}) {
  const [filteredItems, setFilteredItems] = useState(items);

  // Update filtered items when items or filters change
  useEffect(() => {
    if (!filters || filters.length === 0) {
      setFilteredItems(items);
      return;
    }

    const newFilteredItems = items.filter((item) =>
      filters.every((filter) => filter.predicate(item))
    );
    setFilteredItems(newFilteredItems);
  }, [items, filters]);

  return (
    <div className="p-8 min-w-full">
      <div className="flex gap-x-3">{header}</div>
      {filters && filters.length > 0 && (
        <div className="flex gap-4 my-4">
          {filters.map((filter, index) => (
            <div key={index} className="flex items-center gap-2">
              {filter.component}
            </div>
          ))}
        </div>
      )}
      <hr className="my-3" />
      {filteredItems.length ? (
        <Grid>{filteredItems.map((item) => renderItem(item))}</Grid>
      ) : (
        emptyItem
      )}
    </div>
  );
}
