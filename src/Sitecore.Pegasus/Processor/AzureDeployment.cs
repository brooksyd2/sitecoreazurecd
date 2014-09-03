using System.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Pegasus.Core.Configuration;
using Sitecore.Pegasus.Core.Services;
using Sitecore.Pipelines.HttpRequest;

namespace Sitecore.Pegasus.Processor
{
    public class AzureDeployment : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");

            var deploymentSettings = new AzureDeploymentConfigurationProvider();

            if (deploymentSettings.Settings == null || !Sitecore.Context.RawUrl.Contains(deploymentSettings.Settings.RequestPath)) return;

            var deploymentService = new AzureDeploymentService(deploymentSettings);

            deploymentService.UpdateFiles();

            args.AbortPipeline();
        }
    }
}