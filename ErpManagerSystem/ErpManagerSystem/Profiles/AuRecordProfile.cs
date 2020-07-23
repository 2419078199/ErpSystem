using AutoMapper;
using Model.Dtos.AddDto;
using Model.Entitys;

namespace ErpManagerSystem.Profiles
{
    public class AuRecordProfile : Profile
    {
        public AuRecordProfile()
        {
            CreateMap<AuRecord,AuRecordDto>();
        }
    }
}
