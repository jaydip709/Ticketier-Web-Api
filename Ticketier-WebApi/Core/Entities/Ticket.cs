using System.ComponentModel.DataAnnotations;

namespace Ticketier_WebApi.Core.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerPhoneNumber { get; set; }
        public string PassengerSSN { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int  Price { get; set; }
        public DateTime CreatedAt {  get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set;}= DateTime.Now;
        public string ConfidentialComment { get; set; } = "Normal";

    }
}
