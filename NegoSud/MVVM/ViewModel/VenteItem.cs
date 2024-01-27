using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public abstract class VenteItem : ViewModelBase
    {
        public ICommand CMD_AjoutPanier { get; set; }
        public ICommand CMD_VoirPdt { get; set; }
        public ICommand CMD_plusU { get; set; }
        public ICommand CMD_moinsU { get; set; }
        public ICommand CMD_plusC { get; set; }
        public ICommand CMD_moinsC { get; set; }

        public event EventHandler EH_ajoutPanier;
        public event EventHandler EH_plusU;
        public event EventHandler EH_moinsU;
        public event EventHandler EH_plusC;
        public event EventHandler EH_moinsC;
        public event EventHandler EH_voirPdt;

        protected void invoke_AjoutPanier(object sender)
        {
            EH_ajoutPanier?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_voirPDT(object sender)
        {
            EH_voirPdt?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_plusU(object sender)
        {
            EH_plusU?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_moinsU(object sender)
        {
            EH_moinsU?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_plusC(object sender)
        {
            EH_plusC?.Invoke(sender, EventArgs.Empty);
        }
        protected void invoke_moinsC(object sender)
        {
            EH_moinsC?.Invoke(sender, EventArgs.Empty);
        }

    }
}
