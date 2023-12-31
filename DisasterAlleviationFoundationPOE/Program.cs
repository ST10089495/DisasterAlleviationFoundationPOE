﻿using DisasterAlleviationFoundationPOE.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DisasterContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DisasterContext")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DisasterContext>().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
