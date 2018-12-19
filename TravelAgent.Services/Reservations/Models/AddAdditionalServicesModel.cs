namespace TravelAgent.Services.Reservations.Models
{

    public class AddAdditionalServicesModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public decimal Price { get; set; }

        public bool IsSelected { get; set; }
    }
}
