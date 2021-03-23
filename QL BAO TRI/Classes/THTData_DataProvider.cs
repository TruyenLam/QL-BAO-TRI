using QL_BAO_TRI.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BAO_TRI.Classes
{
    public class THTData_DataProvider
    {
        private static THTData_DataProvider _ins;
        public static THTData_DataProvider Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new THTData_DataProvider();
                }
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public THTDataEntities DB { get; set; }
        private THTData_DataProvider()
        {

            DB = new THTDataEntities();
        }

        //Sử dụng
        // var a = DataProvider.INS.DB_THTData . .
    }
}
