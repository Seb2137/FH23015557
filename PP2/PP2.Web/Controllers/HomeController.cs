using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PP2.Web.Models;

namespace PP2.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new OperacionBinaria());
    }

    [HttpPost]
        public IActionResult Index(OperacionBinaria model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.aBinary = model.a.PadLeft(8, '0');
            model.bBinary = model.b.PadLeft(8, '0');

            model.andResult = OpAND(model.aBinary, model.bBinary);
            model.orResult = OpOR(model.aBinary, model.bBinary);
            model.xorResult = OpXOR(model.aBinary, model.bBinary);

            int aDecimal = Convert.ToInt32(model.aBinary, 2);
            int bDecimal = Convert.ToInt32(model.bBinary, 2);
            
            int sum = aDecimal + bDecimal;
            int multiply = aDecimal * bDecimal;

            model.sumResult = Convert.ToString(sum, 2);
            model.multiplyResult = Convert.ToString(multiply, 2);

            return View(model);
        }

        private string OpAND(string a, string b)
        {
            char[] result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (a[i] == '1' && b[i] == '1') ? '1' : '0';
            }
            return new string(result).TrimStart('0') == "" ? "0" : new string(result).TrimStart('0');
        }

        private string OpOR(string a, string b)
        {
            char[] result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (a[i] == '1' || b[i] == '1') ? '1' : '0';
            }
            return new string(result).TrimStart('0') == "" ? "0" : new string(result).TrimStart('0');
        }

        private string OpXOR(string a, string b)
        {
            char[] result = new char[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (a[i] != b[i]) ? '1' : '0';
            }
            return new string(result).TrimStart('0') == "" ? "0" : new string(result).TrimStart('0');
        }
    }

