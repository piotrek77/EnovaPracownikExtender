using EnovaPracownikExtender;
using Soneta.Business;
using Soneta.Business.App;
using Soneta.Handel;
using Soneta.Kadry;
using System;
using System.Collections.Generic;
using System.Text;
[assembly: Worker(typeof(ScpPracownikExtenderWorker), typeof(Soneta.Kadry.Pracownik))]
namespace EnovaPracownikExtender
{
    public class ScpPracownikExtenderWorker
    {

        private Pracownik pracownik;

        EnovaPracownikExtender.ScpPracownikExtender e=null;


        
        [Context]
        public Context Cx { get; set; }

        [Context]
        public Pracownik Pracownik
        { 
            
            get
            {
                return this.pracownik;
            }
            
            set
            {
                this.pracownik = value;

                Ustaw();

            }
        
        }


        private void Ustaw()
        {
            EnovaPracownikExtender.ScpPracownikExtenderModule mod = EnovaPracownikExtender.ScpPracownikExtenderModule.GetInstance(pracownik.Session);

            e = mod.ScpPracExtTable.WgHost[this.pracownik];
        }


        public int NumerButa
        {
            get
            {
                if (e==null)
                {
                    return 0;
                }
                return e.NumerButa;
            }
            set

            {

                if (e == null)
                {

                    using (Session session = this.pracownik.Session.Login.CreateSession(false, false))
                    {
                        using (ITransaction tran = session.Logout(true))
                        {
                            Pracownik p = (Pracownik)session[pracownik];

                            if (e == null)
                            {
                                e = new EnovaPracownikExtender.ScpPracownikExtender()
                                {
                                    Host = p,
                                };
                            
                            }
                            else
                            {
                                e = (ScpPracownikExtender)session[e];
                            }
                           
                            e.NumerButa = value;
                            session.AddRow(e);
                            tran.Commit();

                        }
                        session.Save();
                    }
                            
                }


                
                


            }
        }
    }
}
