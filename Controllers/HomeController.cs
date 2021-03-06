using SinglePageApp.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SinglePageApp.Controllers
{
    public class HomeController : Controller
    {
        DbSinglePageContext db = new DbSinglePageContext();
        DescriptionRepository descriptionRepository;
        GroupGalleryRepository GroupGalleryRepository;
        ProductRepository ProductRepository;
        GroupsRepository GroupsRepository;
        public HomeController()
        {
            descriptionRepository = new DescriptionRepository(db);
            GroupGalleryRepository = new GroupGalleryRepository(db);
            ProductRepository = new ProductRepository(db);
            GroupsRepository = new GroupsRepository(db);
        }
        public ActionResult _Slider()
        {
            return PartialView(ProductRepository.ListProduct());


        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyWork()
        {

            return PartialView("_MyWork", GroupsRepository.GetAllGroups());
        }
        [HttpGet]
        public ActionResult _GetProduct(Group group)
        {
            List<Product> products = new List<Product>();
          
            foreach(var item in group.ProductGroups)
            {
                products.Add(item.Product);
            }
            return PartialView("_GetProduct",products);
        }
      [AllowAnonymous]
     
        public ActionResult ShowProduct(int id)
        {
            var product = ProductRepository.GetById(id);
            return View( product);


        }

        public ActionResult AboutMe()
        {

            return PartialView("_AboutMe", ProductRepository.ListProduct());
        }

        public ActionResult ContactMe()
        {

            return PartialView("_ContactMe");
        }
        public ActionResult MyServices()
        {

            return PartialView("_MyServices");
        }
    }
}