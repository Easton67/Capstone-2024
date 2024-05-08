using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/08/2024
    /// Summary: Resources Needed Fakes class to help with testing. It implements
    ///          the IResourcesNeededAccessor interface. 
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// Last Updated By: Andrew Larson
    /// Last Updated: 2/19/2024
    /// What Was Changed: Implemented AddResourcesNeeded method into data fakes.
    /// </summary>


    public class ResourcesNeededAccessorFakes : IResourcesNeededAccessor
    {
        private List<ResourcesNeeded> _resourcesNeeded = new List<ResourcesNeeded>();

        public ResourcesNeededAccessorFakes()
        {
            _resourcesNeeded.Add(new ResourcesNeeded
            {
                ResourceID = "resource1",
                Category = "category1",
                Active = true
            });
            _resourcesNeeded.Add(new ResourcesNeeded
            {
                ResourceID = "resource2",
                Category = "category2",
                Active = true
            });
            _resourcesNeeded.Add(new ResourcesNeeded
            {
                ResourceID = "resource3",
                Category = "category3",
                Active = false
            });
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/19/2024
        /// Summary: The implementation of the AddResourcesNeeded() method that is being used for testing
        /// Last Updated By: Andrew Larson
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int AddResourcesNeeded(string resourceID, string category)
        {
            int rows = 0;
            ResourcesNeeded newResource = new ResourcesNeeded
            { 
                ResourceID = resourceID,
                Category = category,
                Active = true
            };
            rows++;
            return rows;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/08/2024
        /// Summary: The implementation of SelectActivelyNeededResources() that is being used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<ResourcesNeeded> SelectActivelyNeededResources()
        {
            List<ResourcesNeeded> rn = new List<ResourcesNeeded>();

            foreach (ResourcesNeeded resource in _resourcesNeeded)
            {
                if (resource.Active)
                {
                    rn.Add(resource);
                }
            }

            return rn;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: The implementation of SelectAllResourceCategories() that is being used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<string> SelectAllResourceCategories()
        {
            List<string> category = new List<string>();

            foreach (ResourcesNeeded rn in _resourcesNeeded)
            {
                category.Add(rn.Category);
            }

            return category;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/08/2024
        /// Summary: The implementation of SelectResourcesNeededByCategory() that is being used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<ResourcesNeeded> SelectResourcesNeededByCategory(string category)
        {
            return _resourcesNeeded.FindAll(r => r.Category == category);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: The implementation of UpdateResourceNeeded() that is being used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public int UpdateResourceNeeded(ResourcesNeeded oldResourceNeeded, ResourcesNeeded newResourceNeeded)
        {
            int rows = 0;

            for (int i = 0; i < _resourcesNeeded.Count; i++)
            {
                if (_resourcesNeeded[i].ResourceID == oldResourceNeeded.ResourceID)
                {
                    _resourcesNeeded[i] = newResourceNeeded;
                    rows += 1;
                }
            }
            if (rows != 1)
            {
                throw new ApplicationException("Resource not updated.");
            }

            return rows;
        }
    }
}
