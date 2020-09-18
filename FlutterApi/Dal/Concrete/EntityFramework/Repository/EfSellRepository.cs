using Dal.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete.EntityFramework.Repository
{
    public class EfSellRepository : EfGenericRepository<SellDetail>, ISellRepository
    {
        public EfSellRepository():base()
        {
            
        }

        public bool deleteOffer(int offerId)
        {
            try
            {
                context.OfferDetail.Remove(context.OfferDetail.FirstOrDefault(x => x.OfferDetalId == offerId));
                return Convert.ToBoolean(context.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteSell(int sellDetailId)
        {
            try
            {
                context.SellDetail.Remove(context.SellDetail.FirstOrDefault(x => x.sellId == sellDetailId));
                return Convert.ToBoolean(context.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int makeOffer(OfferDetail offerDetail)
        {
            try
            {
                offerDetail.OfferDate = DateTime.Now;
                offerDetail.OfferStatus = 0;
                context.OfferDetail.Add(offerDetail);
                context.SaveChanges();
                return offerDetail.OfferDetalId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int sellBook(SellDetail selldetail)
        {
            try
            {
                selldetail.PublishDate = DateTime.Now;
                selldetail.IsActive = true;
                selldetail.Status = 0;
                context.SellDetail.Add(selldetail);
                context.SaveChanges();
                return selldetail.sellId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
