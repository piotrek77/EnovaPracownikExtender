using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnovaPracownikExtender
{
    public class ScpPracownikExtender : EnovaPracownikExtender.ScpPracownikExtenderModule.ScpPracownikExtenderRow
    {


        protected override void OnDeleting()
        {
            base.OnDeleting();
            RowStatus status = Host.Status;

            if ((status & RowStatus.Deleting) == 0 && !Session.InImport)
            {
                throw new RowException(this, "Dodatkowe informacje o pracowniku mogą być kasowe tylko z zapisem głównym");
            }
        }


    }
}
