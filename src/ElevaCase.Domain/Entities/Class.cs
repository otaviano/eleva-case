namespace ElevaCase.Domain.Entities
{
    public class @Class
    {
        public int Id { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}