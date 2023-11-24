using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        [BindProperty]
        public OrderModel _orderModel { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InitiateOrder()
        {
            string key = "rzp_test_mdczWtn8wsa2AG";
            string secret = "5w24UBblc07D8PoqocgnsANf";

            Random _random = new Random();
            string TransactionId = _random.Next(0, 10009).ToString();


            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", Convert.ToDecimal(_orderModel.Price)); // this amount should be same as transaction amount
            input.Add("currency", "TRY");
            input.Add("receipt", TransactionId);

            RazorpayClient client = new RazorpayClient(key, secret);
            Razorpay.Api.Order order = client.Order.Create(input);
            ViewBag.OrderId = order["id"].ToString();
            return View("Payment", _orderModel);
        }

        public IActionResult Payment(string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", razorpay_payment_id);
            attributes.Add("razorpay_order_id", razorpay_order_id);
            attributes.Add("razorpay_signature", razorpay_signature);

            Utils.verifyPaymentSignature(attributes);

            OrderModel orderModel = new OrderModel();
            orderModel.TransactionId = razorpay_payment_id;
            orderModel.OrderId = razorpay_order_id;

            return View("PaymentSuccess", orderModel);
        }


    }
}
