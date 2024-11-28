/* eslint-disable react-refresh/only-export-components */
import { useState } from "react";
import { redirect, useNavigate, useActionData } from "react-router-dom";
import FormTitle from "../components/UI/FormTitle";
import MoneyContribForm from "../components/Contributions/MoneyContribForm";
import ContributionType from "../components/Contributions/ContributionType";
import FoodContribForm from "../components/Contributions/FoodContribForm";
import DistributionContribForm from "../components/Contributions/DistributionContribForm";
import PersonContribForm from "../components/Contributions/PersonContribForm";
import FridgeContribForm from "../components/Contributions/FridgeContribForm";
import ProductContribForm from "../components/Contributions/ProductContribForm";
import Modal from "../components/UI/Modal";
import FormError from "../components/UI/FormError";
import { config } from "../config";

export default function NewContributionPage() {
  const [contributionType, setContributionType] = useState("money");
  const navigate = useNavigate();
  const errors = useActionData();

  return (
    <Modal onClose={() => navigate("../")}>
      <FormTitle text={"Realizar una contribucion"} />
      <br />
      <ContributionType onSelect={setContributionType} />

      {(errors && (
        <FormError>
          <ul>
            {Object.keys(errors).map((key) =>
              errors[key].map((item) => <li key={item}>{item}</li>)
            )}
          </ul>
        </FormError>
      )) || <br />}

      {contributionType === "money" && <MoneyContribForm errors={errors} />}
      {contributionType === "food" && <FoodContribForm />}
      {contributionType === "distribution" && <DistributionContribForm />}
      {contributionType === "person" && <PersonContribForm />}
      {contributionType === "fridge" && <FridgeContribForm />}
      {contributionType === "product" && <ProductContribForm />}
    </Modal>
  );
}

export const newContribAction = async ({ request }) => {
  const form = await request.formData();
  const data = Object.fromEntries(form.entries());
  console.log(data);

  const type = data.type;
  delete data.type;

  const response = await fetch(`${config.BACKEND_URL}/Contribution/${type}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${sessionStorage.getItem("jwt")}`,
    },
    body: JSON.stringify(data),
  });
  if (!response.ok) {
    const errors = await response.json();
    return errors.errors;
  }
  return redirect("..");
};
