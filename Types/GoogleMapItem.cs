using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigGoogleMapApi.Types
{
    public class GoogleMapItem
    {
        private string _longitude = string.Empty;
        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        private string _lotitude = string.Empty;
        public string Latitude
        {
            get { return _lotitude; }
            set { _lotitude = value; }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
    }
}
