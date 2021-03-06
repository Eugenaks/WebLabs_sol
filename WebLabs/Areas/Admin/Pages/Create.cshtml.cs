﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebLabs.DAL.Data.ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public CreateModel(WebLabs.DAL.Data.ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
            ViewData["TehnikaGroupId"] = new SelectList(_context.TehnikaGroups, "TehnikaGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Tehnika Tehnika { get; set; }
        [BindProperty]
        public IFormFile image { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tehniks.Add(Tehnika);
            await _context.SaveChangesAsync();

            if(image!=null)
            {
                Tehnika.Images = Tehnika.TehnikaId + Path.GetExtension(image.FileName);
                var path = Path.Combine(_environment.WebRootPath, "images", Tehnika.Images);
                using(var stream=new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                };
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
