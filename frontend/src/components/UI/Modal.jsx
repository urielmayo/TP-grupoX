import { useEffect, useRef } from "react";
import { createPortal } from "react-dom";

export default function Modal({ children, onClose }) {
  const dialog = useRef();

  useEffect(() => {
    const modal = dialog.current;
    modal.showModal();

    // Escuchar la tecla "Esc" para cerrar el modal
    const handleKeyDown = (event) => {
      if (event.key === "Escape") {
        onClose();
      }
    };

    // Agregar el event listener para la tecla "Escape"
    document.addEventListener("keydown", handleKeyDown);

    return () => {
      modal.close();
      document.removeEventListener("keydown", handleKeyDown);
    };
  }, [onClose]);

  return createPortal(
    <dialog className="modal rounded-2xl p-8" ref={dialog}>
      <button onClick={onClose} className="text-blue-600 hover:underline mb-3">
        Volver
      </button>
      <div className="flex items-start justify-center">
        <div className="w-full max-w-4xl bg-white">{children}</div>
      </div>
    </dialog>,
    document.getElementById("modal")
  );
}
