using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Pegasus.Core.Models
{
    public class AzureEnvironment
    {
        public AzureEnvironment()
        {
            Deployment = new List<AzureDeployment>();
        }

        public string Environment { get; set; }
        public Guid EnvironmentId { get; set; }
        public IList<AzureDeployment> Deployment { get; set; }
    }
}
