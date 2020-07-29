using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using StockMarket.ExcelAPI.Models;

namespace StockMarket.ExcelAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        //[Obsolete]
        //private readonly IHostingEnvironment _hostingEnvironment;

        stockmarketdbContext _db = new stockmarketdbContext();

        [HttpGet]
        [Route("ImportStock")]
        public IList<Stockprice> ImportStock()
        {
            string filePath = @"C:\Users\vnssh\StockMarketProject\Upload\sample_stock_data.xlsx";

            FileInfo file = new FileInfo(filePath);
            string fileName = file.Name;

            using(ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];

                int totalRows = workSheet.Dimension.Rows;

                List<Stockprice> stockprices = new List<Stockprice>();

                for (int i = 2; i <= totalRows; i++)
                {
                    string sexchg = workSheet.Cells[i, 2].Value.ToString().Trim();
                    stockprices.Add(new Stockprice
                    {
                        CompanyCode = int.Parse(workSheet.Cells[i, 1].Value.ToString().Trim()),
                        StockExchangeId = _db.Stockexchange.FirstOrDefault(
                            se => se.StockExchangeName == sexchg).StockExchangeId,
                        CurrentPrice = double.Parse(workSheet.Cells[i, 3].Value.ToString().Trim()),
                        Date = DateTime.Parse(workSheet.Cells[i, 4].Value.ToString().Trim()),
                        Time = TimeSpan.Parse(workSheet.Cells[i, 5].Value.ToString().Trim()),
                    });
                }
                
                _db.Stockprice.AddRange(stockprices);
                _db.SaveChanges();
                
                return stockprices;
            }
        }

        [HttpGet]
        [Route("ExportStock")]
        [Obsolete]
        public string ExportStock()
        {
            //string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = "ExportStockPrices.xlsx";

            string filePath = @"C:\Users\vnssh\StockMarketProject\Download";

            //FileInfo file = new FileInfo(filePath);

            FileInfo file = new FileInfo(Path.Combine(filePath, fileName));

            //return file.ToString();

            
            using(ExcelPackage package = new ExcelPackage(file))
            {
                IList<Stockprice> stockprices = _db.Stockprice.ToList();

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Stockprices");
                int totalRows = stockprices.Count();

                worksheet.Cells[1, 1].Value = "Company Code";
                worksheet.Cells[1, 2].Value = "Stock Exchange";
                worksheet.Cells[1, 3].Value = "Price";
                worksheet.Cells[1, 4].Value = "Date";
                worksheet.Cells[1, 5].Value = "Time";

                int i = 0;
                for (int row = 2; row <= totalRows + 1; row++)
                {
                    worksheet.Cells[row, 1].Value = stockprices[i].CompanyCode;
                    worksheet.Cells[row, 2].Value = stockprices[i].StockExchangeId;
                    worksheet.Cells[row, 3].Value = stockprices[i].CurrentPrice;
                    worksheet.Cells[row, 4].Value = stockprices[i].Date.ToString("dd-MM-yyyy");
                    worksheet.Cells[row, 5].Value = stockprices[i].Time.ToString();
                    i++;
                }

                package.Save();
            }

            return "Stockprices list has been exported succesfully.";
            
        }
    }
}
