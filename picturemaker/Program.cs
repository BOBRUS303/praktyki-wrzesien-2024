using ScreenshotMaker;

using var rendered = new ImageRenderer();

Console.WriteLine("Czekam na link: ");
var htmlContent = Console.ReadLine();

await rendered.GetDataFromURL(htmlContent);
await rendered.CreateScreen(htmlContent);


Console.WriteLine("Wait for me: ");
Console.Read();