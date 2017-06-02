using GLMSCrm.Fakes.BusinessLogic;
using GLMSCrm.Fakes.Entity;
using GLMSCrm.Fakes.Exceptions;
using Moq;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GLMSCrm.Fakes.UnitTest
{
    /// <summary>
    /// For test case method naming convention I have used "MethodName_StateUnderTest_ExpectedBehavior"
    /// </summary>
    public class EmployeeBusinessTest_MOQ
    {
        /// <summary>
        /// 
        /// </summary>
        IEmployeeBusiness employee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EmployeeBusinessTest_MOQ()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
    
        public void GetAllEmployeesName_CustomerCountMoreThenZero_GetsDataFromDAL()
        {
            var fixture = new Fixture();
           
            //Arrange
            Mock<IEmployeeDAL> mockEmployeeDAL = new Mock<IEmployeeDAL>();
            mockEmployeeDAL.Setup(x => x.GetEmployees()).
                Returns(new List<Employee> { fixture.Create<Employee>(), fixture.Create<Employee>() });
            IEmployeeBusiness employee = new EmployeeBusiness(mockEmployeeDAL.Object);

            //Act
            var empNames = employee.GetAllEmployeesName();

            //Assert
            Assert.True(empNames.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(3)]
        [InlineData(100)]
        public void GetEmployeeById_GetEmployeeInfo_GetsDataFromDAL(int id)
        {
            var fixture = new Fixture();
            //Arrange
            Mock<IEmployeeDAL> mockEmployeeDAL = new Mock<IEmployeeDAL>();
            mockEmployeeDAL.Setup(x => x.GetEmployeeById(It.IsAny<int>())).
                Returns(fixture.Create<Employee>());
            IEmployeeBusiness employee = new EmployeeBusiness(mockEmployeeDAL.Object);

            //Act
            var employeeData = employee.GetEmployeeById(id);

            //Assert
            Assert.NotNull(employeeData);
            Assert.Contains("MoqF", employeeData.EmpFName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetEmployeeById_EmployeeIdLessthenEqualToZero_ExceptionShouldOccure(int id)
        {
            var fixture = new Fixture();
            //Arrange
            Mock<IEmployeeDAL> mockEmployeeDAL = new Mock<IEmployeeDAL>();
            mockEmployeeDAL.Setup(x => x.GetEmployeeById(It.IsAny<int>())).Returns(fixture.Create<Employee>());
            IEmployeeBusiness employee = new EmployeeBusiness(mockEmployeeDAL.Object);

            //Act & //Assert
            var ex = Assert.Throws<IncorrectInputValueException>(() => employee.GetEmployeeById(id));

            Assert.Equal("Id value must be greator then 0.", ex.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Save_EmployeeSaved_DataTransferToDAL()
        {
            //Arrange
            Mock<IEmployeeDAL> mockEmployeeDAL = new Mock<IEmployeeDAL>();
            mockEmployeeDAL.Setup(x => x.SaveEmployee(It.IsAny<Employee>())).Returns(true);
            IEmployeeBusiness employee = new EmployeeBusiness(mockEmployeeDAL.Object);

            //Act
            var saveStatus = employee.Save(new Employee());

            //Assert
            Assert.True(saveStatus);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async void MyMethodAsync_TestinfAsync_ExpectedResult()
        {
            //Arrange
            Mock<IEmployeeDAL> mockEmployeeDAL = new Mock<IEmployeeDAL>();
            mockEmployeeDAL.Setup(x => x.LongRunningOperationAsync()).Returns(Task.FromResult(1));
            IEmployeeBusiness employee = new EmployeeBusiness(mockEmployeeDAL.Object);

            //Act
            var intValue = await employee.MyMethodAsync();

            //Assert
            Assert.Equal(intValue, 1);
        }
    }
}
