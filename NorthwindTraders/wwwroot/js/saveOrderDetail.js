document.addEventListener("DOMContentLoaded", function () {
    const productSelect = document.getElementById("OrderDetails_ProductId");
    const unitPriceInput = document.getElementById("OrderDetails_UnitPrice");
    const quantityInput = document.getElementById("OrderDetails_Quantity");
    const totalInput = document.getElementById("total");
    const btnSave = document.getElementById("addItem");

    if (btnSave) {
        btnSave.addEventListener("click", function (event) {
            event.preventDefault();

            const productId = productSelect.value;
            const orderId = document.getElementById("currentOrderId").value;
            const productName = productSelect.options[productSelect.selectedIndex].text;
            const quantity = parseFloat(quantityInput.value) || 0;
            const unitPrice = parseFloat(unitPriceInput.value) || 0;
            const total = quantity * unitPrice;

            if (!productId || quantity <= 0 || unitPrice <= 0) {
                alert("Please fill in all the fields correctly.");
                return;
            }

            const itemData = {
                orderId: orderId,
                productId: productId,
                quantity: quantity,
                unitPrice: unitPrice,
                total: total
            };

            console.log("itemData: ", itemData);

            fetch('/OManagement/AddItem', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(itemData)
            })
                .then(response => response.json())
                .then(result => {
                    if (result.success) {
                        alert("✔️ Item added successfully!");

                        quantityInput.value = '';
                        unitPriceInput.value = '';
                        totalInput.value = '';

                        const tableBody = document.querySelector("#orderDetailsTable tbody");
                        const newRow = document.createElement("tr");
                        newRow.setAttribute("data-product-id", productId);
                        newRow.setAttribute("data-order-id", orderId);

                        console.log("ProductName: " + productName);
                        console.log("Quantity: " + quantity);
                        console.log("UnitPrice: " + unitPrice);
                        console.log("Total: " + total);

                        newRow.innerHTML = `
                            <td>${productName}</td>
                            <td>${quantity}</td>
                            <td>${unitPrice.toFixed(2)}</td>
                            <td>${total.toFixed(2)}</td>
                            <td>
                                <button class="btn btn-danger btn-form delete-btn">Delete</button>
                            </td>
                        `;

                        tableBody.appendChild(newRow);
                    } else {
                        alert("❌ Error: " + (result.message || "Unknown error"));
                    }
                })
                .catch(error => {
                    alert("❌ Error when adding item");
                    console.error(error);
                });
        });
    }
});