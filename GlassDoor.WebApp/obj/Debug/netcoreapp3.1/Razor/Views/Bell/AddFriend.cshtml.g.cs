#pragma checksum "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13cbb955ec7d06d9301eea92b70174f52b052fcb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bell_AddFriend), @"mvc.1.0.view", @"/Views/Bell/AddFriend.cshtml")]
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
#line 1 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\_ViewImports.cshtml"
using GlassDoor.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\_ViewImports.cshtml"
using GlassDoor.WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13cbb955ec7d06d9301eea92b70174f52b052fcb", @"/Views/Bell/AddFriend.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7deb6afff5f1a351d512ae62524814509aa8e43f", @"/Views/_ViewImports.cshtml")]
    public class Views_Bell_AddFriend : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GlassDoor.Data.Entities.Models.FriendPhotoEntryModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
  
    ViewData["Title"] = "Friend List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Your Friend List</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
Write(Html.HiddenFor(x => x.UserId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
Write(Html.HiddenFor(x => x.FriendId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
Write(Html.HiddenFor(x => x.ImageBase64));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
Write(Html.HiddenFor(x => x.ImageExtension));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 17 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
   Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 21 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
   Write(Html.LabelFor(x => x.FriendName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 22 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
   Write(Html.TextBoxFor(x => x.FriendName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        <input type=\"file\" id=\"myinput\" onchange=\"encode();\" />\r\n    </div>\r\n");
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Add</button>\r\n");
#nullable restore
#line 30 "C:\Users\Bartosz\source\repos\GlassDoor.WebAPI\GlassDoor.WebApp\Views\Bell\AddFriend.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function encode() {
        var selectedfile = document.getElementById(""myinput"").files;
        if (selectedfile.length > 0) {
          var imageFile = selectedfile[0];
          var fileReader = new FileReader();
          fileReader.onload = function(fileLoadedEvent) {
            var srcData = fileLoadedEvent.target.result;
            var newImage = document.createElement('img');
              newImage.src = srcData;
              document.querySelectorAll(""[name='ImageBase64']"")[0].value = srcData;
              document.querySelectorAll(""[name='ImageExtension']"")[0].value = imageFile.name.split('.').pop();
            //document.getElementById(""dummy"").innerHTML = newImage.outerHTML;
            //document.getElementById(""txt"").value = document.getElementById(""dummy"").innerHTML;
          }
          fileReader.readAsDataURL(imageFile);
        }
      }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GlassDoor.Data.Entities.Models.FriendPhotoEntryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591