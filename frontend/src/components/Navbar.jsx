import { NavLink, useRouteLoaderData, Form } from "react-router-dom";
import { useState, useRef } from "react";

export default function Navbar() {
  const user = useRouteLoaderData("root");
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const timeoutRef = useRef(null);

  const handleMouseEnter = () => {
    if (timeoutRef.current) {
      clearTimeout(timeoutRef.current);
      timeoutRef.current = null;
    }
    setDropdownOpen(true);
  };

  const handleMouseLeave = () => {
    timeoutRef.current = setTimeout(() => {
      setDropdownOpen(false);
    }, 150); // Retraso de 150 ms
  };

  const dropdownCssClass = "block px-4 py-2 hover:bg-gray-500 hover:rounded-lg";

  return (
    <nav className="bg-gray-900 text-white p-4 justify-between flex w-full sticky top-0">
      <div className="flex justify-start gap-x-4">
        <NavLink to="" className="hover:underline">
          SiMAA
        </NavLink>
        {user !== null && (
          <>
            <NavLink to="users/me/contributions" className="hover:underline">
              Contribuciones
            </NavLink>
            <NavLink to="rewards" className="hover:underline">
              Canjea tus puntos
            </NavLink>
          </>
        )}
      </div>

      <div className="flex justify-end pl-3 gap-x-4">
        {(user === null && (
          <NavLink to="users/login" className="hover:underline">
            Iniciar Sesion
          </NavLink>
        )) || (
          <ul>
            <li
              className="relative"
              onMouseEnter={handleMouseEnter}
              onMouseLeave={handleMouseLeave}
            >
              {user.username}
              {dropdownOpen && (
                <ul className="absolute w-48 bg-gray-900 right-0 rounded-lg shadow-lg mt-2">
                  <li>
                    <NavLink to="users/me" className={dropdownCssClass}>
                      Perfil
                    </NavLink>
                  </li>
                  <li>
                    <Form
                      action="/users/logout"
                      method="post"
                      className={dropdownCssClass}
                    >
                      <button>Cerrar sesion</button>
                    </Form>
                  </li>
                </ul>
              )}
            </li>
          </ul>
        )}
      </div>
    </nav>
  );
}
