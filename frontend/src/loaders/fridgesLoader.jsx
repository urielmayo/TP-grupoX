import { fetchFridges } from "../utils/http";

export async function fridgesLoader() {
  const fridges = await fetchFridges();
  return fridges;
}
