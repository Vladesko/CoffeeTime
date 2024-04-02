const Capucino = {
    Price: 3.25,
    Name: "Capucino"
};

const Expresso = {
    Price: 2.00,
    Name: "Expresso"
};

const Cacao = {
    Price: 1.5,
    Name: "Cacao"
};

const Orders = [Capucino, Cacao, Expresso]; //get orders

let params = (new URL(document.location)).searchParams;
let nameOfOrder = params.get("name");  //get name of order

const formElement = document.getElementById("form");
 //get data from form



const btn = document.getElementById("createOrder");

btn.addEventListener("click", () => {
    const form = new FormData(formElement);
    Orders.forEach(element => {
        if(element.Name === nameOfOrder){
            const createOrderDto = {
                name: element.Name,
                price: element.Price,
                person: form.get("namePerson"),
                phone: form.get("numberPhone")
            };
            PostOrder(createOrderDto)
        }
    });
});

function PostOrder(createOrderDto){
    const xhr = new XMLHttpRequest();
    xhr.open("POST", "https://localhost:7175/api/Order");
    xhr.setRequestHeader("Content-type", "application/json; charset=UTF-8");
    console.log(createOrderDto);
    const json = JSON.stringify(createOrderDto);
    console.log(json);
    xhr.send(json);

    xhr.onload = function() {
        if(xhr.status === 200){
            window.location.href="orderProcessed.html";
        }
        if(xhr.status === 400){
            window.location.href = `orderIsNotValide.html?errorMessage=${xhr.responseText}`;
        }
    }

}
