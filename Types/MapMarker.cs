using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrigGoogleMapApi.Types
{
    public class MapMarker
    {
        private string _title = string.Empty;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        

        private LatLng _latLng = new LatLng();
        public LatLng LatLng
        {
            get { return _latLng; }
            set { _latLng = value; }
        }

    }
}
