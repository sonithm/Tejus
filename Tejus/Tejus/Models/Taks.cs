using System;
using System.Collections.Generic;
using System.Text;

namespace Tejus.Models
{
    public class Tareas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class TEJUSDonorModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string BloodGroup { get; set; }
        public string Type { get; set; }
    }
}
