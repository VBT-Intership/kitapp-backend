using Dal.Abstract;
using Dal.AbstractInterfaces;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Bll
{
    public class SellManager : GenericManager<SellDetail>, ISellService
    {
        ISellRepository sellRepository;

        public SellManager(ISellRepository sellRepository) : base(sellRepository)
        {
            this.sellRepository = sellRepository;
        }

        public bool deleteOffer(int offerId)
        {
            return sellRepository.deleteOffer(offerId);
        }

        public bool deleteSell(int sellDetailId)
        {
            return sellRepository.deleteSell(sellDetailId);
        }

        public int makeOffer(OfferDetail offerDetail)
        {
            return sellRepository.makeOffer(offerDetail);
        }

        public int sellBook(SellDetail selldetail)
        {
            return sellRepository.sellBook(selldetail);
        }
    }
}
