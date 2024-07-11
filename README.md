PDF Generator with DinkToPdf
Este projeto é um exemplo de como gerar um relatório financeiro em formato
PDF usando a biblioteca DinkToPdf em um aplicativo ASP.NET Core.

Pré-requisitos
.NET 5.0 SDK ou superior
Visual Studio ou Visual Studio Code
Bibliotecas NuGet:
DinkToPdf
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.Extensions.Logging.Debug
Microsoft.VisualStudio.Web.CodeGeneration.Design
Estrutura do Projeto
Controllers: Contém o controlador PdfCreatorController que é responsável por gerar o PDF.
Models: Contém o modelo Employee que representa os dados financeiros.
Utility: Contém classes auxiliares como DataStorage para armazenar os dados
e TemplateGenerator para gerar o conteúdo HTML.
assets: Contém arquivos de estilo CSS utilizados na geração do PDF.
