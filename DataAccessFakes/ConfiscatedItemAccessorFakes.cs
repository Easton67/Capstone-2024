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
    /// Creator:            Andrew Larson
    /// Created:            04/9/2024
    /// Summary:            data access fakes class for confiscated items
    /// Last Updated By:    Andrew Larson
    /// Last Updated:       04/9/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class ConfiscatedItemAccessorFakes : IConfiscatedItemAccessor
    {
        List<ConfiscatedItem> _confiscatedItems = new List<ConfiscatedItem>();

        public ConfiscatedItemAccessorFakes() 
        {
            _confiscatedItems.Add(new ConfiscatedItem
            { 
                LogConfiscatedItemsID = 1,
                ItemsConfiscated = "Mike's Hard Lemonade",
                ConfiscationDate = DateTime.Parse("04-09-2024"),
                ReasonForConfiscation = "Not allowed"
            });
            _confiscatedItems.Add(new ConfiscatedItem
            {
                LogConfiscatedItemsID = 2,
                ItemsConfiscated = "Knife",
                ConfiscationDate = DateTime.Parse("06-19-2023"),
                ReasonForConfiscation = "Knives not allowed on property"
            });
            _confiscatedItems.Add(new ConfiscatedItem
            {
                LogConfiscatedItemsID = 3,
                ItemsConfiscated = "Drugs",
                ConfiscationDate = DateTime.Parse("04-20-2024"),
                ReasonForConfiscation = "Drugs are not tolerated"
            });
            _confiscatedItems.Add(new ConfiscatedItem
            {
                LogConfiscatedItemsID = 4,
                ItemsConfiscated = "Mike's Hard Lemonade",
                ConfiscationDate = DateTime.Parse("04-10-2024"),
                ReasonForConfiscation = "He had more"
            });
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/15/2024
        /// Summary:            adds a new item to the confiscated item list and returns the number of rows affected
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/9/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int AddConfiscatedItem(string itemConfiscated, string reasonForConfiscation)
        {
            int result = 0;
            int oldCount = _confiscatedItems.Count;
            _confiscatedItems.Add(new ConfiscatedItem { LogConfiscatedItemsID = 5, ItemsConfiscated = "test item", ConfiscationDate = DateTime.Parse("04-15-2024"), ReasonForConfiscation = "test reason" });
            result = _confiscatedItems.Count - oldCount;
            return result;
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/9/2024
        /// Summary:            returns a list of all fake confiscated items
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/9/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<ConfiscatedItem> GetAllConfiscatedItems()
        {
            return _confiscatedItems;
        }
    }
}
