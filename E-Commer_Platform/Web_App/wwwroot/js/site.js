// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*var minus_A = document.querySelector("#product_A_form .btn-subtract")
var add_A = document.querySelector("#product_A_form .btn-add");
var quantity_A = document.querySelector("#product_A_form .item-quantity");

minus_A.addEventListener("click", function () {
    quantity_A.value--;
});

add_A.addEventListener("click", function () {
    quantity_A.value++;
});*/

$(document).ready(function () {
    // Handle the click on the "+" button
    $(".btn-add").on("click", function () {
        var inputField = $(this).closest("tr").find(".item-quantity");
        var currentQuantity = parseInt(inputField.val());
        inputField.val(currentQuantity + 1);
        updateItemTotal(inputField);
    });

    // Handle the click on the "-" button
$(".btn-subtract").on("click", function () {
        var inputField = $(this).closest("tr").find(".item-quantity");
        var currentQuantity = parseInt(inputField.val());
        if (currentQuantity > 1) {
            inputField.val(currentQuantity - 1);
            updateItemTotal(inputField);
        }
});

    // Function to update the item total
function updateItemTotal(inputField) {
        var quantity = parseInt(inputField.val());
        var price = parseFloat(inputField.closest("tr").find(".item-price").text());
        var total = quantity * price;
        inputField.closest("tr").find(".item-total").text(total.toFixed(2));
    }
});

function updateItemTotal(inputField) {
    var quantity = parseInt(inputField.val());
    var price = parseFloat(inputField.closest("tr").find(".item-price").text());

    if (isNaN(quantity) || isNaN(price)) {
        // Handle invalid input or data
        console.error("Invalid quantity or price:", quantity, price);
        return;
    }

    var total = quantity * price;
    inputField.closest("tr").find(".item-total").text(total.toFixed(2));
}




/*function fetchCartItemCount(_userId) {
    fetch('/api/cart/itemcount?userid=${userid}')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            // `data` contains the cart item count returned from the server
            displayCartNotification(data);
        })
        .catch(error => {
            console.error('Fetch error:', error);
        });
}

function displayCartNotification(itemCount) {
    // Create a div element to display the notification
    const notificationDiv = document.createElement('div');
    notificationDiv.className = 'cart-notification';
    notificationDiv.innerHTML = `You have <span class="cart-item-count">${itemCount}</span> items in your cart.`;

    // Append the notification div to the document body or a specific container
    document.body.appendChild(notificationDiv);

    // Add CSS styles to the notification (you can define these styles in your CSS)
    notificationDiv.style.position = 'fixed';
    notificationDiv.style.top = '10px';
    notificationDiv.style.right = '10px';
    notificationDiv.style.backgroundColor = 'rgba(0, 0, 0, 0.8)';
    notificationDiv.style.color = 'white';
    notificationDiv.style.padding = '10px';
    notificationDiv.style.borderRadius = '5px';
    notificationDiv.style.zIndex = '1000';

    // Optionally, add animation or fade-in effects
    notificationDiv.style.animation = 'fade-in 1s ease';

    // Set a timer to remove the notification after a few seconds (optional)
    setTimeout(() => {
        notificationDiv.style.display = 'none';
    }, 5000); // Hide the notification after 5 seconds (adjust as needed)
}

const _userid = userid
fetchCartItemCount(_userid)


*/
