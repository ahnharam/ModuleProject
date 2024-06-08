using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleProject.Models
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
