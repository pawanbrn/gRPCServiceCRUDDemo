using Microsoft.EntityFrameworkCore;
using ProductOfferGrpcService.Data;
using ProductOfferGrpcService.Entities;
using System.Text;

namespace ProductOfferGrpcService.Repositories
{
    public class ProductOfferService : IProductOfferService
    {
        private readonly DbContextClass _dbContext;
        // private readonly string FileName = @"C:\Users\kumar-152\Downloads\gRPCServiceCRUDDemo\out.txt";
        private readonly string FileName = @"C:\gRPCDemo\out.txt";

        public ProductOfferService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Offer> GetOfferList()
        {
            var list = new List<Offer>();
            using (StreamReader sr = File.OpenText(FileName))
            {
                var all = System.Text.Json.JsonSerializer.Deserialize<Offer>(sr.ReadToEnd());
                list.Add(all);
            }
            return list;
        }

        public Offer GetOfferByIdAsync(int Id)
        {
            var list = new List<Offer>();
            using (StreamReader sr = File.OpenText(FileName))
            {
                var all = System.Text.Json.JsonSerializer.Deserialize<Offer>(sr.ReadToEnd());
                list.Add(all);
            }
            return list.Find(x => x.Id == Id);
        }

        public async Task<Offer> AddOfferAsync(Offer offer)
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }

            var x = System.Text.Json.JsonSerializer.Serialize(offer);

            await using (FileStream fs = File.Create(FileName))
            {
                Byte[] content = new UTF8Encoding(true).GetBytes(x);
                fs.Write(content, 0, content.Length);
            }

            return offer;
        }

        public async Task<Offer> UpdateOfferAsync(Offer offer)
        {
            var result = _dbContext.Offer.Update(offer);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<bool> DeleteOfferAsync(int Id)
        {
            var filteredData = _dbContext.Offer.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }
    }
}
