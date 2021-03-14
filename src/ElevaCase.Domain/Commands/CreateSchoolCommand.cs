namespace ElevaCase.Domain.Commands
{
    public class CreateSchoolCommand : SchoolCommand
    {
        public CreateSchoolCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
