using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Websitebangiay.Models;

namespace Websitebangiay.Controllers
{
    public class ThuongHieuController : Controller
    {
        ShopShoe db = new ShopShoe();
        // GET: ThuongHieu

        public ActionResult xemthuonghieu( int Mahang)
        {
            var listhang = db.Hangsanxuats.Where(p => p.Mahang == Mahang).ToList();
            ViewBag.listhang = listhang;
            var listsanpham = db.Sanphams.Where(p => p.Mahang == Mahang).ToList();
            if (listsanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(listsanpham);

        }


}
}