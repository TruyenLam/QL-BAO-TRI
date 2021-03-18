using DevExpress.Mvvm;
using System;

namespace QL_BAO_TRI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            
        }
        protected override void OnInitializeInRuntime()
        {
            //tren giao dien người dung
          
        }
        #region Khai báo Command
        public DelegateCommand BtnTreoThe { get; private set; }
        public DelegateCommand LoadForm_Command { get; private set; }
        #endregion
        public MainViewModel()
        {
            LoadForm_Command = new DelegateCommand(Load_form, true);
        }

        #region xu ly cac command
        void Load_form()
        {

        }
        #endregion
    }
}