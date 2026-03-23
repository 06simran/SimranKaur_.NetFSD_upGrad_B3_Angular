// 🔷 UPDATE CART COUNT
function updateCartCount(){

let cart = JSON.parse(localStorage.getItem("cart")) || [];

$("#cartCount").text(cart.length);

}


// 🔷 ADD TO CART
$(document).on("click",".addCart",function(){

let button = $(this);
let id = button.data("id");

$.getJSON("data/products.json",function(products){

let product = products.find(p => p.id == id);

let cart = JSON.parse(localStorage.getItem("cart")) || [];

cart.push(product);

localStorage.setItem("cart", JSON.stringify(cart));

// ✅ UPDATE COUNT
updateCartCount();

// ✅ BUTTON FEEDBACK (PASTEL)
button.text("Added ✔")
.css("background","#FFD6C9");

});

});


// 🔷 LOAD CART PAGE
function loadCart(){

let cart = JSON.parse(localStorage.getItem("cart")) || [];

let html = "";
let total = 0;

cart.forEach((item,index)=>{

total += item.price;

html += `
<div class="card p-3 mb-2">

<h5>${item.name}</h5>
<p>₹${item.price}</p>

<button class="btn btn-danger removeItem" data-index="${index}">
Remove
</button>

</div>
`;

});

$("#cartItems").html(html);
$("#cartTotal").text("Total: ₹" + total);

}


// 🔷 REMOVE ITEM
$(document).on("click",".removeItem",function(){

let index = $(this).data("index");

let cart = JSON.parse(localStorage.getItem("cart")) || [];

cart.splice(index,1);

localStorage.setItem("cart", JSON.stringify(cart));

loadCart();
updateCartCount();

});


// 🔷 PAGE LOAD
$(document).ready(function(){

updateCartCount();

if($("#cartItems").length){
loadCart();
}

});