#pragma checksum "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Newsletter\SendEmailInitial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e33888619e97b8bdac4b8b4e80ac1d1c73598f47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Newsletter_SendEmailInitial), @"mvc.1.0.view", @"/Views/Newsletter/SendEmailInitial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Newsletter/SendEmailInitial.cshtml", typeof(AspNetCore.Views_Newsletter_SendEmailInitial))]
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
#line 1 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Web;

#line default
#line hidden
#line 2 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Web.Models;

#line default
#line hidden
#line 3 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Web.Models.Tours;

#line default
#line hidden
#line 4 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Web.Models.Contacts;

#line default
#line hidden
#line 5 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Services.Newsletter.Models;

#line default
#line hidden
#line 6 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Services.Tours.Models;

#line default
#line hidden
#line 7 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Services.Reservations.Models;

#line default
#line hidden
#line 8 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Web.Infrastructure.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e33888619e97b8bdac4b8b4e80ac1d1c73598f47", @"/Views/Newsletter/SendEmailInitial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45e7f56dc290bd9852c7b824264c7c07fd46c35e", @"/Views/_ViewImports.cshtml")]
    public class Views_Newsletter_SendEmailInitial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SubscribersServiceModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Newsletter\SendEmailInitial.cshtml"
   
    Layout = null;

#line default
#line hidden
            BeginContext(60, 382, true);
            WriteLiteral(@"
<div class=""row"" borderstyle=""solid"">
    <div class=""col-md-12"">
        <h4>
            Hello!
            You applied to receive newsletters from our Tour Agency for our new tours, holidays, news and promotions!
            To be sure, that this registration is send from you, please confirm Your e-mail:
        </h4>
        <br />
        <a class=""btn btn-success""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 442, "\"", 523, 4);
            WriteAttributeValue("", 449, "https://localhost:5001/Newsletter/Confirm?email=", 449, 48, true);
#line 14 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Newsletter\SendEmailInitial.cshtml"
WriteAttributeValue("", 497, Model.Email, 497, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 509, "&key=", 509, 5, true);
#line 14 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Newsletter\SendEmailInitial.cshtml"
WriteAttributeValue("", 514, Model.Id, 514, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(524, 126, true);
            WriteLiteral(">CONFIRM YOUR SUBSCRIPTION</a>\r\n        <br />\r\n        <h4>\r\n            If you have not applied, please do not confirm or <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 650, "\"", 730, 4);
            WriteAttributeValue("", 657, "https://localhost:5001/Newsletter/Reject?email=", 657, 47, true);
#line 17 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Newsletter\SendEmailInitial.cshtml"
WriteAttributeValue("", 704, Model.Email, 704, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 716, "&key=", 716, 5, true);
#line 17 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Newsletter\SendEmailInitial.cshtml"
WriteAttributeValue("", 721, Model.Id, 721, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(731, 314, true);
            WriteLiteral(@">reject here!</a>
        </h4>
        <br />
    </div>
    <hr>
    <div class=""col-lg-12"">
        <h5>Travel Agency</h5>
        <h5>Contact information:</h5>
        <h5>Phone: 08888888888</h5>
        <h5>E-mail: girginchev@abv.bg</h5>
        <h5>www.travelagency.com</h5>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SubscribersServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
