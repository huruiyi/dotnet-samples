namespace ConApp.Samples
{
    public class PdfDemo
    {
        public static void Demo()
        {
            PdfConvert.ConvertHtmlToPdf(new PdfDocument
            {
                Url = @"layout.html"
            }, new PdfOutput
            {
                OutputFilePath = "layout.pdf"
            });
        }
    }
}