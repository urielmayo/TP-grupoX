import { NavLink } from "react-router-dom";

export default function Navbar() {
  return (
    <nav className="bg-black text-white p-4 justify-start flex w-full">
      <NavLink to="" className="mr-4 hover:underline">
        Home
      </NavLink>
      <NavLink to="viandas" className="mr-4 hover:underline">
        Viandas
      </NavLink>
    </nav>
  );
}
