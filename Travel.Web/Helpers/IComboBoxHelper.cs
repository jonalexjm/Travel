using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Travel.Web.Helpers
{
    public interface IComboBoxHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboEditoriales();
    }
}
