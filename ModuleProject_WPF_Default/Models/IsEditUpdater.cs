using Prism.Mvvm;

namespace ModuleProject_WPF_Default.Models
{
    public delegate void DBModelEditEventHandler();

    public class IsEditUpdater : BindableBase
    {
        public DBModelEditEventHandler UserEditEvent;

        public bool IsEdit
        {
            get
            {
                UserEditEvent?.Invoke();
                return IsUserEdit();
            }
        }

        public virtual void CopyOriginToUI() { }

        public virtual void CopyUIToOrigin() { }

        public virtual bool IsUserEdit() { return false; }
    }
}
