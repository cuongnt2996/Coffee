using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee.Models;
[Table("EmployeeStatus")]
public class EmployeeStatus
{
    public int StatusId { get; set; }
    public string StatusCode { get; set; } = null!;
    public string StatusName { get; set; } = null!;
    public string? Description { get; set; }
    public int OrderNo { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime?  ModifiedDate{ get; set; }
}