using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustDisApp.Areas.HelpPage.ModelDescriptions
{
    class ModelDescriptions
    {
        public abstract class ModelDescription
        {
            public string Documentation { get; set; }

            public Type ModelType { get; set; }

            public string Name { get; set; }
        }
    }
}
