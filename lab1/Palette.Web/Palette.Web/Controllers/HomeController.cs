using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Palette.Lib.Mappers;
using Palette.Lib.Models;
using Palette.Web.Models;
using System;

namespace Palette.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var rgb = new RgbColor()
            {
                Red = 252, 
                Green = 3, 
                Blue = 173
            };

            return View(new Colors()
            {
                RGB = rgb,
                CMYK = rgb.ToCmyk(),
                HSV = rgb.ToHsv(),
                Hex = rgb.ToHexString()
            });
        }

        [HttpPost]
        public IActionResult PostHex(Colors colors)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", colors);
            }

            var rgb = colors.Hex.ToRgb();

            return View("Index", new Colors()
            {
                RGB = rgb,
                CMYK = rgb.ToCmyk(),
                HSV = rgb.ToHsv(),
                Hex = colors.Hex
            });
        }

        [HttpPost]
        public IActionResult PostRgb(Colors colors)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", colors);
            }

            return View("Index", new Colors()
            {
                RGB = colors.RGB,
                CMYK = colors.RGB.ToCmyk(),
                HSV = colors.RGB.ToHsv(),
                Hex = colors.RGB.ToHexString()
            });
        }

        [HttpPost]
        public IActionResult PostCmyk(Colors colors)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", colors);
            }

            var rgb = colors.CMYK.ToRgb();

            return View("Index", new Colors()
            {
                RGB = rgb,
                CMYK = colors.CMYK,
                HSV = colors.CMYK.ToHsv(),
                Hex = rgb.ToHexString()
            });
        }

        [HttpPost]
        public IActionResult PostHsv(Colors colors)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", colors);
            }

            var rgb = colors.HSV.ToRgb();

            return View("Index", new Colors()
            {
                RGB = rgb,
                CMYK = colors.HSV.ToCmyk(),
                HSV = colors.HSV,
                Hex = rgb.ToHexString()
            });
        }
    }
}
