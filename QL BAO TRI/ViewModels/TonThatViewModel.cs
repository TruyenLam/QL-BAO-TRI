using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using QL_BAO_TRI.DBContext;
using System.Linq;
using QL_BAO_TRI.Classes;
using QL_BAO_TRI.Views;
using System.Windows.Data;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;

namespace QL_BAO_TRI.ViewModels
{
    public class TonThatViewModel : ViewModelBase
    {
        THTDataEntities db_THTData = new THTDataEntities();
        #region bien toan cuc
        public ObservableCollection<tbDanhMucLoaiTonThat> List_LoaiTonthat
        {
            get { return GetProperty(() => List_LoaiTonthat); }
            set { SetProperty(() => List_LoaiTonthat, value); }
        }
        public ObservableCollection<tbDanhMucLoaiTonThat> List_Item { get; set; } = new ObservableCollection<tbDanhMucLoaiTonThat>();
        #endregion
        #region lay máy bên model mainview
        //public int MaMay = 
        #endregion
        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();

        }
        protected override void OnInitializeInRuntime()
        {
            //tren giao dien người dung
            List_LoaiTonthat = new ObservableCollection<tbDanhMucLoaiTonThat>();
        }
        #region Command
        public DelegateCommand<object> BtnChon_Dong_Ton_That_Command { get; private set; }
        public DelegateCommand Event_unload_from_Command { get; private set; }
        #endregion

        public TonThatViewModel()
        {
            List_LoaiTonthat = new ObservableCollection<tbDanhMucLoaiTonThat>( db_THTData.tbDanhMucLoaiTonThats.Where(x=>x.LoaiMay.Contains( Models.May_Dang_Chon_Class.LoaiMay)).ToList());
            foreach (var item in List_LoaiTonthat)
            {
                item.TenTonThat = TienIchFunctions.VniToUni(item.TenTonThat);
            }

            BtnChon_Dong_Ton_That_Command = new DelegateCommand<object>(Chon_Dong_Ton_That, true);
            Event_unload_from_Command = new DelegateCommand(Unload_from, true);
        }
        void Unload_from()
        {
            if (List_Item.Count() < 1)
            {
                MessageBoxResult result = ThemedMessageBox.Show("Thông báo", "Bạn có muốn tiếp tục dừng máy này hay không", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (MessageBoxResult.Yes == result)
                {
                    string sqlquery = @"UPDATE tbDanhMucMay SET TrangThai = 'Dung', ThoiGianDung = GETDATE(),NguoiBaoDung ='" + Models.User_Class.UserID + "' WHERE (MaMay =" + Models.May_Dang_Chon_Class.MaMay + ")";

                    int update = db_THTData.Database.ExecuteSqlCommand(sqlquery);
                    Models.May_Dang_Chon_Class.TrangThai = "Dung";
                }
                else
                {
                    Models.May_Dang_Chon_Class.TrangThai = "Chay";
                }
            }    
             
        }
        void Chon_Dong_Ton_That(object p)
        {
            if (List_Item.Count()>0)
            {
                //MessageBox.Show(List_Item[0].TenTonThat);
                string sqlquery = @"UPDATE tbDanhMucMay SET TrangThai = 'Dung', MaTonThat = " + List_Item[0].MaTonThat + ", LyDoDung = '" + List_Item[0].TenTonThat + "'," +
                    "ThoiGianDung = GETDATE(),NguoiBaoDung ='" + Models.User_Class.UserID + "' WHERE (MaMay =" + Models.May_Dang_Chon_Class.MaMay + ")";

                int update = db_THTData.Database.ExecuteSqlCommand(sqlquery);
                Models.May_Dang_Chon_Class.TrangThai = "Dung";
                Window dXWindow = new Window();
                dXWindow = p as Window;
                dXWindow.Close();
            }
            else
            {
                ThemedMessageBox.Show("Thông báo", "Vui lòng liên hệ bộ phận IT " +
                    "để cập nhật lý do dừng máy cho thiết bị này. Máy này vẩn được dừng",MessageBoxButton.OK,MessageBoxImage.Information);
                
            }
            
        }
    }
}