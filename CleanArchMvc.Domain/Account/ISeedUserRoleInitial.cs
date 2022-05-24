using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Domain.Account
{
    public interface ISeedUserRoleInitial
    {
        void SeedUsers();
        void SeedRoles();
    }
}
