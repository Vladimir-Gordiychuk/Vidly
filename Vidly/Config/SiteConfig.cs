using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Vidly.Config
{
    //This class reads the defined config section (if available) and stores it locally in the static _Config variable.
    //This config data is available by calling MedGroups.GetMedGroups().
    public class SiteConfig
    {
        public const string SiteConfigSection = "siteConfig";

        public static SiteConfigSection Config
        {
            get { return ConfigurationManager.GetSection(SiteConfigSection) as SiteConfigSection; }
        }
    }
}