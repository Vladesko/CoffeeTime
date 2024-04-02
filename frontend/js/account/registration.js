const formElement = document.getElementById("form");
const btn = document.getElementById("registration");
let errorMessage = document.getElementById("errorMessage");

btn.addEventListener("click", () => {
    const form = new FormData(formElement);
    const UserRegistrationRequest = {
      UserName: form.get("UserName"),
      Password: form.get("Password"),
      Email: form.get("Email"),
      NumberPhone: form.get("NumberPhone"),
      ConfirmPassword: form.get("ConfirmPassword"),
    };
    registration(UserRegistrationRequest);
  });

  function registration(UserRegistrationRequest){
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "https://localhost:7188/api/Account/Registration");
    xhr.setRequestHeader("Content-type", "application/json; charset=UTF-8");
    const json = JSON.stringify(UserRegistrationRequest);
    xhr.send(json);

    xhr.onload = function () {
      if(xhr.status === 200) {
        window.location.href = "login.html";
      }
      if(xhr.status === 400){
        console.log("Im here");
        errorMessage.textContent = xhr.responseText;
      }
    }
  }