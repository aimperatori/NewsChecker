using AutoMapper;
using FluentResults;
using NewsChecker.Data;
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

        public IList<Newspaper> Get()
        {
            return _mapper.Map<List<Newspaper>>(_context.Newspaper);
        }

        public ReadNewspaperDTO? Get(int id)
        {
            var newspaper = FindNewspaper(id);

            if (newspaper is not null)
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
            var newspaper = FindNewspaper(id);

            if (newspaper is null)
            {
                return Result.Fail("Jornal não encontrado.");
            }

            _mapper.Map(newspaperDTO, newspaper);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            var newspaper = FindNewspaper(id);

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
