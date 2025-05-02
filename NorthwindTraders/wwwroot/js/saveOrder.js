document.addEventListener('DOMContentLoaded', function () {
    const btnSave = document.getElementById('btnSave');

    if (btnSave) {
        btnSave.addEventListener('click', async function () {
            // GET Data from backend
            const customerId = document.querySelector('[name="CustomerId"]').value;
            const employeeId = document.querySelector('[name="EmployeeId"]').value;
            const orderDate = document.querySelector('[name="OrderDate"]').value;
            const shipAddress = document.querySelector('[name="ShipAddress"]').value;

            const data = {
                customerId: customerId,
                employeeId: parseInt(employeeId),
                orderDate: orderDate,
                shipAddress: shipAddress
            };

            try {
                const response = await fetch('/OManagement/SaveOrder', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data)
                });

                const result = await response.json();

                if (response.ok && result.success) {
                    alert("¡Data was saved! ID: " + result.orderId);
                } else {
                    alert("Error: " + (result.message || "Unknown Error"));
                }
            } catch (error) {
                console.error('Error:', error);
                alert("There was an error in the request.");
            }
        });
    }
});