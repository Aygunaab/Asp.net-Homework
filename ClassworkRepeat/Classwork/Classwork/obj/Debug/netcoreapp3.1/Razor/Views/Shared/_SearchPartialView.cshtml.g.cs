#pragma checksum "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\Shared\_SearchPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b78e9629f39cc140241b91e6fe9c1980aff37da9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchPartialView), @"mvc.1.0.view", @"/Views/Shared/_SearchPartialView.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\_ViewImports.cshtml"
using Classwork;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\_ViewImports.cshtml"
using Classwork.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\_ViewImports.cshtml"
using Classwork.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b78e9629f39cc140241b91e6fe9c1980aff37da9", @"/Views/Shared/_SearchPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aa049beec99011ef7665e89ffddbdcf1f11f57f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Flower>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\Shared\_SearchPartialView.cshtml"
 if (Model.Count > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\Shared\_SearchPartialView.cshtml"
     foreach (var flower in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 8 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\Shared\_SearchPartialView.cshtml"
       Write(flower.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 9 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\Shared\_SearchPartialView.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\Shared\_SearchPartialView.cshtml"
     

}
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>Netice tapilmadi</li>\r\n");
#nullable restore
#line 15 "C:\Users\Admin\OneDrive\Desktop\ClassworkRepeat\Classwork\Classwork\Views\Shared\_SearchPartialView.cshtml"
            }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Flower>> Html { get; private set; }
    }
}
#pragma warning restore 1591
