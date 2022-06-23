using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consumer.API.Models;
public class Business
{
    [Key]
    public Guid BusinessID{get;set;}
    public string BusinessType{get;set;}
    public int TotalEmployees{get;set;}
    public int AnnualTurnover{get;set;}
    public int BusinessValue{get;set;}
}