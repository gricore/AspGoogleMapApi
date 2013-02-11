using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigGoogleMapApi.Types
{
    public class LatLngsCollection : List<LatLng>
    {
        public override string ToString()
        {
            string latLngString = string.Empty;           
            return this.Aggregate(latLngString, (current, latlng) => current + (latlng.ToString() + ", "));
        }
    }
}
