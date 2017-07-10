using BasicElasticsearch.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Interface
{
    public interface IReferenceService
    {
        IEnumerable<PositionViewModel> GetAllPosition();
        PositionViewModel GetPosition(int id);

        IEnumerable<VisaStatusViewModel> GetAllVisaStatus();
        VisaStatusViewModel GetVisaStatus(int id);

        IEnumerable<VisaTypeViewModel> GetAllVisaType();
        VisaTypeViewModel GetVisaType(int id);

        IEnumerable<PositionViewModel> PutManyPosition(IEnumerable<PositionViewModel> dtos);
        IEnumerable<VisaStatusViewModel> PutManyVisaStatus(IEnumerable<VisaStatusViewModel> dtos);
        IEnumerable<VisaTypeViewModel> PutManyVisaType(IEnumerable<VisaTypeViewModel> dtos);

    }
}
