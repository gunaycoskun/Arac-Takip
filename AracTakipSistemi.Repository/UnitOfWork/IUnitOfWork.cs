using AracTakipSistemi.Repository;
using AracTakipSistemi.Repository.Interfaces;
using System;

namespace Eselfware.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
       
        object Entity<T>();

        IUsers Users { get; }
        IArac Arac { get; }
        ICihaz Cihaz { get; }
        IKapiTip KapiTip { get; }
        IKasaTip KasaTip { get; }
        IMarka Marka { get; }
        IModel Model { get; }
        IMotorTip MotorTip { get; }
        IMusteri Musteri { get; }
        IYakitTip YakitTip { get; }
        IVites Vites { get; }
        int Save();
    }
}