#pragma checksum "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "973c1c2e7270c9fb34a9d0a4e5749aafc044d0c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewWedding), @"mvc.1.0.view", @"/Views/Home/ViewWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewWedding.cshtml", typeof(AspNetCore.Views_Home_ViewWedding))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/_ViewImports.cshtml"
using weddingPlanner;

#line default
#line hidden
#line 2 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/_ViewImports.cshtml"
using weddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"973c1c2e7270c9fb34a9d0a4e5749aafc044d0c9", @"/Views/Home/ViewWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d2f7e7fad137d735531a94f00fd8cb8297fea8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WrapperModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(20, 89, true);
            WriteLiteral("\n<div class=\"container\">\n    <div class=\"row\">\n        <div class=\"col\">\n            <h3>");
            EndContext();
            BeginContext(110, 26, false);
#line 6 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml"
           Write(Model.newWedding.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(136, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(140, 26, false);
#line 6 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml"
                                         Write(Model.newWedding.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(166, 271, true);
            WriteLiteral(@"</h3>
        </div>
        <div class=""col"">
            <a href=""/Dashboard"" class=""btn btn-success"">Dashboard</a>
            <a href=""/SignOut"" class=""btn btn-dark"">Log Out</a>
        </div>
    </div>
    <div class=""row"">
        <div class=""col"">
            <p>");
            EndContext();
            BeginContext(438, 21, false);
#line 15 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml"
          Write(Model.newWedding.Date);

#line default
#line hidden
            EndContext();
            BeginContext(459, 31, true);
            WriteLiteral("</p>\n            <p>Guests</p>\n");
            EndContext();
#line 17 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml"
              
                foreach(var guest in Model.newWedding.WeddingGuest)
                {

#line default
#line hidden
            BeginContext(591, 23, true);
            WriteLiteral("                    <p>");
            EndContext();
            BeginContext(615, 20, false);
#line 20 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml"
                  Write(guest.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(635, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(637, 19, false);
#line 20 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml"
                                        Write(guest.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(656, 5, true);
            WriteLiteral("</p>\n");
            EndContext();
#line 21 "/Users/katherinemartin/Documents/CodingDojo/csharp/weddingPlanner/Views/Home/ViewWedding.cshtml"
                }
            

#line default
#line hidden
            BeginContext(693, 650, true);
            WriteLiteral(@"        </div>
        <div class=""col"">
            <div id=""map""></div>
            <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyCrYEpsKhOJ9vtrNVnobGxE8S-ecaws8kw&callback=initMap"" async defer>
            </script>
            <script>
                var map;
                var geocoder;
                function initMap(){
                    map = new google.maps.Map(document.getElementById('map'),{
                        zoom:8,
                        center:{lat:47.36,lng:-122.20},
                        height: 100%
                    });
                }
            </script>
        </div>
    </div>
</div>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WrapperModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
