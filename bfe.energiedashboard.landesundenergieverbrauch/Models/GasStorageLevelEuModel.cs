namespace bfe.energiedashboard.landesundenergieverbrauch.Models
{
    public class GasStorageLevelEuModel
    {
        public DateTime Datum { get; set; }

        public string Speicherregion { get; set; }

        public double Speicherstand_TWh { get; set; }

        public double Lagerkapazitaet_prozent { get; set; }

    }
}
