using TrainingPlanService.Api.Domain;

namespace TrainingPlanService.Tests;

public class TrainingPlanTests
{
    [Fact]
    public void Constructor_ValidInput_CreatesPlan()
    {
        var exercises = new[] { new Exercise("Squat", 3, 10) };

        var plan = new TrainingPlan("Styrke", exercises);

        Assert.Equal("Styrke", plan.Name);
        Assert.Single(plan.Exercises);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_EmptyName_Throws(string name)
    {
        var exercises = new[] { new Exercise("Squat", 3, 10) };

        Assert.Throws<ArgumentException>(() => new TrainingPlan(name, exercises));
    }

    [Fact]
    public void Constructor_NoExercises_Throws()
    {
        Assert.Throws<ArgumentException>(() => new TrainingPlan("Styrke", []));
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(3, 0)]
    public void Exercise_NonPositiveSetsOrReps_Throws(int sets, int reps)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Exercise("Squat", sets, reps));
    }
}