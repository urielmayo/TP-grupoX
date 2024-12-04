import { fetchUser } from "../utils/http";
import { DUMMY_PRODUCTS } from "../dummy_data";

export async function rewardsLoader() {
  const user = await fetchUser();
  const rewards = DUMMY_PRODUCTS;
  return { user, rewards };
}
