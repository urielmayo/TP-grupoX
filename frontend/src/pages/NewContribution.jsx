import { useState } from "react";
import { redirect, useNavigate } from "react-router-dom";
import FormTitle from "../components/UI/FormTitle";
import MoneyContribForm from "../components/Contributions/MoneyContribForm";
import ContributionType from "../components/Contributions/ContributionType";
import FoodContribForm from "../components/Contributions/FoodContribForm";
import DistributionContribForm from "../components/Contributions/DistributionContribForm";
import PersonContribForm from "../components/Contributions/PersonContribForm";
import FridgeContribForm from "../components/Contributions/FridgeContribForm";
import ProductContribForm from "../components/Contributions/ProductContribForm";
import Modal from "../components/UI/Modal";

export default function NewContributionPage() {
  const [contributionType, setContributionType] = useState("money");
  const navigate = useNavigate();

  return (
    <Modal onClose={() => navigate("../")}>
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
    </Modal>
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
      Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
    },
    body: JSON.stringify(data),
  });

  return redirect("..");
};
