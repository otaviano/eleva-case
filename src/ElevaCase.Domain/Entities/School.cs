using System.Collections.Generic;

namespace ElevaCase.Domain.Entities
{
    public class School
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<@Class> Classes { get; set; }
    }
}
