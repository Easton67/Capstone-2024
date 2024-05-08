using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 01/29/2024
    /// Summary: This interface for HoursOfOperation lists 
    /// the required methods to be implemented.
    /// Last Updated By: Andrew Larson
    /// Last Updated 01/29/2024
    /// What was changed: Initial Creation.
    /// </summary>
    public interface IHoursOfOperationManager
    {
        List<Location> GetLocationsByZipCode(int zipCode);
        List<Location> ChangeHoursOfOperationToLocations(List<HoursOfOperation> hoursOfOperationList);
    }
}
