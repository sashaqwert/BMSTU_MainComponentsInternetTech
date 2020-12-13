using System;
using System.Xml.Serialization;

namespace RK_2
{
    [XmlRoot(ElementName = "RK2Class")]
    public class XMLatrTest
    {
        [XmlIgnore]
        public int var1;

        [XmlAttribute(AttributeName = "NumberWitchDotPoint")]
        public double var2;

        [XmlAttribute(AttributeName = "ZeroOrOne")]
        public bool var3;

        [XmlAttribute(AttributeName = "TheSring")]
        public string var4;

        public override string ToString()
        {
            return var1 + "\n" + var2 + "\n" + var3 + "\n" + var4 + "\n";
        }
    }
}
