document.addEventListener("DOMContentLoaded", function () {
    const unitPriceInput = document.getElementById("unitPrice");
    const quantityInput = document.getElementById("quantity");
    const totalInput = document.getElementById("total");

    function calculateTotal() {
        const unitPrice = parseFloat(unitPriceInput.value) || 0;
        const quantity = parseFloat(quantityInput.value) || 0;
        const total = (unitPrice * quantity).toFixed(2); 
        totalInput.value = total;
    }

    
    unitPriceInput.addEventListener("input", calculateTotal);
    quantityInput.addEventListener("input", calculateTotal);
});