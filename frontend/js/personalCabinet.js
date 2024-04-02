let access_token = localStorage.getItem("key");

    const xhr = new XMLHttpRequest();
    xhr.open("GET", "https://localhost:7175/api/Order");
   
    xhr.addEventListener("load", ParseResponce);

    xhr.setRequestHeader("Authorization", "Bearer " + access_token);
    xhr.send();

function ParseResponce(){

    const orders = JSON.parse(xhr.responseText);
    const table = document.getElementsByClassName("table");
    
    
    orders.forEach(item => {
        console.log(item);
        const row = document.createElement("div");
        row.classList.add("row");
    
        const columnName = document.createElement("div");
        columnName.classList.add("column");
        const name = document.createElement("p");
        name.textContent = item.name;
        columnName.appendChild(name);
    
        const columnPerson = document.createElement("div");
        columnPerson.classList.add("column");
        const person = document.createElement("p");
        person.textContent = item.person;
        columnPerson.appendChild(person);
    
        const columnStatus = document.createElement("div");
        columnStatus.classList.add("column");
        const status = document.createElement("img");
        if(item.status === 0){
            status.src = "./images/orders/yes.svg"
        }
        if(item.status === 1){
            status.src = "./images/orders/no.svg";
        }
        columnStatus.appendChild(status);
    
        const columnNav = document.createElement("div");
        columnNav.classList.add("column");
        const nav = document.createElement("a");
        nav.classList.add("table-nav");
        nav.textContent = "Подробнее";
        nav.href=`orderDetails.html?id=${item.id}`;
        columnNav.appendChild(nav);
    
        row.appendChild(columnName);
        row.appendChild(columnPerson);
        row.appendChild(columnStatus);
        row.appendChild(columnNav);
    
        table[0].appendChild(row);
    })
}