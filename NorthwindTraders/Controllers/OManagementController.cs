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

        //public IActionResult Create()
        //{
        //    int orderId = HttpContext.Session.GetInt32("CurrentOrderId") ?? 0;
        //    ViewData["CurrentOrderId"] = orderId;
        //    return View();
        //}
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
                HttpContext.Session.SetInt32("CurrentOrderId", orderId);
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
        public async Task<IActionResult> AddItem([FromBody] CreateOrderDetailRequest request)
        {
            if (request == null || request.Quantity <= 0 || request.UnitPrice <= 0M) return BadRequest("Invalid item data.");

            int? orderId = HttpContext.Session.GetInt32("CurrentOrderId");
            request.OrderId = orderId!.Value;

            await orderDetailService.CreateOrderAsync(request);

            return Json(new { success = true, message = "Item added successfully" });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteItem([FromBody] DeleteItemRequest request)
        {
            if (request.OrderId <= 0 || request.ProductId <= 0) return BadRequest("Invalid item data.");
            await orderDetailService.DeleteOrderDetailAsync(request.OrderId, request.ProductId);
            return Json(new { success = true, message = "Item deleted successfully" });
        }
    }
}
