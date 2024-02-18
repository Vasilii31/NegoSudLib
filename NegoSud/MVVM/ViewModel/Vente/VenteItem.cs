using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public abstract class VenteItem : ViewModelBase
    {
        public ICommand CMD_AjoutPanier { get; set; }
        public ICommand CMD_VoirPdt { get; set; }
        public ICommand CMD_PlusU { get; set; }
        public ICommand CMD_MoinsU { get; set; }
        public ICommand CMD_PlusC { get; set; }
        public ICommand CMD_MoinsC { get; set; }

        public event EventHandler EH_AjoutPanier;
        public event EventHandler EH_PlusU;
        public event EventHandler EH_MoinsU;
        public event EventHandler EH_PlusC;
        public event EventHandler EH_MoinsC;
        public event EventHandler EH_VoirPdt;
        public event EventHandler EH_DeleteCommandeAuto;

        protected void invoke_DeleteCommandeAuto(object sender)
        {
            EH_DeleteCommandeAuto?.Invoke(sender, EventArgs.Empty);
        }

        protected void invoke_AjoutPanier(object sender)
        {
            EH_AjoutPanier?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_VoirPDT(object sender)
        {
            EH_VoirPdt?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_PlusU(object sender)
        {
            EH_PlusU?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_MoinsU(object sender)
        {
            EH_MoinsU?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_PlusC(object sender)
        {
            EH_PlusC?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_MoinsC(object sender)
        {
            EH_MoinsC?.Invoke(sender, EventArgs.Empty);
        }

    }
}
