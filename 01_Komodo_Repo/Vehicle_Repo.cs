using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Repo
{
    public class VehicleRepo
    {
        private List<Vehicle> _repo = new List<Vehicle>();

        public bool AddVehicleToProgram(Vehicle vehicle)
        {
            int startingCount = _repo.Count;

            _repo.Add(vehicle);

            bool vehicleAdded = (_repo.Count > startingCount) ? true : false;
            return vehicleAdded;
        }

        public List<Vehicle> GetVehicles()
        {
            return _repo;
        }

        public Vehicle GetVehicleByModel(string model)
        {
            foreach (Vehicle vehicle in _repo)
            {
                if (vehicle.Model.ToLower() == model.ToLower())
                {
                    return vehicle;
                }
            }
            return null;
        }


        public bool UpdateExistingVehicle(string originalModel, Vehicle newVehicle)
        {
            Vehicle oldVehicle = GetVehicleByModel(originalModel);

            if (oldVehicle != null)
            {
                oldVehicle.Type = newVehicle.Type;
                oldVehicle.Make = newVehicle.Make;
                oldVehicle.Model = newVehicle.Model;
                oldVehicle.MPG = newVehicle.MPG;
                oldVehicle.Range = newVehicle.Range;
                return true;
            }
            else { return false; }
        }


        public bool DeleteExistingVehicle(Vehicle existingVehicle)
        {
            bool wasDeleted = _repo.Remove(existingVehicle);
            return wasDeleted;
        }
    }
}
