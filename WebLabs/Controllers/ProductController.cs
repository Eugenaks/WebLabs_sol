using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLabs.DAL.Entities;
using WebLabs.Models;
using Microsoft.AspNetCore.Http;
using WebLabs.Extensions;
using WebLabs.DAL.Data;
using Microsoft.Extensions.Logging;

namespace WebLabs.Controllers
{
    public class ProductController : Controller
    {
        
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context
            /*ILogger<ProductController> logger*/)
        {
            _pageSize = 3;
            _context = context;
           // _logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group ,int pageNo=1)
        {
           
            var tehnikaFilter = _context.Tehniks
                .Where(t => !group.HasValue || t.TehnikaGroupId == group.Value);

            ViewData["Groups"] = _context.TehnikaGroups;
            var currentGroup = group.HasValue ? group.Value : 0;
            ViewData["CurrentGroup"] = currentGroup;

            if (Request.IsAjaxRequest())
                return PartialView("_ListPartial",
                    ListViewModel<Tehnika>.GetModel(tehnikaFilter, pageNo, _pageSize));

            return View(ListViewModel<Tehnika>.GetModel(tehnikaFilter, pageNo, _pageSize));
        }
       
    }
}