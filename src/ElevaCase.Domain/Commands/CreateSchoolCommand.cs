namespace ElevaCase.Domain.Commands
{
    public class CreateSchoolCommand : SchoolCommand
    {
        public CreateSchoolCommand(string name, string description) // TODO: school ID
        {
            Name = name;
            Description = description;
        }
    }
}
