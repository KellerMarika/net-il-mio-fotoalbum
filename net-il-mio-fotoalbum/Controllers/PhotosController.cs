using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotosController : Controller
    {
        /*private readonly*/ public PhotoAlbumContext _context;//dep injection

        public PhotosController(PhotoAlbumContext context)
        {
            _context = context;
        }

        // GET: Photos
        public IActionResult Index()
        {
            if (_context.Photos != null)
            {
                var photoList = _context.Photos
                          .Include(p => p.Categories)
                          .ToList();
                return View(photoList);
            }
            else
                return Problem("Entity Photos is null");
        }

        // GET: Photos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }
            var photo = _context.Photos.Where(p => p.Id == id).Include(p=>p.Categories).FirstOrDefault();
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create()
        {
            PhotoFormModel FormModel = new PhotoFormModel();
            FormModel.Photo = new Photo();
      
            List<SelectListItem> CategoriesList = new List<SelectListItem>();

            foreach (var ing in _context.Categories.ToList())
            {
                CategoriesList.Add(new SelectListItem() { Text = ing.Name, Value = ing.Id.ToString() });
            }
            FormModel.Categories = CategoriesList;//tutta sta cosa deve poter diventare una funzione
            return View("Create", FormModel);
        }

        // POST: Photos/Create
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*[Bind("Id,Description,Visible,Image")]*/ PhotoFormModel data)
        {
            if (!ModelState.IsValid)
            {
               List <SelectListItem> CategoriesList = new List<SelectListItem>() 
               { new SelectListItem() { Text = "", Value = "" } };
                foreach (var cat in _context.Categories.ToList())
                {
                    CategoriesList.Add(new SelectListItem() { Text = cat.Name, Value = cat.Id.ToString() });
                }
                data.Categories= CategoriesList;
                return View("Create", data);
            }
            else
            {
                Photo newPhoto = new Photo(data.Photo.Title, data.Photo.Description, data.Photo.Visible, data.Photo.Image);
                if (data.SelectedCategories != null)
                {
                    foreach (var selectedCat in data.SelectedCategories)
                    {
                        int selectedIntCatId = int.Parse(selectedCat);
                        Category category = _context.Categories
                            .Where(c => c.Id == selectedIntCatId)
                            .FirstOrDefault();
                        newPhoto.Categories.Add(category);
                    }
                }
                _context.Photos.Add(newPhoto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Photos/Edit/5
        [Authorize(Roles = "ADMIN")]
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Photos == null)
            {
                return NotFound();
            }
            Photo photoToEdit = _context.Photos.Where(p => p.Id == id)
                .Include(p=>p.Categories)
                .FirstOrDefault();

            if (photoToEdit == null)
            {
                return NotFound();
            }
            else
            {
                PhotoFormModel FormModel = new PhotoFormModel();
                FormModel.Photo = photoToEdit;
                List<SelectListItem> Categorieslist = new List<SelectListItem>();
                foreach (var cat in _context.Categories.ToList())
                {
                    Categorieslist.Add(new SelectListItem()
                    {
                        Text = cat.Name,
                        Value = cat.Id.ToString(),
                        Selected = photoToEdit.Categories.Any(c => c.Id == cat.Id)
                    });
                }
                    FormModel.Categories = Categorieslist;
                    return View(FormModel);
            }
        }

        // POST: Photos/Edit/5
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("Id,Description,Visible,Image")] */PhotoFormModel data)
        {
            if (!ModelState.IsValid)
            { 
                List<SelectListItem> CategoriesList = new List<SelectListItem>();
                foreach (var cat in _context.Categories.ToList())
                {
                    CategoriesList.Add(new SelectListItem() { Text = cat.Name, Value = cat.Id.ToString()});
                }
                data.Categories = CategoriesList;
                return View(data);
            }

            Photo photoToEdit = _context.Photos.Where(p => p.Id == id).Include(p => p.Categories).FirstOrDefault();
            photoToEdit.Categories.Clear();

            if (data.SelectedCategories != null & photoToEdit != null)
            {
                foreach (var SelectedCatId in data.SelectedCategories)
                {
                    int SelectedIntCatId = int.Parse(SelectedCatId);

                    Category cat = _context.Categories.Where(c => c.Id == SelectedIntCatId).FirstOrDefault();
                    photoToEdit.Categories.Add(cat);
                }
                photoToEdit.Title = data.Photo.Title;
                photoToEdit.Description = data.Photo.Description;
                photoToEdit.Image = data.Photo.Image;
                photoToEdit.Visible = data.Photo.Visible;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }
        // POST: Photos/Delete/
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (_context.Photos == null)
            {
                return Problem("Entity set 'PhotoAlbumContext.Photos'  is null.");
            }
            Photo photoToDelete =  _context.Photos.Find(id);
            if (photoToDelete != null)
            {
                _context.Photos.Remove(photoToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
