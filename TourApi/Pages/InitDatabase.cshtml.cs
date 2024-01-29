// <copyright file="InitDatabase.cshtml.cs" company="1.61">
// Copyright (c) 1.61. All rights reserved.
// </copyright>

namespace TourApi.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Resources;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using TourApi.Models;

#pragma warning disable SA1649 // File name must match first type name.

    /// <summary>
    /// Page model class for the InitDataBase11 page.
    /// </summary>
    public class InitDatabaseModel : PageModel
    {
        private readonly TouristAgencyDbContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="InitDatabaseModel"/> class.
        /// </summary>
        /// <param name="dataContext">Application data context.</param>
        public InitDatabaseModel(
            TouristAgencyDbContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// Gets or sets a value indicating whether database was recreated successfully.
        /// </summary>
        public bool IsDatabaseRecreatedSuccessfully { get; set; }

        /// <summary>
        /// Automatically executed as a result of a GET request.
        /// </summary>
        /// <returns>Page action result.</returns>
        public IActionResult OnGet()
        {
            return this.Page();
        }

        /// <summary>
        /// Пересоздание базы данных.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task OnPost()
        {
            // (Re-)create database.
            this.dataContext.Database.SetCommandTimeout(3600);
            await this.dataContext.Database.EnsureDeletedAsync();
            await this.dataContext.Database.EnsureCreatedAsync();

            await this.CreateDataAsync();

            this.IsDatabaseRecreatedSuccessfully = true;
        }

        private async Task CreateDataAsync()
        {
            var user = new User
            {
                FirstName = "FirstName_1",
                LastName = "LastName_1",
                MiddleName = "MiddleName_1",
                Birthdate = DateTime.UtcNow.AddYears(-20),
                Login = "Login_1",
                Email = "Email_1@mailtest.ru",
                Password = "Password_1",
            };

            this.dataContext.Add(user);
            await this.dataContext.SaveChangesAsync();
        }
    }
}