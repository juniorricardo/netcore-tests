namespace Poke.API.Entities
{
    public class Employee : BaseEntity
    {
        public string EndDate  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StartDate { get; set; }
        public string Title { get; set; }

        public Employee()
        {
        }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}