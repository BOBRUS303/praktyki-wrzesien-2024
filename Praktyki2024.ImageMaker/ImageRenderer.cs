using PuppeteerSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScreenshotMaker
{
    public class ImageRenderer : IDisposable
    {
        private BrowserFetcher _browserFetcher;
        private static readonly string[] options = new[] { "--window-size=3840,2160" };
        private static readonly HttpClient _httpClient = new HttpClient();

        public ImageRenderer()
        {
            _browserFetcher = new BrowserFetcher();
        }

        public async Task GetDataFromURL(string htmlUrl)
        {
            try
            {

                await new BrowserFetcher().DownloadAsync();


                using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    Args = options
                });


                using var page = await browser.NewPageAsync();


                await page.GoToAsync(htmlUrl);


                var imageElements = await page.EvaluateExpressionAsync<string[]>(@"
                    Array.from(document.querySelectorAll('img')).map(img => img.getAttribute('src') || 'Brak źródła')
                ");


                foreach (var imageUrl in imageElements)
                {
                    Console.WriteLine($"Found image: {imageUrl}");

                    if (!string.IsNullOrEmpty(imageUrl) && Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
                    {

                        await DownloadAndSaveImageAsync(imageUrl);
                    }
                }

                Console.WriteLine("=======================================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task DownloadAndSaveImageAsync(string imageUrl)
        {
            try
            {
                var imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);


                var imageFileName = Path.GetFileName(new Uri(imageUrl).LocalPath);
                var localFilePath = Path.Combine(Directory.GetCurrentDirectory(), imageFileName);


                await File.WriteAllBytesAsync(localFilePath, imageBytes);

                Console.WriteLine($"Image saved locally: {localFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to download or save image {imageUrl}: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _browserFetcher = null;
        }

        public async Task CreateScreen(string url)
        {

            await new BrowserFetcher().DownloadAsync();


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


            using var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(url);

            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 2160,
                Height = 3840
            });


            await page.ScreenshotAsync(Path.Combine(Directory.GetCurrentDirectory(), "test_image_from_url_2.png"));

            await browser.CloseAsync();

            Console.WriteLine("Screenshot saved!");
        }
    }
}