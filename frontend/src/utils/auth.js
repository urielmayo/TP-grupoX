export function getUserData() {
  return JSON.parse(sessionStorage.getItem("user"));
}

export function userLoader() {
  return getUserData();
}
