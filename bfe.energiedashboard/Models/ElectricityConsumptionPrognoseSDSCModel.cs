namespace bfe.energiedashboard.landesundenergieverbrauch.Models
{
    public class ElectricityConsumptionPrognoseSDSCModel
    {
        public DateTime Datum { get; set; }

        public int Endverbrauch_Prognose_Min_GWh { get; set; }

        public int Endverbrauch_Prognose_Mittel_GWh { get; set; }

        public int Endverbrauch_Prognose_Max_GWh { get; set; }
    }
}
