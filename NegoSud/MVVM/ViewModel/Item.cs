using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public abstract class Item : ViewModelBase
    {
        public ICommand ClickDeleteCommand { get; set; }

        public ICommand ClickModifyCommand { get; set; }

        public event EventHandler deleted;
        public event EventHandler modify;

        protected void invoke_Delete(object sender)
        {
            deleted?.Invoke(sender, EventArgs.Empty);
        }

        protected void invoke_Modify(object sender)
        {
            modify?.Invoke(sender, EventArgs.Empty);
        }
    }
}
