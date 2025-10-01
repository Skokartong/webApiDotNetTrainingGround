using webApiDotNetTrainingGround.Models;
public class Db
{
    public Db()
    {
        Developers = new List<Developer>() {
            new Developer() { Id = 1, Name = "Marcus", Role = "DevOps Engineer", Experience = 5 },
            new Developer() { Id = 2, Name = "Beatrice", Role = "Frontend Developer", Experience = 3 },
        };
    }
    public List<Developer> Developers { get; set; }
}