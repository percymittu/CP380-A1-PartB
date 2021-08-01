using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using RatingAdjustment.Services;
using BreadmakerReport.Models;

namespace BreadmakerReport
{
    class Program
    {
        static string dbfile = @".\data\breadmakers.db";
        static RatingAdjustmentService ratingAdjustmentService = new RatingAdjustmentService();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bread World");
            var BreadmakerDb = new BreadMakerSqliteContext(dbfile);
            
            //Fetch the data into List
            var BMList = BreadmakerDb.Breadmakers
                .Select(breadmaker => new {
                            ID = breadmaker.BreadmakerId,
                            CalReviews = breadmaker.Reviews.Count,
                            CalAverage = breadmaker.Reviews.Average(x => x.stars),
                            CalAdjust = ratingAdjustmentService.Adjust(breadmaker.Reviews.Average(x => x.stars),breadmaker.Reviews.Count),
                            Description = breadmaker.title
                        })
                .AsEnumerable()
                .OrderByDescending(x => x.CalAdjust)
                .ToList();

            //Display the list data
            Console.WriteLine("[#]  Reviews Average  Adjust    Description");
            for (var j = 0; j < 3; j++)
            {
                var i = BMList[j];
                Console.WriteLine($"[{j+1}] {i.CalReviews,8} {i.CalAverage,-2:F2} {i.CalAdjust,8:F2}      {i.Description}");
            }
            Console.ReadLine();
        }
    }
}
