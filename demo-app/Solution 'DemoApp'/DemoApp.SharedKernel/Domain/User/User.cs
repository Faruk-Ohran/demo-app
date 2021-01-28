using System.Collections.Generic;

namespace DemoApp.SharedKernel.Domain.User
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Device.Device> Devices { get; set; }
    }
}