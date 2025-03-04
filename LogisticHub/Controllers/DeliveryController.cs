﻿using LogisticHub.Domain;
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
                int numberOrder = newOrder.Id;
                // Можно перенаправить пользователя на страницу подтверждения
                return RedirectToAction("Confirmation",new { numberOrder });
            }

            return View("Index", model);
        }

        public ActionResult Confirmation(int numberOrder)
        {
            ViewData["NumberOrder"] = numberOrder;
            return View();
        }
    }
}
