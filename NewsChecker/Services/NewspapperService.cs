using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using NewsChecker.Data;
using NewsChecker.Data.DTO.Newspapper;
using NewsChecker.Data.DTO.Newspapper;
using NewsChecker.Models;

namespace NewsChecker.Services
{
    public class NewspapperService
    {
        private readonly NewsCheckerContext _context;
        private readonly IMapper _mapper;

        public NewspapperService(NewsCheckerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DbSet<Newspapper> Get()
        {
            return _context.Newspapper;
        }

        public ReadNewspapperDTO? Get(int id)
        {
            Newspapper? Newspapper = FindNewspapper(id);

            if (Newspapper != null)
            {
                return _mapper.Map<ReadNewspapperDTO>(Newspapper);
            }

            return null;
        }

        public ReadNewspapperDTO Post(CreateNewspapperDTO NewspapperDTO)
        {
            Newspapper Newspapper = _mapper.Map<Newspapper>(NewspapperDTO);
            _context.Newspapper.Add(Newspapper);
            _context.SaveChanges();

            return _mapper.Map<ReadNewspapperDTO>(Newspapper);
        }

        public Result Put(UpdateNewspapperDTO NewspapperDTO, int id)
        {
            Newspapper? Newspapper = FindNewspapper(id);

            if (Newspapper == null)
            {
                return Result.Fail("Jornal não encontrado.");
            }

            _mapper.Map(NewspapperDTO, Newspapper);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            Newspapper? Newspapper = FindNewspapper(id);

            if (Newspapper == null)
            {
                return Result.Fail("Jornal não encontrado.");
            }

            _context.Remove(Newspapper);
            _context.SaveChanges();
            return Result.Ok();
        }


        private Newspapper? FindNewspapper(int id)
        {
            return _context.Newspapper.FirstOrDefault(_ => _.Id == id);
        }
    }
}
