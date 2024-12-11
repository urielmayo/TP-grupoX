import { requireAdmin } from "../utils/auth";

export async function bulkContribLoader() {
  requireAdmin(); // Lanza un error 403 si el usuario no es admin
  return null; // Si el usuario es admin, permite el acceso
}
