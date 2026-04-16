namespace FinalProject_ContemporaryProgramming.Models
{
    public class TeamMember
    {
        public int TeamMemberId { get; set; }
        public required string TeamMemberBirthdate{ get; set; }
        public required string TeamMemberName { get; set; }
        public required string TeamMemberProgram { get; set; }
        public required string TeamMemberYear { get; set; }

        // dotnet-ef migrations add TeamMember
        // add this model to the database, then update the database

        // dotnet-ef database update

    }
}
