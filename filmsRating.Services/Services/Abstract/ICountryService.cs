using filmsRating.Services.Models;

namespace filmsRating.Services.Abstract;

public interface ICountryService
{
    CountryModel GetCountry(Guid id);

    CountryModel AddCountry(CountryModel countryModel);

    void DeleteCountry(Guid id);

    PageModel<CountryModel> GetCountrys(int limit = 20, int offset = 0);
}