export function getUserData() {
  const user = JSON.parse(localStorage.getItem("user"));
  return user;
}

export function userLoader() {
  return getUserData();
}
