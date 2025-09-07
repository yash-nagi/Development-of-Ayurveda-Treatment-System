using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Repository;

public class EbooksRepository : IEbooks
{
    private readonly AyurgrowDBContext _context;
    public EbooksRepository(AyurgrowDBContext context)
    {
        _context = context;
    }
    public async Task<EBooks> AddEbook(EBooks model)
    {
        try
        {
            _context.EBooks.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<EBooks> GetByIdAsync(string Id)
    {
        try
        {
            var model = _context.EBooks.FirstOrDefault(id => id.BookId == Id.ToString());
            if (model != null)
            {
                return model;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<bool> DeleteByIdAsync(string Id)
    {
        try
        {
            var model = _context.EBooks.FirstOrDefault(id => id.BookId == Id.ToString());
            if (model != null)
            {
                _context.EBooks.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task<bool> EditByIdAsync(EBooks model)
    {
        try
        {
            var book = _context.EBooks.FirstOrDefault(id => id.BookId == model.BookId.ToString());
            if (book != null)
            {
                book.BookName = model.BookName;
                book.AuthorName = model.AuthorName;
                book.EditionNo = model.EditionNo;
                book.DateOfPublish = model.DateOfPublish;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
