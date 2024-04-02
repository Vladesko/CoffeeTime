console.log("Begin");
const btn = document.getElementById("login");
btn.addEventListener("click", () => {
    console.log("Im here");
    const xhr = new XMLHttpRequest();
    xhr.open("GET", "https://localhost:7188/Account/Login");
    xhr.send();
    xhr.onload() = function() {
        if(xhr.status === 200){
            window.location.href=`personal.html`;
        }
    }

   // window.location.href = "https://localhost:7188/Account/Login";
});