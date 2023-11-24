using AutoMapper;
using QSMS.Application.Features.Commands.AppRole.CreateAppRole;
using QSMS.Application.Features.Commands.AppRole.UpdateAppRole;
using QSMS.Application.Features.Commands.AppUser.CreateAppUser;
using QSMS.Application.Features.Commands.Category.CreateCategory;
using QSMS.Application.Features.Commands.Category.RemoveCategory;
using QSMS.Application.Features.Commands.Product.CreateProduct;
using QSMS.Application.Features.Commands.Product.RemoveProduct;
using QSMS.Application.Features.Commands.Tag.CreateTag;
using QSMS.Application.Features.DTOs.Auth;
using QSMS.Application.Features.DTOs.Category;
using QSMS.Application.Features.DTOs.Product;
using QSMS.Application.Features.DTOs.Role;
using QSMS.Application.Features.DTOs.Tag;
using QSMS.Application.Features.DTOs.User;
using QSMS.Application.Features.Queries.AppRole.GetByIdAppRole;
using QSMS.Application.Features.Queries.AppUser.GetByIdAppUser;
using QSMS.Application.Features.Queries.Auth.Login;
using QSMS.Application.Features.Queries.Product.GetByIdProduct;
using QSMS.Domain.Entities;
using QSMS.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();

            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductQueryRequest>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();

            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, CreateTagCommandRequest>().ReverseMap();

            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateAppRoleCommandRequest>().ReverseMap();

            CreateMap<AppUser, CreateUserDto>().ReverseMap();
            CreateMap<AppUser, CreateAppUserCommandRequest>().ReverseMap();

            CreateMap<AppUser, LoginUserDto>().ReverseMap();
            CreateMap<AppUser, AuthLoginQueryRequest>().ReverseMap();

            CreateMap<AppUser, GetByIdAppUserQueryRequest>().ReverseMap();
            CreateMap<AppUser, GetByIdAppUserDto>().ReverseMap();

            CreateMap<Product, RemoveProductCommandRequest>().ReverseMap();
            CreateMap<Product, RemoveProductDto>().ReverseMap();

            CreateMap<Category, RemoveCategoryDto>().ReverseMap();
            CreateMap<Category, RemoveCategoryCommandRequest>().ReverseMap();

            CreateMap<AppRole, UpdateAppRoleCommandRequest>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();



            CreateMap<AppRole, GetByIdAppRoleDto>().ReverseMap();
            CreateMap<AppRole, GetByIdAppRoleQueryRequest>().ReverseMap();

        }
    }
}
