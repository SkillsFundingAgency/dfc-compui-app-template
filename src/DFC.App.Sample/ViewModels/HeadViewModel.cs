﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace $safeprojectname$.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class HeadViewModel
    {
        public string? Title { get; set; }

        public Uri? CanonicalUrl { get; set; }

        public string? Description { get; set; }

        public string? Keywords { get; set; }
    }
}
