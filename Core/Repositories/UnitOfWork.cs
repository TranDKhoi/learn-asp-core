using AutoMapper;
using LearnASP.Core.Contracts;
using LearnASP.Models;
using Microsoft.Extensions.Configuration;

namespace LearnASP.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ICategoryRepo Category { get; private set; }
        public IProductRepo Product { get; private set; }
        public IUserRepo User { get; private set; }

        public UnitOfWork(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;

            Category = new CategoryRepo(context);
            Product = new ProductRepo(context);
            User = new UserRepo(context, _configuration);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
