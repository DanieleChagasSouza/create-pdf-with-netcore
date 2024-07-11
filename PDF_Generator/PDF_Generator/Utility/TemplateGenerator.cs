using System.Text;

namespace PDF_Generator.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var employees = DataStorage.GetAllEmployess();

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                                <style>
                                    .header {
                                        text-align: center;
                                        color: green;
                                        padding-bottom: 35px;
                                    }
                                    table {
                                        width: 80%;
                                        border-collapse: collapse;
                                    }
                                    td, th {
                                        border: 1px solid gray;
                                        padding: 30px;
                                        font-size: 22px;
                                        text-align: center;
                                    }
                                    table th {
                                        background-color: green;
                                        color: white;
                                    }
                                </style>
                            </head>
                            <body>
                                <div class='header'><h1>Nome da Empresa: New Show Tech Brazil  =>  Período Financeiro: Janeiro 2024</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Data</th>
                                        <th>Descrição</th>
                                        <th>Categoria</th>
                                        <th>Valor</th>
                                        <th>Moeda</th>
                                    </tr>");

            foreach (var emp in employees)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", emp.Data, emp.Descricao, emp.Categoria, emp.Valor, emp.Moeda);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
