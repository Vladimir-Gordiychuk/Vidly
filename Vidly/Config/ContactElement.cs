using System.Configuration;

namespace Vidly.Config
{
    public class ContactElement : ConfigurationElement
    {
        public const string FirstNameTag = "FirstName";
        public const string LastNameTag = "LastName";
        public const string AddressLine1Tag = "AddressLine1";
        public const string AddressLine2Tag = "AddressLine2";
        public const string CountryTag = "Country";
        public const string ZipCodeTag = "ZipCode";
        public const string EmailTag = "Email";
        public const string PhoneTag = "Phone";

        [ConfigurationProperty(FirstNameTag, IsRequired = true)]
        public string FirstName
        {
            get { return (string)this[FirstNameTag]; }
            set { this[FirstNameTag] = value; }
        }

        [ConfigurationProperty(LastNameTag, IsRequired = true)]
        public string LastName
        {
            get { return (string)this[LastNameTag]; }
            set { this[LastNameTag] = value; }
        }

        [ConfigurationProperty(AddressLine1Tag, IsRequired = false)]
        public string AddressLine1
        {
            get { return (string)this[AddressLine1Tag]; }
            set { this[AddressLine1Tag] = value; }
        }

        [ConfigurationProperty(AddressLine2Tag, IsRequired = false)]
        public string AddressLine2
        {
            get { return (string)this[AddressLine2Tag]; }
            set { this[AddressLine2Tag] = value; }
        }

        [ConfigurationProperty(CountryTag, IsRequired = true)]
        public string Country
        {
            get { return (string)this[CountryTag]; }
            set { this[CountryTag] = value; }
        }

        [ConfigurationProperty(ZipCodeTag, IsRequired = false)]
        public string ZipCode
        {
            get { return (string)this[ZipCodeTag]; }
            set { this[ZipCodeTag] = value; }
        }

        [ConfigurationProperty(EmailTag, IsRequired = false)]
        public string Email
        {
            get { return (string)this[EmailTag]; }
            set { this[EmailTag] = value; }
        }

        [ConfigurationProperty(PhoneTag, IsRequired = false)]
        public string Phone
        {
            get { return (string)this[PhoneTag]; }
            set { this[PhoneTag] = value; }
        }
    };
}