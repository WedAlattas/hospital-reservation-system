namespace hospital_reservation_system.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
