using LogisticHub.Domain;
using LogisticHub.Domain.Entities;
using LogisticHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticHub.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly LogisticHubContext _context;
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Orders()
        {
            try
            {
                var orders = _context.Orders.ToList();
                return View(orders);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Произошла ошибка при загрузке заказов.";
                return View(new List<DeliveryRequest>()); // Передаем пустой список
            }
        }

        public DeliveryController(LogisticHubContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeliveryRequest model)
        {
            if (ModelState.IsValid)
            {
                //Проверки на дубль не будет да и вообще много чего не будет просто добавление в тупую
                var newOrder = new OrdersApp
                {
                    Id = default,
                    Name = model.Name,
                    Comments = model.Comments,
                    CreateDate = DateTime.UtcNow,
                    ModifyDate = DateTime.UtcNow,
                    PickupCity = model.PickupCity,
                    PickupSreet = model.PickupStreet,
                    DeliveryCity = model.DeliveryCity,
                    DeliveryStreet = model.DeliveryStreet,
                    weight = model.weight,
                    phone = model.Phone,

                };
                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();
                // Можно перенаправить пользователя на страницу подтверждения
                return RedirectToAction("Confirmation");
            }

            return View("Index", model);
        }
        /*        private List<DeliveryRequest> GetOrders()
                {
                    //  Пример данных (замени на свой код получения данных)
                    var orders = new List<DeliveryRequest>()
                    {
                        new DeliveryRequest { OrderId = 1, OrderDate = DateTime.Now.AddDays(-2), CustomerName = "Иван Иванов", DeliveryAddress = "ул. Ленина, 1", TotalAmount = 1500, Status = "Доставлен" },
                        new DeliveryRequest { OrderId = 2, OrderDate = DateTime.Now.AddDays(-1), CustomerName = "Петр Петров", DeliveryAddress = "пр. Мира, 10", TotalAmount = 2000, Status = "В обработке" },
                        new DeliveryRequest { OrderId = 3, OrderDate = DateTime.Now, CustomerName = "Анна Сидорова", DeliveryAddress = "ул. Гагарина, 5", TotalAmount = 1000, Status = "Новый" }
                    };
                    return orders;
                }*/
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose(); // Освобождаем ресурсы DbContext
            }
            base.Dispose(disposing);
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
