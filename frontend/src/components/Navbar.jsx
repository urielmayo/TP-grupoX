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
  const isLogged = user !== null;

  // TODO: Hacer que el usuario admin tenga los links: carga masiva, tecnicos

  return (
    <nav className="bg-gray-900 text-white p-4 justify-between flex w-full sticky top-0">
      <div className="flex justify-start gap-x-4">
        <NavLink to="" className="hover:underline">
          SiMAA
        </NavLink>
        {isLogged && (
          <>
            <NavLink to="fridges" className="hover:underline">
              Heladeras
            </NavLink>
            {user.role === "Collaborator" && (
              <>
                <NavLink to="contributions" className="hover:underline">
                  Contribuciones
                </NavLink>
                <NavLink to="rewards" className="hover:underline">
                  Canjea tus puntos
                </NavLink>
              </>
            )}

            {user.role === "Admin" && (
              <>
                <NavLink to="bulk-contributions" className="hover:underline">
                  Carga masiva CSV
                </NavLink>
                <NavLink to="technicians" className="hover:underline">
                  Técnicos
                </NavLink>
              </>
            )}
          </>
        )}
      </div>

      <div className="flex justify-end pl-3 gap-x-4">
        {(!isLogged && (
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
                  {user.role === "Admin" && (
                    <li>
                      <NavLink to="coefficients" className={dropdownCssClass}>
                        Coeficientes
                      </NavLink>
                    </li>
                  )}
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
