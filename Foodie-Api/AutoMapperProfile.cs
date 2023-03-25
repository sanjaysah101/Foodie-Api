using Foodie_Api.Dtos.Booking;
using Foodie_Api.Dtos.Categories;
using Foodie_Api.Dtos.Contact;
using Foodie_Api.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie_Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<Contact, GetContactDto>();
            CreateMap<AddContactDto, Contact>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Items, GetItemDto>();
            CreateMap<AddItemDto, Items>();
            CreateMap<Booking, GetBookingDto>();
            CreateMap<AddBookingDto, Booking>();
        }
    }
}