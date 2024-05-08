using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/08/2024
    /// Summary: Resources Needed class that implements IResourcesNeeded interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// Last Updated By: Andrew Larson
    /// Last Updated: 2/19/2024
    /// What Was Changed: Created AddResourcesNeeded method.
    /// </summary>

    public class ResourcesNeededManager : IResourcesNeededManager
    {
        private IResourcesNeededAccessor _resourcesNeededAccessor = null;

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/08/2024
        /// Summary: Created two constructors for dependency inversion.
        ///          The first is for the presentation layer and the second is 
        ///          for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// Last Updated By: Andrew Larson
        /// Last Updated: 2/19/2024
        /// What Was Changed: Implemented the AddResourcesNeeded method.
        /// </summary>

        public ResourcesNeededManager()
        {
            _resourcesNeededAccessor = new ResourcesNeededAccessor();
        }

        public ResourcesNeededManager(IResourcesNeededAccessor resourcesNeededAccessor)
        {
            _resourcesNeededAccessor = resourcesNeededAccessor;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/19/2024
        /// Summary: Created the AddResourcesNeeded() method.
        /// Last Updated By: Andrew Larson
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool AddResourcesNeeded(string resourceID, string category)
        {
            bool result = false;
            try
            {
                result = (1 == _resourcesNeededAccessor.AddResourcesNeeded(resourceID, category));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error adding resources needed", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: Created the EditResourceNeeded() method. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public bool EditResourceNeeded(ResourcesNeeded oldResourceNeeded, ResourcesNeeded newResourceNeeded)
        {
            bool result = false;

            try
            {
                result = (1 == _resourcesNeededAccessor.UpdateResourceNeeded(oldResourceNeeded, newResourceNeeded));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Resource not updated.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/08/2024
        /// Summary: Created the GetActiveResourcesNeeded() method. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<ResourcesNeeded> GetActiveResourcesNeeded()
        {
            List<ResourcesNeeded> rn = new List<ResourcesNeeded>();

            try
            {
                rn = _resourcesNeededAccessor.SelectActivelyNeededResources();

                if (rn == null || rn.Count == 0)
                {
                    throw new ArgumentException("No resources needed found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found.", ex);
            }

            return rn;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: Created the GetResourcesByCategory() method. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<ResourcesNeeded> GetResourcesByCategory(string category)
        {
            List<ResourcesNeeded> rn = null;

            try
            {
                rn = _resourcesNeededAccessor.SelectResourcesNeededByCategory(category);

                if (rn == null || rn.Count == 0)
                {
                    throw new ArgumentException("Resources not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found", ex);
            }

            return rn;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: Created the GetResourceCategoriesForDropDown() method. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<string> GetResourceCategoriesForDropDown()
        {
            List<string> categoryList = null;

            try
            {
                categoryList = _resourcesNeededAccessor.SelectAllResourceCategories();

                if (categoryList == null || categoryList.Count == 0)
                {
                    throw new ArgumentException("Categories not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found", ex);
            }

            return categoryList;
        }
    }
}
