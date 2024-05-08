using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/08/2024
    /// Summary: Resources Needed Interface
    /// Last Updated: 02/08/2024
    /// Last Updated By: Andrew Larson
    /// Last Updated: 2/19/2024
    /// What Was Changed: Added AddResourcesNeeded method
	/// Last Updated By: Kirsten Stage
    /// Last Updated: 02/22/2024
    /// What Was Changed: Added the necessary methods for filtering and editing resources needed 
    /// </summary>

    public interface IResourcesNeededManager
    {
        // this method will obtain all resources needed that are currently active
        List<ResourcesNeeded> GetActiveResourcesNeeded();

        // this method will obtain resources needed based upon a selected category
        List<ResourcesNeeded> GetResourcesByCategory(string category);

        // this method will be used to update a resource needed by shelters
        bool EditResourceNeeded(ResourcesNeeded oldResourceNeeded, ResourcesNeeded newResourceNeeded);
		
        bool AddResourcesNeeded(string resourceID, string category);
        List<string> GetResourceCategoriesForDropDown();
    }
}
