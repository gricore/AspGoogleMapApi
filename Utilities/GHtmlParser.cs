using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigGoogleMapApi.Utilities
{
    public class GHtmlParser
    {
        #region Methods

        public string ParserHtmlString(string inputString)
        {
            // inputString = inputString.Replace(@"&quot;", string.Empty);
            return inputString;
        }

        public string AddNewLines(string inputString)
        {
            return "\n" + inputString + "\n";
        }

        #endregion
    }
}
