using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessFakes;
using System.Collections.Generic;
using DataObjects;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/08/2024
    /// Summary: Created the Resources Needed unit tests.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// Last Updated By: Andrew Larson
    /// Last Updated: 2/19/2024
    /// What Was Changed: Added AddResourcesNeeded tests
    /// </summary>

    [TestClass]
    public class ResourcesNeededTests
    {
        private ResourcesNeededManager _resourcesNeededManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _resourcesNeededManager = new ResourcesNeededManager(new ResourcesNeededAccessorFakes());
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/08/2024
        /// Summary: Testing the GetActiveResourcesNeeded() method using the ResourcesNeededAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetActiveResourcesNeededWorksCorrectly()
        {
            // arrange
            List<ResourcesNeeded> rn = _resourcesNeededManager.GetActiveResourcesNeeded();
            int expectedCount = 2;
            int actualCount = 0;

            // act
            actualCount = rn.Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);

        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: Testing the GetResourcesByCategory() method using the ResourcesNeededAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetResourcesByCategoryReturnsCorrectList()
        {
            // arrange
            string category = "category1";
            int expectedCount = 1;
            int actualCount = 0;

            // act
            actualCount = _resourcesNeededManager.GetResourcesByCategory(category).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: Testing the GetResourceCategoriesForDropDown() method using the ResourcesNeededAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetResourceCategoriesForDropDownReturnsCorrectList()
        {
            // arrange
            int expectedCount = 3;
            int actualCount = 0;

            // act
            actualCount = (_resourcesNeededManager.GetResourceCategoriesForDropDown()).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: Testing the EditResourceNeeded() method using the ResourcesNeededAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestEditResourceNeededWorksCorrectly()
        {
            // arrange
            ResourcesNeeded oldResource = new ResourcesNeeded
            {
                ResourceID = "resource1",
                Category = "category1",
                Active = true
            };
            ResourcesNeeded newResource = new ResourcesNeeded
            {
                ResourceID = "resource1",
                Category = "category2",
                Active = true
            };
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _resourcesNeededManager.EditResourceNeeded(oldResource, newResource);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

            /// <summary>
            /// Creator: Andrew Larson
            /// Created: 02/19/2024
            /// Summary: Testing the AddResourcesNeeded() method using the ResourcesNeededAccessorFakes class. 
            /// Last Updated By: Andrew Larson
            /// Last Updated: 02/19/2024
            /// What Was Changed: Initial Creation
            /// </summary>
            [TestMethod]
            public void TestAddResourcesNeededReturnsAValuesWithValidInputs()
            {
                bool expectedResult = true;

                bool actualResult = _resourcesNeededManager.AddResourcesNeeded("TestResourceID", "TestCategory");

                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
