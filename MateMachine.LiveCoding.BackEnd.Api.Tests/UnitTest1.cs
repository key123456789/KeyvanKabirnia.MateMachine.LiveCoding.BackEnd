using MateMachine.LiveCoding.BackEnd.Api.Commands;
using MateMachine.LiveCoding.BackEnd.Api.DataAccess;
using MateMachine.LiveCoding.BackEnd.Api.Domain;
using MateMachine.LiveCoding.BackEnd.Api.Repositories;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using System;
using System.Threading.Tasks;

namespace MateMachine.LiveCoding.BackEnd.Tests
{
    public class Tests
    {
        private AppDbContext _context;
        private ICountryRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            _context = new AppDbContext(options);
            _repository = new CountryRepository(_context);
        }
        [TearDown]
        public void Dispose()
        {
            _context.Dispose();
        }

        [Test]
        public async Task TestCreateCountryCommandHandler()
        {
            var handler = new CreateCountryCommandHandler(_repository);
            var command = new CreateCountryCommand
            {
                Name = "Test Country",
                Code = "TC",
                DefaultCurrency = "IRR",
                DefaultLocale = "fa-IR"
            };

            var result = await handler.Handle(command, new CancellationToken());

            Assert.That(result.Success, Is.True);
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.Name, Is.EqualTo(command.Name));
        }

        [Test]
        public async Task TestUpdateCountryCommandHandler()
        {
            // First, create a country to update
            var createHandler = new CreateCountryCommandHandler(_repository);
            var createCommand = new CreateCountryCommand
            {
                Name = "Test Country",
                Code = "TC",
                DefaultCurrency = "IRR",
                DefaultLocale = "fa-IR"
            };
            var createResult = await createHandler.Handle(createCommand, new CancellationToken());
            Assert.That(createResult.Success, Is.True);

            // Now, update the country
            var updateHandler = new UpdateCountryCommandHandler(_repository);
            var updateCommand = new UpdateCountryCommand
            {
                Id = createResult.Value.Id,
                Name = "Updated Country",
                Code = "UC",
                DefaultCurrency = "USD",
                DefaultLocale = "en-US"
            };
            var updateResult = await updateHandler.Handle(updateCommand, new CancellationToken());

            Assert.That(updateResult.Success, Is.True);

            // Verify the country was updated
            var country = await _repository.Get(createResult.Value.Id);
            Assert.That(country.Name, Is.EqualTo(updateCommand.Name));
        }

        [Test]
        public async Task TestDeleteCountryCommandHandler()
        {
            // First, create a country to delete
            var createHandler = new CreateCountryCommandHandler(_repository);
            var createCommand = new CreateCountryCommand
            {
                Name = "Test Country",
                Code = "TC",
                DefaultCurrency = "IRR",
                DefaultLocale = "fa-IR"
            };
            var createResult = await createHandler.Handle(createCommand, new CancellationToken());
            Assert.That(createResult.Success, Is.True);

            // Now, delete the country
            var deleteHandler = new DeleteCountryCommandHandler(_repository);
            var deleteCommand = new DeleteCountryCommand
            {
                Id = createResult.Value.Id
            };
            var deleteResult = await deleteHandler.Handle(deleteCommand, new CancellationToken());

            Assert.That(deleteResult.Success, Is.True);

            // Verify the country was deleted
            var country = await _repository.Get(createResult.Value.Id);
            Assert.That(country, Is.Null);
        }

        [Test]
        public async Task TestGetCountryCommandHandler()
        {
            // First, create a country to get
            var createHandler = new CreateCountryCommandHandler(_repository);
            var createCommand = new CreateCountryCommand
            {
                Name = "Test Country",
                Code = "TC",
                DefaultCurrency = "IRR",
                DefaultLocale = "fa-IR"
            };
            var createResult = await createHandler.Handle(createCommand, new CancellationToken());
            Assert.That(createResult.Success, Is.True);

            // Now, get the country
            var getHandler = new GetCountryCommandHandler(_repository);
            var getCommand = new GetCountryCommand
            {
                Id = createResult.Value.Id
            };
            var getResult = await getHandler.Handle(getCommand, new CancellationToken());

            Assert.That(getResult.Success, Is.True);
            Assert.That(getResult.Value.Name, Is.EqualTo(createCommand.Name));
        }
    }
}
