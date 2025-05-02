document.addEventListener("DOMContentLoaded", function () {
    const productSelect = document.getElementById("productId");
    const unitPriceInput = document.getElementById("unitPrice");

    productSelect.addEventListener("change", function () {
        const productId = productSelect.value;
        if (productId) {
            fetch(`/OManagement/GetProductPrice?id=${productId}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Error when tried to get price");
                    }
                    return response.json();
                })
                .then(data => {
                    unitPriceInput.value = parseFloat(data.unitPrice).toFixed(2);
                })
                .catch(error => {
                    alert("Error when tried to get product price");
                    console.error(error);
                });
        }
    });
});