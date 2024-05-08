using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IPartsInventoryAccessor
    {
        /* 
        <summary>
            Creator:            Mitchell Stirmel
            Created:            02/07/2024
            Summary:            IPartsInventoryAccessor.cs
            Last Updated By:    Darryl Shirley
            Last Updated:       02/07/2024
            What Was Changed:   Initial creation  
        </summary>
        */
        List<PartsInventory> SelectAllMaintenanceItems();
        List<PartsInventory> ViewPartsInventory();
        DateTime ViewLastUpdatedTime();
        int InsertPartsInventory(PartsInventory partsInventory);
        int DeletePartsInventory(string partId);
        List<string> SelectAllStockType();
        List<string> SelectAllCategory();
    }
}
