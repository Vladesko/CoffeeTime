const formElement = document.getElementById("form");
const btn = document.getElementById("login");

let errorMessage = document.getElementById("errorMessage");

btn.addEventListener("click", () => {
  const form = new FormData(formElement);
  const UserLoginRequest = {
    UserName: form.get("UserName"),
    Password: form.get("Password"),
  };
  login(UserLoginRequest);
});

function login(UserLoginRequest) {
  const xhr = new XMLHttpRequest();
  xhr.open("POST", "https://localhost:7188/api/Account/Login");
  xhr.setRequestHeader("Content-type", "application/json; charset=UTF-8");
  const json = JSON.stringify(UserLoginRequest);
  xhr.send(json);

  xhr.onload = function () {
    if (xhr.status === 200) {
      localStorage.setItem("key", xhr.responseText);
      console.log(xhr.responseText);
      window.location.href = `personal.html`;
    }
    if (xhr.status === 400) {
      errorMessage.textContent = xhr.responseText;
    }
    if (xhr.status === 404) {
      errorMessage.textContent = xhr.responseText;
    }
    if (xhr.status === 403) {
      window.location.href = `confirmEmail.html?email=${xhr.responseText}`;
    }
  };
}
