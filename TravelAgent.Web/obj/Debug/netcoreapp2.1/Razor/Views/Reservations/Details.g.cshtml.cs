#pragma checksum "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4d4f941dc50b5ab1b31ea2b1d64b87ab10c1d49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservations_Details), @"mvc.1.0.view", @"/Views/Reservations/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reservations/Details.cshtml", typeof(AspNetCore.Views_Reservations_Details))]
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
#line 9 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\_ViewImports.cshtml"
using TravelAgent.Web.Models.Reservations;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4d4f941dc50b5ab1b31ea2b1d64b87ab10c1d49", @"/Views/Reservations/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49e98158984f26560a560cc42931eb805427061a", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservations_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReservationShortDetailsServiceModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("disabled", new global::Microsoft.AspNetCore.Html.HtmlString("disabled"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 810, true);
            WriteLiteral(@"
<aside id=""colorlib-hero"">
    <div class=""flexslider"">
        <ul class=""slides"">
            <li style=""background-image: url(/images/tr10.jpg);"">
                <div class=""overlay""></div>
                <div class=""container-fluid"">
                    <div class=""row"">
                        <div class=""col-md-6 col-md-offset-3 col-sm-12 col-xs-12 slider-text"">
                            <div class=""slider-text-inner text-center"">
                            </div>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
    </div>
</aside>
<div id=""colorlib-contact"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-10 col-md-offset-1 animate-box"">

                <h3>Tour: ");
            EndContext();
            BeginContext(855, 15, false);
#line 25 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
                     Write(Model.TourTitle);

#line default
#line hidden
            EndContext();
            BeginContext(870, 39, true);
            WriteLiteral("</h3>\r\n                <h3>Start Date: ");
            EndContext();
            BeginContext(910, 19, false);
#line 26 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
                           Write(Model.TripStartDate);

#line default
#line hidden
            EndContext();
            BeginContext(929, 242, true);
            WriteLiteral("</h3>\r\n                <div class=\"row form-group\">\r\n                </div>\r\n                <div class=\"row form-group\">\r\n                    <div class=\"col-md-6\">\r\n                        <label>First Name</label>\r\n                        ");
            EndContext();
            BeginContext(1171, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d87cb18d92674095a9d47071b5a89422", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 32 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FirstNameLatin);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1263, 218, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"row form-group\">\r\n                    <div class=\"col-md-6\">\r\n                        <label>Last Name</label>\r\n                        ");
            EndContext();
            BeginContext(1481, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "38ffa1221fc24caaaa71b6c97989b2e7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 38 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.LastNameLatin);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1572, 100, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"row form-group\">\r\n");
            EndContext();
#line 42 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
                     for (int i = 0; i < Model.IncludedAdditionalServices.Count; i++)
                    {

#line default
#line hidden
            BeginContext(1782, 98, true);
            WriteLiteral("                        <div class=\"col-md-6 padding-bottom\">\r\n                            <label>");
            EndContext();
            BeginContext(1881, 43, false);
#line 45 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
                              Write(Model.IncludedAdditionalServices[i].Content);

#line default
#line hidden
            EndContext();
            BeginContext(1924, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1928, 41, false);
#line 45 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
                                                                             Write(Model.IncludedAdditionalServices[i].Price);

#line default
#line hidden
            EndContext();
            BeginContext(1969, 42, true);
            WriteLiteral("</label>\r\n                        </div>\r\n");
            EndContext();
#line 47 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
                    }

#line default
#line hidden
            BeginContext(2034, 88, true);
            WriteLiteral("                    <div class=\"col-md-6\">\r\n                        <label>Final Price: ");
            EndContext();
            BeginContext(2123, 16, false);
#line 49 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
                                       Write(Model.TotalPrice);

#line default
#line hidden
            EndContext();
            BeginContext(2139, 243, true);
            WriteLiteral("</label>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row form-group\">\r\n                    <div class=\"col-md-6 padding-bottom\">\r\n                        <label>Seat Number</label>\r\n                        ");
            EndContext();
            BeginContext(2382, 88, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0f2592cd84b2447eb5c42c87dc50b18d", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 55 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.SeatNumber);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2470, 70, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                ");
            EndContext();
            BeginContext(2540, 367, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38bd157db4334b348b0293b26c8e331c", async() => {
                BeginContext(2560, 169, true);
                WriteLiteral("\r\n                    <div>\r\n                        <div class=\"col-md-6\">\r\n                            <label>Confirm Reservation</label>\r\n                            ");
                EndContext();
                BeginContext(2729, 93, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8a15348b2861479588b4316cae83c281", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 62 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Reservations\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.IsFinalized);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2822, 78, true);
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2907, 58, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReservationShortDetailsServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
