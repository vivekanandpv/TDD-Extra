using System;
using System.Collections.Generic;
using System.Text;

namespace CarInfo.Core.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
        public string VIN { get; set; } //  vehicle identification number

        //  system fields
        public DateTime CreatedOn { get; set; }
        public string UID { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
