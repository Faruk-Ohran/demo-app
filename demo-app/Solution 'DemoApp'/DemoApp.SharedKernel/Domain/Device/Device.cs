namespace DemoApp.SharedKernel.Domain.Device
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int UserId { get; set; }
        public User.User User { get; set; }
    }
}