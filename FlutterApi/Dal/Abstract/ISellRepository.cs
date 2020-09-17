using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface ISellRepository : IGenericRepository<SellDetail>
    {
        int sellBook(SellDetail selldetail);
        int makeOffer(OfferDetail offerDetail);
        bool deleteSell(int sellDetailId);
        bool deleteOffer(int offerId);
    }
}
