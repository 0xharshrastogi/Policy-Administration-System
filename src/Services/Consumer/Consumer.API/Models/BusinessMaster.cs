using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class BusinessMaster
{
    [Key]
    public Guid BusinessTypeID { get; set; }

    public string BusinessType { get; set; }

    public DateTime ModifyDate { get; set; }

    public string ModifiedBy { get; set; }
}