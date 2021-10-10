using CoderByte_DAL.Repositories.Interfaces;
using CoderByte_WebApp.Models;
using CoderByte_WebApp.UiServices.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByte_WebApp.UiServices
{
    public class LossTypesUiService : ILossTypesUiService
    {
        private readonly ILossTypesRepository _lossTypesRepository;

        public LossTypesUiService(ILossTypesRepository lossTypesRepository)
        {
            _lossTypesRepository = lossTypesRepository;
        }

        public async Task<LossTypesIndexViewModel> GetIndexViewModel()
        {
            var lossTypes = await _lossTypesRepository.GetListAsync();

            var lossTytpesRows = lossTypes.Select(lt => new LossTypeRow
            {
                Code = lt.LossTypeCode,
                Description = lt.LossTypeDescription,
                CreatedDate = lt.CreatedDate,
                LastUpdatedDate = lt.LastUpdatedDate
            });

            var vm = new LossTypesIndexViewModel
            {
                LossTypes = lossTytpesRows.ToList()

            };
            return vm;

        }
    }
}
