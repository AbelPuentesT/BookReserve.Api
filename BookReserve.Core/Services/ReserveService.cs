using BookReserve.Core.Entities;
using BookReserve.Core.Interfaces;
using BookReserve.Core.QueryFilters;
using PolizaSOAT.Core.Interfaces;

namespace BookReserve.Core.Services
{
    public class ReserveService : IReserveService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReserveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Reserve>> GetAll()
        {
            var reserves = _unitOfWork.ReserveRepository.GetAll();

            return reserves.ToList();
        }
        public async Task<Reserve> GetById(int id)
        {
            var reserve = await _unitOfWork.ReserveRepository.GetById(id);
            if (reserve == null)
            {
                throw new Exception("Not fount");
            }
            return reserve;
        }
        public async Task<Reserve> Insert(Reserve reserve)
        {
            await _unitOfWork.ReserveRepository.Insert(reserve);
            await _unitOfWork.SaveChangesAsync();

            return reserve;
        }
        public async Task<bool> Update(Reserve reserve)
        {
            var reserveExisting = await _unitOfWork.ReserveRepository.GetById(reserve.Id);
            _unitOfWork.ReserveRepository.Update(reserveExisting);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ReserveRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

    }
}
