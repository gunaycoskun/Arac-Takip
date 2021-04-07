using AracTakipSistemi.DAL.Concrete;
using Eselfware.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracTakipSistemi.Repository.Seeder
{
    public static class DataSeeder
    {
        [Obsolete]
        public static void Seed(IUnitOfWork _unitOfWork)
        {
            if (_unitOfWork.Kullanici.FirstOrDefault()==null)
            {
                _unitOfWork.Kullanici.Add(new tbl_Kullanicilar
                {
                    KullaniciAdi = "admin",
                    Parola = "43314",
                    OlusturulmaTarihi = DateTime.Now
                });
            }
            if (_unitOfWork.YakitTip.FirstOrDefault() == null)
            {
                _unitOfWork.YakitTip.Add(new tbl_YakitTip
                {
                    YakitAD = "Benzin",
                    _id = "1"
                });
                _unitOfWork.YakitTip.Add(new tbl_YakitTip
                {
                    YakitAD = "Dizel",
                    _id = "2"
                });
                _unitOfWork.YakitTip.Add(new tbl_YakitTip
                {
                    YakitAD = "LPG/Benzin",
                    _id = "3"
                });
                _unitOfWork.YakitTip.Add(new tbl_YakitTip
                {
                    YakitAD = "Elektrikli",
                    _id = "4"
                });


            }
            if (_unitOfWork.KasaTip.FirstOrDefault() == null)
            {
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "1",
                    KasaAD = "Minivan/Panelvan"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "2",
                    KasaAD = "Hatchback"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "3",
                    KasaAD = "Station Wagon"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "4",
                    KasaAD = "Sedan"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "5",
                    KasaAD = "Coupe"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "6",
                    KasaAD = "Cabrio"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "7",
                    KasaAD = "MPV"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "8",
                    KasaAD = "SUV"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "9",
                    KasaAD = "Kamyon"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "10",
                    KasaAD = "Damperli Kamyon"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "11",
                    KasaAD = "Minibüs"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "12",
                    KasaAD = "Midibüs"
                });
                _unitOfWork.KasaTip.Add(new tbl_KasaTip
                {
                    _id = "13",
                    KasaAD = "Tır"
                });


            }
            if (_unitOfWork.KapiTip.FirstOrDefault() == null)
            {
                _unitOfWork.KapiTip.Add(new tbl_KapiTip
                {
                    _id = "1",
                    KapiAD = "Tek Kapı"

                });
                _unitOfWork.KapiTip.Add(new tbl_KapiTip
                {
                    _id = "2",
                    KapiAD = "Standart"

                });
                _unitOfWork.KapiTip.Add(new tbl_KapiTip
                {
                    _id = "3",
                    KapiAD = "6 Kapılı"

                });
                _unitOfWork.KapiTip.Add(new tbl_KapiTip
                {
                    _id = "4",
                    KapiAD = "8 Kapılı"

                });
            }
            if (_unitOfWork.Vites.FirstOrDefault() == null) {
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "1",
                    VitesAD="Manuel",
                    VitesSayisi="5"
                });
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "2",
                    VitesAD = "Manuel",
                    VitesSayisi = "6"
                });
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "3",
                    VitesAD = "Manuel",
                    VitesSayisi = "8"
                });
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "4",
                    VitesAD = "Manuel",
                    VitesSayisi = "12"
                });
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "5",
                    VitesAD = "Otomatik",
                    VitesSayisi = "5"
                });
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "6",
                    VitesAD = "Otomatik",
                    VitesSayisi = "6"
                });
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "7",
                    VitesAD = "Otomatik",
                    VitesSayisi = "8"
                });
                _unitOfWork.Vites.Add(new tbl_Vites
                {
                    _id = "8",
                    VitesAD = "Otomatik",
                    VitesSayisi = "12"
                });


            }

        }
    }
}
