using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductSysMag.Models;
using ProductSysMag.ProductReboistory;

namespace ProductSysMag.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductsReboistory _productsReboistory;

        public ProductsController(ProductsReboistory productsReboistory)
        {
            _productsReboistory = productsReboistory;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productsReboistory.GetAllProduct();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productsReboistory.CrerateProduct(productModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(productModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occured while adding the product model");
                return View(productModel);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productsReboistory.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productsReboistory.UpdateProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occured while updating the product model");
                return View(product);
            }


        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productsReboistory.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {  
            await _productsReboistory.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
