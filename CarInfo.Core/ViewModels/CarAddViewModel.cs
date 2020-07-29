using System;
using System.Collections.Generic;
using System.Text;

namespace CarInfo.Core.ViewModels
{
    public class CarAddViewModel
    {
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
        public string VIN { get; set; }
    }
}
