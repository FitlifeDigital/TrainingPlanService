namespace TrainingPlanService.Api.Domain;

public class Exercise
{
    public string Name { get; }
    public int Sets { get; }
    public int Reps { get; }

    public Exercise(string name, int sets, int reps)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Navn må ikke være tomt.", nameof(name));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sets);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(reps);

        Name = name;
        Sets = sets;
        Reps = reps;
    }
}