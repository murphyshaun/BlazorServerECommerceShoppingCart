﻿using Microsoft.EntityFrameworkCore;
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;

namespace Shop.Logic.Services
{
	public class AdminService : IAdminService
	{
		private readonly ShoppingCardDbContext _dbContext;

		public AdminService(ShoppingCardDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		/// <summary>
		/// Logins the admin.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns></returns>
		public async Task<ResponseModel> LoginAdmin(LoginModel request)
		{
			var response = new ResponseModel
			{
				Status = false,
				Message = "Incorrect Id / Password"
			};

			try
			{
				var userData = await _dbContext.AdminInfos.SingleOrDefaultAsync(c => c.Password == request.Password && c.Email == request.Email);

				if (userData is not null)
				{
					response.Status = true;
					response.Message = $"{userData.Id}|{userData.Name}|{userData.Email}";
				}
			}
			catch (Exception)
			{
				response.Message = "An Error has occured. Please try again!";
			}

			return response;
		}

		/// <summary>
		/// Saves the category.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns></returns>
		public async Task<CategoryModel> SaveCategory(CategoryModel request)
		{
			try
			{
				var category = new Category
				{
					Name = request.Name
				};

				await _dbContext.AddAsync(category);

				await _dbContext.SaveChangesAsync();

				return request;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Gets the categories.
		/// </summary>
		/// <returns></returns>
		public async Task<List<CategoryModel>> GetCategories()
		{
			var data = await _dbContext.Categories.ToListAsync();

			var categoryList = data.Select(c => new CategoryModel
			{
				Id = c.Id,
				Name = c.Name
			}).ToList();

			return categoryList;
		}

		/// <summary>
		/// Updates the category.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns></returns>
		public async Task<bool> UpdateCategory(CategoryModel request)
		{
			try
			{
				var flag = false;
				var categoryUpdate = _dbContext.Categories.FirstOrDefault(c => c.Id == request.Id);
				if (categoryUpdate is not null)
				{
					categoryUpdate.Name = request.Name;
					_dbContext.Categories.Update(categoryUpdate);
					await _dbContext.SaveChangesAsync();
					flag = true;
				}

				return flag;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Deletes the category.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns></returns>
		public async Task<bool> DeleteCategory(CategoryModel request)
		{
			try
			{
				var flag = false;
				var categoryDelete = _dbContext.Categories.FirstOrDefault(c => c.Id == request.Id);
				if (categoryDelete is not null)
				{
					_dbContext.Categories.Remove(categoryDelete);
					await _dbContext.SaveChangesAsync();
					flag = true;
				}

				return flag;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}