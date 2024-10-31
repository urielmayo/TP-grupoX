import { useNavigate, useLoaderData } from "react-router-dom";
import { fetchContribution } from "../utils/auth";
import { moneyDonationMapper } from "../components/UI/ContributionCard";
import Modal from "../components/UI/Modal";

export default function ContributionDetailPage() {
  const contribution = useLoaderData();
  const navigate = useNavigate();
  let content;
  if (contribution.type == "MoneyDonation") {
    content = (
      <>
        <h1 className="text-xl">Contribucion de dinero</h1>
        <p>Monto: ${contribution.attributes.Amount}</p>
      </>
    );
  }
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="flex items-start justify-center">
        <div className="min-w-full max-w-4xl">{content}</div>
      </div>
    </Modal>
  );
}

export async function loader({ params }) {
  const contribution = await fetchContribution(params.id);
  console.log(contribution);

  return contribution;
}
