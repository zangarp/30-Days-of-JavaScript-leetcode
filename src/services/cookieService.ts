import Cookies from "js-cookie";

export function saveToCookie(cname: string, token: string, expiresDay: number) {
  Cookies.set(cname, token, {
    expires: expiresDay,
    secure: true,
    sameSite: "Strict",
  });
}

export function clearCookie(cname: string) {
  Cookies.remove(cname);
}

export function getCookie(cname: string) {
  return Cookies.get(cname);
}
