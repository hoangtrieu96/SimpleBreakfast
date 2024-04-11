
using SimpleBreakfast.Models.Entities;

namespace SimpleBreakfast.Services.BreakfastService;

public interface IBreakfastRepository 
{
    void CreateBreakfast(Breakfast breakfast);
    IEnumerable<Breakfast> GetBreakfasts();
    Breakfast? GetBreakfast(Guid id);
    void UpdateBreakfast(Breakfast breakfast);
    void RemoveBreakfast(Breakfast breakfast);
    void SaveChanges();
}