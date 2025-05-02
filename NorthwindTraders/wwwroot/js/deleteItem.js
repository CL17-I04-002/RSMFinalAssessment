document.addEventListener("DOMContentLoaded", function () {
    const table = document.getElementById("orderDetailsTable");

    table.addEventListener("click", function (event) {
        if (event.target && event.target.classList.contains("delete-btn")) {
            const row = event.target.closest("tr");

            // ✅ Obtenemos directamente desde los atributos del <tr>
            const productId = row.getAttribute("data-product-id");
            const orderId = row.getAttribute("data-order-id");

            console.log("productId" + productId);
            console.log("orderId" + orderId);

            if (!orderId || !productId) {
                alert("❌ Missing order or product ID.");
                return;
            }

            if (!confirm("Are you sure you want to delete this item?")) return;

            fetch('/OManagement/DeleteItem', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ orderId: parseInt(orderId), productId: parseInt(productId) })
            })
                .then(response => response.json())
                .then(result => {
                    if (result.success) {
                        alert("✔️ Item deleted successfully!");
                        row.remove();
                    } else {
                        alert("❌ Error deleting item: " + result.message);
                    }
                })
                .catch(error => {
                    console.error("Error:", error);
                    alert("❌ Server error during deletion.");
                });
        }
    });
});