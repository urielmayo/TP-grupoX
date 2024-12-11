import { Outlet } from "react-router-dom";
import TechniciansList from "../../components/technicians/TechniciansList";

export default function TechniciansListPage() {
  return (
    <div className="flex items-start justify-center">
      <Outlet />
      <TechniciansList />
    </div>
  );
}
