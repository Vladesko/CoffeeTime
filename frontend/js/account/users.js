let access_token = localStorage.getItem("key");

const xhr = new XMLHttpRequest();
xhr.open("GET", "https://localhost:7188/api/Account/Users");

xhr.addEventListener("load", ParseResponce);

xhr.setRequestHeader("Authorization",  `${access_token}`);
xhr.send();

function ParseResponce() {
  const orders = JSON.parse(xhr.responseText);
  console.log(orders);
  const table = document.getElementsByClassName("table");

  orders.forEach((item) => {
    const row = document.createElement("div");
    row.classList.add("row");

    const columnName = document.createElement("div");
    columnName.classList.add("column");
    const name = document.createElement("p");
    name.textContent = item.userName;
    columnName.appendChild(name);

    const columnPhone = document.createElement("div");
    columnPhone.classList.add("column");
    const phone = document.createElement("p");
    phone.textContent = item.phone;
    columnPhone.appendChild(phone);

    const columnEmail = document.createElement("div");
    columnEmail.classList.add("column");
    const email = document.createElement("p");
    email.textContent = item.email;
    columnEmail.appendChild(email);

    const columnNav = document.createElement("div");
    columnNav.classList.add("column");
    const nav = document.createElement("a");
    nav.classList.add("table-nav");
    nav.textContent = "Отправить код";
    nav.href = `sendMessage.html?email=${item.email}`;
    columnNav.appendChild(nav);

    row.appendChild(columnName);
    row.appendChild(columnPhone);
    row.appendChild(columnEmail);
    row.appendChild(columnNav);

    table[0].appendChild(row);
  });
}
