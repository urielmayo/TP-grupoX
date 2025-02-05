import { Form, useActionData, useLoaderData } from "react-router-dom";
import { useState } from "react";
import Modal from "./UI/Modal";
import FormTitle from "./Ui/form/FormTitle";
import Field from "./UI/form/Field";
import SubmitButton from "./UI/form/SubmitButton";
import FormError from "./UI/form/FormError";

export default function Profile() {
  const user = useLoaderData();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const errors = useActionData();

  const handleEditClick = () => {
    setIsModalOpen(true);
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  return (
    <div className="bg-white shadow-lg rounded-2xl p-8 min-h-96 min-w-full">
      <div className="flex gap-x-3 items-center">
        <h1 className="text-4xl">Datos personales</h1>
        <button
          className="px-2 py-1 bg-blue-500 hover:bg-blue-600 text-white rounded-md text-lg"
          onClick={handleEditClick}
        >
          Editar
        </button>
      </div>
      <hr className="my-3" />
      <div className="grid lg:grid-cols-2 md:grid-cols-1 gap-3">
        <div className="flex gap-x-3">
          <h1 className="font-bold">Email:</h1>
          <p>{user.email}</p>
        </div>
        <div className="flex gap-x-3">
          <h1 className="font-bold">Nombre de usuario:</h1>
          <p>{user.userName}</p>
        </div>
        <div className="flex gap-x-3">
          <h1 className="font-bold">Telefono:</h1>
          <p>{user.phoneNumber}</p>
        </div>
        <div className="flex gap-x-3">
          <h1 className="font-bold">Dirección:</h1>
          <p>{user.address}</p>
        </div>
        {user.type === "HumanPerson" && (
          <div className="flex gap-x-3">
            <h1 className="font-bold">Código de tarjeta:</h1>
            <p>{user.cardCode}</p>
          </div>
        )}
        <div className="flex gap-x-3">
          <h1 className="font-bold">Cantidad de contribuciones:</h1>
          <p>{user.contributions.length}</p>
        </div>
        <div className="flex gap-x-3">
          <h1 className="font-bold">Puntos acumulados:</h1>
          <p>{user.accumulatedPoints}</p>
        </div>
      </div>

      {isModalOpen && (
        <Modal onClose={handleCloseModal}>
          <Form method="put" onSubmit={handleCloseModal}>
            {(errors && (
              <FormError>
                <ul>
                  {Object.keys(errors).map((key) =>
                    errors[key].map((item) => <li key={item}>{item}</li>)
                  )}
                </ul>
              </FormError>
            )) || <br />}

            <FormTitle text="Editar informacion de usuario" />
            <hr className="my-3" />
            <div className="grid md:grid-cols-2 gap-x-3">
              <Field
                label="Email"
                name="email"
                type="email"
                placeholder="user@example.com"
                defaultValue={user.email}
                required
              />
              <Field
                label="Telefono"
                name="phoneNumber"
                type="text"
                placeholder="Ingrese un numero de contacto"
                defaultValue={user.phoneNumber}
                required
              />
              <Field
                label="Dirección"
                name="address"
                type="text"
                placeholder="Ingrese su dirección"
                defaultValue={user.address}
                required
              />
              <Field
                label="Nombre de usuario"
                name="userName"
                type="text"
                placeholder="Ingrese su nombre de usuario"
                defaultValue={user.userName}
                required
              />
            </div>
            <SubmitButton text="Actualizar" />
          </Form>
        </Modal>
      )}
    </div>
  );
}
