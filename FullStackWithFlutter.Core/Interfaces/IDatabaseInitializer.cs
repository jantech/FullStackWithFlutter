using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackWithFlutter.Core.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task SeedSampleData();
    }
}
