import { useNavigate, useActionData } from "react-router-dom";

import Modal from "../UI/Modal";

export default function TechnianDetail() {
  const navigate = useNavigate();
  const errors = useActionData();
  return (
    <Modal onClose={() => navigate("../")}>
      <div className="w-96 h-48"></div>
    </Modal>
  );
}
