namespace EFDemo.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HoAMember
    {
        [Key]
        public string Id { get; set; }

        public string Address { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public double Fees { get; set; }
    }
}
