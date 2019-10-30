using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string planeModel;
        public int planeMaxSpeed;
        public int planeMaxFlightDistance;
        public int planeMaxLoadCapacity;

        public Plane(string planeModel, int planeMaxSpeed, int planeMaxFlightDistance, int planeMaxLoadCapacity)
        {
            this.planeModel = planeModel;
            this.planeMaxSpeed = planeMaxSpeed;
            this.planeMaxFlightDistance = planeMaxFlightDistance;
            this.planeMaxLoadCapacity = planeMaxLoadCapacity;
        }

        public string GetPlaneModel()
        {
            return this.planeModel;
        }

        public int GetPlaneMaxSpeed()
        {
            return this.planeMaxSpeed;
        }

        public int GetPlaneMaxFlightDistance()
        {
            return this.planeMaxFlightDistance; 
        }

        public int GetPlaneMaxLoadCapacity()
        {
            return this.planeMaxLoadCapacity;
        }

        public override string ToString()
        {
            return "Plane{ model='" + this.planeModel + '\'' +
                ", maxSpeed=" + this.planeMaxSpeed +
                ", maxFlightDistance=" + this.planeMaxFlightDistance +
                ", maxLoadCapacity=" + this.planeMaxLoadCapacity + '}';
        }

        public override bool Equals(object objectToCompare)
        {
            return (objectToCompare as Plane) != null &&
                  planeModel == (objectToCompare as Plane).planeModel &&
                  planeMaxSpeed == (objectToCompare as Plane).planeMaxSpeed &&
                  planeMaxFlightDistance == (objectToCompare as Plane).planeMaxFlightDistance &&
                  planeMaxLoadCapacity == (objectToCompare as Plane).planeMaxLoadCapacity;
        }

        public override int GetHashCode()
        {
            int coefficient = -1521134295;
            return ((((-1043886837 * coefficient) + EqualityComparer<string>.Default.GetHashCode(planeModel))
                * coefficient + planeMaxSpeed.GetHashCode())
                * coefficient + planeMaxFlightDistance.GetHashCode())
                * coefficient + planeMaxLoadCapacity.GetHashCode();
        }        

    }
}
