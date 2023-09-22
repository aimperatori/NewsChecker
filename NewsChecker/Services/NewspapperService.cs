using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Newspaper;
using NewsChecker.Data.DTO.Newspaper;
using NewsChecker.Models;

namespace NewsChecker.Services
{
    public class NewspaperService
    {
        private readonly NewsCheckerContext _context;
        private readonly IMapper _mapper;

        public NewspaperService(NewsCheckerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DbSet<Newspaper> Get()
        {
            return _context.Newspaper;
        }

        public ReadNewspaperDTO? Get(int id)
        {
            Newspaper? newspaper = FindNewspaper(id);

            if (newspaper != null)
            {
                return _mapper.Map<ReadNewspaperDTO>(newspaper);
            }

            return null;
        }

        public ReadNewspaperDTO Post(CreateNewspaperDTO newspaperDTO)
        {
            Newspaper newspaper = _mapper.Map<Newspaper>(newspaperDTO);
            _context.Newspaper.Add(newspaper);
            _context.SaveChanges();

            return _mapper.Map<ReadNewspaperDTO>(newspaper);
        }

        public Result Put(UpdateNewspaperDTO newspaperDTO, int id)
        {
            Newspaper? newspaper = FindNewspaper(id);

            if (newspaper == null)
            {
                return Result.Fail("Jornal não encontrado.");
            }

            _mapper.Map(newspaperDTO, newspaper);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Newspaper? newspaper = FindNewspaper(id);

            if (newspaper == null)
            {
                return Result.Fail("Jornal não encontrado.");
            }

            _context.Remove(newspaper);
            _context.SaveChanges();
            return Result.Ok();
        }


        private Newspaper? FindNewspaper(int id)
        {
            return _context.Newspaper.FirstOrDefault(_ => _.Id == id);
        }
    }
}
