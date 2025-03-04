using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticHub.Domain.Entities
{
    public class OrdersApp : Entity
    {
        public required string Name { get; set; }
      
        public required string PickupCity { get; set; }

        public required string PickupSreet { get; set; }

        public required string DeliveryCity { get; set; }

        public required string DeliveryStreet { get; set; }

        public required float weight { get; set; }

        public required string phone { get; set; }

        public required string Comments { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

    }
}