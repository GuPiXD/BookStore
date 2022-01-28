using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStore.Data.DataDB.DAL.Models;
using BookStore.Data.DataDB.DAL;
using BookStore.Data.DataDB.BL.DTOs;

namespace BookStore.Data.DataDB.BL
{
  public class AuthorRepository : IRepository<AuthorDTO>
  {
    private IMapper mapper;

    private BookLibraryDbContext context;
    public AuthorRepository(BookLibraryDbContext context, IMapper mapper)
    {
      this.context = context;
      this.mapper = mapper;
    }

    public void Create(AuthorDTO authorDTO)
    {
      authorDTO.Id = Guid.NewGuid().ToString();
      context.Authors.Add(mapper.Map<AuthorDTO, Author>(authorDTO));
    }

    public void Delete(string id)
    {
      var authorInDB = context.Authors.SingleOrDefault(a => a.Id.ToString() == id);
      if (authorInDB != null)
      {
        context.Authors.Remove(authorInDB);
      }
    }

    public AuthorDTO Get(string id)
    {
      //Добавлен AsNoTracking(), так как этот метод используется для проверки пустых ссылок в действии Edit в AuthorsController. В противном случае сущность не будет обновляться
      var authorInDB = context.Authors.Include(a => a.Books).AsNoTracking().SingleOrDefault(a => a.Id.ToString() == id);
      var authorDTO = mapper.Map<Author, AuthorDTO>(authorInDB);
      authorDTO.Id = authorInDB.Id.ToString();

      return authorDTO;
    }

    public IEnumerable<AuthorDTO> GetAll()
    {
      var authorQuery = context.Authors.Include(a => a.Books).ToList();
      //Расширен запрос Linq, так как Author и AuthorDTO имеют разные типы для свойства Id.
      var authorDetailedDTOList = authorQuery.Select(a => {
        var b = mapper.Map<Author, AuthorDTO>(a);
        b.Id = a.Id.ToString();
        return (b);
      });

      return authorDetailedDTOList;
    }

    public int GetAmount()
    {
      throw new NotImplementedException();
    }

    public void Update(AuthorDTO authorDTO)
    {
      var author = mapper.Map<AuthorDTO, Author>(authorDTO);
      author.Id = new Guid(authorDTO.Id);

      context.Entry(author).State = EntityState.Modified;
    }
  }
}
