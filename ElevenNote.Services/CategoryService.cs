﻿using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;
        
        public CategoryService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    CategoryID = e.CategoryId,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == id && e.OwnerId == _userId);
                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        Name = entity.Name,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}
