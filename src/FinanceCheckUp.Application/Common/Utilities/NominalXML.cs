namespace FinanceCheckUp.Application.Common.Utilities.NominalXML
{
    public class NominalXML
    {
    }
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.edefter.gov.tr")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.edefter.gov.tr", IsNullable = false)]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class defter
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {

        private xbrl xbrlField;

        private Signature signatureField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/2003/instance")]
        public xbrl xbrl
        {
            get
            {
                return xbrlField;
            }
            set
            {
                xbrlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature
        {
            get
            {
                return signatureField;
            }
            set
            {
                signatureField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/2003/instance", IsNullable = false)]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class xbrl
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {

        private schemaRef schemaRefField;

        private xbrlContext contextField;

        private xbrlUnit[] unitField;

        private accountingEntries accountingEntriesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/2003/linkbase")]
        public schemaRef schemaRef
        {
            get
            {
                return schemaRefField;
            }
            set
            {
                schemaRefField = value;
            }
        }

        /// <remarks/>
        public xbrlContext context
        {
            get
            {
                return contextField;
            }
            set
            {
                contextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("unit")]
        public xbrlUnit[] unit
        {
            get
            {
                return unitField;
            }
            set
            {
                unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
        public accountingEntries accountingEntries
        {
            get
            {
                return accountingEntriesField;
            }
            set
            {
                accountingEntriesField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/linkbase")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/2003/linkbase", IsNullable = false)]
    public partial class schemaRef
    {

        private string hrefField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string href
        {
            get
            {
                return hrefField;
            }
            set
            {
                hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContext
    {

        private xbrlContextEntity entityField;

        private xbrlContextPeriod periodField;

        private string idField;

        /// <remarks/>
        public xbrlContextEntity entity
        {
            get
            {
                return entityField;
            }
            set
            {
                entityField = value;
            }
        }

        /// <remarks/>
        public xbrlContextPeriod period
        {
            get
            {
                return periodField;
            }
            set
            {
                periodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContextEntity
    {

        private xbrlContextEntityIdentifier identifierField;

        /// <remarks/>
        public xbrlContextEntityIdentifier identifier
        {
            get
            {
                return identifierField;
            }
            set
            {
                identifierField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContextEntityIdentifier
    {

        private string schemeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string scheme
        {
            get
            {
                return schemeField;
            }
            set
            {
                schemeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlContextPeriod
    {

        private DateTime instantField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(DataType = "date")]
        public DateTime instant
        {
            get
            {
                return instantField;
            }
            set
            {
                instantField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/2003/instance")]
    public partial class xbrlUnit
    {

        private string measureField;

        private string idField;

        /// <remarks/>
        public string measure
        {
            get
            {
                return measureField;
            }
            set
            {
                measureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25", IsNullable = false)]
    public partial class accountingEntries
    {

        private accountingEntriesDocumentInfo documentInfoField;

        private accountingEntriesEntityInformation entityInformationField;

        private accountingEntriesEntryHeader[] entryHeaderField;

        /// <remarks/>
        public accountingEntriesDocumentInfo documentInfo
        {
            get
            {
                return documentInfoField;
            }
            set
            {
                documentInfoField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntityInformation entityInformation
        {
            get
            {
                return entityInformationField;
            }
            set
            {
                entityInformationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("entryHeader")]
        public accountingEntriesEntryHeader[] entryHeader
        {
            get
            {
                return entryHeaderField;
            }
            set
            {
                entryHeaderField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfo
    {

        private accountingEntriesDocumentInfoEntriesType entriesTypeField;

        private accountingEntriesDocumentInfoUniqueID uniqueIDField;

        private accountingEntriesDocumentInfoLanguage languageField;

        private accountingEntriesDocumentInfoCreationDate creationDateField;

        private creator creatorField;

        private accountingEntriesDocumentInfoEntriesComment entriesCommentField;

        private accountingEntriesDocumentInfoPeriodCoveredStart periodCoveredStartField;

        private accountingEntriesDocumentInfoPeriodCoveredEnd periodCoveredEndField;

        private sourceApplication sourceApplicationField;

        /// <remarks/>
        public accountingEntriesDocumentInfoEntriesType entriesType
        {
            get
            {
                return entriesTypeField;
            }
            set
            {
                entriesTypeField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoUniqueID uniqueID
        {
            get
            {
                return uniqueIDField;
            }
            set
            {
                uniqueIDField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoLanguage language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoCreationDate creationDate
        {
            get
            {
                return creationDateField;
            }
            set
            {
                creationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public creator creator
        {
            get
            {
                return creatorField;
            }
            set
            {
                creatorField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoEntriesComment entriesComment
        {
            get
            {
                return entriesCommentField;
            }
            set
            {
                entriesCommentField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoPeriodCoveredStart periodCoveredStart
        {
            get
            {
                return periodCoveredStartField;
            }
            set
            {
                periodCoveredStartField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesDocumentInfoPeriodCoveredEnd periodCoveredEnd
        {
            get
            {
                return periodCoveredEndField;
            }
            set
            {
                periodCoveredEndField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public sourceApplication sourceApplication
        {
            get
            {
                return sourceApplicationField;
            }
            set
            {
                sourceApplicationField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoEntriesType
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoUniqueID
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoLanguage
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoCreationDate
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class creator
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoEntriesComment
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoPeriodCoveredStart
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesDocumentInfoPeriodCoveredEnd
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class sourceApplication
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntityInformation
    {

        private entityPhoneNumber entityPhoneNumberField;

        private entityFaxNumberStructure entityFaxNumberStructureField;

        private entityEmailAddressStructure entityEmailAddressStructureField;

        private organizationIdentifiers organizationIdentifiersField;

        private organizationAddress organizationAddressField;

        private entityWebSite entityWebSiteField;

        private businessDescription businessDescriptionField;

        private fiscalYearStart fiscalYearStartField;

        private fiscalYearEnd fiscalYearEndField;

        private accountantInformation[] accountantInformationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityPhoneNumber entityPhoneNumber
        {
            get
            {
                return entityPhoneNumberField;
            }
            set
            {
                entityPhoneNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityFaxNumberStructure entityFaxNumberStructure
        {
            get
            {
                return entityFaxNumberStructureField;
            }
            set
            {
                entityFaxNumberStructureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityEmailAddressStructure entityEmailAddressStructure
        {
            get
            {
                return entityEmailAddressStructureField;
            }
            set
            {
                entityEmailAddressStructureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public organizationIdentifiers organizationIdentifiers
        {
            get
            {
                return organizationIdentifiersField;
            }
            set
            {
                organizationIdentifiersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public organizationAddress organizationAddress
        {
            get
            {
                return organizationAddressField;
            }
            set
            {
                organizationAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public entityWebSite entityWebSite
        {
            get
            {
                return entityWebSiteField;
            }
            set
            {
                entityWebSiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public businessDescription businessDescription
        {
            get
            {
                return businessDescriptionField;
            }
            set
            {
                businessDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public fiscalYearStart fiscalYearStart
        {
            get
            {
                return fiscalYearStartField;
            }
            set
            {
                fiscalYearStartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public fiscalYearEnd fiscalYearEnd
        {
            get
            {
                return fiscalYearEndField;
            }
            set
            {
                fiscalYearEndField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("accountantInformation", Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public accountantInformation[] accountantInformation
        {
            get
            {
                return accountantInformationField;
            }
            set
            {
                accountantInformationField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityPhoneNumber
    {

        private entityPhoneNumberPhoneNumberDescription phoneNumberDescriptionField;

        private entityPhoneNumberPhoneNumber phoneNumberField;

        /// <remarks/>
        public entityPhoneNumberPhoneNumberDescription phoneNumberDescription
        {
            get
            {
                return phoneNumberDescriptionField;
            }
            set
            {
                phoneNumberDescriptionField = value;
            }
        }

        /// <remarks/>
        public entityPhoneNumberPhoneNumber phoneNumber
        {
            get
            {
                return phoneNumberField;
            }
            set
            {
                phoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityPhoneNumberPhoneNumberDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityPhoneNumberPhoneNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityFaxNumberStructure
    {

        private entityFaxNumberStructureEntityFaxNumber entityFaxNumberField;

        /// <remarks/>
        public entityFaxNumberStructureEntityFaxNumber entityFaxNumber
        {
            get
            {
                return entityFaxNumberField;
            }
            set
            {
                entityFaxNumberField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityFaxNumberStructureEntityFaxNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityEmailAddressStructure
    {

        private entityEmailAddressStructureEntityEmailAddress entityEmailAddressField;

        /// <remarks/>
        public entityEmailAddressStructureEntityEmailAddress entityEmailAddress
        {
            get
            {
                return entityEmailAddressField;
            }
            set
            {
                entityEmailAddressField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityEmailAddressStructureEntityEmailAddress
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class organizationIdentifiers
    {

        private organizationIdentifiersOrganizationIdentifier organizationIdentifierField;

        private organizationIdentifiersOrganizationDescription organizationDescriptionField;

        /// <remarks/>
        public organizationIdentifiersOrganizationIdentifier organizationIdentifier
        {
            get
            {
                return organizationIdentifierField;
            }
            set
            {
                organizationIdentifierField = value;
            }
        }

        /// <remarks/>
        public organizationIdentifiersOrganizationDescription organizationDescription
        {
            get
            {
                return organizationDescriptionField;
            }
            set
            {
                organizationDescriptionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationIdentifiersOrganizationIdentifier
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationIdentifiersOrganizationDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class organizationAddress
    {

        private organizationAddressOrganizationBuildingNumber organizationBuildingNumberField;

        private organizationAddressOrganizationAddressStreet organizationAddressStreetField;

        private organizationAddressOrganizationAddressStreet2 organizationAddressStreet2Field;

        private organizationAddressOrganizationAddressCity organizationAddressCityField;

        private organizationAddressOrganizationAddressZipOrPostalCode organizationAddressZipOrPostalCodeField;

        private organizationAddressOrganizationAddressCountry organizationAddressCountryField;

        /// <remarks/>
        public organizationAddressOrganizationBuildingNumber organizationBuildingNumber
        {
            get
            {
                return organizationBuildingNumberField;
            }
            set
            {
                organizationBuildingNumberField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressStreet organizationAddressStreet
        {
            get
            {
                return organizationAddressStreetField;
            }
            set
            {
                organizationAddressStreetField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressStreet2 organizationAddressStreet2
        {
            get
            {
                return organizationAddressStreet2Field;
            }
            set
            {
                organizationAddressStreet2Field = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressCity organizationAddressCity
        {
            get
            {
                return organizationAddressCityField;
            }
            set
            {
                organizationAddressCityField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressZipOrPostalCode organizationAddressZipOrPostalCode
        {
            get
            {
                return organizationAddressZipOrPostalCodeField;
            }
            set
            {
                organizationAddressZipOrPostalCodeField = value;
            }
        }

        /// <remarks/>
        public organizationAddressOrganizationAddressCountry organizationAddressCountry
        {
            get
            {
                return organizationAddressCountryField;
            }
            set
            {
                organizationAddressCountryField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationBuildingNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressStreet
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressStreet2
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressCity
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressZipOrPostalCode
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class organizationAddressOrganizationAddressCountry
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class entityWebSite
    {

        private entityWebSiteWebSiteURL webSiteURLField;

        /// <remarks/>
        public entityWebSiteWebSiteURL webSiteURL
        {
            get
            {
                return webSiteURLField;
            }
            set
            {
                webSiteURLField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class entityWebSiteWebSiteURL
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class businessDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class fiscalYearStart
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class fiscalYearEnd
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class accountantInformation
    {

        private accountantInformationAccountantName accountantNameField;

        private accountantInformationAccountantAddress accountantAddressField;

        private accountantInformationAccountantEngagementTypeDescription accountantEngagementTypeDescriptionField;

        private accountantInformationAccountantContactInformation accountantContactInformationField;

        /// <remarks/>
        public accountantInformationAccountantName accountantName
        {
            get
            {
                return accountantNameField;
            }
            set
            {
                accountantNameField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddress accountantAddress
        {
            get
            {
                return accountantAddressField;
            }
            set
            {
                accountantAddressField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantEngagementTypeDescription accountantEngagementTypeDescription
        {
            get
            {
                return accountantEngagementTypeDescriptionField;
            }
            set
            {
                accountantEngagementTypeDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformation accountantContactInformation
        {
            get
            {
                return accountantContactInformationField;
            }
            set
            {
                accountantContactInformationField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantName
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddress
    {

        private accountantInformationAccountantAddressAccountantBuildingNumber accountantBuildingNumberField;

        private accountantInformationAccountantAddressAccountantStreet accountantStreetField;

        private accountantInformationAccountantAddressAccountantAddressStreet2 accountantAddressStreet2Field;

        private accountantInformationAccountantAddressAccountantCity accountantCityField;

        private accountantInformationAccountantAddressAccountantCountry accountantCountryField;

        private accountantInformationAccountantAddressAccountantZipOrPostalCode accountantZipOrPostalCodeField;

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantBuildingNumber accountantBuildingNumber
        {
            get
            {
                return accountantBuildingNumberField;
            }
            set
            {
                accountantBuildingNumberField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantStreet accountantStreet
        {
            get
            {
                return accountantStreetField;
            }
            set
            {
                accountantStreetField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantAddressStreet2 accountantAddressStreet2
        {
            get
            {
                return accountantAddressStreet2Field;
            }
            set
            {
                accountantAddressStreet2Field = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantCity accountantCity
        {
            get
            {
                return accountantCityField;
            }
            set
            {
                accountantCityField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantCountry accountantCountry
        {
            get
            {
                return accountantCountryField;
            }
            set
            {
                accountantCountryField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantAddressAccountantZipOrPostalCode accountantZipOrPostalCode
        {
            get
            {
                return accountantZipOrPostalCodeField;
            }
            set
            {
                accountantZipOrPostalCodeField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantBuildingNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantStreet
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantAddressStreet2
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantCity
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantCountry
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantAddressAccountantZipOrPostalCode
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantEngagementTypeDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformation
    {

        private accountantInformationAccountantContactInformationAccountantContactPhone accountantContactPhoneField;

        private accountantInformationAccountantContactInformationAccountantContactFax accountantContactFaxField;

        private accountantInformationAccountantContactInformationAccountantContactEmail accountantContactEmailField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactPhone accountantContactPhone
        {
            get
            {
                return accountantContactPhoneField;
            }
            set
            {
                accountantContactPhoneField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactFax accountantContactFax
        {
            get
            {
                return accountantContactFaxField;
            }
            set
            {
                accountantContactFaxField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactEmail accountantContactEmail
        {
            get
            {
                return accountantContactEmailField;
            }
            set
            {
                accountantContactEmailField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactPhone
    {

        private accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumberDescription accountantContactPhoneNumberDescriptionField;

        private accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumber accountantContactPhoneNumberField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumberDescription accountantContactPhoneNumberDescription
        {
            get
            {
                return accountantContactPhoneNumberDescriptionField;
            }
            set
            {
                accountantContactPhoneNumberDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumber accountantContactPhoneNumber
        {
            get
            {
                return accountantContactPhoneNumberField;
            }
            set
            {
                accountantContactPhoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumberDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactPhoneAccountantContactPhoneNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactFax
    {

        private accountantInformationAccountantContactInformationAccountantContactFaxAccountantContactFaxNumber accountantContactFaxNumberField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactFaxAccountantContactFaxNumber accountantContactFaxNumber
        {
            get
            {
                return accountantContactFaxNumberField;
            }
            set
            {
                accountantContactFaxNumberField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactFaxAccountantContactFaxNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactEmail
    {

        private accountantInformationAccountantContactInformationAccountantContactEmailAccountantContactEmailAddress accountantContactEmailAddressField;

        /// <remarks/>
        public accountantInformationAccountantContactInformationAccountantContactEmailAccountantContactEmailAddress accountantContactEmailAddress
        {
            get
            {
                return accountantContactEmailAddressField;
            }
            set
            {
                accountantContactEmailAddressField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    public partial class accountantInformationAccountantContactInformationAccountantContactEmailAccountantContactEmailAddress
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeader
    {

        private accountingEntriesEntryHeaderEnteredBy enteredByField;

        private accountingEntriesEntryHeaderEnteredDate enteredDateField;

        private accountingEntriesEntryHeaderEntryNumber entryNumberField;

        private accountingEntriesEntryHeaderEntryComment entryCommentField;

        private totalDebit totalDebitField;

        private totalCredit totalCreditField;

        private accountingEntriesEntryHeaderEntryNumberCounter entryNumberCounterField;

        private accountingEntriesEntryHeaderEntryDetail[] entryDetailField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEnteredBy enteredBy
        {
            get
            {
                return enteredByField;
            }
            set
            {
                enteredByField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEnteredDate enteredDate
        {
            get
            {
                return enteredDateField;
            }
            set
            {
                enteredDateField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryNumber entryNumber
        {
            get
            {
                return entryNumberField;
            }
            set
            {
                entryNumberField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryComment entryComment
        {
            get
            {
                return entryCommentField;
            }
            set
            {
                entryCommentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public totalDebit totalDebit
        {
            get
            {
                return totalDebitField;
            }
            set
            {
                totalDebitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public totalCredit totalCredit
        {
            get
            {
                return totalCreditField;
            }
            set
            {
                totalCreditField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryNumberCounter entryNumberCounter
        {
            get
            {
                return entryNumberCounterField;
            }
            set
            {
                entryNumberCounterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("entryDetail")]
        public accountingEntriesEntryHeaderEntryDetail[] entryDetail
        {
            get
            {
                return entryDetailField;
            }
            set
            {
                entryDetailField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEnteredBy
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEnteredDate
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryComment
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class totalDebit
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public float decimals
        {
            get
            {
                return decimalsField;
            }
            set
            {
                decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string unitRef
        {
            get
            {
                return unitRefField;
            }
            set
            {
                unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public decimal Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class totalCredit
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public float decimals
        {
            get
            {
                return decimalsField;
            }
            set
            {
                decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string unitRef
        {
            get
            {
                return unitRefField;
            }
            set
            {
                unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public decimal Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryNumberCounter
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private long valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public float decimals
        {
            get
            {
                return decimalsField;
            }
            set
            {
                decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string unitRef
        {
            get
            {
                return unitRefField;
            }
            set
            {
                unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public long Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetail
    {

        private accountingEntriesEntryHeaderEntryDetailLineNumber lineNumberField;

        private accountingEntriesEntryHeaderEntryDetailLineNumberCounter lineNumberCounterField;

        private accountingEntriesEntryHeaderEntryDetailAccount accountField;

        private accountingEntriesEntryHeaderEntryDetailAmount amountField;

        private accountingEntriesEntryHeaderEntryDetailDebitCreditCode debitCreditCodeField;

        private accountingEntriesEntryHeaderEntryDetailPostingDate postingDateField;

        private accountingEntriesEntryHeaderEntryDetailDocumentType documentTypeField;

        private accountingEntriesEntryHeaderEntryDetailDocumentNumber documentNumberField;

        private accountingEntriesEntryHeaderEntryDetailDocumentReference documentReferenceField;

        private accountingEntriesEntryHeaderEntryDetailDocumentDate documentDateField;

        private paymentMethod paymentMethodField;

        private accountingEntriesEntryHeaderEntryDetailDetailComment detailCommentField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailLineNumber lineNumber
        {
            get
            {
                return lineNumberField;
            }
            set
            {
                lineNumberField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailLineNumberCounter lineNumberCounter
        {
            get
            {
                return lineNumberCounterField;
            }
            set
            {
                lineNumberCounterField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccount account
        {
            get
            {
                return accountField;
            }
            set
            {
                accountField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAmount amount
        {
            get
            {
                return amountField;
            }
            set
            {
                amountField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDebitCreditCode debitCreditCode
        {
            get
            {
                return debitCreditCodeField;
            }
            set
            {
                debitCreditCodeField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailPostingDate postingDate
        {
            get
            {
                return postingDateField;
            }
            set
            {
                postingDateField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentType documentType
        {
            get
            {
                return documentTypeField;
            }
            set
            {
                documentTypeField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentNumber documentNumber
        {
            get
            {
                return documentNumberField;
            }
            set
            {
                documentNumberField = value == null ? new accountingEntriesEntryHeaderEntryDetailDocumentNumber() : value;

            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentReference documentReference
        {
            get
            {
                return documentReferenceField;
            }
            set
            {
                documentReferenceField = value;

            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDocumentDate documentDate
        {
            get
            {
                return documentDateField;
            }
            set
            {
                documentDateField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
        public paymentMethod paymentMethod
        {
            get
            {
                return paymentMethodField;
            }
            set
            {
                paymentMethodField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailDetailComment detailComment
        {
            get
            {
                return detailCommentField;
            }
            set
            {
                detailCommentField = value;

            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailLineNumber
    {

        private string contextRefField;

        private long valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public long Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailLineNumberCounter
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private long valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public float decimals
        {
            get
            {
                return decimalsField;
            }
            set
            {
                decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string unitRef
        {
            get
            {
                return unitRefField;
            }
            set
            {
                unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public long Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccount
    {

        private accountingEntriesEntryHeaderEntryDetailAccountAccountMainID accountMainIDField;

        private accountingEntriesEntryHeaderEntryDetailAccountAccountMainDescription accountMainDescriptionField;

        private accountingEntriesEntryHeaderEntryDetailAccountAccountSub accountSubField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountMainID accountMainID
        {
            get
            {
                return accountMainIDField;
            }
            set
            {
                accountMainIDField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountMainDescription accountMainDescription
        {
            get
            {
                return accountMainDescriptionField;
            }
            set
            {
                accountMainDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountSub accountSub
        {
            get
            {
                return accountSubField;
            }
            set
            {
                accountSubField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountMainID
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountMainDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountSub
    {

        private accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubDescription accountSubDescriptionField;

        private accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubID accountSubIDField;

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubDescription accountSubDescription
        {
            get
            {
                return accountSubDescriptionField;
            }
            set
            {
                accountSubDescriptionField = value;
            }
        }

        /// <remarks/>
        public accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubID accountSubID
        {
            get
            {
                return accountSubIDField;
            }
            set
            {
                accountSubIDField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubDescription
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAccountAccountSubAccountSubID
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailAmount
    {

        private string contextRefField;

        private float decimalsField;

        private string unitRefField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public float decimals
        {
            get
            {
                return decimalsField;
            }
            set
            {
                decimalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string unitRef
        {
            get
            {
                return unitRefField;
            }
            set
            {
                unitRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public decimal Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDebitCreditCode
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailPostingDate
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentType
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentNumber
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value == null ? string.Empty : value;

            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentReference
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value == null ? string.Empty : value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDocumentDate
    {

        private string contextRefField;

        private DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public DateTime Value
        {
            get
            {
                return valueField;
            }
            set
            {

                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.xbrl.org/int/gl/bus/2006-10-25", IsNullable = false)]
    public partial class paymentMethod
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.xbrl.org/int/gl/cor/2006-10-25")]
    public partial class accountingEntriesEntryHeaderEntryDetailDetailComment
    {

        private string contextRefField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string contextRef
        {
            get
            {
                return contextRefField;
            }
            set
            {
                contextRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;

            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class Signature
    {

        private SignatureSignedInfo signedInfoField;

        private SignatureSignatureValue signatureValueField;

        private SignatureKeyInfo keyInfoField;

        private SignatureObject objectField;

        private string idField;

        /// <remarks/>
        public SignatureSignedInfo SignedInfo
        {
            get
            {
                return signedInfoField;
            }
            set
            {
                signedInfoField = value;
            }
        }

        /// <remarks/>
        public SignatureSignatureValue SignatureValue
        {
            get
            {
                return signatureValueField;
            }
            set
            {
                signatureValueField = value;
            }
        }

        /// <remarks/>
        public SignatureKeyInfo KeyInfo
        {
            get
            {
                return keyInfoField;
            }
            set
            {
                keyInfoField = value;
            }
        }

        /// <remarks/>
        public SignatureObject Object
        {
            get
            {
                return objectField;
            }
            set
            {
                objectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfo
    {

        private SignatureSignedInfoCanonicalizationMethod canonicalizationMethodField;

        private SignatureSignedInfoSignatureMethod signatureMethodField;

        private SignatureSignedInfoReference[] referenceField;

        private string idField;

        /// <remarks/>
        public SignatureSignedInfoCanonicalizationMethod CanonicalizationMethod
        {
            get
            {
                return canonicalizationMethodField;
            }
            set
            {
                canonicalizationMethodField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoSignatureMethod SignatureMethod
        {
            get
            {
                return signatureMethodField;
            }
            set
            {
                signatureMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Reference")]
        public SignatureSignedInfoReference[] Reference
        {
            get
            {
                return referenceField;
            }
            set
            {
                referenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoCanonicalizationMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }
            set
            {
                algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoSignatureMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }
            set
            {
                algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReference
    {

        private SignatureSignedInfoReferenceTransforms transformsField;

        private SignatureSignedInfoReferenceDigestMethod digestMethodField;

        private string digestValueField;

        private string uRIField;

        private string idField;

        private string typeField;

        /// <remarks/>
        public SignatureSignedInfoReferenceTransforms Transforms
        {
            get
            {
                return transformsField;
            }
            set
            {
                transformsField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoReferenceDigestMethod DigestMethod
        {
            get
            {
                return digestMethodField;
            }
            set
            {
                digestMethodField = value;
            }
        }

        /// <remarks/>
        public string DigestValue
        {
            get
            {
                return digestValueField;
            }
            set
            {
                digestValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string URI
        {
            get
            {
                return uRIField;
            }
            set
            {
                uRIField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceTransforms
    {

        private SignatureSignedInfoReferenceTransformsTransform transformField;

        /// <remarks/>
        public SignatureSignedInfoReferenceTransformsTransform Transform
        {
            get
            {
                return transformField;
            }
            set
            {
                transformField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceTransformsTransform
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }
            set
            {
                algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceDigestMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }
            set
            {
                algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignatureValue
    {

        private string idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfo
    {

        private SignatureKeyInfoKeyValue keyValueField;

        private SignatureKeyInfoX509Data x509DataField;

        /// <remarks/>
        public SignatureKeyInfoKeyValue KeyValue
        {
            get
            {
                return keyValueField;
            }
            set
            {
                keyValueField = value;
            }
        }

        /// <remarks/>
        public SignatureKeyInfoX509Data X509Data
        {
            get
            {
                return x509DataField;
            }
            set
            {
                x509DataField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoKeyValue
    {

        private SignatureKeyInfoKeyValueRSAKeyValue rSAKeyValueField;

        /// <remarks/>
        public SignatureKeyInfoKeyValueRSAKeyValue RSAKeyValue
        {
            get
            {
                return rSAKeyValueField;
            }
            set
            {
                rSAKeyValueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoKeyValueRSAKeyValue
    {

        private string modulusField;

        private string exponentField;

        /// <remarks/>
        public string Modulus
        {
            get
            {
                return modulusField;
            }
            set
            {
                modulusField = value;
            }
        }

        /// <remarks/>
        public string Exponent
        {
            get
            {
                return exponentField;
            }
            set
            {
                exponentField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoX509Data
    {

        private string x509SubjectNameField;

        private string x509CertificateField;

        /// <remarks/>
        public string X509SubjectName
        {
            get
            {
                return x509SubjectNameField;
            }
            set
            {
                x509SubjectNameField = value;
            }
        }

        /// <remarks/>
        public string X509Certificate
        {
            get
            {
                return x509CertificateField;
            }
            set
            {
                x509CertificateField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureObject
    {

        private QualifyingProperties qualifyingPropertiesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public QualifyingProperties QualifyingProperties
        {
            get
            {
                return qualifyingPropertiesField;
            }
            set
            {
                qualifyingPropertiesField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://uri.etsi.org/01903/v1.3.2#", IsNullable = false)]
    public partial class QualifyingProperties
    {

        private QualifyingPropertiesSignedProperties signedPropertiesField;

        private string targetField;

        /// <remarks/>
        public QualifyingPropertiesSignedProperties SignedProperties
        {
            get
            {
                return signedPropertiesField;
            }
            set
            {
                signedPropertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Target
        {
            get
            {
                return targetField;
            }
            set
            {
                targetField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedProperties
    {

        private QualifyingPropertiesSignedPropertiesSignedSignatureProperties signedSignaturePropertiesField;

        private string idField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignatureProperties SignedSignatureProperties
        {
            get
            {
                return signedSignaturePropertiesField;
            }
            set
            {
                signedSignaturePropertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignatureProperties
    {

        private DateTime signingTimeField;

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificate signingCertificateField;

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole signerRoleField;

        /// <remarks/>
        public DateTime SigningTime
        {
            get
            {
                return signingTimeField;
            }
            set
            {
                signingTimeField = value;
            }
        }

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificate SigningCertificate
        {
            get
            {
                return signingCertificateField;
            }
            set
            {
                signingCertificateField = value;
            }
        }

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole SignerRole
        {
            get
            {
                return signerRoleField;
            }
            set
            {
                signerRoleField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificate
    {

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCert certField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCert Cert
        {
            get
            {
                return certField;
            }
            set
            {
                certField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCert
    {

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertCertDigest certDigestField;

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertIssuerSerial issuerSerialField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertCertDigest CertDigest
        {
            get
            {
                return certDigestField;
            }
            set
            {
                certDigestField = value;
            }
        }

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertIssuerSerial IssuerSerial
        {
            get
            {
                return issuerSerialField;
            }
            set
            {
                issuerSerialField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertCertDigest
    {

        private DigestMethod digestMethodField;

        private string digestValueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public DigestMethod DigestMethod
        {
            get
            {
                return digestMethodField;
            }
            set
            {
                digestMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string DigestValue
        {
            get
            {
                return digestValueField;
            }
            set
            {
                digestValueField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class DigestMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }
            set
            {
                algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSigningCertificateCertIssuerSerial
    {

        private string x509IssuerNameField;

        private string x509SerialNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string X509IssuerName
        {
            get
            {
                return x509IssuerNameField;
            }
            set
            {
                x509IssuerNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string X509SerialNumber
        {
            get
            {
                return x509SerialNumberField;
            }
            set
            {
                x509SerialNumberField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRole
    {

        private QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles claimedRolesField;

        /// <remarks/>
        public QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles ClaimedRoles
        {
            get
            {
                return claimedRolesField;
            }
            set
            {
                claimedRolesField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public partial class QualifyingPropertiesSignedPropertiesSignedSignaturePropertiesSignerRoleClaimedRoles
    {

        private string claimedRoleField;

        /// <remarks/>
        public string ClaimedRole
        {
            get
            {
                return claimedRoleField;
            }
            set
            {
                claimedRoleField = value;
            }
        }
    }


}
