import { useRouteLoaderData } from "react-router-dom";

export default function ContributionType({ onSelect }) {
  const user = useRouteLoaderData("root");
  const buttonCssClass =
    "px-4 py-2 text-sm font-medium text-gray-900 bg-white border rounded-lg border-gray-200 hover:text-blue-400";

  return (
    <div className="flex justify-center gap-x-5 ">
      <button
        type="button"
        name="money"
        className={buttonCssClass}
        onClick={(e) => onSelect(e.target.name)}
        onFocus={"hola"}
      >
        Donar dinero
      </button>
      {user.personType === "humana" && (
        <>
          <button
            type="button"
            name="food"
            className={buttonCssClass}
            onClick={(e) => onSelect(e.target.name)}
          >
            Donar vianda
          </button>
          <button
            type="button"
            name="distribution"
            className={buttonCssClass}
            onClick={(e) => onSelect(e.target.name)}
          >
            Distribuir viandas
          </button>
          <button
            type="button"
            name="person"
            className={buttonCssClass}
            onClick={(e) => onSelect(e.target.name)}
          >
            Registrar persona vulnerable
          </button>
        </>
      )}
      {user.personType === "juridica" && (
        <>
          <button
            type="button"
            name="fridge"
            className={buttonCssClass}
            onClick={(e) => onSelect(e.target.name)}
          >
            Hacerse cargo de una heladera
          </button>
          <button
            type="button"
            name="product"
            className={buttonCssClass}
            onClick={(e) => onSelect(e.target.name)}
          >
            Publicar producto beneficio
          </button>
        </>
      )}
    </div>
  );
}
