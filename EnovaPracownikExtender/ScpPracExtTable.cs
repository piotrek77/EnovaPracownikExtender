using Soneta.Handel;
using Soneta.Kadry;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnovaPracownikExtender
{
    public class ScpPracExtTable : EnovaPracownikExtender.ScpPracownikExtenderModule.ScpPracownikExtenderTable
    {


        static ScpPracExtTable()
        {
            //Soneta.Handel.HandelModule.DokumentHandlowySchema.AddOnAdded(new Soneta.Business.RowDelegate<Soneta.Handel.HandelModule.DokumentHandlowyRow>(DokumentHandlowyAdded));
            Soneta.Kadry.KadryModule.PracownikSchema.AddOnAdded(new Soneta.Business.RowDelegate<Soneta.Kadry.KadryModule.PracownikRow>(PracownikAdded));

        }



        static void PracownikAdded(Soneta.Kadry.KadryModule.PracownikRow pracownikRow)
        {
            Pracownik pracownik = (Pracownik)pracownikRow;

            ScpPracownikExtender scpPracownikExtender = new ScpPracownikExtender()
            {
                Host = pracownik,
            };
            ScpPracownikExtenderModule.GetInstance(pracownik).ScpPracExtTable.AddRow(scpPracownikExtender);
            
        }


    }
}
