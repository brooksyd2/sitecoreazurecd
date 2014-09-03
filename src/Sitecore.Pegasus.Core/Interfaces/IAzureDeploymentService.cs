using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Pegasus.Core.Models;

namespace Sitecore.Pegasus.Core.Interfaces
{
    public interface IAzureDeploymentService
    {
        AzureDeployments GetDeployments();
        void UpdateFiles();
        void SwapDeployments();
    }
}
