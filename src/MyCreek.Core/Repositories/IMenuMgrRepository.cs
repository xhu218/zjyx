using Abp.Domain.Repositories;
using MyCreek.Entities.SysAdmin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Repositories
{
    public interface IMenuMgrRepository : IRepository<MenuItemDefine>
    {
        Task<MenuItemDefine> GetSingleMenuItemDefine(int menuGuid);
    }
}
