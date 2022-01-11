using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces;
using Travel.Core.Interfaces.Services;

namespace Travel.Infrastructure.Services
{
    public class EditorialService : IEditorialService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public EditorialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<bool> ActualizarEditorial(Editorial editorial)
        {
            var editorialResultado = await _unitOfWork.EditorialRepository.GetById(editorial.Id);
            if (editorialResultado != null)
            {
                editorialResultado.Nombre = editorial.Nombre;
                editorialResultado.Sede = editorial.Sede;
                var actualizarEditorial = await _unitOfWork.EditorialRepository.UpdateAsync(editorialResultado);

                return true;
            }

            return false;
        }

        public async Task CrearEditorial(Editorial editorial)
        {
            await _unitOfWork.EditorialRepository.Add(editorial);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Editorial> ObtenerEditorial(int id)
        {
            return await this._unitOfWork.EditorialRepository.GetById(id);
        }

        public async Task<List<Editorial>> ObtenerEditoriales()
        {
            return  this._unitOfWork.EditorialRepository.GetAll().ToList();
        }
    }
}
