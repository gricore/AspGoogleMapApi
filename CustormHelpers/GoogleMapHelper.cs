using System.Web.Mvc;
using GrigGoogleMapApi.Types;
using GrigGoogleMapApi.Utilities;

namespace GrigGoogleMapApi.CustormHelpers
{
    public static class GoogleMapHelper
    {
        /// <summary>
        /// Get GooleMap 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="mapMarkersCollection"></param>
        /// <returns></returns>
        public static MvcHtmlString GoogleMapPlace(this HtmlHelper html, MapMarkersCollection mapMarkersCollection)
        {
            var latLngs = new LatLngsCollection();
            var titlesCollection = new MarkerTitlesCollection();

            foreach (var mapMarker in mapMarkersCollection)
            {
                latLngs.Add(mapMarker.LatLng);
                titlesCollection.Add(mapMarker.Title);
            }

            // Declare result string.
            string resultString = string.Empty;
            // Include GoogleMap v3 Library
            resultString += GetGoogleMapNamespaceScript();
            // Get Empty JavaScript script
            var mapInitializeBuilder = GetJavaScriptTagBuilter();
            // Add function to sctipt
            mapInitializeBuilder.InnerHtml = GetJavaScripFunction(latLngs.ToString(), titlesCollection.ToString());


            resultString += mapInitializeBuilder.ToString();
            resultString += GetGoogleMapCanvas();
            return new MvcHtmlString(resultString);
        }

        #region Utilities

        /// <summary>
        /// Get Google Map v3.0 Namespace
        /// </summary>
        /// <returns></returns>
        private static string GetGoogleMapNamespaceScript()
        {
            var tagBuilder = new TagBuilder("script");
            tagBuilder.MergeAttribute("type", "text/javascript");
            tagBuilder.MergeAttribute("src", "https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false");

            return tagBuilder.ToString() + "\n";
        }

        /// <summary>
        /// Get JavaScript Tag Builder
        /// </summary>
        /// <returns></returns>
        private static TagBuilder GetJavaScriptTagBuilter()
        {
            var tagBuilder = new TagBuilder("script");
            tagBuilder.MergeAttribute("type", "text/javascript");
            return tagBuilder;
        }

        /// <summary>
        /// Get Google Maps JavaScript 'function()'
        /// </summary>
        /// <returns></returns>
        private static string GetJavaScripFunction(string latlongs, string titles)
        {

            string jstring = string.Empty;
            var htmlParser = new GHtmlParser();
            // Add Global Variables
            jstring += htmlParser.AddNewLines(Properties.Resources.GoogleMapGlobalVariables).Replace(@"[];//LatLongs", "[" + latlongs + "];").
                Replace(@"[];//Titles", "[" + titles + "];");
            // Add Initilize function
            jstring += htmlParser.AddNewLines(Properties.Resources.GoogleMapFunction);
            // Add Events functions
            jstring += htmlParser.AddNewLines(Properties.Resources.GoogleMapEventsFunction);
            // Return results
            return htmlParser.AddNewLines(jstring);
        }

        /// <summary>
        /// Get Google Maps Canvas Tag
        /// </summary>
        /// <returns></returns>
        private static string GetGoogleMapCanvas()
        {
            var canvasBuilder = new TagBuilder("div");
            canvasBuilder.MergeAttribute("id", "map_canvas");
            canvasBuilder.MergeAttribute("style", @"height: 500px");
            return "\n" + canvasBuilder.ToString();
        }

        //private static string GetMapMarker(string latitude, string longitude)
        //{
        //    string marker = string.Empty;

        //    string latlng = GetMarkerLatLng(latitude, longitude);
        //    marker = "new google.maps.Marker({position: " + latlng + ", map: map })";

        //    return marker;
        //}

        //private static string GetMarkerLatLng(string latitude, string longitude)
        //{
        //    string latlng = "new google.maps.LatLng(" + latitude + ", " + longitude + ")";
        //    return latlng;
        //}

        //private static string AddMapMarker(this string latlongs, string larlong)
        //{
        //    latlongs += larlong;
        //    return latlongs;
        //}

        #endregion
    }
}
