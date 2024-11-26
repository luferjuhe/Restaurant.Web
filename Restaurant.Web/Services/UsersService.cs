using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Entities;
using Restaurant.Web.ViewModels;

namespace Restaurant.Web.Services
{
	public interface IUsersService
	{
		Task<List<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserById(int userId);
        Task<User> GetUserByEmail(string email);
        Task AddUserAsync(UserViewModel vm);
        Task EditUserAsync(UserViewModel vm);
		Task DeleteUserAsync(int userId);
    }

    public class UsersService : IUsersService
	{
		private readonly RestaurantContext ctx;
		private readonly IMapper mapper;

        public UsersService(RestaurantContext ctx, IMapper mapper)
		{
			this.ctx = ctx;
			this.mapper = mapper;
		}

		public async Task<List<UserViewModel>> GetUsersAsync() =>
			mapper.Map<List<UserViewModel>>(await ctx.Users.Where(u=> u.InactiveDate == null).ToListAsync());

		public async Task AddUserAsync(UserViewModel vm)
		{
			User user = new User
			{
				Name = vm.Name,
			CreationDate = DateTime.Now,
			Email = vm.Email,
			Password = vm.Password,
			CreationUserId = 1
			};

			ctx.Users.Add(user);
			await ctx.SaveChangesAsync();
		}

        public async Task EditUserAsync(UserViewModel vm)
        {
			User user = await ctx.Users.FirstOrDefaultAsync(u => u.UserId == vm.UserId);
			user.Email = vm.Email;
			user.Name = vm.Name;

			await ctx.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            User user = await ctx.Users.FirstOrDefaultAsync(u => u.UserId == userId);

			user.InactiveDate = DateTime.Now;
			await ctx.SaveChangesAsync();
        }

		public async Task<UserViewModel> GetUserById(int userId) =>
			mapper.Map<UserViewModel>(await ctx.Users.FirstOrDefaultAsync(u => u.UserId == userId));

        public async Task<User> GetUserByEmail(string email) =>
            await ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}

