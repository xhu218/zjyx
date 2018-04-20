using Abp.Application.Navigation;
using Abp.Localization;
using MyCreek.Authorization;
using MyCreek.Entities.SysAdmin;
using MyCreek.SysAdmin;
using System.Collections.Generic;
using System.Linq;

namespace MyCreek.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class MyCreekNavigationProvider : NavigationProvider
    {

        private readonly IMenuMgrAppService _menuMgrAppService;
        public MyCreekNavigationProvider(IMenuMgrAppService menuMgrAppService)
        {
            _menuMgrAppService = menuMgrAppService;
        }

        public override void SetNavigation(INavigationProviderContext context)
        {

            CreateMenuTree(context);

        }

        private void CreateMenuTree(INavigationProviderContext context)
        {
            //获取菜单表数据
            var data = _menuMgrAppService.GetList();
            //通过递归构造数据
            if (data != null)
            {

                var roots = data.Where(c => c.ParentMenuId==0).OrderBy(c => c.Order);
                foreach (var item in roots)
                {
                    var menuItem = new MenuItemDefinition(
                           item.Name,
                           L(item.DisplayName),
                           url: item.Url,
                           icon: item.Icon
                       );
                    context.Manager.MainMenu.AddItem(menuItem);
                    BuildTree(menuItem, item, data);

                }
            }
        }

        private void BuildTree(MenuItemDefinition menuItem, MenuItemDefine item, List<MenuItemDefine> data)
        {

            //找当前项的子项
            var subMenuList = data.FindAll(c => c.ParentMenuId == item.Id).OrderBy(c => c.Order).ToList();
            foreach (var subItem in subMenuList)
            {
                var subMenuItem = new MenuItemDefinition(
                           subItem.Name,
                           L(subItem.DisplayName),
                           url: subItem.Url + "/index?menuGuid=" + subItem.Id.ToString(),
                           icon: subItem.Icon
                       );
                menuItem.AddItem(subMenuItem);
                BuildTree(subMenuItem, subItem, subMenuList);
            }

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyCreekConsts.LocalizationSourceName);
        }
    }
}
