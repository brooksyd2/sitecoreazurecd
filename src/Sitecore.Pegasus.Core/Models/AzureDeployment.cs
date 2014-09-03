using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Pegasus.Core.Models
{
    public class AzureDeployment
    {
        public string DeploymentId { get; set; }
        public string Location { get; set; }
        public string DeploymentName { get; set; }
        public string DeploymentType { get; set; }
        public string DeploymentSlot { get; set; }
        public string HostedServiceName { get; set; }
        public string Databases { get; set; }
    }
}
