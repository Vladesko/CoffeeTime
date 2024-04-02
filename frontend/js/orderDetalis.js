let params = new URL(document.location).searchParams;
let idOrder = params.get("id");

let access_token = localStorage.getItem("key");

const orderName = document.getElementById("name");
const person = document.getElementById("person");
const phone = document.getElementById("phone");
const price = document.getElementById("price");
const orderStatus = document.getElementById("status");
const createDate = document.getElementById("createDate");
const changeDate = document.getElementById("changeDate");

const xhr = new XMLHttpRequest();

xhr.open("GET", `https://localhost:7175/api/Order/${idOrder}`);

xhr.addEventListener("load", ParseResponce);

xhr.setRequestHeader("Authorization", `Bearer ${access_token}`);
xhr.send();

function ParseResponce() {
  const orderDto = JSON.parse(xhr.responseText);
  orderName.textContent = orderDto.name;
  person.textContent = orderDto.person;
  phone.textContent = orderDto.phone;
  price.textContent = orderDto.price + `$`;
  if (orderDto.status === 0) {
    orderStatus.src = "./images/orders/yes.svg";
  }
  if (orderDto.status === 1) {
    orderStatus.src = "./images/orders/no.svg";
  }
  createDate.textContent = orderDto.create;
  changeDate.textContent = orderDto.update;
  console.log(orderDto);
}

const btnReady = document.getElementById("btn-ready");
const btnDelete = document.getElementById("btn-delete");

btnReady.addEventListener("click", updateOrder);
btnDelete.addEventListener("click", deleteOrder);

function updateOrder() {
  const UpdateOrderDto = {
    Id: idOrder,
    Status: 0,
  };

  const json = JSON.stringify(UpdateOrderDto);

  const xhr = new XMLHttpRequest();
  xhr.open("PUT", "https://localhost:7175/api/Order");

  xhr.setRequestHeader("Content-type", "application/json; charset=UTF-8");
  xhr.setRequestHeader("Authorization", `Bearer ${access_token}`);

  xhr.onload = function() {
    if(xhr.status === 204){
      console.log("Im here 204");
      window.location.href = "personal.html"
    }
    if(xhr.status === 401){
      console.log("My error");
    }
  }
  xhr.send(json);
}

function deleteOrder() {
  const DeleteOrderDto = {
    Id: idOrder,
  };
  const json = JSON.stringify(DeleteOrderDto);

  const xhr = new XMLHttpRequest();
  xhr.open("DELETE", "https://localhost:7175/api/Order");
  xhr.setRequestHeader("Content-type", "application/json; charset=UTF-8");

  xhr.setRequestHeader("Authorization", `Bearer ${access_token}`);
  xhr.send(json);
}
