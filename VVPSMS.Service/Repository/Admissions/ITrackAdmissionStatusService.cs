using VVPSMS.Domain.Models;

namespace VVPSMS.Service.Repository.Admissions
{
    public interface ITrackAdmissionStatusService 
    {
        List<TrackAdmissionStatus> GetAll(int id);
        Task<bool> Insert(TrackAdmissionStatus entity);
    }
}
