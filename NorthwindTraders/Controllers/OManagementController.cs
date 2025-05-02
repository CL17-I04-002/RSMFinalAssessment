using Application.dto.Order;
using Application.dto.OrderDetail;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NorthwindTraders.Controllers
{
    public class OManagementController(IEmployeeService employeeService,
        ICustomerService customerService,
        IOrderService orderService,
        IProductService productService,
        IOrderDetailService orderDetailService) : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var employees = await employeeService.GetAllEmployeesAsync();
            var customers = await customerService.GetAllCustomersAsync();
            var products = await productService.GetAllProductsAsync();
            ViewBag.EmployeeList = new SelectList(employees, "EmployeeID", "FirstName");
            ViewBag.CustomerList = new SelectList(customers, "CustomerID", "ContactName");
            ViewBag.ProductList = new SelectList(products, "ProductID", "ProductName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] CreateOrderRequest request)
        {
            if (ModelState.IsValid)
            {
                var orderId = await orderService.CreateOrderAsync(request);
                return Ok(new { success = true, orderId = orderId });
            }
            return BadRequest(new { success = false, message = "Invalid data" });
        }

        [HttpGet]
        public async Task<IActionResult> GetProductPrice(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return Json(new { unitPrice = product.UnitPrice });
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrderDetail([FromBody] CreateOrderDetailRequest request)
        {
            if (ModelState.IsValid)
            {
                await orderDetailService.CreateOrderAsync(request);
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false, message = "Invalid data" });
        }
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] CreateOrderDetailRequest itemDto)
        {
            if (itemDto == null || itemDto.Quantity <= 0 || itemDto.UnitPrice <= 0)
            {
                return BadRequest("Invalid item data.");
            }

            try
            {
                
                await orderDetailService.CreateOrderAsync(itemDto);

                return Json(new { success = true, message = "Item added successfully" });
            }
            catch (Exception ex)
            {
                // Si hay un error, retornar un mensaje de error
                return Json(new { success = false, message = "Error adding item: " + ex.Message });
            }
        }
    }
}
