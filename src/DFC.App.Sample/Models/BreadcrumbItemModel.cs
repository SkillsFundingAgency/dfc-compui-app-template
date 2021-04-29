using System.Diagnostics.CodeAnalysis;

namespace $safeprojectname$.Models
{
    [ExcludeFromCodeCoverage]
    public class BreadcrumbItemModel
    {
        public string? Route { get; set; }

        public string? Title { get; set; }
    }
}
