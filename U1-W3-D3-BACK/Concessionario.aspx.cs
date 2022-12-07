using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U1_W3_D3_BACK
{
    public partial class Concessionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach(Auto autovettura in Auto.GetList())
                {
                    ListItem autoItem = new ListItem(autovettura.NomeAuto, autovettura.Id.ToString());
                    ddlAuto.Items.Add(autoItem);
                }
                
            }
        }

        protected void ConfermaAcquisto_Click(object sender, EventArgs e)
        {
            int autoScelta = Convert.ToInt32(ddlAuto.SelectedValue);

            foreach(Auto autovettura in Auto.GetList())
            {
                if(autovettura.Id == autoScelta)
                {
                    string optional = "";
                    decimal costoOptional = 0;

                    foreach (ListItem optionalItem in CheckBoxOptional.Items)
                    {
                        if(optionalItem.Selected)
                        {
                            optional += $"{optionalItem.Text}";
                            costoOptional += Convert.ToInt32(optionalItem.Value);
                        }
                    }

                    string garanzia = "";
                    decimal costoGaranzia = 0;

                    foreach(ListItem garanziaItem in ddlGaranzia.Items)
                    {
                        if(garanziaItem.Selected)
                        {
                            garanzia += $"{garanziaItem.Text}";
                            costoGaranzia += Convert.ToInt32(garanziaItem.Value);
                        }
                    }

                    Auto AutoScelta = new Auto()
                    {
                        NomeAuto = $"{autovettura.NomeAuto} {autovettura.CostoAuto}, Optional: {optional} {costoOptional}, Garanzia: {garanzia} {costoGaranzia}",
                        CostoAuto = autovettura.CostoAuto,
                        CostoOptional = costoOptional,
                        CostoGaranzia = costoGaranzia
                    };
                    Auto.ListaAuto.Add(AutoScelta);
                }
            }

            decimal totaleDaPagare = 0;
            foreach (Auto AutoDaPagare in Auto.ListaAuto)
            {
                TotaleAcquisto.Text += AutoDaPagare.NomeAuto;
                totaleDaPagare = AutoDaPagare.CostoAuto + AutoDaPagare.CostoOptional + AutoDaPagare.CostoGaranzia;
            }
            PrezzoTotale.Text = totaleDaPagare.ToString("c2");
        }

        public class Auto
        {
            public int Id { get; set; }
            public string NomeAuto { get; set; }
            public decimal CostoAuto { get; set; }
            public decimal CostoOptional { get; set; }
            public decimal CostoGaranzia { get; set; }
            public decimal Totale { get; set; }
            public static List<Auto> ListaAuto = new List<Auto>();
            public static List<Auto> GetList()
            {
                List<Auto> autoList = new List<Auto>();
                
                Auto auto1 = new Auto { Id = 1, NomeAuto = "Ferrari", CostoAuto = 1000000.00M };
                Auto auto2 = new Auto { Id = 2, NomeAuto = "McLaren", CostoAuto = 1200000.00M };
                Auto auto3 = new Auto { Id = 3, NomeAuto = "Toyota", CostoAuto = 30000.00M };

                autoList.Add(auto1);
                autoList.Add(auto2);
                autoList.Add(auto3);

                return autoList;
            }
        }

        protected void ddlAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string autoSelezionata = ddlAuto.SelectedValue;
            if(autoSelezionata == "1")
            {
                CarImage.ImageUrl = "./img/ferrari-laferrari.jpg";
            } else if(autoSelezionata == "2")
            {
                CarImage.ImageUrl = "./img/2013-03-05_Geneva_Motor_Show_7845.JPG";
            } else if (autoSelezionata == "3")
            {
                CarImage.ImageUrl = "./img/trueno.jpg";
            } else if (autoSelezionata == "0")
            {
                CarImage.ImageUrl = "";
            }

        }
    }
}