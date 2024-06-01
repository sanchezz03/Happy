namespace Happy.Domain.Entities;

public class Exercise : Base<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int? Weight { get; set; }
    public int NumberOfRepetitions { get; set; }

    #region Navigation properties

    public ICollection<ComplexExercise> ComplexExercises { get; set; } = new List<ComplexExercise>();

    public ICollection<Progress> Progresses { get; set; } = new List<Progress>();

    #endregion
}
