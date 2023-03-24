namespace bfe.energiedashboard.landesundenergieverbrauch.Models
{
    public class DailyElectricityFlowInAndOutOfCHModel
    {

        public DateTime Datetime { get; set; }

        public double AT_CH_MW { get; set; }

        public double DE_CH_MW { get; set; }

        public double FR_CH_MW { get; set; }

        public double IT_CH_MW { get; set; }

        public double CH_AT_MW { get; set; }

        public double CH_DE_MW { get; set; }

        public double CH_FR_MW { get; set; }

        public double CH_IT_MW { get; set; }

        public double Nettoimport { get; set; }

    }
}
