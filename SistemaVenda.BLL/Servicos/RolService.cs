﻿using System;
using System.Collections.Generic;
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
    public class RolService: IRoleService
    {
        private readonly IGenericRepository<Rol> _rolRepositorio;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepositorio, IMapper mapper)
        {
            _rolRepositorio = rolRepositorio;
            _mapper = mapper;
        }

        public async Task<List<RolDTO>> Lista()
        {
            try
            {
                var listaRoles = await _rolRepositorio.Consultar();
                return _mapper.Map<List<RolDTO>>(listaRoles.ToList());

            }
            catch
            {
                throw;

            }
        }
    }
}
