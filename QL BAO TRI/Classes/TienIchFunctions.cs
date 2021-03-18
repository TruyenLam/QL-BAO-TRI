using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_BAO_TRI.Classes
{
    public class TienIchFunctions
    {
        public static string VniToUni(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder sUni = new StringBuilder();

                //string VNI = "aù,aø,aû,aõ,aï,aâ,aê,aá,aà,aå,aã,aä,aé,aè,aú,aü,aë,AÙ,AØ,AÛ,AÕ,AÏ,AÂ,AÊ,AÁ,AÀ,AÅ,AÃ,AÄ,AÉ,AÈ,AÚ,AÜ,AË,eù,eø,eû,eõ,eï,eâ,eá,eà,eå,eã,eä,EÙ,EØ,EÛ,EÕ,EÏ,EÂ,EÁ,EÀ,EÅ,EÃ,EÄ,í ,ì ,æ ,ó ,ò ,Í ,Ì ,Æ ,Ó ,Ò ,où,oø,oû,oõ,oï,oâ,ô ,oá,oà,oå,oã,oä,ôù,ôø,ôû,ôõ,ôï,OÙ,OØ,OÛ,OÕ,OÏ,OÂ,Ô ,OÁ,OÀ,OÅ,OÃ,OÄ,ÔÙ,ÔØ,ÔÛ,ÔÕ,ÔÏ,uù,uø,uû,uõ,uï,ö ,öù,öø,öû,öõ,öï,UÙ,UØ,UÛ,UÕ,UÏ,Ö ,ÖÙ,ÖØ,ÖÛ,ÖÕ,ÖÏ,yù,yø,yû,yõ,î ,YÙ,YØ,YÛ,YÕ,Î ,ñ ,Ñ ";
                //string UNI = "E1,E0,1EA3,E3,1EA1,E2,103,1EA5,1EA7,1EA9,1EAB,1EAD,1EAF,1EB1,1EB3,1EB5,1EB7,C1,C0,1EA2,C3,1EA0,C2,102,1EA4,1EA6,1EA8,1EAA,1EAC,1EAE,1EB0,1EB2,1EB4,1EB6,E9,E8,1EBB,1EBD,1EB9,EA,1EBF,1EC1,1EC3,1EC5,1EC7,C9,C8,1EBA,1EBC,1EB8,CA,1EBE,1EC0,1EC2,1EC4,1EC6,ED,EC,1EC9,129,1ECB,CD,CC,1EC8,128,1ECA,F3,F2,1ECF,F5,1ECD,F4,1A1,1ED1,1ED3,1ED5,1ED7,1ED9,1EDB,1EDD,1EDF,1EE1,1EE3,D3,D2,1ECE,D5,1ECC,D4,1A0,1ED0,1ED2,1ED4,1ED6,1ED8,1EDA,1EDC,1EDE,1EE0,1EE2,FA,F9,1EE7,169,1EE5,1B0,1EE9,1EEB,1EED,1EEF,1EF1,DA,D9,1EE6,168,1EE4,1AF,1EE8,1EEA,1EEC,1EEE,1EF0,FD,1EF3,1EF7,1EF9,1EF5,DD,1EF2,1EF6,1EF8,1EF4,111,110";

                //ký tự VNI
                string[] arrVNI = {
                    "aù","aø","aû","aõ","aï","aâ","aê","aá","aà","aå",
                    "aã","aä","aé","aè","aú","aü","aë","AÙ","AØ","AÛ",
                    "AÕ","AÏ","AÂ","AÊ","AÁ","AÀ","AÅ","AÃ","AÄ","AÉ",
                    "AÈ","AÚ","AÜ","AË","eù","eø","eû","eõ","eï","eâ",
                    "eá","eà","eå","eã","eä","EÙ","EØ","EÛ","EÕ","EÏ",
                    "EÂ","EÁ","EÀ","EÅ","EÃ","EÄ","í ","ì ","æ ","ó ",
                    "ò ","Í ","Ì ","Æ ","Ó ","Ò ","où","oø","oû","oõ",
                    "oï","oâ","ô ","oá","oà","oå","oã","oä","ôù","ôø",
                    "ôû","ôõ","ôï","OÙ","OØ","OÛ","OÕ","OÏ","OÂ","Ô ",
                    "OÁ","OÀ","OÅ","OÃ","OÄ","ÔÙ","ÔØ","ÔÛ","ÔÕ","ÔÏ",
                    "uù","uø","uû","uõ","uï","ö ","öù","öø","öû","öõ",
                    "öï","UÙ","UØ","UÛ","UÕ","UÏ","Ö ","ÖÙ","ÖØ","ÖÛ",
                    "ÖÕ","ÖÏ","yù","yø","yû","yõ","î ","YÙ","YØ","YÛ",
                    "YÕ","Î ","ñ ","Ñ "
                };

                //số Hex
                string[] arrUNI = {
                    "á","à","ả","ã","ạ","â","ă","ấ","ầ","ẩ",
                    "ẫ","ậ","ắ","ằ","ẳ","ẵ","ặ","Á","À","Ả",
                    "Ã","Ạ","Â","Ă","Ấ","Ầ","Ẩ","Ẫ","Ậ","Ắ",
                    "Ằ","Ẳ","Ẵ","Ặ","é","è","ẻ","ẽ","ẹ","ê",
                    "ế","ề","ể","ễ","ệ","É","È","Ẻ","Ẽ","Ẹ",
                    "Ê","Ế","Ề","Ể","Ễ","Ệ","í","ì","ỉ","ĩ",
                    "ị","Í","Ì","Ỉ","Ĩ","Ị","ó","ò","ỏ","õ",
                    "ọ","ô","ơ","ố","ồ","ổ","ỗ","ộ","ớ","ờ",
                    "ở","ỡ","ợ","Ó","Ò","Ỏ","Õ","Ọ","Ô","Ơ",
                    "Ố","Ồ","Ổ","Ỗ","Ộ","Ớ","Ờ","Ở","Ỡ","Ợ",
                    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ",
                    "ự","Ú","Ù","Ủ","Ũ","Ụ","Ư","Ứ","Ừ","Ử",
                    "Ữ","Ự","ý","ỳ","ỷ","ỹ","ỵ","Ý","Ỳ","Ỷ",
                    "Ỹ","Ỵ","đ","Đ"
            };
                for (int i = 0; i < str.Length; i++)
                {
                    if (i != str.Length - 1 && arrVNI.Contains(str.Substring(i, 2)))
                    {
                        var charUNI = arrUNI[Array.IndexOf(arrVNI, str.Substring(i, 2))];
                        sUni.Append(charUNI);
                        if (str.Substring(i + 1, 1) != " ") //ký tự thứ 2 " " --> ví dụ: Thị Tư có dấu cách
                        {
                            //tăng i lên
                            i = i + 1;
                        }
                    }
                    else if (arrVNI.Contains(str.Substring(i, 1) + " "))
                    {
                        //xác định index trong arrUNI
                        var charUNI = arrUNI[Array.IndexOf(arrVNI, str.Substring(i, 1) + " ")];
                        sUni.Append(charUNI);
                    }
                    else
                    {
                        sUni.Append(str[i]);

                    }

                }
                return sUni.ToString();
            }
            else
            {
                return str;
            }
        }

        public static string UniToVni(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder sVni = new StringBuilder();
                //ký tự VNI - bỏ dấu cách
                string[] arrVNI = {
                    "aù","aø","aû","aõ","aï","aâ","aê","aá","aà","aå",
                    "aã","aä","aé","aè","aú","aü","aë","AÙ","AØ","AÛ",
                    "AÕ","AÏ","AÂ","AÊ","AÁ","AÀ","AÅ","AÃ","AÄ","AÉ",
                    "AÈ","AÚ","AÜ","AË","eù","eø","eû","eõ","eï","eâ",
                    "eá","eà","eå","eã","eä","EÙ","EØ","EÛ","EÕ","EÏ",
                    "EÂ","EÁ","EÀ","EÅ","EÃ","EÄ","í","ì","æ","ó",
                    "ò","Í","Ì","Æ","Ó","Ò","où","oø","oû","oõ",
                    "oï","oâ","ô","oá","oà","oå","oã","oä","ôù","ôø",
                    "ôû","ôõ","ôï","OÙ","OØ","OÛ","OÕ","OÏ","OÂ","Ô",
                    "OÁ","OÀ","OÅ","OÃ","OÄ","ÔÙ","ÔØ","ÔÛ","ÔÕ","ÔÏ",
                    "uù","uø","uû","uõ","uï","ö","öù","öø","öû","öõ",
                    "öï","UÙ","UØ","UÛ","UÕ","UÏ","Ö","ÖÙ","ÖØ","ÖÛ",
                    "ÖÕ","ÖÏ","yù","yø","yû","yõ","î","YÙ","YØ","YÛ",
                    "YÕ","Î","ñ","Ñ"
                };

                string[] arrUni = {
                    "á","à","ả","ã","ạ","â","ă","ấ","ầ","ẩ",
                    "ẫ","ậ","ắ","ằ","ẳ","ẵ","ặ","Á","À","Ả",
                    "Ã","Ạ","Â","Ă","Ấ","Ầ","Ẩ","Ẫ","Ậ","Ắ",
                    "Ằ","Ẳ","Ẵ","Ặ","é","è","ẻ","ẽ","ẹ","ê",
                    "ế","ề","ể","ễ","ệ","É","È","Ẻ","Ẽ","Ẹ",
                    "Ê","Ế","Ề","Ể","Ễ","Ệ","í","ì","ỉ","ĩ",
                    "ị","Í","Ì","Ỉ","Ĩ","Ị","ó","ò","ỏ","õ",
                    "ọ","ô","ơ","ố","ồ","ổ","ỗ","ộ","ớ","ờ",
                    "ở","ỡ","ợ","Ó","Ò","Ỏ","Õ","Ọ","Ô","Ơ",
                    "Ố","Ồ","Ổ","Ỗ","Ộ","Ớ","Ờ","Ở","Ỡ","Ợ",
                    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ",
                    "ự","Ú","Ù","Ủ","Ũ","Ụ","Ư","Ứ","Ừ","Ử",
                    "Ữ","Ự","ý","ỳ","ỷ","ỹ","ỵ","Ý","Ỳ","Ỷ",
                    "Ỹ","Ỵ","đ","Đ"
                };

                for (int i = 0; i < str.Length; i++)
                {
                    //xác định index trong arrUNI
                    var index = Array.IndexOf(arrUni, str[i].ToString());
                    //nếu index >=0 (tìm thấy) thì thay thế, không thì không cần thay thế
                    if (index >= 0)
                    {
                        var vni = arrVNI[index];
                        sVni.Append(vni);
                    }
                    else
                    {
                        sVni.Append(str[i]);
                    }
                }
                return sVni.ToString();
            }
            else
            {
                return str;
            }

        }
    }
}
