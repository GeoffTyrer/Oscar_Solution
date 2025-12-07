namespace OscarModel_Lib.Models
{
    public class Person
    {
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
