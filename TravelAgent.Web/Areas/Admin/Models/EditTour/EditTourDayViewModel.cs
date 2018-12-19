namespace TravelAgent.Web.Areas.Admin.Models.EditTour
{
    public class EditTourDayViewModel
    {
        public int DayId { get; set; }

        public string DayTitle { get; set; }

        public string DayDescription { get; set; }

        public byte[] DayPicture { get; set; }
    }
}
