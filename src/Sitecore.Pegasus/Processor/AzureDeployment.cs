using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;

namespace Sitecore.Pegasus.Processor
{
    public class AzureDeployment : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");

        }
    }
}