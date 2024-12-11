import { useLoaderData } from "react-router-dom";

export default function Profile() {
  const user = useLoaderData();
  console.log(user);

  return (
    <div className="bg-white shadow-lg rounded-2xl p-8 min-h-96 min-w-full">
      <h1 className="text-4xl">Datos personales</h1>
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
          <h1 className="font-bold">Cantidad de contribuciones:</h1>
          <p>{user.contributions.length}</p>
        </div>
        <div className="flex gap-x-3">
          <h1 className="font-bold">Telefono:</h1>
          <p>{user.phoneNumber}</p>
        </div>
        <div className="flex gap-x-3">
          <h1 className="font-bold">Puntos acumulados:</h1>
          <p>{user.accumulatedPoints}</p>
        </div>
      </div>
    </div>
  );
}
