using AutoMapper;
using FluentResults;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Journalist;
using NewsChecker.Models;

namespace NewsChecker.Services
{
    public class JournalistService
    {
        private readonly NewsCheckerContext _context;
        private readonly IMapper _mapper;

        public JournalistService(NewsCheckerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<Journalist> Get()
        {
            return _mapper.Map<List<Journalist>>(_context.Journalist);
        }

        public ReadJournalistDTO? Get(int id)
        {
            Journalist? journalist = FindJournalist(id);

            if (journalist != null)
            {
                return _mapper.Map<ReadJournalistDTO>(journalist);
            }

            return null;
        }

        public ReadJournalistDTO Post(CreateJournalistDTO journalistDTO)
        {
            Journalist journalist = _mapper.Map<Journalist>(journalistDTO);
            _context.Journalist.Add(journalist);
            _context.SaveChanges();

            return _mapper.Map<ReadJournalistDTO>(journalist);
        }

        public Result Put(UpdateJournalistDTO journalistDTO, int id)
        {
            Journalist? journalist = FindJournalist(id);

            if (journalist == null)
            {
                return Result.Fail("Jornalista não encontrado.");
            }

            _mapper.Map(journalistDTO, journalist);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Journalist? journalist = FindJournalist(id);

            if (journalist == null)
            {
                return Result.Fail("Jornalista não encontrado.");
            }

            _context.Remove(journalist);
            _context.SaveChanges();
            return Result.Ok();
        }


        private Journalist? FindJournalist(int id)
        {
            return _context.Journalist.FirstOrDefault(_ => _.Id == id);
        }
    }
}
