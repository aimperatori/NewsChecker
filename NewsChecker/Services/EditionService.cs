using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Edition;
using NewsChecker.Models;

namespace NewsChecker.Services
{
    public class EditionService
    {
        private readonly NewsCheckerContext _context;
        private readonly IMapper _mapper;

        public EditionService(NewsCheckerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DbSet<Edition> Get()
        {
            return _context.Edition;
        }

        public ReadEditionDTO? Get(int id)
        {
            Edition? edition = _context.Edition.FirstOrDefault(edition => edition.Id == id);

            if (edition != null)
            {
                ReadEditionDTO editionDTO = _mapper.Map<ReadEditionDTO>(edition);
                return editionDTO;
            }

            return null;
        }

        public ReadEditionDTO Post(CreateEditionDTO editionDTO)
        {
            Edition edition = _mapper.Map<Edition>(editionDTO);
            _context.Edition.Add(edition);
            _context.SaveChanges();

            return _mapper.Map<ReadEditionDTO>(edition);
        }

        public Result Put(UpdateEditionDTO editionDTO, int id)
        {
            Edition? edition = _context.Edition.FirstOrDefault(edition => edition.Id == id);

            if (edition == null)
            {
                return Result.Fail("Edição não encontrada.");
            }

            _mapper.Map(editionDTO, edition);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Edition? edition = _context.Edition.FirstOrDefault(_ => _.Id == id);

            if (edition == null)
            {
                return Result.Fail("Edição não encontrada.");
            }

            _context.Remove(edition);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
