using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace $safeprojectname$.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class HealthViewModel
    {
        public IList<HealthItemViewModel>? HealthItems { get; set; }
    }
}
