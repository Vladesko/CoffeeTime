const formElement = document.getElementById("form");
const btn = document.getElementById("confirm");
const errorMessage = document.getElementById("errorMessage");

let params = new URL(document.location).searchParams;
let email = params.get("email");

btn.addEventListener("click", () => {
  const form = new FormData(formElement);
  const ConfirmUserRequest = {
    Email: email,
    SecretCode: form.get("secretCode"),
  };
  const xhr = new XMLHttpRequest();
  open("POST", "https://localhost:7188/api/Account/CodeConfirmation");
  xhr.setRequestHeader("Content-type", "application/json; charset=UTF-8");
  const json = JSON.stringify(ConfirmUserRequest);
  xhr.send(json);

  xhr.onload = function () {
    if (xhr.status === 200) {
      window.location.href = "index.html";
    }
    if (xhr.status === 403) {
      errorMessage.textContent = xhr.responseText;
    }
  };
});
