#pragma checksum "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a529f5aa0a1bcfa74463574410f7c43b0c3f63a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\_ViewImports.cshtml"
using HOLIX;

#line default
#line hidden
#line 2 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\_ViewImports.cshtml"
using HOLIX.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a529f5aa0a1bcfa74463574410f7c43b0c3f63a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"479b116fc93c818b1559b3db8fdd2970e9afb353", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HOLIX.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\Home\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(66, 40, true);
            WriteLiteral("<script>\r\n    const model = JSON.parse(\'");
            EndContext();
            BeginContext(107, 31, false);
#line 6 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\Home\Index.cshtml"
                         Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
            EndContext();
            BeginContext(138, 227, true);
            WriteLiteral("\')\r\n</script>\r\n\r\n<script>const pins = [];</script>\r\n<title>Index</title>\r\n<script src=\"https://unpkg.com/axios/dist/axios.min.js\"></script>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(366, 40, false);
#line 17 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(406, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 22 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(518, 89, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <p>\r\n                        ");
            EndContext();
            BeginContext(608, 39, false);
#line 27 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(647, 70, true);
            WriteLiteral("\r\n                    </p>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 31 "C:\Users\Landix\Desktop\HOLIX\HOLIX\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(728, 2189, true);
            WriteLiteral(@"    </tbody>
</table>

<button onclick=""console.log(pins)"">
    OKOK
</button>


<div id=""map""></div>
<style type=""text/css"">

    #map {
        height: 50%;
        width: 50%;
    }
</style>
<script>let map;
    function initMap() {

        map = new google.maps.Map(document.getElementById(""map""), {
            center: { lat: -18.9113, lng: -48.2622 },
            zoom: 13,
        });



        for (i = 0; i < 5; i++) {
            coords = { lat: -18.9119 + i, lng: -48.2629 + i }
            addMarker(coords)
        }

        function addMarker(coords) {
            var marker = new google.maps.Marker({
                position: coords,
                map: map,
            });
        }


    }



    function geocode(address) {


        var location = address;
        axios.get('https://maps.googleapis.com/maps/api/geocode/json', {
            params: {
                address: location,
                key: 'AIzaSyD9Efdj9hUrm19UoFsq3AkGFRsHl3sPxA4");
            WriteLiteral(@"'
            }
        })
            .then(function (response) {
                //console.log(response);
                //console.log(response.data.results[0].geometry.location.lat)
                //console.log(response.data.results[0].geometry.location.lng)
                pins.push({ lat: response.data.results[0].geometry.location.lat, lng: response.data.results[0].geometry.location.lng })
            })
            .catch(function (error) {
                console.log(error);
            })

    }</script>
<script src=""https://polyfill.io/v3/polyfill.min.js?features=default""></script>
<script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyB2uWZqKkDLR96USbDml8aKdjo6i8zt-7E&callback=initMap&libraries=&v=weekly"" async></script>

<script>for (i in model) {

        var res =
            model[i].addressCity + ' ' +
            model[i].addressComplement + ' ' +
            model[i].addressCountry + ' ' +
            model[i].addressNeighborhood + ' ' +
            model[i].");
            WriteLiteral("addressNumber + \' \' +\r\n            model[i].addressState + \' \' +\r\n            model[i].addressStreet;\r\n\r\n        geocode(res)\r\n    }</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HOLIX.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
