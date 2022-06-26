using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class PropertyMaster
{
    
    [Key]
    public Guid PropertyTypeID { get; set; }
    public string PropertyName { get; set; }
    private DateTime modifyDate;
    public DateTime ModifyDate
    {
        get{return modifyDate;}
        set { modifyDate = DateTime.Now; }
    }
    public string ModifiedBy { get; set; }
}