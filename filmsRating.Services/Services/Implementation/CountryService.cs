using AutoMapper;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;

namespace filmsRating.Services.Implementation;

public class CountryService : ICountryService
{
    private readonly IRepository<Country> countrysRepository;
    private readonly IMapper mapper;
    public CountryService(IRepository<Country> countrysRepository, IMapper mapper)
    {
        this.countrysRepository = countrysRepository;
        this.mapper = mapper;
    }

    public void DeleteCountry(Guid id)
    {
        var countryToDelete = countrysRepository.GetById(id);
        if (countryToDelete == null)
        {
            throw new Exception("Country not found");
        }

        countrysRepository.Delete(countryToDelete);
    }

    public CountryModel GetCountry(Guid id)
    {
        var country = countrysRepository.GetById(id);
        return mapper.Map<CountryModel>(country);
    }

    public PageModel<CountryModel> GetCountrys(int limit = 20, int offset = 0)
    {
        var countrys = countrysRepository.GetAll();
        int totalCount = countrys.Count();
        var chunk = countrys.OrderBy(x => x.Id).Skip(offset).Take(limit);

        return new PageModel<CountryModel>()
        {
            Items = mapper.Map<IEnumerable<CountryModel>>(chunk),
            TotalCount = totalCount
        };
    }

    CountryModel ICountryService.AddCountry(CountryModel countryModel)
    {
        countrysRepository.Save(mapper.Map<Country>(countryModel));
        return countryModel;
    }
}