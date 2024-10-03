using System.Globalization;
using ExemploExplorando.Models;
using ExemplosExplorando.Models;
using Newtonsoft.Json;

//Aula: Propriedades, Métodos e Construtores
//Concatenação e Interpolação de Strings
Pessoa p1 = new Pessoa(nome: "ana", sobrenome: "barreto");
Pessoa p2 = new Pessoa("laura", "bandeira");

Curso ingles = new Curso();
ingles.Nome = "Curso de Inglês - Nível Intermediário";
ingles.Alunos = new List<Pessoa>();
ingles.AdicionarAluno(p1);
ingles.AdicionarAluno(p2);
ingles.ListarAlunos();

//Aula: Manipulando Valores com C#
//Formatando valores monetários - moeda corrente do sistema
decimal valorMonetarioBR = 81232.49301M;
Console.WriteLine($"Brasil: {valorMonetarioBR:C}");

//Formatando valores monetários - moeda diferente (mas isso afeta o programa todo)
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
decimal valorMonetarioEspanha = 81232.49301M;
Console.WriteLine($"Espanha: {valorMonetarioEspanha:C}");

//Formatando valores monetários - moeda diferente (sem afetar o programa todo)
decimal valorMonetarioUSA = 81232.49301M;
Console.WriteLine("EUA: " + valorMonetarioUSA.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));

//Formatando o tipo DateTime 
DateTime dataAtual = DateTime.Now;
Console.WriteLine(dataAtual.ToString("dd/MM/yyyy"));

//Convertendo uma data que não está no padrão DateTime
string dataString = "2022-12-17 18:00";

bool sucesso = DateTime.TryParseExact(dataString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataFormatada);

if (sucesso)
    Console.WriteLine($"Conversão feita com sucesso! \n Data: {dataFormatada}");
else
    Console.WriteLine($"Não foi possível fazer a conversão. Data {dataString} inválida.");

//Leitura das linhas de um arquivo txt - Caminho feliz
string[] linhas = File.ReadAllLines("Arquivos/arquivoLeitura.txt");
foreach (string linha in linhas)
{
    Console.WriteLine(linha);
}

//Aula: Exceções e Coleções com C#
//Exemplo de tentativa de leitura do arquivo com nome errado
//Tratando exceções específicas e genéricas com Try/Catch
try
{
    string[] linhasComErro = File.ReadAllLines("Arqauivos/arquivoLeitura.txt");
    //Para verificar quais exceções podem surgir, passar o mouse em cima do método
    foreach (string linha in linhasComErro)
    {
        Console.WriteLine(linha);
    }
}
catch(FileNotFoundException ex) //classe específica
{
    Console.WriteLine($"Ococrreu um erro na leitura do arquivo. Arquivo não encontrado. {ex.Message}");    
}
catch(DirectoryNotFoundException ex) //classe específica
{
    Console.WriteLine($"Ococrreu um erro na leitura do arquivo. Caminho da pasta não encontrado. {ex.Message}");    
}
catch(Exception ex) //classe mais genérica de exceção, da qual outras classes de exceções específicas herda
{
    Console.WriteLine($"Ocorreu uma exceção genérica. {ex.Message}");    
}
finally
{
    //Bloco de código que será executado independente de ter caído em algum catch ou não
    Console.WriteLine("Chegou até aqui!");  
}

//Uso de throw
new ExemploExcecao().Metodo1();

//Queue - filas
Queue<int> filaInteiros = new Queue<int>();
filaInteiros.Enqueue(2);
filaInteiros.Enqueue(4);
filaInteiros.Enqueue(6);
filaInteiros.Enqueue(8);
Console.WriteLine("Itens da fila:");
foreach (int item in filaInteiros)
{
    Console.WriteLine(item);
}

Console.WriteLine($"Removendo o elemento: {filaInteiros.Dequeue()}"); //'Dequeue' remove sempre o primeiro elemento que entrou da fila, por isso não precisa de passar parâmetro
Console.WriteLine("Itens da fila após remoção do primeiro item:");
foreach (int item in filaInteiros)
{
    Console.WriteLine(item);
}

//Stack - pilhas
Stack<int> pilhaInteiros = new Stack<int>();
pilhaInteiros.Push(1);
pilhaInteiros.Push(2);
pilhaInteiros.Push(3);
pilhaInteiros.Push(4);
pilhaInteiros.Push(5);
pilhaInteiros.Push(6);

