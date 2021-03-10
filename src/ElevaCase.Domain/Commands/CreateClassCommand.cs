namespace ElevaCase.Domain.Commands
{
    public class CreateClassCommand : ClassCommand
    {
        public CreateClassCommand(int schoolId, string name, string description)
        {
            SchoolId = schoolId;
            Name = name;
            Description = description;
        }
    }
}
