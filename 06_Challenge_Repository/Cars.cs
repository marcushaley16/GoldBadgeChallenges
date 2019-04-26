using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge_Repository
{
    public enum CarType
    {
        Electric = 1,
        Hybrid,
        Gas
    }

    public class Car
    {
        public CarType Type { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public int DoorNumber { get; set; }
        public string CarColor { get; set; }
        public int CarID { get; set; }

        public Car () { }
        public Car (CarType type, string carMake, string carModel, int carYear, int doorNumber, string carColor, int carID)
        {
            Type = type;
            CarMake = carMake;
            CarModel = carModel;
            CarYear = carYear;
            DoorNumber = doorNumber;
            CarColor = carColor;
            CarID = carID;
        }
    }
}
