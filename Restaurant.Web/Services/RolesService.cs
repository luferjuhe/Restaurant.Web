using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Entities;

namespace Restaurant.Web.Services
{
    public interface IRolesService
    {
        Task AddRoleAsync(RoleViewModel vm);
        Task UpdateRoleAsync(RoleViewModel vm);
        Task<RoleViewModel> GetRoleAsync(int roleId);
        Task<List<RoleViewModel>> GetRolesAsync();
    }

    public class RolesService : IRolesService
    {
        private readonly RestaurantContext ctx;
        private IMapper mapper;

        public RolesService(RestaurantContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task AddRoleAsync(RoleViewModel vm)
        {
            Role role = new Role
            {
                Name = vm.Name,
                CreationDate = DateTime.Now,
                CreationUserId = 1,
            };

            ctx.Roles.Add(role);
            await ctx.SaveChangesAsync();
        }

        public async Task<RoleViewModel> GetRoleAsync(int roleId) =>
            mapper.Map<RoleViewModel>(await ctx.Roles.FindAsync(roleId));

        public async Task<List<RoleViewModel>> GetRolesAsync() =>
            mapper.Map <List<RoleViewModel>>(await ctx.Roles.Where(r => r.InactiveDate == null).ToListAsync());

 
        public async Task UpdateRoleAsync(RoleViewModel vm)
        {
            Role role = await ctx.Roles.FirstOrDefaultAsync(r => r.RoleId == vm.RoleId);

            role.Name = vm.Name;

            await ctx.SaveChangesAsync();
        }
    }
}

