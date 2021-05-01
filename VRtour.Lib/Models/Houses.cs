using System;
using System.Collections.Generic;
using VRtour.Lib.Enums;

namespace VRtour.Lib.Models
{
    public class Houses
    {
        public decimal Price { get; set; }

        public List<string> VRtours { get; set; }

        public CyprusCityEnum City { get; set; }

        public AreaEnum Area { get; set; }

        public TypeEnum Type { get; set; }

        public ConditionEnum Condition { get; set; }

        public int PlotSizeSquareMeters { get; set; }

        public int NumberOfParkingSpaces { get; set; }

        public int NumberOfBalconies { get; set; }

        public int NumberOfAirCondition { get; set; }

        public int NumberOfBedrooms { get; set; }

        public int NumberOfBathrooms { get; set; }

        public bool IsFurnishing { get; set; }

        public bool HasPool { get; set; }

        public bool HasGarden { get; set; }

        public bool HasElevator { get; set; }

        public bool HasAlarm { get; set; }

        public bool HasFireplace { get; set; }

        public bool HasPlayroom { get; set; }

        public bool HasAtticLoft { get; set; }

        public bool HasStorageRoom { get; set; }

        public bool HasSauna { get; set; }
    }
}
