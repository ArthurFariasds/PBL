#pragma checksum "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f73693f14a9b84e69147c82fe8b51d62d2232d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Historico), @"mvc.1.0.view", @"/Views/Dashboard/Historico.cshtml")]
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
#line 1 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\_ViewImports.cshtml"
using PBL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\_ViewImports.cshtml"
using PBL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\_ViewImports.cshtml"
using LEMA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\_ViewImports.cshtml"
using LEMA.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f73693f14a9b84e69147c82fe8b51d62d2232d5", @"/Views/Dashboard/Historico.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54af81bc992bdced12f1f1100022cceb7af457cc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard_Historico : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HistoricoViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/historico.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("DadosHistorico"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row d-flex justify-content-center align-items-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("gap:50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
  
    ViewData["Title"] = "Histórico";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f73693f14a9b84e69147c82fe8b51d62d2232d57019", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script>\r\n    var $historicoViewModel = ");
#nullable restore
#line 10 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                         Write(Html.Raw(Json.Serialize(ViewBag.HistoricoViewModel)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n</script>\r\n\r\n<section class=\"home-section\" style=\"overflow:hidden\">\r\n    <h1 class=\"text\">Histórico</h1>\r\n    <br />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f73693f14a9b84e69147c82fe8b51d62d2232d58616", async() => {
                WriteLiteral("\r\n        <div class=\"form-group col-2\">\r\n            <label for=\"DataInicio\" class=\"control-label\">Data Inicio:</label>\r\n            <input type=\"date\" id=\"DataInicio\" Name=\"DataInicio\"");
                BeginWriteAttribute("value", " value=\"", 700, "\"", 749, 1);
#nullable restore
#line 19 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
WriteAttributeValue("", 708, Model.DataInicio?.ToString("yyyy-MM-dd"), 708, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" autocomplete=\"off\" />\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f73693f14a9b84e69147c82fe8b51d62d2232d59546", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 20 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DataInicio);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <br />\r\n        </div>\r\n        <div class=\"form-group col-2\">\r\n            <label for=\"DataFim\" class=\"control-label\">Data Fim:</label>\r\n            <input type=\"date\" id=\"DataFim\" Name=\"DataFim\"");
                BeginWriteAttribute("value", " value=\"", 1082, "\"", 1128, 1);
#nullable restore
#line 25 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
WriteAttributeValue("", 1090, Model.DataFim?.ToString("yyyy-MM-dd"), 1090, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" autocomplete=""off"" />
            <br />
        </div>
        <div class=""form-group col-2"">
            <label for=""TemperaturaInicial"" class=""control-label"">Temperatura Inicial:</label>
            <input type=""text"" id=""TemperaturaInicial"" Name=""TemperaturaInicial""");
                BeginWriteAttribute("value", " value=\"", 1426, "\"", 1459, 1);
#nullable restore
#line 30 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
WriteAttributeValue("", 1434, Model.TemperaturaInicial, 1434, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" autocomplete=\"off\" oninput=\"javascript:this.value = this.value.replace(/\\D/g, \'\')\" />\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f73693f14a9b84e69147c82fe8b51d62d2232d512686", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 31 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TemperaturaInicial);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <br />\r\n        </div>\r\n        <div class=\"form-group col-2\">\r\n            <label for=\"TemperaturaFinal\" class=\"control-label\">Temperatura Final:</label>\r\n            <input type=\"text\" id=\"TemperaturaFinal\" Name=\"TemperaturaFinal\"");
                BeginWriteAttribute("value", " value=\"", 1900, "\"", 1931, 1);
#nullable restore
#line 36 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
WriteAttributeValue("", 1908, Model.TemperaturaFinal, 1908, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" autocomplete=""off"" oninput=""javascript:this.value = this.value.replace(/\D/g, '')"" />
            <br />
        </div>
        <div class=""div-botoes"">
            <button type=""submit"" class=""btn"" style=""padding:19px; margin-top:7px"">Filtrar</button>
            <a class=""btn"" href=""/Dashboard/Historico"" style=""padding:19px; margin-top:7px;color: darkred;"">Limpar</a>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <br />
    <div class=""row justify-content-around"">
        <figure class=""highcharts-figure"">
            <div id=""chart-mediaTemperaturas""></div>
        </figure>

        <div class=""col-4 text-center"">
            <h5>TOP 5</h5>
            <br />
            <div class=""row justify-content-center"">
                <div class=""col-6"">
                    <h6>Maiores Temperaturas</h6>
                    <table class=""table table-hover"">
                        <tr>
                            <th style=""text-align:center"">Data</th>
                            <th style=""text-align:center"">Temperatura</th>
                        </tr>
");
#nullable restore
#line 61 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                         foreach (var temperatura in Model.MaioresTemperaturas.OrderByDescending(o => o.ValorTemperatura).Take(5))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td style=\"text-align:center\">");
#nullable restore
#line 64 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                                                         Write(temperatura.DataLeitura.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td style=\"text-align:center\">");
#nullable restore
#line 65 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                                                         Write(temperatura.ValorTemperatura.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ºC</td>\r\n                            </tr>\r\n");
#nullable restore
#line 67 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </table>
                </div>

                <div class=""col-6"">
                    <h6>Menores Temperaturas</h6>
                    <table class=""table table-hover"">
                        <tr>
                            <th style=""text-align:center"">Data</th>
                            <th style=""text-align:center"">Temperatura</th>
                        </tr>
");
#nullable restore
#line 78 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                         foreach (var temperatura in Model.MenoresTemperaturas.OrderBy(o => o.ValorTemperatura).Take(5))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td style=\"text-align:center\">");
#nullable restore
#line 81 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                                                         Write(temperatura.DataLeitura.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td style=\"text-align:center\">");
#nullable restore
#line 82 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                                                         Write(temperatura.ValorTemperatura.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ºC</td>\r\n                            </tr>\r\n");
#nullable restore
#line 84 "C:\Users\arthu\OneDrive\Área de Trabalho\PBL\PBL\LEMA\Views\Dashboard\Historico.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </table>
                </div>
            </div>
        </div>
    </div>

    <figure class=""highcharts-figure"">
        <div id=""chart-history""></div>
    </figure>
    <table class=""table table-hover"">
    </table>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HistoricoViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
