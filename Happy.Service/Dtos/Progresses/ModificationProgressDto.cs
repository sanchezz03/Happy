namespace Happy.Service.Dtos.Progresses;

public class ModificationProgressDto : ProgressDto
{
    public string UserId { get; set; }
    public long ExerciseId { get; set; }
}
