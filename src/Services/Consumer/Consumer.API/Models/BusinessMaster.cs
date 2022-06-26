using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class BusinessMaster
{
    [Key]
    public Guid BusinessTypeID { get; set; }
    public string BusinessName { get; set; }
    private DateTime modifyDate;
    public DateTime ModifyDate
    {
        get { return modifyDate; }
        set { modifyDate = DateTime.Now; }
    }
    public string ModifiedBy { get; set; }
}