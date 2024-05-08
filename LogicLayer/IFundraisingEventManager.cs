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
    /// Created: 04/11/2024
    /// Summary: Fundraising Event Manager Interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/11/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public interface IFundraisingEventManager
    {
        bool CreateFundraisingEvent(FundraisingEvent fundraisingEvent);
        List<FundraisingEvent> GetFundraisingEvents();
    }
}
