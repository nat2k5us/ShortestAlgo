using System;
using System.Collections.Generic;
using System.Text;

namespace stoneeagle
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class root
    {

        private rootPlayer[] playersField;

        private string[] mapField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("player", IsNullable = false)]
        public rootPlayer[] players
        {
            get
            {
                return this.playersField;
            }
            set
            {
                this.playersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        public string[] map
        {
            get
            {
                return this.mapField;
            }
            set
            {
                this.mapField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootPlayer
    {

        private rootPlayerTile[] tileField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tile")]
        public rootPlayerTile[] tile
        {
            get
            {
                return this.tileField;
            }
            set
            {
                this.tileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootPlayerTile
    {

        private string terrainField;

        private string costField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string terrain
        {
            get
            {
                return this.terrainField;
            }
            set
            {
                this.terrainField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string cost
        {
            get
            {
                return this.costField;
            }
            set
            {
                this.costField = value;
            }
        }
    }


}
