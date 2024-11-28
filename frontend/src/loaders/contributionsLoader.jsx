import { fetchContribution } from "../utils/http";

export async function contributionLoader({ params }) {
  const contribution = await fetchContribution(params.id);
  return contribution;
}
