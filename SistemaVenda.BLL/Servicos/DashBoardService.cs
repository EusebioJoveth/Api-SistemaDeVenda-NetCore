using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DAL.Repositorios.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.Model;



namespace SistemaVenda.BLL.Servicos
{
    public class DashBoardService: IDashBoardService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IGenericRepository<Produto> _produtoRepositorio;
        private readonly IMapper _mapper;

        public DashBoardService(IVendaRepository vendaRepository, IGenericRepository<Produto> produtoRepositorio, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        private IQueryable<Venda>retornarVendas(IQueryable<Venda> tabelaVenda, int restarQuantidadeDias)
        {
            DateTime? ultimaData = tabelaVenda.OrderByDescending(vend => vend.DataRegisto)
                .Select(vend => vend.DataRegisto).First();

            ultimaData = ultimaData.Value.AddDays(restarQuantidadeDias);
            return tabelaVenda.Where(vend => vend.DataRegisto.Value.Date >= ultimaData.Value.Date);
        }

        private async Task<int> TotalVendasUltimaSemana()
        {
            int total = 0;
            IQueryable<Venda> _vendaQuery = await _vendaRepository.Consultar();

            if(_vendaQuery.Count() > 0)
            {
                var tabelaVenda = retornarVendas(_vendaQuery, -7);
                total= tabelaVenda.Count();
            }
            return total;
        }

        private async Task<string> TotalRendasUltimaSemana()
        {
            decimal resultado = 0;
            IQueryable<Venda> _vendaQuery = await _vendaRepository.Consultar();

            if(_vendaQuery.Count() > 0)
            {
                var tabelaVenda = retornarVendas(_vendaQuery, -7);
                resultado = tabelaVenda.Select(vend => vend.Total).Sum(vend => vend.Value);
            }

            return Convert.ToString(resultado, new CultureInfo("pt-AO"));
        }

        private async Task<int> TotalProdutos()
        {
            IQueryable<Produto> _produtoQuery = await _produtoRepositorio.Consultar();

            int total = _produtoQuery.Count();

            return total;
        }

        private async Task<Dictionary<string, int>> VendasUltimaSemana()
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            IQueryable<Venda> _vendaQuery = await _vendaRepository.Consultar();

            if(_vendaQuery.Count()>0)
            {
                var tabelaVenda = retornarVendas(_vendaQuery, - 7);

                resultado = tabelaVenda.GroupBy(vend => vend.DataRegisto.Value.Date)
                    .OrderBy(group => group.Key)
                    .Select(detalheV => new {data = detalheV.Key.ToString("dd/MM/yyyy"), total=detalheV.Count()})
                    .ToDictionary(keySelector: ret => ret.data, elementSelector: ret => ret.total) ;    
            }

            return resultado;
        }

        public async Task<DashBoardDTO> Resumo()
        {
            DashBoardDTO vmDashboard = new DashBoardDTO();

            try
            {
                vmDashboard.TotalVendas = await TotalVendasUltimaSemana();
                vmDashboard.ToatalRendas = await TotalRendasUltimaSemana();
                vmDashboard.TotalProdutos = await TotalProdutos();

                List<VendaSemanaDTO> listaVendaSemana = new List<VendaSemanaDTO>();
                foreach(KeyValuePair<string, int> item in await VendasUltimaSemana())
                {
                    listaVendaSemana.Add(new VendaSemanaDTO()
                    {
                        DataRegisto = item.Key,
                        Total = item.Value,
                    });
                }

                vmDashboard.VendasUltimaSemana = listaVendaSemana;

            }
            catch
            {
                throw;

            }

            return vmDashboard;
        }
    }
}
