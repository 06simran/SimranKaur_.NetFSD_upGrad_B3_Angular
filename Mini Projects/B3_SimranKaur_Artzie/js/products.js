$(document).ready(function(){

    if($("#homeProducts").length){
        loadHomeProducts();
    }

    if($("#productList").length){
        loadProducts();
    }

    if($("#productDetails").length){
        loadProductDetails();
    }

});


//  HOME PRODUCTS (LIMITED)
function loadHomeProducts(){

    $.getJSON("data/products.json", function(products){

        // show only first 6 products
        let featured = products.slice(0,6);

        displayProducts(featured,"#homeProducts");

    });

}


//  PRODUCTS PAGE (WITH CATEGORY FILTER)
function loadProducts(){

    let category = new URLSearchParams(window.location.search).get("category");

    $.getJSON("data/products.json", function(products){

        if(category){
            products = products.filter(p => p.category == category);
        }

        displayProducts(products,"#productList");

    });

}


//  DISPLAY PRODUCTS
function displayProducts(products,target){

    let html="";

    products.forEach(p=>{

        html+=`
        <div class="col-md-4 mb-3">
        <div class="card p-3">

        <img src="${p.image}">
        <h5>${p.name}</h5>

        <p>${p.description}</p>

        <p>₹${p.price}</p>

        <a href="product-details.html?id=${p.id}" class="btn btn-info mb-2">
        View
        </a>

        <button class="btn btn-primary addCart" data-id="${p.id}">
        Add to Cart
        </button>

        </div>
        </div>
        `;
    });

    $(target).html(html);

}


//  PRODUCT DETAILS PAGE
function loadProductDetails(){

    let id = new URLSearchParams(window.location.search).get("id");

    $.getJSON("data/products.json", function(products){

        let product = products.find(p => p.id == id);

        let html = `
        <div class="card p-4">

        <img src="${product.image}" style="height:300px;object-fit:cover;">

        <h3>${product.name}</h3>

        <p>${product.description}</p>

        <h4>₹${product.price}</h4>

        <button class="btn btn-primary addCart" data-id="${product.id}">
        Add to Cart
        </button>

        </div>
        `;

        $("#productDetails").html(html);

        //  UPDATE BREADCRUMB
        $("#categoryLink")
        .text(product.category)
        .attr("href","products.html?category="+product.category);

    });

}