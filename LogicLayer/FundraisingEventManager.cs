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
    /// Created: 04/11/2024
    /// Summary: Fundraising Event Manager class that 
    ///          implements IFundraisingEventManager interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/11/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public class FundraisingEventManager : IFundraisingEventManager
    {
        private IFundraisingEventAccessor _fundraisingEventAccessor = null;

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/11/2024
        /// Summary: Created two constructors for dependency inversion.
        ///          The first is for the presentation layer and the second is 
        ///          for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/11/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public FundraisingEventManager()
        {
            _fundraisingEventAccessor = new FundraisingEventAccessor();
        }

        public FundraisingEventManager(IFundraisingEventAccessor fundraisingEventAccessor)
        {
            _fundraisingEventAccessor = fundraisingEventAccessor;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/11/2024
        /// Summary: Created the CreateFundraisingEvent() method.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/11/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public bool CreateFundraisingEvent(FundraisingEvent fundraisingEvent)
        {
            bool result = false;
            try
            {
                result = (1 == _fundraisingEventAccessor.InsertFundraisingEvent(fundraisingEvent));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error adding fundraising event.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/18/2024
        /// Summary: Created the GetFundraisingEvents() method.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<FundraisingEvent> GetFundraisingEvents()
        {
            List<FundraisingEvent> fe = new List<FundraisingEvent>();

            try
            {
                fe = _fundraisingEventAccessor.RetrieveFundraisingEvents();

                if (fe == null || fe.Count == 0)
                {
                    throw new ArgumentException("No events found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found.", ex);
            }

            return fe;
        }
    }
}
