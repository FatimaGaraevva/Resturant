namespace Resturants.ViewModels.ReservationVM
{
    public class GetReservationVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
