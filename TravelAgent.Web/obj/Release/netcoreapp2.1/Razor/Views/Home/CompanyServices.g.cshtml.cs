#pragma checksum "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Home\CompanyServices.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ab4956a6f39b722ac9f25ac8f7b5d81a3155d04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CompanyServices), @"mvc.1.0.view", @"/Views/Home/CompanyServices.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/CompanyServices.cshtml", typeof(AspNetCore.Views_Home_CompanyServices))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ab4956a6f39b722ac9f25ac8f7b5d81a3155d04", @"/Views/Home/CompanyServices.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45e7f56dc290bd9852c7b824264c7c07fd46c35e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CompanyServices : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Repositories\TravelAgent\TravelAgent.Web\Views\Home\CompanyServices.cshtml"
  
    ViewData["Title"] = "CompanyServices";

#line default
#line hidden
            BeginContext(53, 5476, true);
            WriteLiteral(@"
<aside id=""colorlib-hero"">
    <div class=""flexslider"">
        <ul class=""slides"">
            <li style=""background-image: url(/images/tr4.jpg);"">
                <div class=""overlay""></div>
                <div class=""container-fluid"">
                    <div class=""row"">
                        <div class=""col-md-6 col-sm-12 col-md-offset-3 slider-text"">
                            <div class=""slider-text-inner text-center"">
                                <h2>by colorlib.com</h2>
                                <h1>Our Services</h1>
                            </div>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
    </div>
</aside>
<div id=""colorlib-services"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-3 animate-box text-center"">
                <div class=""services"">
                    <span class=""icon"">
                        <i class=""flaticon-around""></i>
      ");
            WriteLiteral(@"              </span>
                    <h3>Amazing Travel</h3>
                    <p>Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies</p>
                </div>
            </div>
            <div class=""col-md-3 animate-box text-center"">
                <div class=""services"">
                    <span class=""icon"">
                        <i class=""flaticon-boat""></i>
                    </span>
                    <h3>Our Cruises</h3>
                    <p>Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies</p>
                </div>
            </div>
            <div class=""col-md-3 animate-box text-center"">
                <div class=""services"">
                    <span class=""icon"">
                        <i class=""flaticon-car""></i>
                    </span>
   ");
            WriteLiteral(@"                 <h3>Book Your Trip</h3>
                    <p>Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies</p>
                </div>
            </div>
            <div class=""col-md-3 animate-box text-center"">
                <div class=""services"">
                    <span class=""icon"">
                        <i class=""flaticon-postcard""></i>
                    </span>
                    <h3>Nice Support</h3>
                    <p>Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies</p>
                </div>
            </div>
        </div>
    </div>
</div>
<div id=""colorlib-testimony"" class=""colorlib-light-grey"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-6 col-md-offset-3 text-center colorlib-heading animate-box"">
    ");
            WriteLiteral(@"            <h2>Our Satisfied Guests says</h2>
                <p>We love to tell our successful far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</p>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-8 col-md-offset-2 animate-box"">
                <div class=""owl-carousel2"">
                    <div class=""item"">
                        <div class=""testimony text-center"">
                            <span class=""img-user"" style=""background-image: url(/images/person1.jpg);""></span>
                            <span class=""user"">Alysha Myers</span>
                            <small>Miami Florida, USA</small>
                            <blockquote>
                                <p>"" A small river named Duden flows by their place and supplies it with the necessary regelialia.</p>
                            </blockquote>
                        </div>
                    </div>
       ");
            WriteLiteral(@"             <div class=""item"">
                        <div class=""testimony text-center"">
                            <span class=""img-user"" style=""background-image: url(/images/person2.jpg);""></span>
                            <span class=""user"">James Fisher</span>
                            <small>New York, USA</small>
                            <blockquote>
                                <p>One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar.</p>
                            </blockquote>
                        </div>
                    </div>
                    <div class=""item"">
                        <div class=""testimony text-center"">
                            <span class=""img-user"" style=""background-image: url(/images/person3.jpg);""></span>
                            <span class=""user"">Jacob Webb</span>
                            <small>Athens, Greece</small>
                            <blockquote>
          ");
            WriteLiteral(@"                      <p>Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric question ran over her cheek, then she continued her way.</p>
                            </blockquote>
                        </div>
                    </div>
                </div>
            </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
