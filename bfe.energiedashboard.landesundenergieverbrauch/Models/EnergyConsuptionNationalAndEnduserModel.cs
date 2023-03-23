namespace bfe.energiedashboard.landesundenergieverbrauch.Models
{
    public class EnergyConsuptionNationalAndEnduserModel
    {
        public DateTime Datum { get; set; }

        public int Landesverbrauch_GWh { get; set; }

        public int Endverbrauch_GWh { get; set; }

    }
}