
using MCS_oneday_intern.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace MCS_oneday_intern.Controllers
{
    public class ProductDetailController : Controller
    {
        /// <summary>
        /// 產品頁
        /// </summary>
        /// <param name="ProductNumber">產品id</param>
        /// <returns>產品頁cshtml</returns>
        public ActionResult Index(int ProductNumber = 0)
        {
            // 使用streamReader 讀取存貨json檔
            var inventoryPath = "__/__.json"; // [TODO]: 取代__帶入正確值

            // using語句，定義一個範圍，在範圍結束時處理物件
            using (StreamReader sr = new StreamReader(__)) // [TODO]: 取代__帶入正確值
            {
                // streamReader將json檔讀成string,再將字串轉成json格式
                var __ = JsonConvert.DeserializeObject<List<__>>(sr.ReadToEnd()); // [TODO]: 取代__帶入正確值

                // 將結果放至ViewBag, 就可以在View中使用此物件
                ViewBag.Product = __; // [TODO]: 取代__帶入正確值
            }

            // [TODO] 嘗試使用streamReader 讀取評價(reviews) json檔

            // 回傳View物件(ProductDetail/index.cshtml)
            return View();
        }
        

        /// <summary>
        /// 購買產品action
        /// </summary>
        /// <param name="productId">產品id</param>
        /// <param name="quantity">購買數量</param>
        /// <returns>回傳ok 及 扣除數量</returns>
        public ActionResult Buy(int productId, int quantity)
        {
            // 使用streamReader 讀取存貨json檔
            var path = "__"; // [TODO]: 取代__帶入正確值
            var json = string.Empty;

            // using語句，定義一個範圍，在範圍結束時處理物件
            using (StreamReader sr = new StreamReader(__)) // [TODO]: 取代__帶入正確值
            {
                // streamReader將json檔讀成string,再將字串轉成json格式
                var products = JsonConvert.DeserializeObject<List<__>>(sr.ReadToEnd()); // [TODO]: 取代__帶入正確值
                var product = __; // [TODO]: 取代__帶入正確值，透過Id當作Index找出Array裡面正確的Product進行修改

                // 存貨數量扣除購買數量
                product.Inventory -= __; // [TODO]: 取代__帶入正確值

                // 將改寫結果轉換成formatted的json string
                json = JsonConvert.SerializeObject(products.ToArray(),Formatting.Indented);
            }

            // 將改寫結果寫回json檔中
            System.IO.File.WriteAllText(path, json);
            return Ok(new{ message="ok", deductionQuantity=quantity});
        }

        /// <summary>
        /// 購買產品action
        /// </summary>
        /// <param name="reviewModel">評價Model</param>
        /// <returns>回傳ok</returns>
        public ActionResult SubmitReview(Review reviewModel)
        {
            // 使用streamReader 讀取評價json檔
            var path = "JsonData/review.json";
            var json = string.Empty;

            // using語句，定義一個範圍，在範圍結束時處理物件
            using (__) // [TODO]: 取代__帶入正確值
            {
                // streamReader將json檔讀成string,再將字串轉成json格式
                var reviews = __; // [TODO]: 取代__帶入正確值

                // 新增的評價Id就是目前的評價的數量
                reviewModel.ReviewId = reviews.Count;

                // 評價時間帶入現在時間
                reviewModel.ReviewTime = DateTime.Now;

                // 將評價加在原本的評價list後面
                reviews.Add(__); // [TODO]: 取代__帶入正確值

                // 將改寫結果轉換成formatted的json string
                json = JsonConvert.SerializeObject(reviews.ToArray(),Formatting.Indented);
            }

            // 將改寫結果寫回json檔中
            System.IO.File.WriteAllText(path, json);
            return Ok(new{ message="ok"});
        }
    }
}
