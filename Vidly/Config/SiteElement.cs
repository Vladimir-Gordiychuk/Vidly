using System.Configuration;

namespace Vidly.Config
{
    //Extend the ConfigurationElement class.  This class represents a single element in the collection.
    //Create a property for each xml attribute in your element.
    //Decorate each property with the ConfigurationProperty decorator.  See MSDN for all available options.
    public class SiteElement : ConfigurationElement
    {
        public const string CompanyTag = "company";
        public const string SiteNameTag = "name";
        public const string SiteUrlTag = "url";
        public const string FacebookAppIdTag = "FacebookAppId";
        public const string FacebookAppSecretTag = "FacebookAppSecret";

        [ConfigurationProperty(CompanyTag, IsRequired = true)]
        public string Company
        {
            get { return (string)this[CompanyTag]; }
            set { this[CompanyTag] = value; }
        }

        [ConfigurationProperty(SiteNameTag, IsRequired = true)]
        public string Name
        {
            get { return (string)this[SiteNameTag]; }
            set { this[SiteNameTag] = value; }
        }

        [ConfigurationProperty(SiteUrlTag, IsRequired = true)]
        public string Url
        {
            get { return (string)this[SiteUrlTag]; }
            set { this[SiteUrlTag] = value; }
        }

        [ConfigurationProperty(FacebookAppIdTag, IsRequired = false)]
        public string FacebookAppId
        {
            get { return (string)this[FacebookAppIdTag]; }
            set { this[FacebookAppIdTag] = value; }
        }

        [ConfigurationProperty(FacebookAppSecretTag, IsRequired = false)]
        public string FacebookAppSecret
        {
            get { return (string)this[FacebookAppSecretTag]; }
            set { this[FacebookAppSecretTag] = value; }
        }
    };
}