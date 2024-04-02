let params = (new URL(document.location)).searchParams;
let email = params.get("email"); 
const message = document.getElementById("responceText"); 

const ConfirmUserRequest = {
    Email: email,
};

const json = JSON.stringify(ConfirmUserRequest);

let access_token = localStorage.getItem("key");

const xhr = new XMLHttpRequest();
xhr.open("POST", "https://localhost:7188/api/Account/SendCode");


xhr.setRequestHeader("Content-type", "application/json; charset=UTF-8");
xhr.setRequestHeader("Authorization",  `${access_token}`);

xhr.send(json);

xhr.onload = function() {
    if(xhr.status === 200){
        message.classList.add("responce-positive");
        message.textContent = "Письмо отправлено";
    }
    if(xhr.status === 404){
        message.classList.add("responce-negative");
        message.textContent = xhr.responseText;
    }
}