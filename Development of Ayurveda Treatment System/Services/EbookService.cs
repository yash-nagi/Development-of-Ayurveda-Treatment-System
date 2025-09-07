using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Services;

public class EbookService
{
    private readonly IEbooks _ebook;
    public EbookService(IEbooks ebooks)
    {
        _ebook = ebooks;
    }
    public async Task<(bool IsSuccess, string message)> AddNewBook(EBooks model)
    {
        var bookExist = await _ebook.GetByIdAsync(model.BookId);
        if (bookExist != null)
        {
            return (false, "Ebook already exists.");
        }
        else
        {
            EBooks ebookAdd = new EBooks
            {
                BookId = model.BookId,
                BookName = model.BookName,
                AuthorName = model.AuthorName,
                EditionNo = model.EditionNo,
                DateOfPublish = model.DateOfPublish
            };
            var newEbook = await _ebook.AddEbook(ebookAdd);
            if (newEbook != null)
            {
                return (true, "Ebook added successfully.");
            }
            else
            {
                return (false, "Ebook already exists.");
            }
        }
    }
    public async Task<EBooks> GetEbook(string id)
    {
        var bookExist = await _ebook.GetByIdAsync(id);
        if (bookExist != null)
        {
            return bookExist;
        }
        else
        {
            return null;
        }
    }
    public async Task<(bool IsSuccess, string message)> EditEbook(EBooks eBooks)
    {
        var bookExist = await _ebook.GetByIdAsync(eBooks.BookId);
        if (bookExist == null)
        {
            return (false, "Ebook not exists.");
        }
        else
        {
            EBooks ebookEdit = new EBooks
            {
                BookId = eBooks.BookId,
                BookName = eBooks.BookName,
                AuthorName = eBooks.AuthorName,
                EditionNo = eBooks.EditionNo,
                DateOfPublish = eBooks.DateOfPublish
            };
            var newEbook = await _ebook.EditByIdAsync(ebookEdit);
            if (newEbook == true)
            {
                return (true, "Ebook update successfully.");
            }
            else
            {
                return (false, "Ebook update failed.");
            }
        }
    }
    public async Task<(bool IsSuccess, string message)> DeleteEbook(string id)
    {
        var result = await _ebook.DeleteByIdAsync(id);
        if (result)
        {
            return (result, "Delete Successfull");
        }
        else
        {
            return (result, "Delete Failed");
        }
    }
}
