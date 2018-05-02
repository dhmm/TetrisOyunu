using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetrisOyunu.Kutuphane
{
    public interface INesne
    {
        void Dondur();
        void SagaGit();
        void SolaGit();
        bool AsagiIn();
        void PaneleEkle(Panel Panel);
        void Sabitle();
        bool UsteCarptiMi();
        void SonrakiPaneldeGoster(Panel pnlSonraki);
    }
}
