export function getUserData() {
  const user = JSON.parse(localStorage.getItem("user"));
  return user;
}

export function userLoader() {
  return getUserData();
}

export async function fetchUser() {
  const user = getUserData();
  const jwt = localStorage.getItem("jwt");
  const response = await fetch(
    `https://localhost:7017/Collaborator/${user.id}`,
    {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `bearer ${jwt}`,
      },
    }
  );
  const data = await response.json();
  return data.data;
}
