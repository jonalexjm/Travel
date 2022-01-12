using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces;
using Travel.Core.Interfaces.Services;
using Travel.Infrastructure.Services;

namespace Travel.UnitTest.Travel.Infrastructure.Services
{
    public class LibroServiceTest
    {
        [Test]
        public async Task Verify_LibroService_Given_All_Items()
        {
            var fakeLibros = new List<Libro>
            {
                new Libro
                {
                    Isbn = 1,
                    Titulo = "Pa que se acabe la vaina",
                    Sinopsis = "Libro sobre la politica Colombia",
                    NPaginas = "256",
                    Editoriales = 1                     

                },
                new Libro
                {
                    Isbn = 2,
                    Titulo = "La noche que mataron a Bolivar",
                    Sinopsis = "La decandencia de la vida de Bolivar",
                    NPaginas = "300",
                    Editoriales = 2
                },
                new Libro
                {
                    Isbn = 2,
                    Titulo = "Vigilancia permanente",
                    Sinopsis = "hackers",
                    NPaginas = "400",
                    Editoriales = 2
                },
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            IEnumerable<Libro> fakeLibrosIEnumerable = fakeLibros;
            unitOfWorkMock.Setup(m => m.LibroRepository.GetAll()).Returns(fakeLibrosIEnumerable);

            ILibroService libroService = new LibroService(unitOfWorkMock.Object);

            //Act           
            var actual = await libroService.ObtenerLibros();

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsNotEmpty(actual);
            Assert.AreEqual(fakeLibros, actual);

        }

        [Test]
        public async Task Verify_LibroService_Given_Libro_by_Isbn()
        {
            var fakeLibro = new Libro()
            {                
                    Isbn = 1,
                    Titulo = "Pa que se acabe la vaina",
                    Sinopsis = "Libro sobre la politica Colombia",
                    NPaginas = "256",
                    Editoriales = 1
               
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();           
            unitOfWorkMock.Setup(m => m.LibroRepository.GetById(1)).ReturnsAsync(fakeLibro);

            ILibroService libroService = new LibroService(unitOfWorkMock.Object);

            //Act           
            var actual = await libroService.ObtenerLibro(1);

            //Assert
            Assert.IsNotNull(actual);            
            Assert.AreEqual(fakeLibro, actual);

        }

    }
}
