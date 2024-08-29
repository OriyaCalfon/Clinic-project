namespace Clinic.API.Models
{
    public class AppointmentPostModel
    {
        public string Title { get; set; }
        public int Hour { get; set; }

        public int Day { get; set; }


        public int BabyId { get; set; }
        public int NurseId { get; set; }
    }
}
