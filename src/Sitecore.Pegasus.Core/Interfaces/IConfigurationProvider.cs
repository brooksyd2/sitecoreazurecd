using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Pegasus.Core.Interfaces
{
    public interface IConfigurationProvider<out T>
    {
        T Settings { get; }
    }
}
