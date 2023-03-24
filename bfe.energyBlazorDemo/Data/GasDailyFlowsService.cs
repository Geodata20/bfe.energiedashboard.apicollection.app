using bfe.Energy.Api;

namespace bfe.energyBlazorDemo.Data
{

    public class GasDailyFlowsService
    {

        public async Task<List<DailyGasFlowInAndOutOfCHModel>> GetGasFlowAsync()
        {
            string baseUrl = "https://bfeprototype.sh1.hidora.com/";

            var apiClient = new BfeEnergyApi(baseUrl, new HttpClient());

            var result = await apiClient.GetDailyGasFlowInAndOutOfCHAsync();

            return result.ToList();

        }
    }
}