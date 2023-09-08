using VVPSMS.Domain.Models;
using VVPSMS.Service.Repository.Parents;

namespace VVPSMS.Service.DataManagers.ParentDataManagers
{
    public class ParentDocumentService : GenericService<ParentDocument>,IParentDocumentService
    {
        public ParentDocumentService(VvpsmsdbContext context) : base(context)
        {
        }


    }
}
