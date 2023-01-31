using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.BLL.Servicos.Contrato;
using SistemaVenda.DAL.Repositorios.Contrato;
using SistemaVenda.DTO;
using SistemaVenda.Model;

namespace SistemaVenda.BLL.Servicos
{
    public class VendaService:IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private IGenericRepository<DetalheVenda> _detalheVendaRepositorio;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IGenericRepository<DetalheVenda> detalheVendaRepositorio, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _detalheVendaRepositorio = detalheVendaRepositorio;
            _mapper = mapper;
        }

        public async Task<VendaDTO> Registar(VendaDTO modelo)
        {
            try
            {
                var vendaGerada = await _vendaRepository.Registar(_mapper.Map<Venda>(modelo));

                if(vendaGerada.IdVenda == 0)
                    throw new TaskCanceledException("Não é possível criar");
                return _mapper.Map<VendaDTO>(vendaGerada);

            }
            catch
            {
                throw;

            }
        }

        public async Task<List<VendaDTO>> Historico(string buscarPor, string numeroVenda, string dataInicio, string dataFim)
        {
            IQueryable<Venda> query = await _vendaRepository.Consultar();
            var ListaResultado = new List<Venda>();

            try
            {
                if(buscarPor == "data")
                {
                    DateTime data_Inicio = DateTime.ParseExact(dataInicio, "dd/MM/yyyy", new CultureInfo("pt-AO"));
                    DateTime data_fim = DateTime.ParseExact(dataFim, "dd/MM/yyyy", new CultureInfo("pt-AO"));

                    ListaResultado = await query.Where(venda =>
                    venda.DataRegisto.Value.Date >= data_Inicio.Date && venda.DataRegisto.Value.Date <= data_fim.Date
                    ).Include(detalheV => detalheV.DetalheVenda).ThenInclude(prod => prod.IdProdutoNavigation)
                    .ToListAsync();
                }
                else
                {
                    ListaResultado = await query.Where(venda => venda.NumeroDocumento == numeroVenda)
                        .Include(detalheV => detalheV.DetalheVenda).ThenInclude(prod => prod.IdProdutoNavigation)
                        .ToListAsync();
                }
               

            }
            catch
            {
                throw;

            }

            return _mapper.Map<List<VendaDTO>>(ListaResultado); 
        }

        public async Task<List<ReporteDTO>> Reporte(string dataInicio, string dataFim)
        {
            IQueryable<DetalheVenda> query = await _detalheVendaRepositorio.Consultar();
            var ListaResultado = new List<DetalheVenda>();
            try
            {
                DateTime data_inicio = DateTime.ParseExact(dataInicio, "dd/MM/yyyy", new CultureInfo("pt-AO"));
                DateTime data_fim = DateTime.ParseExact(dataFim, "dd/MM/yyyy", new CultureInfo("pt-AO"));

                ListaResultado = await query.Include(prod => prod.IdProdutoNavigation)
                    .Include(vend => vend.IdVendaNavigation)
                    .Where(detalheV => detalheV.IdVendaNavigation.DataRegisto.Value.Date >= data_inicio.Date
                    && detalheV.IdVendaNavigation.DataRegisto.Value.Date <= data_fim.Date)
                    .ToListAsync();

            }
            catch
            {
                throw;

            }

            return _mapper.Map<List<ReporteDTO>>(ListaResultado);   
        }
    }
}
