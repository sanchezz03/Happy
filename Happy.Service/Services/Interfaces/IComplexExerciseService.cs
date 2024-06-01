namespace Happy.Service.Services.Interfaces;

public interface IComplexExerciseService
{
    Task CreateAsync(long complexId, string exerciseName);
    Task DeleteAsync(long complexId, string exerciseName);
}
