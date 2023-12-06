using Microsoft.IdentityModel.Tokens;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels.Curremcy;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Domain.Models.ResponseModels.Currency;

namespace ShippingStudio.Services.Api.Services
{
    public class CurrencyService
    {
        private readonly ICurrency currencyRepository;

        public CurrencyService(ICurrency currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        public BaseResponseModel AddNew(AddCurrencyRequestModel currency)
        {
            var response = new BaseResponseModel
            {
                Code = 0,
                Message = string.Empty
            };

            if (currency == null)
            {
                response.Code = 1;
                response.Message = "Currency Data is invalid";
            }


            var exists = currencyRepository.GetAll().Find(x => x.CurrencyCode == currency.CurrencySymbol);

            if (exists is not null)
            {
                response.Code = 2;
                response.Message = "Currency Exists";
            }
            else
            {
                var result = currencyRepository.Add(new Currency
                {
                    CurrencyCode = currency.CurrencySymbol,
                    CurrencyName = currency.CurrencyDescription,
                    IsDisabled = false
                });

                if (result)
                {
                    response.Code = 0;
                    response.Message = "Successfully created currency";
                }
            }

            return response;
        }

        public List<Currency> GetAllCurrencies()
        {
            return currencyRepository.GetAll();
        }

        public CurrencyResponseModel GetCurrency(string currencyCode)
        {
            var response = new CurrencyResponseModel();

            if (currencyCode.IsNullOrEmpty())
            {
                response.Code = 1;  
                response.Message= "Currency Code cannot be null, empty or blank.";
                return response;
            }

            var result = currencyRepository.GetAll().Where(x => x.CurrencyCode == currencyCode).FirstOrDefault();

            if (result == null)
            {
                response.Code = 2;
                response.Message = $"Could not find currency. {currencyCode}";
                return response;
            }

            response.CurrencyCode = currencyCode;
            response.Description = result.CurrencyName;
            response.Code = 0;
            response.Message = "Currency Found";
            
            return response;

            
        }

        public BaseResponseModel Update(int Id)
        {
            var response = new BaseResponseModel();

            var result = currencyRepository.Get(Id);

            if (result == null)
            {
                response.Code= 1;
                response.Message = "Could not find currency";
                return response;
            }

            result.IsDisabled = true;
            currencyRepository.Save(result);

            response.Code = 0;
            response.Message = "Currency has been successfully been disabled.";

            return response;
        }

    }
}
