using System.Configuration;

namespace Vidly.Config
{
    //Extend the ConfigurationSection class.
    //Your class name should match your section name and be postfixed with "Section".
    public class SiteConfigSection : ConfigurationSection
    {
        public const string SiteTag = "site";
        public const string ContactTag = "contact";

        [ConfigurationProperty(SiteTag)]
        public SiteElement Site
        {
            get { return (SiteElement)this[SiteTag]; }
        }

        [ConfigurationProperty(ContactTag)]
        public ContactElement Contact
        {
            get { return (ContactElement)this[ContactTag]; }
        }
    }
}