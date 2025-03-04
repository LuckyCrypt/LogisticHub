using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticHub.Domain.Entities
{
    public class OrdersApp : Entity
    {
        public required string Name { get; set; }
      
        public required string SenderCity { get; set; }

        public required string SenderSreet { get; set; }

        public required string RecipientСity { get; set; }

        public required string RecipientStreet { get; set; }

        public required float weight { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DateAccept { get; set; }

        public DateTime DateDepart { get; set; }

        public DateTime DateArrival { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}