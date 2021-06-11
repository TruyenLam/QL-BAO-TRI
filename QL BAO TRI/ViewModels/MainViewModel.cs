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
using QL_BAO_TRI.Views_PhuTro;

namespace QL_BAO_TRI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        THTDataEntities db_THTData = THTData_DataProvider.Ins.DB;
        #region bien toan cuc 
        public double left_menu
        {
            get { return GetProperty(() => left_menu); }
            set { SetProperty(() => left_menu, value); }
        }
        public double top_menu
        {
            get { return GetProperty(() => top_menu); }
            set { SetProperty(() => top_menu, value); }
        }
        public string visiblity_chaymay
        {
            get { return GetProperty(() => visiblity_chaymay); }
            set { SetProperty(() => visiblity_chaymay, value); }
        }
        //bining may
        public tbdanhMucMay May_Chon { get; set; } = new tbdanhMucMay();
        public string text_chay_dung {
            get { return GetProperty(() => text_chay_dung); }
            set { SetProperty(() => text_chay_dung, value); }
        }
        public string text_Hu_Sua_Xong
        {
            get { return GetProperty(() => text_Hu_Sua_Xong); }
            set { SetProperty(() => text_Hu_Sua_Xong, value); }
        }
        #region list tbDanhMucLoaiTonThat
        //public ObservableCollection<tbDanhMucLoaiTonThat> List_LoaiTonthat
        //{
        //    get { return GetProperty(() => List_LoaiTonthat); }
        //    set { SetProperty(() => List_LoaiTonthat, value); }
        //}
        #endregion

        #region cavas sodoxuong 
        public Canvas DesigningCanvas { get; set; } = new Canvas();
        //the vang
        //public Visibility _visibility {
        //    get { return GetProperty(() => _visibility); }
        //    set { SetProperty(() => _visibility, value); }
        //}

        #endregion
        #endregion
        #region timer cho chaymay
        DispatcherTimer TimerChayMay = new DispatcherTimer();
        DispatcherTimer TimerSoDoMay = new DispatcherTimer();
        DispatcherTimer Timer_btn = new DispatcherTimer();
        DispatcherTimer Timer_LoadSoDoXuong = new DispatcherTimer();
        #endregion
        #region Báo máy hư
        public string Content_BaoMayHu {
            get { return GetProperty(() => Content_BaoMayHu); }
            set { SetProperty(() => Content_BaoMayHu, value); }
        }
        public string text_checkbox_name { get; set; } = "MayDangChay";
        #endregion


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
        public DelegateCommand<object> LoadForm_Command { get; private set; }
        public DelegateCommand BtnCauHinhSoDoXuong_Command { get; private set; }
        public DelegateCommand BtnChay_Dungmay_Command { get; private set; }
        // báo máy hư
        public DelegateCommand BtnMayHu_Command { get; private set; }
        public DelegateCommand<object> BtnMayHu_OK_Command { get; private set; }
        public DelegateCommand<object> Checkbox_MayHu_name { get; private set; }
        //end báo máy hư
        //xem phieu bao tri
        public DelegateCommand BtnXemPhieuBaoTri_Command { get; private set; }
        //end xem phieu bao tri
        #endregion
        public MainViewModel()
        {
            LoadForm_Command = new DelegateCommand<object>(Load_form, true);
            BtnCauHinhSoDoXuong_Command = new DelegateCommand(Cauhinh_SoDoXuong, true);
            BtnChay_Dungmay_Command = new DelegateCommand(Chay_Dung_May, true);
            BtnMayHu_Command = new DelegateCommand(Button_MayHu, true);
            //báo máy hư
            BtnMayHu_OK_Command = new DelegateCommand<object>(Button_MayHu_OK, true);
            Checkbox_MayHu_name = new DelegateCommand<object>(Check_Box_mayHu, true);
            //end báo máy hư
            //xem phieu bao tri
            BtnXemPhieuBaoTri_Command = new DelegateCommand(XemPhieuBaoTri, true);
            //end xem phieu bao tri
        }

        #region xu ly cac command
        #region Xem phiếu bảo trì
        void XemPhieuBaoTri()
        {
            DSPhieuBaoTriWindow frphieubaotri = new DSPhieuBaoTriWindow();
            frphieubaotri.Show();
        }
        #endregion
        #region Button máy hư
        void Check_Box_mayHu(object obj)
        {
            if (obj != null)
            {
                text_checkbox_name = obj.ToString();
            }
           
            //MessageBox.Show(obj.ToString());
        }
        void Button_MayHu_OK(object obj)
        {
            //MessageBox.Show(text_checkbox_name+"  ---  "+Content_BaoMayHu);
            if (String.IsNullOrEmpty(Content_BaoMayHu))
            {
                ThemedMessageBox.Show(title: "Thông báo", text: "Xin cho biết tình trạng máy ?", messageBoxButtons: MessageBoxButton.OK, icon: MessageBoxImage.Warning);
            }

        }
        void Button_MayHu()
        {
            switch (May_Chon.TrangThai)
            {
                case "Chay":
                case "Dung":
                    text_Hu_Sua_Xong = "Máy hư";
                    frmBaoMayHu frm = new frmBaoMayHu();
                    frm.ShowDialog();
                    break;
                case "Sap":
                    //cap nhat trang thay là hu
                    break;
                case "Hu":
                    // cập nhật trang thay nó là Sua
                    break;
                case "Sua":
                    //khi nhấp vào là đã sữa xong. nhấp vào nghiệm thu
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region btn Chay dung may
        void Chay_Dung_May()
        {
            
            if (May_Chon != null)
            {
                if (May_Chon.TrangThai.Equals("Chay"))
                {
                    //mo bang chon  ly do dung may
                    //load loai ton that
                    Models.May_Dang_Chon_Class.LoaiMay = May_Chon.LoaiMay;
                    Models.May_Dang_Chon_Class.MaMay = May_Chon.MaMay;
                    TonThatWindow fr_tonthat = new TonThatWindow();
                    fr_tonthat.ShowDialog();
                    
                    // lam xong thi xoa luu may nay đi
                    
                    //if (List_Item_LoaiTonthat.Count>0)
                    //{
                    //    MessageBox.Show(List_Item_LoaiTonthat[0].MaTonThat.ToString());
                    //}
                    //Thread thread5 = new Thread(new ThreadStart(ShowSubForm));

                    //thread5.SetApartmentState(ApartmentState.STA);
                    //thread5.IsBackground = true;
                    //thread5.Start();
                    ////------------------------
                    //string sqlquery = @"UPDATE tbDanhMucMay SET TrangThai ='Dung',MaTonThat =0 , LyDoDung ='' WHERE (MaMay =" + May_Chon.MaMay + ")";
                    //int update = db_THTData.Database.ExecuteSqlCommand(sqlquery);
                    May_Chon.TrangThai = Models.May_Dang_Chon_Class.TrangThai;
                    Models.May_Dang_Chon_Class.LoaiMay = "";
                    Models.May_Dang_Chon_Class.MaMay = 0;
                    Models.May_Dang_Chon_Class.TrangThai = "";
                }
                else
                {
                    string sqlquery = @"UPDATE tbDanhMucMay SET TrangThai ='Chay',MaTonThat =0 , LyDoDung ='' WHERE (MaMay =" +May_Chon.MaMay+")";
                    int update = db_THTData.Database.ExecuteSqlCommand(sqlquery);
                    May_Chon.TrangThai = "Chay";
                }
                visiblity_chaymay = "Hidden";
                
            }
            //cap nhat mau sac cho may dang chay
            capnhat_btn_may();
        }

        //private void ShowSubForm()
        //{
        //    List_LoaiTonthat = new ObservableCollection<tbDanhMucLoaiTonThat>(db_THTData.tbDanhMucLoaiTonThats.Where(x => x.LoaiMay.Contains(Models.May_Dang_Chon_Class.LoaiMay)).ToList());
        //    foreach (var item in List_LoaiTonthat)
        //    {
        //        item.TenTonThat = TienIchFunctions.VniToUni(item.TenTonThat);
        //    }
        //    new TonThatWindow().Show();

        //    //Nói rằng đây là một Window độc lập
        //    System.Windows.Threading.Dispatcher.Run();
        //}

        #endregion
        void Cauhinh_SoDoXuong()
        {
            SoDoXuongWindowns sdx = new SoDoXuongWindowns();
            sdx.Show();
        }
        public void Load_form(object parameter)
        {
            visiblity_chaymay = "Hidden";
            DesigningCanvas = parameter as Canvas;

            Load_soDoMay();
            

            //chay timer thẻ vang
            timer_loadSoDoMay();   
        }
        public void Load_soDoMay()
        {
            #region load so do may
            var danhmucmay = db_THTData.tbdanhMucMays.Where(x => x.MaCN == "CPD" && x.NhaXuong == "Nhuom" && x.X != null).ToList();
            if (danhmucmay.Count > 0)
            {
                foreach (var item in danhmucmay)
                {
                    double h = Convert.ToDouble(item.H / 15);
                    double w = Convert.ToDouble(item.W / 15);
                    double x = Convert.ToDouble(item.X / 15);
                    double y = Convert.ToDouble(item.Y / 15);

                    SimpleButton btn = new SimpleButton();
                    btn.Height = h;
                    btn.Width = w;
                    btn.Tag = item;
                    btn.ToolTip = item.TenMay;
                    btn.FontSize = 10;
                    btn.Padding = new Thickness(0, 0, 0, 0);
                    //btn.Content = "Hello World!";
                    Canvas.SetTop(btn, y);
                    Canvas.SetLeft(btn, x);
                    //event nhan vao may
                    btn.Click += Btn_Click;
                    //kiem tra trang thay may chay

                    switch (item.TrangThai)
                    {
                        case "Chay":
                            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#A2EB96");
                            break;
                        case "Dung":
                            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#C0C0C0");
                            break;
                        case "Sap":
                            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#EBDE4A");
                            break;
                        case "Hu":
                            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#F5363D");
                            break;
                        case "Sua":
                            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#F5427F");
                            break;
                        default:
                            break;
                    }
                    //tenmay
                    if (item.MayCaption.Contains("@"))
                    {
                        string tenmay;
                        tenmay = item.MayCaption.Substring(3);
                        tenmay = TienIchFunctions.VniToUni(tenmay);
                        btn.Content = tenmay;
                    }
                    else
                    {
                        btn.Content = TienIchFunctions.VniToUni(item.MayCaption);
                    }



                    DesigningCanvas.Children.Add(btn);
                    //load thẻ vàng
                    if (item.SoTheVang != null)
                        if (item.SoTheVang > 0)
                        {
                            Label label = new Label();
                            label.Padding = new Thickness(0, 0, 0, 0);
                            label.Height = 15;
                            label.Width = 15;
                            label.Content = item.SoTheVang;
                            label.VerticalContentAlignment = VerticalAlignment.Center;
                            label.HorizontalContentAlignment = HorizontalAlignment.Center;
                            label.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF00");
                            label.Tag = item.MaMay;
                            //label.Visibility = _visibility;
                            //set bing cho ther vang


                            //=====================
                            Canvas.SetTop(label, y + 2);
                            Canvas.SetLeft(label, x + w - 15);
                            DesigningCanvas.Children.Add(label);
                        }
                }
            }
            #endregion

            //mỗi 30s sẻ load lại so đồ xưởng
            _Timer_LoadSoDoXuong();
        }
        //btn chon may
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            SimpleButton btn = (SimpleButton)sender;
           //hien memu chay dừng
             left_menu = btn.GetLeft()+btn.GetRealWidth();
            top_menu = btn.GetTop();
            if (left_menu >((1366/2)+ (1366 / 4)))
            {
                left_menu = btn.GetLeft() - btn.GetRealWidth()-230;
            }
            visiblity_chaymay = "Visible";
            May_Chon = (tbdanhMucMay)btn.Tag;

            if (May_Chon.TrangThai.Equals("Dung"))
            {
                text_chay_dung = "Chạy";
            }
            else
            {
                text_chay_dung = "Dừng";
            }

            switch (May_Chon.TrangThai)
            {
                case "Chay":
                case "Dung":
                    text_Hu_Sua_Xong = "Máy hư";
                    break;
                case "Sap":
                    text_Hu_Sua_Xong = "Dừng để sửa";
                    break;
                case "Hu":
                    text_Hu_Sua_Xong = "Bắt đầu sửa";
                    break;
                case "Sua":
                    text_Hu_Sua_Xong = "Sửa xong";
                    break;
                default:
                    break;
            }
            //5s tắt menu chay may
            timer_ChayMay();
        }

        #endregion
        #region code timer
            #region hien menu dừng - chay máy

            private void timer_ChayMay()
            {
                TimerChayMay.Tick += new EventHandler(dispatcherTimer_Tick);
                TimerChayMay.Interval = new TimeSpan(0, 0, 3);
                TimerChayMay.Start();
            }
            private void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                //5s chạy 1 lần
                // code goes here 
                visiblity_chaymay = Visibility.Collapsed.ToString();
                //MessageBox.Show("tat ud");
                TimerChayMay.Stop();
                //dừng không cho chạy nữa
            }

            #endregion

            #region chóp tắt thẻ vàng

            private void timer_loadSoDoMay()
            {
                TimerSoDoMay.Tick += new EventHandler(TimerTheVang_Tick);
                TimerSoDoMay.Interval = new TimeSpan(0, 0, 1);
                TimerSoDoMay.Start();
            }
            private void TimerTheVang_Tick(object sender, EventArgs e)
            {

                List<Label> label = DesigningCanvas.Children.OfType<Label>().ToList();
            
                foreach (var lb in label)
                {
                    if (lb.Visibility == Visibility.Visible)
                    {
                        lb.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lb.Visibility = Visibility.Visible;
                    }
                
                    //DesigningCanvas.Children.Remove(image);
                }
                //Load_soDoMay();
            }

            #endregion

            #region cap nhật lại trang thái các máy

            //cap nhat btn may
            private void capnhat_btn_may()
            {
                Timer_btn.Tick += new EventHandler(Timerbtn_Tick);
                Timer_btn.Interval = new TimeSpan(0, 0, 1);
                Timer_btn.Start();
            }
            private void Timerbtn_Tick(object sender, EventArgs e)
            {

                List<SimpleButton> btnl = DesigningCanvas.Children.OfType<SimpleButton>().ToList();

                foreach (var btn in btnl)
                {
                    tbdanhMucMay tbmay = (tbdanhMucMay)btn.Tag;
                    if (tbmay.MaMay== May_Chon.MaMay)
                    {
                        switch (May_Chon.TrangThai)
                        {
                            case "Chay":
                                btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#A2EB96");
                                break;
                            case "Dung":
                                btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#C0C0C0");
                                break;
                            case "Sap":
                                btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#EBDE4A");
                                break;
                            case "Hu":
                                btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#F5363D");
                                break;
                            case "Sua":
                                btn.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#F5427F");
                                break;
                            default:
                                break;
                        }
                    }
                }
                Timer_btn.Stop();
                //Load_soDoMay();
            }

        #endregion

            #region timer load so do xuong moi 15s
        private void _Timer_LoadSoDoXuong()
        {
            Timer_LoadSoDoXuong.Tick += new EventHandler(Timer_LoadSoDoXuong_Tick);
            Timer_LoadSoDoXuong.Interval = new TimeSpan(0, 0, 30);
            Timer_LoadSoDoXuong.Start();
        }

        private void Timer_LoadSoDoXuong_Tick(object sender, EventArgs e)
        {
            DesigningCanvas.Children.Clear();
            Load_soDoMay();
        }
        #endregion

        #endregion
    }
}