using System;
using System.Xml.Linq;
using dip.DataAccess.DataManager.Extension;

namespace dip.DataAccess.DataObject.Implementation
{
    /// <summary>
    /// Custom error
    /// </summary>
    public class Error : Entity
    {
        public int UserId { get; set; }
        public long ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<int>();
            this.UserId = xml.Attribute("UserId").ToType<int>();
            this.ErrorCode = xml.Attribute("ErrorCode").ToType<long>();
            this.ErrorMessage = xml.Attribute("ErrorMessage").ToType<string>();
            this.StackTrace = xml.Attribute("StackTrace").ToType<string>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }

    }
}
