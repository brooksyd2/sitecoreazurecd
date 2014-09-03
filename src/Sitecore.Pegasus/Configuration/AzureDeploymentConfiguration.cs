using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Sitecore.Pegasus.Configuration
{
    public class AzureDeploymentConfiguration : ConfigurationSection
    {
        private const string SectionName = "azuredeployment";
        private const string EnabledKey = "enabled";
        private const string SubscriptionId = "subscriptionId";
        private const string RequestPath = "";

        public static AzureDeploymentConfiguration GetConfiguration()
        {
            var configuration = ConfigurationManager.GetSection(SectionName) as AzureDeploymentConfiguration;
            return configuration ?? new AzureDeploymentConfiguration();
        }

        [ConfigurationProperty(EnabledKey, IsRequired = false, DefaultValue = false)]
        public bool Enabled { get { return (bool)this[EnabledKey]; } }

        [ConfigurationProperty(SubscriptionId, IsRequired = true, DefaultValue = "")]
        public string Subscription { get { return (string)this[SubscriptionId]; } }

        [ConfigurationProperty(RequestPath, IsRequired = true, DefaultValue = "")]
        public string Path { get { return (string)this[RequestPath]; } }
    }
}
