using DAM.Proyecto.WebAPI.Domain.Entities.Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers
{
    public interface IGeneradorPDF
    {
        void GenerarPdf(string pdf);
    }
}
