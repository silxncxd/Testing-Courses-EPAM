using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            planes = planes.ToList();
        }

        public IEnumerable<PassengerPlane> GetPassengerPlanes()
        {
            return planes.Where(plane => plane.GetType() == typeof(PassengerPlane)).Cast<PassengerPlane>();
        }

        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            return planes.Where(plane => plane.GetType() == typeof(MilitaryPlane)).Cast<MilitaryPlane>();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengerPlanes().Aggregate((passengerPlane, plane) =>
                passengerPlane.GetPassengersCapacity() > plane.GetPassengersCapacity() ? passengerPlane : plane);
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
             return GetMilitaryPlanes().Where(plane => plane.GetPlaneType() == MilitaryType.TRANSPORT);
        }

        public Airport SortPlanesByMaxFlightDistance()
        {
            return new Airport(planes.OrderBy(w => w.GetPlaneMaxFlightDistance()));
        }

        public Airport SortPlanesByMaxSpeed()
        {
            return new Airport(planes.OrderBy(w => w.GetPlaneMaxSpeed()));
        }

        public Airport SortPlanesByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(w => w.GetPlaneMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", planes.Select(x => x.GetPlaneModel())) + '}';
        }
    }
}
