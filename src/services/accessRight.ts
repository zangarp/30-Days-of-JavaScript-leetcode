import { getUserRole } from "@/api/finOpsAPI";

export async function checkUserRole(userId: number): Promise<boolean> {
  const userRole = await getUserRole();
  if (userRole === userId) return true;
  else return false;
}
