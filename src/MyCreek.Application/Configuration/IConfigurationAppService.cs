using System.Threading.Tasks;
using MyCreek.Configuration.Dto;

namespace MyCreek.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
