#pragma checksum "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac2d4847f41ac0a8ec570354ff8742b5fbb1662a"
// <auto-generated/>
#pragma warning disable 1591
namespace OpportunitiesDraft1.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\_Imports.razor"
using OpportunitiesDraft1.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
using OpportunitiesDraft1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
using OpportunitiesDraft1.Services;

#line default
#line hidden
#nullable disable
    public partial class BAMEBusinesses : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "card-columns m-5 h-100");
            __builder.AddMarkupContent(2, "\r\n");
#nullable restore
#line 9 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
     foreach (var bame in BAMEService.GetFeaturedBAME())
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "        ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "card m-3 h-100");
            __builder.AddMarkupContent(6, "\r\n            ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "m-2");
            __builder.OpenElement(9, "img");
            __builder.AddAttribute(10, "class", "card-img");
            __builder.AddAttribute(11, "src", 
#nullable restore
#line 12 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
                                                         bame.ImageUrl

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "alt", "Card image cap");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n            ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "card-body");
            __builder.AddMarkupContent(16, "\r\n                ");
            __builder.OpenElement(17, "h5");
            __builder.AddAttribute(18, "class", "card-title boldText");
            __builder.AddContent(19, 
#nullable restore
#line 14 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
                                                 bame.BusinessName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "card-text");
            __builder.AddMarkupContent(23, "\r\n                    ");
            __builder.OpenElement(24, "p");
            __builder.AddContent(25, 
#nullable restore
#line 16 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
                        bame.Statement

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                    ");
            __builder.OpenElement(27, "p");
            __builder.AddContent(28, "   ");
            __builder.AddContent(29, 
#nullable restore
#line 17 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
                           bame.Description

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                ");
            __builder.AddMarkupContent(32, @"<div class=""card-footer"">
                    <div class=""row"">
                        <span class=""col""></span>
                        <span class=""col bame-icons""><i class=""fa fa-external-link""></i></span>
                        <span class=""col bame-icons""><i class=""fa fa-instagram""></i></span>
                        <span class=""col bame-icons""><i class=""fa fa-facebook""></i></span>
                        <span class=""col""></span>
                    </div>
                </div>

            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
#nullable restore
#line 32 "C:\Users\almat\Opportunities\Website\OpportunitiesDraft1\Components\BAMEBusinesses.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private JsonFileFeaturedBAME BAMEService { get; set; }
    }
}
#pragma warning restore 1591
