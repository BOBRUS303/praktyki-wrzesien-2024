using PuppeteerSharp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ScreenshotMaker
{
    public class ImageRenderer : IDisposable
    {
        private BrowserFetcher _browserFetcher;
        private static readonly string[] options = new[] { "--window-size=3840,2160" };

        public ImageRenderer()
        {
            _browserFetcher = new BrowserFetcher();
        }

        public async Task GetDataFromURL(string htmlUrl)
        {
            try
            {
                // Download the Chromium browser if needed
                await new BrowserFetcher().DownloadAsync();

                // Launch the browser
                using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    Args = options
                });

                // Create a new page
                using var page = await browser.NewPageAsync();

                // Navigate to the URL
                await page.GoToAsync(htmlUrl);

                // Execute JavaScript in the page context to find all images
                var imageElements = await page.EvaluateExpressionAsync<string[]>(@"
                    Array.from(document.querySelectorAll('img')).map(img => 
                        `${img.getAttribute('alt') || 'Brak atrybutu ALT'}, SRC: ${img.getAttribute('src') || 'Brak źródła'}` 
                    );
                ");

                // Wypisz wszystkie znalezione obrazy
                foreach (var image in imageElements)
                {
                    Console.WriteLine(image);
                }



                Console.WriteLine("=======================================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            _browserFetcher = null;
        }

        public async Task CreateScreen(string url)
        {
            // Download the Chromium browser if needed
            await new BrowserFetcher().DownloadAsync();

            // Launch the browser
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                DefaultViewport = new ViewPortOptions
                {
                    Width = 2160,
                    Height = 3840,
                    IsLandscape = false,
                },
                Timeout = 3000,
                Args = options,
                AcceptInsecureCerts = true,
                EnqueueAsyncMessages = true
            });

            // Create a new page
            using var page = await browser.NewPageAsync();

            // Navigate to the URL
            var response = await page.GoToAsync(url);

            // Set the viewport size if needed (optional)
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 2160,
                Height = 3840
            });

            // Take the screenshot
            await page.ScreenshotAsync(Path.Combine(Directory.GetCurrentDirectory(), "test_image_from_url_2.png"));

            // Close the browser
            await browser.CloseAsync();

            Console.WriteLine("Screenshot saved!");
        }
    }
}
