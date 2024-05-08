using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Andrew Larson
    /// Created:            04/9/2024
    /// Summary:            manager class for confiscated items
    /// Last Updated By:    Andrew Larson
    /// Last Updated:       04/9/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class ConfiscatedItemManager : IConfiscatedItemManager
    {
        IConfiscatedItemAccessor _confiscatedItemAccessor;
        public ConfiscatedItemManager()
        {
            _confiscatedItemAccessor = new ConfiscatedItemAccessor();
        }

        public ConfiscatedItemManager(IConfiscatedItemAccessor confiscatedItemAccessor)
        {
            _confiscatedItemAccessor = confiscatedItemAccessor;
        }

        public bool AddConfiscatedItem(string itemConfiscated, string reasonForConfiscation)
        {
            bool result = false;
            try
            {
                if( _confiscatedItemAccessor.AddConfiscatedItem(itemConfiscated, reasonForConfiscation) == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add item", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/9/2024
        /// Summary:            returns a list of all confiscated items
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/9/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<ConfiscatedItem> GetAllConfiscatedItems()
        {
            try
            {
                return _confiscatedItemAccessor.GetAllConfiscatedItems();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve all confiscated items", ex);
            }
        }
    }
}
