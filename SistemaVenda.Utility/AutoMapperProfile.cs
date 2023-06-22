using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaVenda.DTO;
using SistemaVenda.Model;

namespace SistemaVenda.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion Menu

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.RolDescricao,
                    opt => opt.MapFrom(origin => origin.IdRolNavigation.Nome)
                )
                .ForMember(destino =>
                destino.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == true ? 1 : 0)
                );

            CreateMap<Usuario, SessaoDTO>()
                .ForMember(destino =>
                destino.RolDescricao,
                opt => opt.MapFrom(origin => origin.IdRolNavigation.Nome)
                );

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo ==1?true:false)
                );
            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(destino =>
                destino.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == true ? 1 : 0)
                );

            CreateMap<CategoriaDTO, Categoria>()
               .ForMember(destino =>
               destino.IsActivo,
               opt => opt.MapFrom(origin => origin.IsActivo == 1 ? true : false)
               );
            #endregion Categoria

            #region Marca
            CreateMap<Marca, MarcaDTO>()
                 .ForMember(destino =>
                destino.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == true ? 1 : 0)
                );

            CreateMap<MarcaDTO, Marca>()
                 .ForMember(destino =>
                destino.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == 1 ? true : false)
                );
            #endregion Marca

            #region Imposto
            CreateMap<Imposto, ImpostoDTO>()
                 .ForMember(destino =>
                 destino.Taxa,
                 opt => opt.MapFrom(origin => Convert.ToString(origin.Taxa.Value))
                 );

            CreateMap<ImpostoDTO, Imposto>()
                .ForMember(destino =>
                destino.Taxa,
                opt =>opt.MapFrom(origin => Convert.ToDecimal(origin.Taxa))
                );
            #endregion Imposto

            #region Produto
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(destino =>
                destino.DescricaoCategoria,
                opt => opt.MapFrom(origin => origin.IdCategoriaNavigation.Nome)
                )
                .ForMember(destino =>
                 destino.DescricaoMarca,
                opt => opt.MapFrom(origin => origin.IdMarcaNavigation.Nome)
                )
                 .ForMember(destino =>
                destino.DescricaoImposto,
                opt => opt.MapFrom(origin => origin.IdImpostoNavigation.Nome)
                )
                 .ForMember(destino =>
                 destino.Preco,
                 opt => opt.MapFrom(origin => Convert.ToString(origin.Preco.Value, new CultureInfo("pt-AO")))
                 )
                 .ForMember(destino =>
                  destino.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == true ? 1 : 0)
                );

            CreateMap<ProdutoDTO, Produto>()
                .ForMember(destino =>
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                 destino.IdMarcaNavigation,
                opt => opt.Ignore()
                )
                 .ForMember(destino =>
                destino.IdImpostoNavigation,
                opt => opt.Ignore()
                )
                 .ForMember(destino =>
                 destino.Preco,
                 opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Preco, new CultureInfo("pt-AO")))
                 )
                 .ForMember(destino =>
                  destino.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == 1 ? true : false)
                );
            #endregion Produto

            #region Venda
            CreateMap<Venda, VendaDTO>()
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("pt-AO")))
                )
                .ForMember(destino =>
                destino.DataRegisto,
                opt => opt.MapFrom(origen => origen.DataRegisto.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<VendaDTO, Venda>()
                 .ForMember(destino =>
                 destino.Total,
                 opt => opt.MapFrom(origin => Convert.ToDecimal(origin.TotalTexto, new CultureInfo("pt-AO")))
                 );
              
            #endregion Venda

            #region DetalheVenda
            CreateMap<DetalheVenda, DetalheVendaDTO>()
                .ForMember(destino =>
                destino.DescricaoProduto,
                opt => opt.MapFrom(origin => origin.IdProdutoNavigation.Nome)
                )
                .ForMember(destino =>
                destino.PrecoTexto,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Preco.Value, new CultureInfo("pt-AO")))
                )
                .ForMember(destino =>
                destino.TotalTexto,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("pt-AO")))
                )
             .ForMember(destino =>
                destino.Desconto,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Desconto.Value))
                );

            CreateMap<DetalheVendaDTO, DetalheVenda>()
               .ForMember(destino =>
               destino.Preco,
               opt => opt.MapFrom(origin => Convert.ToDecimal(origin.PrecoTexto, new CultureInfo("pt-AO")))
               )
               .ForMember(destino =>
               destino.Total,
               opt => opt.MapFrom(origin => Convert.ToDecimal(origin.TotalTexto, new CultureInfo("pt-AO")))
               )
               .ForMember(destino =>
               destino.Desconto,
               opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Desconto, new CultureInfo("pt-AO")))
               );

            #endregion DetalheVEnda

            #region Reporte
            CreateMap<DetalheVenda, ReporteDTO>()
                .ForMember(destino =>
                destino.DataRegisto,
                opt => opt.MapFrom(origin => origin.IdVendaNavigation.DataRegisto.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino =>
                destino.NumeroDocumento,
                opt => opt.MapFrom(origin => origin.IdVendaNavigation.NumeroDocumento)
                )
                .ForMember(destino =>
                destino.TipoPagamento,
                opt => opt.MapFrom(origin => origin.IdVendaNavigation.TipoPagamento)
                )
                .ForMember(destino =>
                  destino.TotalVenda,
                  opt => opt.MapFrom(origin => Convert.ToString(origin.IdVendaNavigation.Total.Value, new CultureInfo("pt-AO")))
                )
                .ForMember(destino =>
                destino.Produto,
                opt => opt.MapFrom(origin => origin.IdProdutoNavigation.Nome)
                )
                 .ForMember(destino =>
                  destino.Preco,
                  opt => opt.MapFrom(origin => Convert.ToString(origin.Preco.Value, new CultureInfo("pt-AO")))
                )
                  .ForMember(destino =>
                  destino.Total,
                  opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("pt-AO")))
                );
            #endregion Reporte




        }
    }
}
