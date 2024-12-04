import { Outlet } from "react-router-dom";
import ContributionList from "../components/Contributions/ContributionList";

export default function ContributionListPage() {
  return (
    <div className="flex items-start justify-center">
      <Outlet />
      <ContributionList />
    </div>
  );
}
