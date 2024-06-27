using NUnit.Framework;
using AutoMapper;
using Moq;
using NominaAPI.Controllers;
using NominaAPI.Repository.Interfaces;
using SharedModels;

namespace NominaAPI.Services
{

    [TestFixture]
    public class EmpleadoServiceTests
    {
        private EmpleadoController _controller;
        private Mock<IRepository<Empleado>> _mockEmpleadoRepository;
        private Mock<IRepository<Ingresos>> _mockIngresosRepository;
        private Mock<IRepository<Deducciones>> _mockDeduccionesRepository;
        private Mock<IRepository<Nomina>> _mockNominaRepository;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockEmpleadoRepository = new Mock<IRepository<Empleado>>();
            _mockIngresosRepository = new Mock<IRepository<Ingresos>>();
            _mockDeduccionesRepository = new Mock<IRepository<Deducciones>>();
            _mockNominaRepository = new Mock<IRepository<Nomina>>();

            _controller = new EmpleadoController(
               _mockDeduccionesRepository.Object,
               _mockEmpleadoRepository.Object,
               _mockIngresosRepository.Object,
               _mockNominaRepository.Object,
               _mockMapper.Object
            );
        }

        // Aquí van las pruebas de los métodos CRUD
    }
}
