using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Concrete.EntityFramework.Context;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FlutterApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ShopController : Controller
    {
        ISellService shopContext;
        public ShopController(ISellService shop)
        {
            this.shopContext = shop;
        }

        [HttpPost]
        public IActionResult SellBook(SellDetail selldetail)
        {
            var product = shopContext.sellBook(selldetail);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult MakeOffer(OfferDetail offerdetail)
        {
            var product = shopContext.makeOffer(offerdetail);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult DeleteOffer(int offerId)
        {
            var product = shopContext.deleteOffer(offerId);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult DeleteSellBook(int sellId)
        {
            var product = shopContext.deleteSell(sellId);
            return Ok(product);
        }
    }
}