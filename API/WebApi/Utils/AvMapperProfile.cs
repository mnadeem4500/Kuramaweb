using AutoMapper;
using ExtremeClassified.Domain.Identity;
using ExtremeClassified.Domain.Listing;
using ExtremeClassified.Domain.Portal;
using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Dtos.Identity;
using ExtremeClassified.WebApi.Dtos.Listing;
using ExtremeClassified.WebApi.Dtos.Portal;
using UserAddressDto = ExtremeClassified.WebApi.Dtos.Account.UserAddressDto;


namespace ExtremeClassified.WebApi.Utils
{
    public class AvMapperProfile : Profile
    {
        public AvMapperProfile()
        {
            //Account
           CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(dest => dest.Password))
                .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserName));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(dest => dest.NameField))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.KeyField));

            CreateMap<UserAddress,UserAddressDto>()
                .ForMember(dest => dest.UserAddressID, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.UserAddressKey, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<UserAddressDto,UserAddress>()
               .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserAddressKey))
               .ForMember(dest => dest.KeyField, opt => opt.Ignore());
            //screen
            CreateMap<ScreenControl, ScreenControlDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.NameField));
            CreateMap<ScreenControlDto, ScreenControl>()
                .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.KeyField, opt => opt.Ignore());


            //Catalogue
            CreateMap<CatalogueMaster, CatalogueMasterDto>()
                .ForMember(dest => dest.MasterId, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.CatalogueName, opt => opt.MapFrom(dest => dest.NameField));
           
            CreateMap<CatalogueMasterDto, CatalogueMaster>()
               .ForMember(dest => dest.KeyField, opt => opt.Ignore())
               .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.CatalogueName));

            CreateMap<CatalogueDetail, CatalogueDetailDto>()
             .ForMember(dest => dest.DetailId, opt => opt.MapFrom(dest => dest.KeyField))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<CatalogueDetailDto, CatalogueDetail>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.Name));

            //Portal
            CreateMap<PortalCountry, PortalCountryDto>()
               .ForMember(dest => dest.CountryId, opt => opt.MapFrom(dest => dest.KeyField))
               .ForMember(dest => dest.CountryName, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<PortalCountryDto, PortalCountry>()
              .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.CountryName))
              .ForMember(dest => dest.KeyField, opt => opt.Ignore());

            CreateMap<CountryAdministrativeDivision, CountryAdministrativeDivisionDto>()
               .ForMember(dest => dest.id, opt => opt.MapFrom(dest => dest.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Name));

            /// Listing
            CreateMap<Category, CategoryDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<CategoryDto, Category>()
              .ForMember(dest => dest.KeyField, opt => opt.MapFrom(dest => dest.Id))
              .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<CategoryProperty, CategoryPropertyDto>()
              .ForMember(dest => dest.CategroyPrpertyId, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.NameField));
            CreateMap<CategoryPropertyDto, CategoryProperty>()
                .ForMember(dest => dest.KeyField, opt => opt.Ignore())
                .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.Name));
            //listing

            CreateMap<Listing, ListingDto>()
              .ForMember(dest => dest.ListingId, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.Title, opt => opt.MapFrom(dest => dest.NameField));
            CreateMap<ListingDto, Listing>()
              .ForMember(dest => dest.KeyField, opt => opt.Ignore())
              .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.Title));

            //....
            CreateMap<ListingAlert, ListingAlertsDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<ListingAlertsDto, ListingAlert>()
              .ForMember(dest => dest.KeyField, opt => opt.Ignore())
              .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserId));

            CreateMap<ListingAttachment, ListingAttachmentDto>()
              .ForMember(dest => dest.ListingAttachmentId, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.Type, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<ListingAttachmentDto,ListingAttachment>()
              .ForMember(dest => dest.KeyField, opt => opt.Ignore())
              .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.Type));

            CreateMap<ListingFavorite, ListingFavoriteDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.Title, opt => opt.MapFrom(dest => dest.NameField));
            CreateMap<ListingProperty, ListingPropertyDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.ListingPropertyName, opt => opt.MapFrom(dest => dest.NameField));
            CreateMap<ListingVersion, ListingVersionDto>()
              .ForMember(dest => dest.VersionId, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.VersionName, opt => opt.MapFrom(dest => dest.NameField));





            #region Identity

            //Group
            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<GroupDto, Group>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(src => src.Name));
            //Role
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(dest => dest.NameField))
                .ForMember(dest => dest.RoleDescription, opt => opt.MapFrom(dest => dest.Description))
                ;

            CreateMap<RoleDto, Role>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.RoleName))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(dest => dest.RoleDescription));
            //UserAccess
            CreateMap<UserAccess, UserAccessDto>()
                .ForMember(dest => dest.AccessId, opt => opt.MapFrom(dest => dest.KeyField))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<UserAccessDto, UserAccess>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserId));
            #endregion
            //UserActivity
            CreateMap<UserActivity, UserActivityDto>()
               .ForMember(dest => dest.UserActivityId, opt => opt.MapFrom(dest => dest.KeyField));
         
            CreateMap<UserActivityDto, UserActivity>()
             .ForMember(dest => dest.KeyField, opt => opt.MapFrom(dest => dest.UserActivityId));
            
            CreateMap<UserDevice, UserDeviceDto>()
               .ForMember(dest => dest.UserDeviceId, opt => opt.MapFrom(dest => dest.KeyField))
               .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(dest => dest.NameField))
               .ForMember(dest => dest.DeviceModel, opt => opt.MapFrom(dest => dest.Model));

            CreateMap<UserDeviceDto, UserDevice>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.DeviceName))
             .ForMember(dest => dest.Model, opt => opt.MapFrom(dest => dest.DeviceModel));
            ///UserGroupDto
            CreateMap<UserGroup, UserGroupDto>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.NameField))
               .ForMember(dest => dest.GroupId, opt => opt.MapFrom(dest => dest.KeyField));

            CreateMap<UserGroupDto, UserGroup>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserId));
            ///Login Provider
            CreateMap<UserLogin, LoginProviderDto>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(dest => dest.LoginProvider))
               .ForMember(dest => dest.Paswword, opt => opt.MapFrom(dest => dest.ProviderKey));

            CreateMap<LoginProviderDto, UserLogin>()
             .ForMember(dest => dest.LoginProvider, opt => opt.Ignore())
             .ForMember(dest => dest.ProviderKey, opt => opt.MapFrom(dest => dest.Paswword));
            ///User paswoord History
            CreateMap<UserPwdHistory, UserPwdHistoryDto>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.KeyField))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<UserPwdHistoryDto, UserPwdHistory>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.Password));
            ///User Rigion
            CreateMap<UserRegion, UserRegionDto>()
              .ForMember(dest => dest.RegionId, opt => opt.MapFrom(dest => dest.KeyField))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<UserRegionDto, UserRegion>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserId));
            ///User ROle
            CreateMap<UserRole, UserRoleDto>()
               .ForMember(dest => dest.RoleId, opt => opt.MapFrom(dest => dest.RoleId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.UserId));

            CreateMap<UserRoleDto, UserRole>()
             .ForMember(dest => dest.RoleId, opt => opt.Ignore())
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.UserId));
            ///Token 
            CreateMap<UserToken, UserTokenDto>()
              .ForMember(dest => dest.tokenId, opt => opt.MapFrom(dest => dest.KeyField))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(dest => dest.NameField));

            CreateMap<UserTokenDto, UserToken>()
             .ForMember(dest => dest.KeyField, opt => opt.Ignore())
             .ForMember(dest => dest.NameField, opt => opt.MapFrom(dest => dest.UserId));


        }
    }
}
