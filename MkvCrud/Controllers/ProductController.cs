using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Serilog;
using Microsoft.AspNetCore.OutputCaching;

namespace MkvCrud.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _product;

        public ProductController(IProductService product)
        {
            _product = product;
            Log.Logger = new LoggerConfiguration()
           .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
        }
       // [OutputCache(Duration = 60)]
        public async Task<IActionResult> GetAll()
        {
            var products =  await _product.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id=0)
        {
            if(id == 0)
            {   
                return View(new Product());
            }
            else
            {
                try
                {
                    Product product = await _product.GetById(id);
                    if (product != null)
                    {
                        return View(product);

                    }
                }
                catch (Exception ex)
                {

                    TempData["errorMessage"] = ex.Message;
                    Log.Error(ex, "CreateOrEdit metodu bir istisna fırlattı.");
                    return RedirectToAction("GetAll");
                }
               
                TempData["errorMessage"]=$"{id} numaralı ürün bulunamadı";
                Log.Error($"{id} numaralı ürün bulunamadı");
                return RedirectToAction("GetAll");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        await _product.Add(model);
                        TempData["successMessage"] = "Ürün eklendi";
                        Log.Information("Ürün eklendi");
                       
                    }
                    else
                    {
                        await _product.Update(model);
                        TempData["successMessage"] = "Ürün başarıyla güncellendi";
                    }
                    return RedirectToAction(nameof(GetAll));
                }
                else
                {
                    TempData["errorMessage"] = "Geçersiz veri";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
           

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product product = await _product.GetById(id);
                if (product != null)
                {
                    return View(product);

                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("GetAll");
            }
            TempData["errorMessage"] = $"{id} nolu Id'li ürün bulunamadı";
            return RedirectToAction("GetAll");
        }


        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _product.Delete(id);
                TempData["successMesaage"] = "Ürün silindi";
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();

            }
        }
    }
}
