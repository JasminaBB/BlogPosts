using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BlogPost_WebAPI.Helpers
{
     public static class GenerateSlug
    {
        public static string ToUrlSlug(string value)
        {
            // Remove all invalid chars  
            value = Regex.Replace(value, @"[^A-Za-z0-9\s-]", "", RegexOptions.Compiled);

            //First to lower case 
            value = value.ToLowerInvariant();

            // convert multiple spaces into one space   
            value = Regex.Replace(value, @"\s+", " ", RegexOptions.Compiled).Trim();

            //Replace spaces 
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars 
            value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

            //Trim dashes from end 
            value = value.Trim('-', '_');

            return value;
        }
    }
}
