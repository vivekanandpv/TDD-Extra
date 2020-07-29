using System;
using System.Collections.Generic;
using System.Text;

namespace CarInfo.Core.ViewModels
{
    public class CarListViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
    }
}
