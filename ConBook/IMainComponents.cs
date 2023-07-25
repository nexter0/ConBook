using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConBook {
    public interface IMainComponents {
        public BindingList<cContact> mContacts { get; set; }
        public int mSelectedRowIndex { get; set; }
        public string? mCurrentFile { get; set; }
        public void RefreshDataGridView();

    }
}
