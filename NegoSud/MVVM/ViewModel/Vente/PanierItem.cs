using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public abstract class PanierItem : ViewModelBase
    {
        public ICommand CMD_SupprimerDuPanier { get; set; }

        public event EventHandler EH_SupprimerDuPanier;


        protected void invoke_SupprimerDuPanier(object sender)
        {
            EH_SupprimerDuPanier?.Invoke(sender, EventArgs.Empty);
        }

    }
}
