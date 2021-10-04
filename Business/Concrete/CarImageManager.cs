using Business.Abstract;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            if (_carImageDal.GetAll(c => c.CarId == carImage.CarId).Count == 5)
            {
                return new ErrorResult("5 adet resim var");
            }
            FileHelperForLocalStorage.Add(file, CreateNewPath(file, out var pathForDb));
            carImage.ImagePath = pathForDb;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult("basarili");
        }

        private string CreateNewPath(IFormFile file, out string pathForDb)
        {
            var fileInfo = new FileInfo(file.FileName);
            pathForDb = Guid.NewGuid() + fileInfo.Extension;
            var createdPathForHdd = Environment.CurrentDirectory + "\\wwwroot\\Images\\" + pathForDb;

            return createdPathForHdd;
        }

        public IResult Delete(CarImage carImage)
        {
            var oldPath = Environment.CurrentDirectory + "\\wwwroot\\Images\\" + _carImageDal.Get(c => c.Id == carImage.Id).ImagePath;
            var info = new FileInfo(oldPath);
            info.Delete();
            

            _carImageDal.Delete(carImage);
            return new SuccessResult("Başarı ile silindi");
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter)
        {
            var result = _carImageDal.GetAll(filter);
            if (result.Count == 0)
            {
                return DefaultPhoto();
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }
        public IDataResult<List<CarImage>> DefaultPhoto()
        {
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>() { new CarImage { ImagePath = "Default.jpg" } });
        }

        public IDataResult<CarImage> GetImageById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var newPath = CreateNewPath(file, out var pathForDb);
            var oldPath = Environment.CurrentDirectory + "\\wwwroot\\Images\\" + _carImageDal.Get(c => c.Id == carImage.Id).ImagePath;
            FileHelperForLocalStorage.Update(oldPath, file, newPath);
            carImage.ImagePath = pathForDb;
            _carImageDal.Update(carImage);
            return new SuccessResult("Başarı ile güncellendi");
        }

        
    }
}
