using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenda.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenda.DAL.Repositorios.Contrato;
using SistemaVenda.DAL.Repositorios;

using SistemaVenda.Utility;
using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.BLL.Servicos;

namespace SistemaVenda.IOC
{
    public static class Dependencia
    {
        public static void InjectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbvendaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadeiaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IRoleService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IImpostoService, ImpostoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IMenuService, MenuService>();
        }
    }
}
