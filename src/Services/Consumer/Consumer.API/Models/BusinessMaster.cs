using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class BusinessMaster{
    [Key]
    public string BusinessType{get;set;}
}