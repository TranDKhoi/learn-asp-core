using AutoMapper;
using LearnASP.Core.Contracts;
using LearnASP.Models;

namespace LearnASP.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ICategoryRepo Category { get; private set; }
        public IProductRepo Product { get; private set; }

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            Category = new CategoryRepo(context);
            Product = new ProductRepo(context);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
