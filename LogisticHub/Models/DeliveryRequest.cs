using System.ComponentModel.DataAnnotations;

namespace LogisticHub.Models
{
    public class DeliveryRequest
    {
        public required int OrderId { get; set; }
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [Display(Name = "Имя")]
        public required string Name { get; set; }


        [Required(ErrorMessage = "Телефон обязателен для заполнения")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        [Display(Name = "Телефон")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Адрес отправки обязателен для заполнения")]
        [Display(Name = "Адрес отправки")]
        public required string PickupCity { get; set; }

        [Required(ErrorMessage = "Адрес отправки обязателен для заполнения")]
        [Display(Name = "Адрес отправки")]
        public required string PickupStreet { get; set; }

        [Required(ErrorMessage = "Адрес доставки обязателен для заполнения")]
        [Display(Name = "Адрес доставки")]
        public required string DeliveryCity { get; set; }


        [Required(ErrorMessage = "Адрес доставки обязателен для заполнения")]
        [Display(Name = "Адрес доставки")]
        public required string DeliveryStreet { get; set; }


        [Display(Name = "Комментарии")]
        [DataType(DataType.Text)]
        public required float weight { get; set; }


    }
}
