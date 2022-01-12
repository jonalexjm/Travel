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
    public class LibroService : ILibroService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public LibroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        /// <summary>
        /// Metodo para actualizar libro
        /// </summary>
        /// <param name="libro"> Objeto property para actualizar </param>
        /// <returns> Retorna resutlado de operacion true o false</returns>
        public async Task<bool> ActualizarLibro(Libro libro)
        {
            var libroResultado = await _unitOfWork.LibroRepository.GetById(libro.Isbn);
            if (libroResultado != null)
            {
                libroResultado.Titulo = libro.Titulo;
                libroResultado.Sinopsis = libro.Sinopsis;
                libroResultado.NPaginas = libro.NPaginas;
                libroResultado.Editoriales = libro.Editoriales;
                var actualizarLibro = await _unitOfWork.LibroRepository.UpdateAsync(libroResultado);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para crear Libro
        /// </summary>
        /// <param name="Libro"> Objeto con la información de libro </param>
        /// <returns></returns>
        public async Task CreateLibro(Libro libro)
        {
            await _unitOfWork.LibroRepository.Add(libro);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método para obtener libro con id
        /// </summary>
        /// <param name="id"> Id property </param>
        /// <returns></returns>
        public async Task<Libro> ObtenerLibro(int id)
        {
            return await this._unitOfWork.LibroRepository.GetById(id);
        }

        public Task<Libro> ObtenerLibroConEditoriales(int isbn)
        {
            return this._unitOfWork.LibroRepository.ObtenerLibroConEditoriales(isbn);
        }

        /// <summary>
        /// Método para consultar todos los registros de Libro
        /// </summary>
        /// <param> </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        public async Task<List<Libro>> ObtenerLibros()
        {
            return this._unitOfWork.LibroRepository.GetAll().ToList();
        }

        public Task<List<Libro>> ObtenerLibrosConEditoriales()
        {
            return this._unitOfWork.LibroRepository.ObtenerLibrosConEditoriales();


        }
    }
}
