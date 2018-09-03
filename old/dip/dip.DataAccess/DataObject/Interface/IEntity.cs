using System;
using System.Xml.Linq;

namespace dip.DataAccess.DataObject.Interface
{
    /// <summary>
    /// Basic data object interface
    /// </summary>
    public interface IEntity
    {
        Int32 Id { get; set; }

        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }

        void UnpackXML(XElement xml, string childNodeName = null);
    }
}
