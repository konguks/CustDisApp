using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustDisApp.Areas.HelpPage.ModelDescriptions
{
    interface IModelDocumentationProvider
    {
        //string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}
