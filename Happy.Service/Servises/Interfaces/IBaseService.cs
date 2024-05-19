namespace Happy.Service.Servises.Interfaces
{
    public interface IBaseService<TDto, KEntity> where TDto : class where KEntity : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task AddAsync(TDto client);
        Task UpdateAsync(TDto client);
        Task DeleteAsync(TDto client);
    }
}
