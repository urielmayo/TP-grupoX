import { redirect, useRouteLoaderData } from "react-router-dom";
import { fetchUser, getUserData } from "../utils/auth";

export default function ProfilePage() {
  const user = useRouteLoaderData("profile");

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
      </div>
    </div>
  );
}

export async function loader() {
  if (getUserData() === null) {
    return redirect("/users/login");
  }
  const data = await fetchUser();
  return data;
}
