using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigGoogleMapApi.Types
{
    public class LatLng
    {
        public override string ToString()
        {
            return "new google.maps.LatLng(" + Latitude + ", " + Longitude + ")";
        }

        private string _latitide = string.Empty;

        public string Latitude
        {
            get { return _latitide; }
            set { _latitide = value; }
        }

        private string _longitude = string.Empty;

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }


    }
}
