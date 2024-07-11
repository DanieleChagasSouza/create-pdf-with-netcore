using PDF_Generator.Models;
using System.Collections.Generic;

namespace PDF_Generator.Utility
{
    public static class DataStorage
    {
        public static List<Employee> GetAllEmployess() =>
            new List<Employee>
            {
                new Employee {  Data = "02/01/2024", Descricao = "Pagamento de Salários", Categoria = "Salários", Valor = 3000.00, Moeda = "BRL" },
                new Employee { Data = "10/01/2024", Descricao = "Campanha de Marketing", Categoria = "Marketing", Valor = 1200.00, Moeda = "BRL" },
                new Employee { Data = "15/01/2024", Descricao = "Pagamento de Faturas", Categoria = "Pagamentos", Valor = 2000.00 , Moeda = "USD" },
                new Employee { Data = "30/01/2024", Descricao = "Administrativo", Categoria = "Administrativos", Valor = 1600.00, Moeda = "USD" },
                new Employee { Data = "01/01/2024", Descricao = "Recursos Humanos", Categoria = "Gestão e Gente", Valor = 3500.00, Moeda = "BRL" },
                new Employee { Data = "10/01/2024", Descricao = "Investimento", Categoria = "Investimentos", Valor = 5000.00, Moeda = "BRL" },
                new Employee { Data = "11/01/2024", Descricao = "venda de Produto", Categoria = "Vendas", Valor = 1500.00, Moeda = "BRL" }
            };
    }
}
