using DinkToPdf; // Bibliotecas necessárias para converter HTML em PDF.
using DinkToPdf.Contracts; // Bibliotecas necessárias para converter HTML em PDF.
using Microsoft.AspNetCore.Mvc; // Biblioteca que fornece funcionalidades para construir APIs web com ASP.NET Core.
using PDF_Generator.Utility; // Chama uma classe TemplateGenerator usada para gerar o conteúdo HTML.
using System;
using System.IO; // Biblioteca do .NET para manipula arquivos e diretórios.

namespace PDF_Generator.Controllers
{
    [Route("api/pdfcreator")] // Define a rota base
    [ApiController] // Indica que este é um controlador de API.
    public class PdfCreatorController : ControllerBase
    {
        // Declara uma dependência de IConverter, usada para converter HTML em PDF.
        private readonly IConverter _converter;

        // Construtor que recebe a dependência IConverter via injeção de dependência e a atribui ao campo _converter.
        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet] // Indica que este método responde a requisições HTTP GET.
        public IActionResult CreatePDF()
        {
            try
            {
                // Define o caminho completo do arquivo PDF no diretório desejado
                var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Employee_Report.pdf");

                // Log do caminho de saída para verificar se está correto
                Console.WriteLine($"Output Path: {outputPath}");

                // Define configurações globais para o documento PDF, como modo de cor, orientação,
                // tamanho do papel, margens, título do documento e o caminho de saída.
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = outputPath // Salva o PDF no diretório especificado
                };

                // Define configurações específicas para o conteúdo do PDF, incluindo o conteúdo HTML,
                // codificação, folha de estilos, configurações de cabeçalho e rodapé.
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = TemplateGenerator.GetHTMLString(),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "página [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Folha Finaceira" }
                };

                // Cria um novo documento PDF com as configurações definidas.
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                // Converte o documento HTML para PDF usando o conversor.
                _converter.Convert(pdf);

                // Retorna uma resposta HTTP 200 OK com uma mensagem de sucesso.
                return Ok("Successfully created PDF document.");
            }
            catch (Exception ex)
            {
                // Captura e registra qualquer exceção que ocorra
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
