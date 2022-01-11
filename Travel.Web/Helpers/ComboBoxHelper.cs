using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Core.Interfaces.Services;
using System.Linq;

namespace Travel.Web.Helpers
{
    public class ComboBoxHelper : IComboBoxHelper
    {
        private readonly IEditorialService _editorialService;
        public ComboBoxHelper(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboEditoriales()
        {
            var editorariales = await _editorialService.ObtenerEditoriales();
            List<SelectListItem> list = editorariales.Select(t => new SelectListItem
            {
                Text = t.Nombre,
                Value = $"{t.Id}"
            })
               .OrderBy(t => t.Text)
               .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione un editorial...]",
                Value = "0"
            });

            return list;
        }
    }
}
