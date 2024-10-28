import { useState } from "react";
import { fetchUser } from "../utils/auth";
import { redirect, Link } from "react-router-dom";
import FormTitle from "../components/UI/FormTitle";
import MoneyContribForm from "../components/Contributions/MoneyContribForm";
import ContributionType from "../components/Contributions/ContributionType";
import FoodContribForm from "../components/Contributions/FoodContribForm";
import DistributionContribForm from "../components/Contributions/DistributionContribForm";
import PersonContribForm from "../components/Contributions/PersonContribForm";
import FridgeContribForm from "../components/Contributions/FridgeContribForm";
import ProductContribForm from "../components/Contributions/ProductContribForm";

export default function NewContributionPage() {
  const [contributionType, setContributionType] = useState("money");

  return (
    <div className="flex items-start justify-center">
      <div className="w-full max-w-4xl bg-white p-8 rounded-lg shadow-lg">
        <Link to={".."} className="text-blue-500 hover:underline">
          Volver
        </Link>
        <FormTitle text={"Realizar una contribucion"} />
        <br />
        <ContributionType onSelect={setContributionType} />
        <br />
        {contributionType === "money" && <MoneyContribForm />}
        {contributionType === "food" && <FoodContribForm />}
        {contributionType === "distribution" && <DistributionContribForm />}
        {contributionType === "person" && <PersonContribForm />}
        {contributionType === "fridge" && <FridgeContribForm />}
        {contributionType === "product" && <ProductContribForm />}
      </div>
    </div>
  );
}

export const action = async ({ request }) => {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());

  const type = data.type;
  delete data.type;

  await fetch(`https://localhost:7017/Contribution/${type}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("jwt")}`,
    },
    body: JSON.stringify(data),
  });

  return redirect("..");
};

export const loader = async () => {
  const data = await fetchUser();
  return data;
};
