using System;

namespace DeviceManager.Model.Abstract
{
    public interface IAuditable
    {
        DateTime CreatedDate { set; get; }
        string CreatedBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        string UpdatedBy { set; get; }
        string Note { get; set; }
    }
}