/* eslint-disable react-refresh/only-export-components */
import { useState } from "react";
import { useNavigate, useActionData } from "react-router-dom";
import FormTitle from "../UI/form/FormTitle";
import MoneyContribForm from "../Contributions/MoneyContribForm";
import ContributionType from "../Contributions/ContributionType";
import FoodContribForm from "../Contributions/FoodContribForm";
import DistributionContribForm from "../Contributions/DistributionContribForm";
import PersonContribForm from "../Contributions/PersonContribForm";
import FridgeContribForm from "../Contributions/FridgeContribForm";
import ProductContribForm from "../Contributions/ProductContribForm";
import Modal from "../UI/Modal";
import FormError from "../UI/form/FormError";

export default function NewContribution() {
  const [contributionType, setContributionType] = useState("money");
  const navigate = useNavigate();
  const errors = useActionData();
  return (
    <Modal onClose={() => navigate("../")}>
      <FormTitle text={"Realizar una contribucion"} />
      <br />
      <ContributionType
        onSelect={setContributionType}
        contributionType={contributionType}
      />

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
