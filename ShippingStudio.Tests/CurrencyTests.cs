using ShippingStudio.Data.Repository;
using Moq;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Services.Api.Services;

namespace ShippingStudio.Tests
{
    [TestClass]
    public class CurrencyTests
    {
        [TestMethod]
        public void UpdateRecord_WhereOriginalRecordFound_NotFound()
        {
            //arrange
            var currencyRepository = new Mock<ICurrency>();
            currencyRepository
                .Setup(m => m.Get(1))
                .Returns(new Domain.Entities.Currency
                    { Id = 1, CurrencyCode = "Usd", CurrencyName = "United States", IsDisabled = false });

            var currencyService = new CurrencyService(currencyRepository.Object);

            //act
            var result = currencyService.Update(10);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Code);
        }

        [TestMethod]
        public void UpdateRecord_WhereOriginalRecordFound()
        {
            //arrange
            var currencyRepository = new Mock<ICurrency>();
            currencyRepository
                .Setup(m => m.Get(1))
                .Returns(new Domain.Entities.Currency 
                    { Id=1, CurrencyCode = "Usd",CurrencyName = "United States",IsDisabled = false});

            var currencyService = new CurrencyService(currencyRepository.Object);
            


            //act
            var result = currencyService.Update(1);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Code);
        }

        [TestMethod]
        public void AddNewRecord_WhereRecordExists()
        {
            // Arrange
            var currencyRepository = new Mock<ICurrency>();
            currencyRepository
                .Setup(m => m.Get(1))
                .Returns(new Domain.Entities.Currency
                { Id = 1, CurrencyCode = "Usd", CurrencyName = "United States", IsDisabled = false });

            var currencyService = new CurrencyService(currencyRepository.Object);

            // Act

            var result = currencyService.AddNew(new Domain.Models.RequestModels.Curremcy.AddCurrencyRequestModel
            {
                CurrencySymbol = "Usd",
                CurrencyDescription = "United States"
            });

            // Assert
            Assert.AreEqual(2, result.Code);
        }
    }
}