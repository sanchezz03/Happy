namespace Happy.Domain.Entities;

public class ComplexExercise : Base<long>
{
    public long ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    public long ComplexId { get; set; }
    public Complex Complex { get; set; }
}
