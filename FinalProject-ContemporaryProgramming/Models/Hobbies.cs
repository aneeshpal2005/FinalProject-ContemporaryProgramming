namespace FinalProject_ContemporaryProgramming.Models
{
    public class Hobbies
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int HobbiesId { get; set; } = 0;
    }
}
