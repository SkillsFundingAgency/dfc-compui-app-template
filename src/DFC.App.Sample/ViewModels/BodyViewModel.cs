﻿using Microsoft.AspNetCore.Html;
using System.Diagnostics.CodeAnalysis;

namespace $safeprojectname$.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class BodyViewModel
    {
        public HtmlString? Body { get; set; } = new HtmlString("Unknown content");
    }
}
