using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private int passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object objectToCompare)
        {
            return (objectToCompare as PassengerPlane) != null &&
                   base.Equals(objectToCompare) &&
                   passengersCapacity == (objectToCompare as PassengerPlane).passengersCapacity;
        }

        public override int GetHashCode()
        {
            int coefficient = -1521134295;
            return ((751774561 * coefficient) + base.GetHashCode()) * coefficient + passengersCapacity.GetHashCode();

        }

        public int GetPassengersCapacity()
        {
            return passengersCapacity;
        }

       
        public override string ToString()
        {
            return base.ToString().Replace("}", ", passengersCapacity=" + passengersCapacity + '}');
        }       
        
    }
}
