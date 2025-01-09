import FridgeDetail from "../../components/fridges/FridgeDetail";
import { Outlet } from "react-router-dom";

export default function FridgeDetailPage() {
  return (
    <>
      <Outlet />
      <FridgeDetail />
    </>
  );
}
