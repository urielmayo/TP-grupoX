import { fetchUser } from "../utils/http";

export async function profileLoader() {
  const data = await fetchUser();
  return data;
}
