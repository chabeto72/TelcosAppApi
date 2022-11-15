﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelcosAppApi.DataAccess.DataAccess;
using TelcosAppApi.DataAccess.Entities;
using TelcosAppApi.DomainServices.Domain.Contracts.Roles;

namespace TelcosAppApi.DomainServices.Domain.Roles
{
    public class RolesDomain:IRolesDomain
    {
        private readonly TelcosApiContext _context;

        public RolesDomain(TelcosApiContext telcosApiContext)
        {
            _context = telcosApiContext;
        }
        #region Method
        public async Task<List<Rol>> GetRoles()
        {
            return await _context.Rol.ToListAsync();         
        }
        #endregion|

    }
}