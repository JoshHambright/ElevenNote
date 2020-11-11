using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var useId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(useId);
            return categoryService;
        }

        //Create
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();
            return Ok();
        }

        //READ

        //Get All Categories
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

        //GetByID
        public IHttpActionResult Get(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            return Ok(category);
        }
    }
}
