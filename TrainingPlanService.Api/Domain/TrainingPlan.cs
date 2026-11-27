namespace TrainingPlanService.Api.Domain;

public class TrainingPlan
{
    public string Name { get; }
    public IReadOnlyList<Exercise> Exercises { get; }

    public TrainingPlan(string name, IEnumerable<Exercise> exercises)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Navn må ikke være tomt.", nameof(name));

        var list = exercises.ToList();
        if (list.Count == 0)
            throw new ArgumentException("En træningsplan skal have mindst én øvelse.", nameof(exercises));

        Name = name;
        Exercises = list;
    }
}