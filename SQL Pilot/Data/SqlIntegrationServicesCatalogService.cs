using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.IntegrationServices;
using System.Threading.Tasks;
using System.Linq;

namespace SQL_Pilot.Data
{
    public class SqlIntegrationServicesCatalogService
    {
        private Catalog[] catalogs;

        public Task<Catalog[]> GetCatalogs()
        {
            if (catalogs == null)
            {
                using (var connection = new System.Data.SqlClient.SqlConnection($"Data Source={SqlServer.ServerName};Integrated Security=True;Encrypt=False;Application Name=\"SQL Management\""))
                {
                    connection.Open();
                    IntegrationServices interServices = new IntegrationServices(connection);
                    catalogs = interServices.Catalogs.ToArray();
                }
            }
            return Task.FromResult(catalogs);
        }
    }
}
