using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Pegasus.Core.Interfaces;
using Sitecore.Pegasus.Core.Models;

namespace Sitecore.Pegasus.Core.Configuration
{
    public class AzureDeploymentConfigurationProvider : IConfigurationProvider<AzureDeploymentSettings>
    {
        public AzureDeploymentConfigurationProvider()
        {
            var config = AzureDeploymentConfiguration.GetConfiguration();

            Settings = new AzureDeploymentSettings
            {
                IsEnabled = config.Enabled,
                SubscriptionId = config.Subscription
            };

        }

        public AzureDeploymentSettings Settings { get; private set; }
    }
}
