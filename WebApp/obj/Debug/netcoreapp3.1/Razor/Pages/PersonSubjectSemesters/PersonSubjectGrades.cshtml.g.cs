#pragma checksum "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9a9a0f63c6dfa871c5552b68c335102deec767a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApp.Pages.PersonSubjectSemesters.Pages_PersonSubjectSemesters_PersonSubjectGrades), @"mvc.1.0.razor-page", @"/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml")]
namespace WebApp.Pages.PersonSubjectSemesters
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9a9a0f63c6dfa871c5552b68c335102deec767a", @"/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56255396305d1d1888ad93afc9c47568e44a4220", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PersonSubjectSemesters_PersonSubjectGrades : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
  
    Layout = Layout;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h5>");
#nullable restore
#line 8 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
Write(Model.PersonSubjectSemester.Person.FirstLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" grades of ");
#nullable restore
#line 8 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
                                                           Write(Model.PersonSubjectSemester.SubjectSemester.SubjectSemesterName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n\n<table class=\"table table-hover\" style=\"table-layout: fixed; word-wrap: break-word; text-align: center\">\n    <thead>\n    <tr>\n        <th scope=\"col\">\n            <a>Grade</a>\n        </th>\n    </tr>\n    </thead>\n    <tbody>\n    \n");
#nullable restore
#line 20 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
     foreach (var item in Model.PersonSubjectSemester.Grades)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n");
#nullable restore
#line 23 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
             if (item.GradeNumber != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"align-middle\">\n                    ");
#nullable restore
#line 26 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
               Write(item.GradeNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n");
#nullable restore
#line 28 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
            }
            else
            {
                if (item.IsPassed)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"align-middle\">\n                        Passed\n                    </td>\n");
#nullable restore
#line 36 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"align-middle\">\n                        Not Passed\n                    </td>\n");
#nullable restore
#line 42 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\n");
#nullable restore
#line 45 "/Users/andre/RiderProjects/StudySystem/WebApp/Pages/PersonSubjectSemesters/PersonSubjectGrades.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Pages.PersonSubjectSemesters.PersonSubjectGrades> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Pages.PersonSubjectSemesters.PersonSubjectGrades> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApp.Pages.PersonSubjectSemesters.PersonSubjectGrades>)PageContext?.ViewData;
        public WebApp.Pages.PersonSubjectSemesters.PersonSubjectGrades Model => ViewData.Model;
    }
}
#pragma warning restore 1591