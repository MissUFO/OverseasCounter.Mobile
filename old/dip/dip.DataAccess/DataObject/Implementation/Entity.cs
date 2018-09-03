using System;
using System.Xml.Linq;
using dip.DataAccess.DataObject.Interface;

namespace dip.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// Basic object implementation
    /// </summary>
    public class Entity : IEntity
    {
        public Int32 Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public void UnpackXML(XElement xml, string childNodeName = null)
        {
            XElement workingXML = null;

            if (string.IsNullOrWhiteSpace(childNodeName))
            {
                workingXML = xml;
            }
            else
            {
                if (xml != null)
                {
                    workingXML = xml.Element(childNodeName);
                }
            }
            if (workingXML == null)
            {
                return;
            }
            CreateObjectFromXml(workingXML);
        }

        protected virtual void CreateObjectFromXml(XElement xml)
        {

        }
    }
}
