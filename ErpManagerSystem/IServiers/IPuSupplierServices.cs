using Common.Help;
using Model.Entitys;
using Model.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IPuSupplierServices : IBaseServices<PuSupplier>
    {
        /// <summary>
        /// 经销商分页根据地址
        /// </summary>
        /// <param name="puSupplierParams"></param>
        /// <returns></returns>
        Task<PagedList<PuSupplier>> PuSupplierPaged(PuSupplierParams puSupplierParams);
    }
}
