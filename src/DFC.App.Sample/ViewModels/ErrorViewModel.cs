using System.Diagnostics.CodeAnalysis;

namespace $safeprojectname$.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrWhiteSpace(RequestId);
    }
}