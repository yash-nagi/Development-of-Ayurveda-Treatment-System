using System;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Interface;

public interface IEbooks
{
    Task<EBooks> AddEbook(EBooks model);
    Task<EBooks> GetByIdAsync(string Id);
    Task<bool> DeleteByIdAsync(string Id);
    Task<bool> EditByIdAsync(EBooks model);
}
