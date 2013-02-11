using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigGoogleMapApi.Types
{
    public class MarkerTitlesCollection : List<string>
    {
        public override string ToString()
        {
            return this.Where(title => !string.IsNullOrWhiteSpace(title)).Aggregate(string.Empty, (current, title) =>
                current + ("\"" + title + "\"" + ","));
        }
    }
}
