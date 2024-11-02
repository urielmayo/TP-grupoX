import { useNavigate, useLoaderData } from "react-router-dom";
import { fetchContribution } from "../utils/auth";
import Modal from "../components/UI/Modal";

export default function ContributionDetailPage() {
  const contribution = useLoaderData();
  console.log(contribution);

  const navigate = useNavigate();
  let content;
  if (contribution.type == "MoneyDonation") {
    content = (
      <>
        <h1 className="text-xl">Contribucion de dinero</h1>
        <hr className="my-3" />
        <div className="grid gap-y-3">
          <div className="flex gap-x-3">
            <h1 className="font-bold">Monto:</h1>
            <p>{contribution.attributes.Amount}</p>
          </div>
          <div className="flex gap-x-3">
            <h1 className="font-bold">Frecuencia:</h1>
            <p>{contribution.attributes.Frequency}</p>
          </div>
        </div>
      </>
    );
  }
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="w-96 h-48">{content}</div>
    </Modal>
  );
}

export async function loader({ params }) {
  const contribution = await fetchContribution(params.id);
  console.log(contribution);

  return contribution;
}
