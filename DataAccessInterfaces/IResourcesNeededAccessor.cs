using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/08/2024
    /// Summary: Resources Needed Accessor Interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// Last Updated By: Andrew Larson
    /// Last Updated: 2/19/2024
    /// What Was Changed: Added AddResourcesNeeded method
    /// </summary>

    public interface IResourcesNeededAccessor
    {
        // this method obtains all active resources needed
        List<ResourcesNeeded> SelectActivelyNeededResources();

        // this method obtains resources needed based upon category selected
        List<ResourcesNeeded> SelectResourcesNeededByCategory(string category);

        // this method will select all resource categories
        List<string> SelectAllResourceCategories();

        // this method updates a needed resource
        int UpdateResourceNeeded(ResourcesNeeded oldResourceNeeded, ResourcesNeeded newResourceNeeded);

        int AddResourcesNeeded(string resourceID, string category);
    }
}
