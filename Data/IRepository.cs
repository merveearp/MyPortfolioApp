using System;

namespace MyPortfolioApp.Data;

public interface IRepository<T> where T:class
{
    Task<IEnumerable<T>> GetAllAsync(); //Tüm kayıtları getirir.
    Task<T?> GetAsync(int id);//ıd li kaydı getirir.
    Task<int> AddAsync(T entity);//yeni k ayıt
    Task<int> UpdateAsync(T entity);//güncelleme
    Task<int> DeleteAsync(int id);//id li kaydı sil
    
}
