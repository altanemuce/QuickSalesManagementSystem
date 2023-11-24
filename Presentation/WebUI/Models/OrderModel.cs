using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public double Price { get; set; }

        [NotMapped]
        public string TransactionId { get; set; }

        [NotMapped]
        public string OrderId { get; set; }
    }
}
