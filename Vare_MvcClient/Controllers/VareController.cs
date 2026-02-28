using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vare_Mvc.Models;

namespace Vare_Mvc.Controllers
{
    public class VareController : Controller
    {
                  
        Kavita _api = new Kavita("https://localhost:7148", new HttpClient());
        
        // GET: VareController1
        public async Task<ActionResult> Index()
        {
            var vareListe = await _api.VaresAllAsync();


            return View(vareListe.Select(c=> new VareViewModel
            {
                Navn = c.Navn,
                Antal = c.Antal,
                Id = c.Id,
                ImageData = c.ImageData,
                Pris = c.Pris
            }));
        }


        // POST: VareController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VareController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VareViewModel vareViewModel, IFormFile? imageFile)
        {
            
            // If a file is uploaded, convert it to byte[]
            if (imageFile != null && imageFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await imageFile.CopyToAsync(ms);
                vareViewModel.ImageData = ms.ToArray();
            }

            Vare vare = new Vare
            {
                ImageData = vareViewModel.ImageData,
                Antal = vareViewModel.Antal,
                Navn = vareViewModel.Navn,
                Pris = vareViewModel.Pris
            };

            await _api.VaresPOSTAsync(vare);
            return RedirectToAction("Index");
        }





        // GET: VareController1/Details/5
        // fetch from API
        public async Task<ActionResult> Details(int id)
        {
            var vare = await _api.VaresGETAsync(id);

            if (vare == null)
                return NotFound();

            var model = new VareViewModel
            {
                Id = vare.Id,
                Navn = vare.Navn,
                Antal = vare.Antal,
                Pris = vare.Pris,
                ImageData = vare.ImageData
            };

            return View(model);
        }









        // GET: VareController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {             
        
            var vare = await _api.VaresGETAsync(id);

            if (vare == null)
                return NotFound();

            var model = new VareViewModel
            {
                Id = vare.Id,
                Navn = vare.Navn,
                Antal = vare.Antal,
                Pris = vare.Pris,
                ImageData = vare.ImageData
            };

            return View(model);
        
        }

        // POST: VareController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, VareViewModel vareViewModel, IFormFile? imageFile)
        //{
        //    if (imageFile != null && imageFile.Length > 0)
        //    {
        //        using var ms = new MemoryStream();
        //        await imageFile.CopyToAsync(ms);
        //        vareViewModel.ImageData = ms.ToArray();
        //    }

        //    var vare = new Vare
        //    {
        //        Id = id,
        //        Navn = vareViewModel.Navn,
        //        Antal = vareViewModel.Antal,
        //        Pris = vareViewModel.Pris,
        //        ImageData = vareViewModel.ImageData
        //    };

        //    await _api.VaresPUTAsync(id, vare); // PUT = update in API
        //    return RedirectToAction(nameof(Index));
        //}


        // GET: VareController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var vare = await _api.VaresGETAsync(id);

            if (vare == null)
                return NotFound();

            var model = new VareViewModel
            {
                Id = vare.Id,
                Navn = vare.Navn,
                Antal = vare.Antal,
                Pris = vare.Pris,
                ImageData = vare.ImageData
            };

            return View(model);
        }

        // POST: VareController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       
        

        
       
    }
}
