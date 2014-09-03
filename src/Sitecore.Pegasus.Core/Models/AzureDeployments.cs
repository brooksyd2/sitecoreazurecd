using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Pegasus.Core.Models
{
    public class AzureDeployments
    {
        public AzureDeployments()
        {
            SubscriptionId = string.Empty;
            Deployments = new List<AzureEnvironment>();
        }

        public string SubscriptionId { get; set; }
        public IList<AzureEnvironment> Deployments { get; set; } 
    }
}
