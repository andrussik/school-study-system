#pragma checksum "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ba66d80eada6e7e7865c761c8b49fd03a83ae6e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.Pages_SubjectGrades), @"mvc.1.0.razor-page", @"/Pages/SubjectGrades.cshtml")]
namespace WebApp.Pages
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
#line 1 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ba66d80eada6e7e7865c761c8b49fd03a83ae6e", @"/Pages/SubjectGrades.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56255396305d1d1888ad93afc9c47568e44a4220", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SubjectGrades : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./EditGrade", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
  
    Layout = Layout;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h5>Grades of ");
#nullable restore
#line 8 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
         Write(Model.SubjectSemester.SubjectSemesterName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n\n<p>\n    <a");
            BeginWriteAttribute("href", " href=\"", 141, "\"", 221, 2);
            WriteAttributeValue("", 148, "/Grades/Create?subjectSemesterId=", 148, 33, true);
#nullable restore
#line 11 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
WriteAttributeValue("", 181, Model.SubjectSemester.SubjectSemesterId, 181, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  class=""card-link"">Add New Grade</a>
</p>

<table class=""table table-hover"" style=""table-layout: fixed; word-wrap: break-word; text-align: center"">
    <thead>
    <tr>
        <th scope=""col"">
            <a>Name</a>
        </th>
        <th scope=""col"">
            <a>Grade</a>
");
#nullable restore
#line 22 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
             if (Model.Grades != null && Model.Grades.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>GPA = ");
#nullable restore
#line 24 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                    Write(Model.AverageGrade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 25 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </th>\n        <th scope=\"col\">\n            <a>Edit</a>\n        </th>\n    </tr>\n    </thead>\n    <tbody>\n    \n");
#nullable restore
#line 34 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
     foreach (var item in Model.PersonSubjectSemesters)
    {
        if (item.Grades.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
             foreach (var grade in item.Grades)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td class=\"align-middle\">\n                        ");
#nullable restore
#line 42 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                   Write(item.Person.FirstLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n");
#nullable restore
#line 44 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                     if (grade.GradeNumber != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"align-middle\">\n                            ");
#nullable restore
#line 47 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                       Write(grade.GradeNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n");
#nullable restore
#line 49 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                    }
                    else
                    {
                        if (grade.IsPassed)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"align-middle\">\n                                Passed\n                            </td>\n");
#nullable restore
#line 57 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"align-middle\">\n                                Not passed\n                            </td>\n");
#nullable restore
#line 63 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"align-middle\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ba66d80eada6e7e7865c761c8b49fd03a83ae6e7776", async() => {
                WriteLiteral("edit grade");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
                                                    WriteLiteral(grade.GradeId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </td>\n                </tr>\n");
#nullable restore
#line 69 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/SubjectGrades.cshtml"
             
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \n    </tbody>\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Pages.SubjectGrades> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Pages.SubjectGrades> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Pages.SubjectGrades>)PageContext?.ViewData;
        public WebApp.Pages.SubjectGrades Model => ViewData.Model;
    }
}
#pragma warning restore 1591
