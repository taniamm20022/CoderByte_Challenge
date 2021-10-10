using System;
namespace CoderByte_WebApp.Models
{
    public class LossTypeRow
    {
        public int LossTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
