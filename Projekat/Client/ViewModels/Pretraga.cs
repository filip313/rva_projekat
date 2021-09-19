using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class Pretraga
    {
        public string PretragaOpis { get; set; }
        public string PretragaNaziv { get; set; }
        public DateTime PretragaPocetakOd { get; set; }
        public DateTime PretragaPocetakDo { get; set; }
        public DateTime PretragaKrajOd { get; set; }
        public DateTime PretragaKrajDo { get; set; }
        public bool CanPonisti { get; set; }

        public List<Common.Models.Planner> temp { get; set; }

        public Pretraga()
        {
            PretragaNaziv = string.Empty;
            PretragaOpis = string.Empty;
            CanPonisti = false;
        }

        public bool Pretrazi(Models.PlanerModel PlanerModel)
        {

            PopuniListu(PlanerModel);
            temp = new List<Common.Models.Planner>();
            foreach (var item in PlanerModel.Planers)
            {
                temp.Add(item);
            }
            int planerCnt = PlanerModel.Planers.Count;
            for (int i = 0; i < planerCnt; i++)
            {
                if (!PlanerModel.Planers[i].Naziv.Contains(PretragaNaziv))
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
                    CanPonisti = true;
                    continue;
                }
                if (!PlanerModel.Planers[i].Opis.Contains(PretragaOpis))
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
                    CanPonisti = true;
                    continue;
                }
                if (PretragaPocetakOd != DateTime.MinValue)
                {
                    if (PlanerModel.Planers[i].DatumPocetka < PretragaPocetakOd)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
                        CanPonisti = true;
                        continue;
                    }
                }
                if (PretragaPocetakDo != DateTime.MinValue)
                {
                    if (PlanerModel.Planers[i].DatumPocetka > PretragaPocetakDo)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
                        CanPonisti = true;
                        continue;
                    }
                }
                if (PretragaKrajOd != DateTime.MinValue)
                {
                    if (PlanerModel.Planers[i].DatumZavrsetka < PretragaKrajOd)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
                        CanPonisti = true;
                        continue;
                    }
                }
                if (PretragaKrajDo != DateTime.MinValue)
                {
                    if (PlanerModel.Planers[i].DatumZavrsetka > PretragaKrajDo)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
                        CanPonisti = true;
                        continue;
                    }
                }
            }

            return CanPonisti;
        }

        public bool PonistiPretragu(Models.PlanerModel PlanerModel)
        {
            CanPonisti = false;

            PopuniListu(PlanerModel);

            PretragaNaziv = string.Empty;

            PretragaOpis = string.Empty;

            PretragaKrajDo = DateTime.MinValue;

            PretragaKrajOd = DateTime.MinValue;

            PretragaPocetakDo = DateTime.MinValue;

            PretragaPocetakOd = DateTime.MinValue;

            return CanPonisti;

        }

        private void PopuniListu(Models.PlanerModel PlanerModel)
        {
            if (temp != null)
            {
                PlanerModel.Planers.Clear();
                foreach (var item in temp)
                {
                    PlanerModel.Planers.Add(item);
                }
            }
        }
    }
}
