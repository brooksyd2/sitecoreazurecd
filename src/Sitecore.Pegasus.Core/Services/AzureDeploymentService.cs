using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Azure.Managers;
using Sitecore.Diagnostics;
using Sitecore.Pegasus.Core.Interfaces;
using Sitecore.Pegasus.Core.Models;

namespace Sitecore.Pegasus.Core.Services
{
    public class AzureDeploymentService 
    {
        private readonly IConfigurationProvider<AzureDeploymentSettings> _configurationProvider;

        public AzureDeploymentService(IConfigurationProvider<AzureDeploymentSettings> configurationProvider)
        {
             _configurationProvider = configurationProvider;
        }

        public void UpdateFiles()
        {
            //If no subscriptionId passed in parameters then use configuration provided id
            var subscriptionId = _configurationProvider.Settings.SubscriptionId;

            //Get list of environments
            IEnumerable<Sitecore.Azure.Deployments.Environments.Environment> environments =
                Sitecore.Azure.Deployments.Environments.Environment.GetEnvironments(subscriptionId);

            //Loop through environments and deployments
            foreach (var deployment in environments.SelectMany(environment => AzureDeploymentManager.Current.GetDeployments(environment)))
            {
                AzureDeploymentManager.Current.UpgradeDeploymentAsync(deployment);

                Log.Info(string.Format("Updated deployment : {0}", deployment.DisplayName), this);
            }
        }

        public void SwapDeployments()
        {
            //If no subscriptionId passed in parameters then use configuration provided id
            var subscriptionId = _configurationProvider.Settings.SubscriptionId;

            //Get list of environments
            IEnumerable<Sitecore.Azure.Deployments.Environments.Environment> environments =
                Sitecore.Azure.Deployments.Environments.Environment.GetEnvironments(subscriptionId);

            //Loop through environments and deployments
            foreach (var deployment in environments.SelectMany(environment => AzureDeploymentManager.Current.GetDeployments(environment)))
            {
                AzureDeploymentManager.Current.SwapAsync(deployment);

                Log.Info(string.Format("Swapped deployment : {0}", deployment.DisplayName), this);
            }
        }

        public AzureDeployments GetDeployments()
        {

            var azureDeployments = new AzureDeployments
                                       {SubscriptionId = _configurationProvider.Settings.SubscriptionId};

            //Get list of environments
            IEnumerable<Sitecore.Azure.Deployments.Environments.Environment> environments =
                Sitecore.Azure.Deployments.Environments.Environment.GetEnvironments(azureDeployments.SubscriptionId);

            if (environments != null)
            {
                foreach (var environment in environments)
                {
                    //Create new environment
                    var azureEnvironment = new AzureEnvironment { EnvironmentId = environment.EnvironmentId, Environment = environment.DisplayName };

                    foreach (var deployment in environment.GetDeployments())
                    {
                        //Add deployment to collection
                        azureEnvironment.Deployment.Add(
                            new AzureDeployment
                                {
                                    DeploymentId = deployment.ID.ToString(),
                                    Location = deployment.WebRole.Farm.Location.Name,
                                    DeploymentName = deployment.DisplayName,
                                    DeploymentType = deployment.DeploymentType.ToString(),
                                    DeploymentSlot = deployment.DeploymentSlot.ToString(),
                                    HostedServiceName = deployment.HostedServiceName,
                                    Databases = deployment.DatabaseReferences.DisplayName
                                });
                    }

                    //Add environment to collection
                    azureDeployments.Deployments.Add(azureEnvironment);

                }

            }
            else
            {
                //Log action
                Log.Info(string.Format("No deployments found for Subscription ID : {0}", _configurationProvider.Settings.SubscriptionId), this);
            }

            return azureDeployments;
        }
    }
}
