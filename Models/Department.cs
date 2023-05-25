namespace Inflowmation.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Employee>? Members { get; set; }


    }
}
