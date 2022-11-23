using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SQL_Pilot.Data
{
    public class SqlAgentJobService
    {
        private Job[] jobs;

        public Job[] GetJobs()
        {
            if (jobs == null)
            {
                Server server = new Server(SqlServer.ServerName);
                jobs = server.JobServer.Jobs.Cast<Job>()
                                     .OrderByDescending(j => j.LastRunDate)
                                     .ToArray();
            }
            return jobs;
        }
    }
}
