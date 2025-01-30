import { useRouteLoaderData } from "react-router-dom";

export default function ContributionType({ contributionType, onSelect }) {
  const user = useRouteLoaderData("contributions");

  const buttonCssClass =
    "px-4 py-2 text-sm font-medium text-gray-900 bg-white border rounded-lg border-gray-200 hover:text-blue-600";

  const activeButtonCssClass =
    "px-4 py-2 text-sm font-medium bg-white border rounded-lg border-gray-200 text-blue-600";

  return (
    <div className="flex justify-center gap-x-5 ">
      <button
        type="button"
        name="money"
        className={
          contributionType === "money" ? activeButtonCssClass : buttonCssClass
        }
        onClick={(e) => onSelect(e.target.name)}
      >
        Donar dinero
      </button>
      {user.type === "HumanPerson" && (
        <>
          <button
            type="button"
            name="food"
            className={
              contributionType === "food"
                ? activeButtonCssClass
                : buttonCssClass
            }
            onClick={(e) => onSelect(e.target.name)}
          >
            Donar vianda
          </button>
          <button
            type="button"
            name="distribution"
            className={
              contributionType === "distribution"
                ? activeButtonCssClass
                : buttonCssClass
            }
            onClick={(e) => onSelect(e.target.name)}
          >
            Distribuir viandas
          </button>
          <button
            type="button"
            name="person"
            className={
              contributionType === "person"
                ? activeButtonCssClass
                : buttonCssClass
            }
            onClick={(e) => onSelect(e.target.name)}
          >
            Registrar persona vulnerable
          </button>
        </>
      )}
      {user.type === "LegalPerson" && (
        <>
          <button
            type="button"
            name="fridge"
            className={
              contributionType === "fridge"
                ? activeButtonCssClass
                : buttonCssClass
            }
            onClick={(e) => onSelect(e.target.name)}
          >
            Hacerse cargo de una heladera
          </button>
          <button
            type="button"
            name="product"
            className={
              contributionType === "product"
                ? activeButtonCssClass
                : buttonCssClass
            }
            onClick={(e) => onSelect(e.target.name)}
          >
            Publicar producto beneficio
          </button>
        </>
      )}
    </div>
  );
}