Console.WriteLine("Itens da pilha:");
foreach (int item in pilhaInteiros)
{
    Console.WriteLine(item); //aqui os números aparecem na ordem contrária ao que foi adicionado
}

Console.WriteLine($"Removendo o elemento do topo: {pilhaInteiros.Pop()}");
Console.WriteLine("Itens da pilha após retirada do último item:");
foreach (int item in pilhaInteiros)
{
    Console.WriteLine(item); //aqui os números aparecem na ordem contrária ao que foi adicionado
}

//Dictionary
Dictionary<string, string> estados = new Dictionary<string, string>
{
    { "AC", "Acre" },
    { "AL", "Alagoas" },
    { "AP", "Amapá" },
    { "AM", "Amazonas" },
    { "BA", "Bahia" },
    { "CE", "Ceará" },
    { "DF", "Distrito Federal" },
    { "ES", "Espírito Santo" },
    { "GO", "Goiás" },
    { "MA", "Maranhão" },
    { "MT", "Mato Grosso" },
    { "MS", "Mato Grosso do Sul" },
    { "MG", "Minas Gerais" },
    { "PA", "Pará" },
    { "PB", "Paraíba" },
    { "PR", "Paraná" },
    { "PE", "Pernambuco" },
    { "PI", "Piauí" },
    { "RJ", "Rio de Janeiro" },
    { "RN", "Rio Grande do Norte" },
    { "RS", "Rio Grande do Sul" },
    { "RO", "Rondônia" },
    { "RR", "Roraima" },
    { "SC", "Santa Catarina" },
    { "SP", "São Paulo" },
    { "SE", "Sergipe" },
    { "TO", "Tocantins" }
};

Console.WriteLine("Estados do Brasil:");
foreach (KeyValuePair<string, string> item in estados)
{
    Console.WriteLine($"Sigla: {item.Key}, Nome do estado: {item.Value}");
}

estados.Remove("BA");
estados["MG"] = "Emigê";

Console.WriteLine("Estados do Brasil sem a Bahia e com MG alterado:");
var contador = 1;
foreach (KeyValuePair<string, string> item in estados)
{
    Console.WriteLine($"{contador} - Sigla: {item.Key}, Nome do estado: {item.Value}");
    contador++;
}

string chave = "S2P";
Console.WriteLine($"Verificando o elemento: {chave}");

if (estados.ContainsKey(chave))
{
    Console.WriteLine($"Valor existente: {chave}");
}
else
{
    Console.WriteLine($"Valor {chave} não existe no dicionário.");
}

//Aula: Tuplas, Operador Ternário e Desconstrução de um Objeto com C#
//Tuplas - 3 formas de declarar
(int, string, string) tuplaIdNomeSobrenome = (1, "Maria", "Chiquinha"); //maneira mais recomendada de declarar tupla
Console.WriteLine($"{tuplaIdNomeSobrenome.Item2} {tuplaIdNomeSobrenome.Item3}");

ValueTuple<int, string, string, decimal> outroExemploTupla = (1, "Ana", "Barreto", 1.54M);
var id = outroExemploTupla.Item1;
Console.WriteLine(id);

var outroExemploTuplaCriar = Tuple.Create(1, "Ana", "Barreto", 1.54M);
var nome = outroExemploTuplaCriar.Item2;
Console.WriteLine(nome);

LeituraArquivo leituraArquivo = new LeituraArquivo();
var (sucessoLeituraArquivo, linhasArquivo, qtdLinhas) = leituraArquivo.LerArquivo("Arquivos/arquivoLeitura.txt");

if (sucessoLeituraArquivo)
{
    Console.WriteLine($"Quantidade de linhas do arquivo: {qtdLinhas}");
    foreach (string linha in linhasArquivo)
    {
        Console.WriteLine(linha);
    }
}
else
{
    Console.WriteLine("Não foi possível ler o arquivo.");
}

//If ternário
var parOuImpar = 20;
Console.WriteLine(parOuImpar % 2 == 0 ? "Par" :"Ímpar");

//Desconstrução
Pessoa testeDesconstrucao = new Pessoa("Aninha", "Barreto");
(string nomePessoa, string sobrenomePessoa) = testeDesconstrucao;
Console.WriteLine($"{nomePessoa} {sobrenomePessoa}");

