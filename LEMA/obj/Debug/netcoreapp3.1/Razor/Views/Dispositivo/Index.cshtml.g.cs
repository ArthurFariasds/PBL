#pragma checksum "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8d22dd61479ca84e92e23ef5938a97a83c47f250c7b5138314d69fd8e9beab6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dispositivo_Index), @"mvc.1.0.view", @"/Views/Dispositivo/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\_ViewImports.cshtml"
using PBL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\_ViewImports.cshtml"
using PBL.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"8d22dd61479ca84e92e23ef5938a97a83c47f250c7b5138314d69fd8e9beab6f", @"/Views/Dispositivo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0e3fc82caf10766cb1452b5cbe93fb4cb4e91443a701e83790c10a85fa115d4f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dispositivo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DispositivoViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
  
    ViewData["Title"] = "Dispositivo";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""home-section"">
    <div class=""text"">Listagem Dispositivo</div>

    <table class=""table table-responsive table-hover"">
        <tr>
            <th style=""text-align:center"">Id dispositivo</th>
            <th style=""text-align:center"">Nome</th>
            <th style=""text-align:center"">Descrição</th>
            <th style=""text-align:center"">Data da criação</th>
            <th style=""text-align:center"">Ações</th>
        </tr>
");
#nullable restore
#line 18 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
         foreach (var dispositivo in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td style=\"text-align:center\">");
#nullable restore
#line 21 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
                                         Write(dispositivo.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-align:center\">");
#nullable restore
#line 22 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
                                         Write(dispositivo.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-align:center\">");
#nullable restore
#line 23 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
                                         Write(dispositivo.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-align:center\">");
#nullable restore
#line 24 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
                                         Write(dispositivo.DataCriacao.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
            WriteLiteral("                <td style=\"text-align:center\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1136, "\"", 1179, 2);
            WriteAttributeValue("", 1143, "/dispositivo/edit?id=", 1143, 21, true);
#nullable restore
#line 28 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
WriteAttributeValue("", 1164, dispositivo.Id, 1164, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> <span class=\"bx bxs-pencil\"></span></a>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1245, "\"", 1290, 2);
            WriteAttributeValue("", 1252, "/dispositivo/delete?id=", 1252, 23, true);
#nullable restore
#line 29 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
WriteAttributeValue("", 1275, dispositivo.Id, 1275, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> <span class=\"bx bxs-trash-alt\"></span></a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 32 "C:\Users\levim\OneDrive\Área de Trabalho\Levi\Faculdade\LP I\PBL - v2\PBL\LEMA\Views\Dispositivo\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <a href=\"/dispositivo/create\" class=\"btn btn-register\">Novo Registro</a>\r\n</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DispositivoViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
