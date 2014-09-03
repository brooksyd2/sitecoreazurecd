using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Pegasus.Core.Models
{
    public class AzureDeploymentSettings
    {
        public AzureDeploymentSettings()
        {
            IsEnabled = false;
            SubscriptionId = string.Empty;
            RequestPath = string.Empty;
        }

        public bool IsEnabled { get; set; }
        public string SubscriptionId { get; set; }
        public string RequestPath { get; set; }
    }
}