//Aula: Nuget, Serializar e Atributos no C#
//Serialização de objeto utilizando pacote Newtonsoft.Json
Venda v1 = new Venda(1, "Material de Escritório", 25.00M);
string serializado = JsonConvert.SerializeObject(v1, Formatting.Indented);
Console.WriteLine(serializado);
File.WriteAllText("Arquivos/vendas.json", serializado);

//Serialização de uma lista utilizando pacote Newtonsoft.Json
List<Venda> listaVendas = new List<Venda>();
DateTime dataDeHoje = DateTime.Now;

Venda v2 = new Venda(2, "Licença de Software", 1000M, dataDeHoje, null);
Venda v3 = new Venda(3, "Café e chá", 200M, dataDeHoje, null);

listaVendas.Add(v2);
listaVendas.Add(v3);

string listaSerializada = JsonConvert.SerializeObject(listaVendas, Formatting.Indented);
Console.WriteLine(listaSerializada);
File.WriteAllText("Arquivos/listaVendas.json", listaSerializada);

//Desserialização de um arquivo json
string conteudoArquivo = File.ReadAllText("Arquivos/listaVendasImportadas.json");
List<Venda> listaVendasImportadas = JsonConvert.DeserializeObject<List<Venda>>(conteudoArquivo);

foreach (Venda venda in listaVendasImportadas)
{
    Console.WriteLine($"Id: {venda.Id}, Produto: {venda.Produto}, " +
                      $"Preço: {venda.Preco:C}, Data: {venda.Data.ToShortDateString()}" +
                      (venda.Desconto.HasValue ? $", Desconto de: {venda.Desconto:C}" : ""));
}

//Tipos especiais no C#
//Nullable
bool? desejaReceberEmail = null;

if(desejaReceberEmail.HasValue && desejaReceberEmail.Value)
//as props HasValue e Value só estão disponíveis devido a variável ser nullable
{
    Console.WriteLine("O usuário optou por receber e-mail.");
}
else
{
    Console.WriteLine("O usuário não respondeu ou optou por não receber e-mail.");
}

//Anônimos
var tipoAnonimo = new { Nome = "Ana", Sobrenome = "Barreto", Altura = 1.54M };
Console.WriteLine("Nome: " + tipoAnonimo.Nome);
Console.WriteLine("Sobrenome: " + tipoAnonimo.Sobrenome);
Console.WriteLine("Altura: " + tipoAnonimo.Altura);

//Anônimos como retorno de coleção
string conteudoArquivoExemploAnonimo = File.ReadAllText("Arquivos/listaVendasImportadasExemploAnonimo.json");
List<Venda> listaVendasImportadasExemploAnonimo = JsonConvert.DeserializeObject<List<Venda>>(conteudoArquivoExemploAnonimo);

var listaAnonimo = listaVendasImportadasExemploAnonimo.Select(x => new { x.Produto, x.Preco });

foreach (var venda in listaAnonimo)
{
    Console.WriteLine($"Produto: {venda.Produto}, Preço: {venda.Preco:C}");
}

//Dynamic
dynamic variavelDinamica = 4; //assume o tipo de acordo com o valor que é atribuído
Console.WriteLine($"Tipo da variável: {variavelDinamica.GetType()}, Valor: {variavelDinamica}");
variavelDinamica = true;
Console.WriteLine($"Tipo da variável: {variavelDinamica.GetType()}, Valor: {variavelDinamica}");
variavelDinamica = "Ana";
Console.WriteLine($"Tipo da variável: {variavelDinamica.GetType()}, Valor: {variavelDinamica}");

//Classes Genéricas
MeuArray<int> arrayInteiros = new MeuArray<int>();
arrayInteiros.AdicionarElementoArray(30);
Console.WriteLine(arrayInteiros[0]);

MeuArray<string> arrayString = new MeuArray<string>();
arrayString.AdicionarElementoArray("Testando classe genérica");
Console.WriteLine(arrayString[0]);

//Métodos de extensão
var numeroParOuImpar = 27;
bool ehPar = false;
ehPar = numeroParOuImpar.EhPar();
Console.WriteLine(ehPar ? "Par" :"Ímpar");