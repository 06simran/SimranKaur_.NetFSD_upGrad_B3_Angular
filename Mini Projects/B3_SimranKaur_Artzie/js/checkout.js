function loadSummary(){

let cart=JSON.parse(localStorage.getItem("cart"))||[];

let html="";
let total=0;

cart.forEach(item=>{
total+=item.price;
html+=`<p>${item.name} - ₹${item.price}</p>`;
});

html+=`<h4>Total ₹${total}</h4>`;

$("#orderSummary").html(html);

}

$("#checkoutForm").submit(function(e){

e.preventDefault();

alert("Order Placed Successfully!");

localStorage.removeItem("cart");

window.location="index.html";

});

$(document).ready(function(){
loadSummary();
});