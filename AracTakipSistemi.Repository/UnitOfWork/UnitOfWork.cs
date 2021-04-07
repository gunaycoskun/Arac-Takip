using AracTakipSistemi.DAL.MongoContext;
using AracTakipSistemi.Repository;
using AracTakipSistemi.Repository.Interfaces;
using AracTakipSistemi.Repository.Repositories;
using System;

namespace Eselfware.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        public IKullanicilar Kullanici { get; }
        public IArac Arac { get; }
        public ICihaz Cihaz { get; }
        public IKapiTip KapiTip { get; }
        public IKasaTip KasaTip { get; }
        public IMarka Marka { get; }
        public IModel Model { get; }
        public IMotorTip MotorTip { get; }
        public IMusteri Musteri { get; }
        public IYakitTip YakitTip { get; }
        public IVites Vites { get; }


        private readonly IMongoContext _mongoContext;

        public UnitOfWork()
        {

            _mongoContext = new MongoContext();
            Kullanici = new KullanicilarRepository(_mongoContext);
            Arac = new AracRepository(_mongoContext);
            Cihaz = new CihazRepository(_mongoContext);
            KapiTip = new KapiTipRepository(_mongoContext);
            KasaTip = new KasaTipRepository(_mongoContext);
            Marka = new MarkaRepository(_mongoContext);
            Model = new ModelRepository(_mongoContext);
            MotorTip = new MotorTipRepository(_mongoContext);
            Musteri = new MusteriRepository(_mongoContext);
            YakitTip = new YakitTipRepository(_mongoContext);
            Vites = new VitesRepository(_mongoContext);


        }

        public void Dispose()
        {

            _mongoContext.Dispose();

        }

        public int Save()
        {
            return 1;
        }

        public object Entity<T>()
        {
            throw new NotImplementedException();
        }
    }
}