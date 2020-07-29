using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarInfo.Core.Domain;
using CarInfo.Core.Exceptions;
using CarInfo.Core.Repositories;
using CarInfo.Core.Services;
using CarInfo.Core.ViewModels;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace CarInfo.Tests
{
    public class CarServiceShould
    {
        [Test]
        public async Task ReturnList()
        {
            var repository = Substitute.For<ICarRepository>();
            var service = new CarService(repository);

            var result = await service.Get();
            Assert.That(result == null, Is.EqualTo(false));
            Assert.That(result, Is.InstanceOf<IEnumerable<CarListViewModel>>());
        }

        [Test]
        [TestCaseSource(typeof(TestDataLoader), "GetTestCases", new object[] {"data.txt"})]
        public async Task ReturnViewModelForValidId(int id, double dummyValue)
        {
            var repository = Substitute.For<ICarRepository>();
            var service = new CarService(repository);

            repository.Get(Arg.Is<int>(i => i > 0 && i % 2 == 0))
                .Returns(Task.FromResult<Car>(new Car { Id = id }));

            var result = await service.Get(id);
            Assert.That(result, Is.TypeOf<CarListViewModel>());
            Assert.That(result.Id, Is.EqualTo(id));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void ThrowExceptionForInvalidId(int id)
        {
            var repository = Substitute.For<ICarRepository>();
            var service = new CarService(repository);

            repository.Get(Arg.Is<int>(i => i == 0 || i % 2 != 0))
                .Throws(new CarNotFoundException());

            Assert.That(async () => await service.Get(id), Throws.TypeOf<CarNotFoundException>());
        }

        
        [Test]
        public void ThrowExceptionForUpdateOfNonExistingId()
        {
            var repository = Substitute.For<ICarRepository>();
            var service = new CarService(repository);
            var viewModel = new CarUpdateViewModel();
            var id = 100;

            repository.Exists(id)
                .Returns(Task.FromResult(false));

            Assert.That(async () => await service.Update(id, viewModel), Throws.TypeOf<CarNotFoundException>());
        }

        [Test]
        public void ThrowExceptionForDeleteOfNonExistingId()
        {
            var repository = Substitute.For<ICarRepository>();
            var service = new CarService(repository);
            var id = 100;

            repository.Exists(id)
                .Returns(Task.FromResult(false));

            Assert.That(async () => await service.Delete(id), Throws.TypeOf<CarNotFoundException>());
        }

        [Test]
        public async Task CallDeleteOnRepositoryForDeleteWithExistingId()
        {
            var repository = Substitute.For<ICarRepository>();
            var service = new CarService(repository);
            var id = 100;

            repository.Exists(id)
                .Returns(Task.FromResult(true));

            await service.Delete(id);
            await repository.Received().Delete(id);
        }
    }
}