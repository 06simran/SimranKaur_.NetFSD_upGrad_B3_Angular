# Artzie – Frontend E-Commerce Application

## Project Overview

Artzie is a frontend-based e-commerce web application developed to demonstrate core web development concepts using modern technologies. The application allows users to browse products, view detailed information, manage a shopping cart, and simulate a checkout process.

This project is entirely client-side and does not use any backend services. All product data and cart information are handled using JSON and browser LocalStorage.

---

## Technologies Used

* HTML5
* CSS3
* JavaScript (ES6)
* Bootstrap 5
* jQuery
* LocalStorage
* JSON

---

## Features

### Product Browsing

* View all available products
* Display product images, names, prices, and descriptions
* Filter products by category

### Product Details

* View detailed product information
* Includes image, name, description, and price
* Add product to cart

### Shopping Cart

* Add items to cart
* Remove items from cart
* View total cart value
* Cart data persists using LocalStorage

### Checkout

* Enter user details (Name, Email, Address)
* View order summary
* Simulate order placement

### User Interface

* Responsive design using Bootstrap
* Clean and aesthetic pastel theme
* Navigation across all pages
* Breadcrumb navigation for better usability

---

## Project Structure

```
Artzie-Frontend
│
├── index.html
├── products.html
├── product-details.html
├── cart.html
├── checkout.html
│
├── css
│   └── styles.css
│
├── js
│   ├── products.js
│   ├── cart.js
│   ├── checkout.js
│   └── common.js
│
├── data
│   └── products.json
│
├── images
│
└── lib
    ├── bootstrap
    └── jquery
```

---

## How to Run the Project

1. Download or clone the project folder
2. Open the project in a code editor (e.g., VS Code)
3. Run the project using a Live Server or open `index.html` in a browser
4. Navigate through the application using the navbar

---

## Functional Flow

Home Page
→ Products Page
→ Product Details
→ Add to Cart
→ Cart Page
→ Checkout Page

---

## Data Handling

* Product data is stored in a JSON file
* Cart data is stored in LocalStorage
* JavaScript modules handle product loading and cart operations

---

## Testing

* Product listing displays correctly
* Add to cart functionality works
* Cart updates and persists correctly
* Total price calculation is accurate
* Checkout form accepts user input

---

## Conclusion

Artzie demonstrates the implementation of a complete frontend e-commerce workflow. It showcases responsive design, dynamic data handling, and user interaction using JavaScript and jQuery. The project is structured to support future backend integration.

---
