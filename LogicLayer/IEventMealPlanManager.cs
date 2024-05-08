using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 03/29/2024
    /// Summary: Event Meal Plan Manager Interface
    /// Last Updated: 03/29/2024
    /// Last Updated By: Kirsten Stage
    /// What Was Changed: Initial Creation
    /// </summary>

    public interface IEventMealPlanManager
    {
        EventMealPlan GetMealPlanByName(string eventName);
    }
}
