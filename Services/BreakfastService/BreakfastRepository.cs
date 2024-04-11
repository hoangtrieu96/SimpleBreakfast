using SimpleBreakfast.Models;
using SimpleBreakfast.Models.Entities;

namespace SimpleBreakfast.Services.BreakfastService;

public class BreakfastRepository : IBreakfastRepository
{
    private BreakfastContext _dbContext;

    public BreakfastRepository(BreakfastContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateBreakfast(Breakfast breakfast)
    {
        _dbContext.Breakfasts.Add(breakfast);
    }

    public Breakfast? GetBreakfast(Guid id)
    {
        return _dbContext.Breakfasts
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
    }

    public IEnumerable<Breakfast> GetBreakfasts()
    {
        return _dbContext.Breakfasts;
    }

    public void RemoveBreakfast(Breakfast breakfast)
    {
        _dbContext.Remove(breakfast);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public void UpdateBreakfast(Breakfast breakfast)
    {
        _dbContext.Breakfasts.Update(breakfast);
    }
}