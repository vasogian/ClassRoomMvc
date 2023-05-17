using AutoMapper;

namespace ClassRoomMvc.Profiles
{
    public class ClassroomViewModelProfile : Profile
    {
        public ClassroomViewModelProfile()
        {
            CreateMap<ViewModels.ClassroomViewModel, Models.ClassRoom>();
            CreateMap<Models.ClassRoom, ViewModels.ClassroomViewModel>();
        }
        
    }

}
