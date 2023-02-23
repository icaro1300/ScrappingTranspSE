using HtmlAgilityPack;
using System;

namespace ScrappingTranspSE
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = @"https://www.transparencia.se.gov.br/Pessoal/VencimentoCargo.xhtml?codigo=4&ano=2022&mes=11";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var tableComissionados = htmlDoc.GetElementbyId("frmPrincipal:Tabela1_data");
            var linhas = tableComissionados.SelectNodes(".//tr");
            int totalPessoas = 0;
            foreach(var item in linhas)
            {
                var colunas = item.SelectNodes(".//td");
                totalPessoas = totalPessoas + Convert.ToInt32(colunas[2].InnerText);
            }
            Console.WriteLine("O total preenchido é: {0} ", totalPessoas);
        }
    }
}
