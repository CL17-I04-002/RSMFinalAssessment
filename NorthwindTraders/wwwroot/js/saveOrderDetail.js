document.addEventListener("DOMContentLoaded", function () {
    const addItemButton = document.getElementById("addItem");
    const productSelect = document.getElementById("productId");
    const unitPriceInput = document.getElementById("unitPrice");
    const quantityInput = document.getElementById("quantity");
    const totalInput = document.getElementById("total");

    addItemButton.addEventListener("click", function (event) {
        // Prevenir la acción por defecto del botón si es necesario
        event.preventDefault();

        const productId = productSelect.value;
        const quantity = parseFloat(quantityInput.value) || 0;
        const unitPrice = parseFloat(unitPriceInput.value) || 0;
        const total = parseFloat(totalInput.value) || 0;

        // Verificar que los valores sean válidos antes de enviar
        if (!productId || quantity <= 0 || unitPrice <= 0) {
            alert("Please fill in all the fields correctly.");
            return;
        }

        // Crear el objeto con los datos a enviar
        const itemData = {
            productId: productId,
            quantity: quantity,
            unitPrice: unitPrice,
            total: total
        };

        // Enviar los datos al controlador usando Fetch (POST)
        fetch('/OManagement/AddItem', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(itemData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error adding item.');
                }
                return response.json();
            })
            .then(data => {
                // Aquí puedes manejar la respuesta del servidor, por ejemplo:
                alert('Item added successfully!');
                // Opcionalmente limpiar los campos
                quantityInput.value = '';
                totalInput.value = '';
            })
            .catch(error => {
                alert('Error when adding item');
                console.error(error);
            });
    });
});