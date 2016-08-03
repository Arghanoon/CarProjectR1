using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Cars
{
    public class NewCar
    {
        public Car CarGeneral { get; set; }
        public List<byte[]> CarImages { get; set; } 


        public NewCar()
        {
            CarGeneral = new Car();
        }
    }
}