using System.Data;
using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;

namespace DaryaVariaTest.Services;

public class ChartServices {
    private readonly IProductRepository _prodRepo;
    private readonly IOrderRepository _repo;
    public ChartServices(IProductRepository productRepository, IOrderRepository repository){
        _prodRepo = productRepository;
        _repo = repository;
    }

    private List<Product> GetAllProduct() {
        return _prodRepo.GetAllProduct();
    }

    public ChartViewModel GetChartShow() {
        List<Product> products = GetAllProduct();
        var listDataFil = new List<ListDataFilter>();
        var allTrx = _repo.GetAllTransactionWithDetailProductTrx();
        List<int> Years = new List<int>();
        foreach (var item in allTrx)
        {
            foreach(ProductsTransaction i in item.ProductsTransactions) {
                var prod = products.FirstOrDefault(p => p.Id == i.ProductId);
                var dataFil = listDataFil.FirstOrDefault(l => l.Label == prod.Name && l.Year == item.OrderDate.Year);
                if(dataFil != null) {
                    dataFil.Data += 1;
                } else {
                    Years.Add(item.OrderDate.Year);
                    listDataFil.Add(
                        new ListDataFilter{
                            Label = prod.Name,
                            Year = item.OrderDate.Year,
                            Data = 1
                        }
                    );
                }
            }
        }

        int[] uniqueOrderedYears = Years.Distinct().OrderBy(y => y).ToArray();
        var yearLabels = uniqueOrderedYears.Select(y => y.ToString()).ToArray();

        var groupedByProduct = listDataFil
            .GroupBy(l => l.Label)
            .Select(g =>
            {
                var dataPerYear = uniqueOrderedYears
                    .Select(y => g.FirstOrDefault(l => l.Year == y)?.Data ?? 0) 
                    .ToArray();

                return new ChartViewModel.Dataset
                {
                    Label = g.Key,
                    Data = dataPerYear,
                    BackgroundColor = GenerateRandomColor()
                };
            }).ToList();

        var viewModel = new ChartViewModel
        {
            Labels = yearLabels,
            Datasets = groupedByProduct
        };

        return viewModel;
    }

    private string GenerateRandomColor() {
        var random = new Random();
        int r = random.Next(0, 256);
        int g = random.Next(0, 256);
        int b = random.Next(0, 256);
        double a = 0.5 + (random.NextDouble() / 2);
        return $"rgba({r}, {g}, {b}, {a.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)})";
    }

}

public class ListDataFilter() {
    public string Label { get; set;} = null!;
    public int Year { get; set; }
    public int Data { get; set;} 
}