using Abp.EntityFrameworkCore;
using MyCreek.Entities.SysAdmin;
using MyCreek.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.EntityFrameworkCore.Repositories
{
    public class MenuMgrRepository : MyCreekRepositoryBase<MenuItemDefine>, IMenuMgrRepository
    {
        public MenuMgrRepository(IDbContextProvider<MyCreekDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<MenuItemDefine> GetSingleMenuItemDefine(int menuGuid)
        {
            var data = await SingleAsync(c => c.Id == menuGuid);

            return data;
        }
    }
}
