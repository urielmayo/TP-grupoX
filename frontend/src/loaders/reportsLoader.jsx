import { requireAdmin } from "../utils/auth";

export function reportsLoader() {
  requireAdmin();
  return null;
}
