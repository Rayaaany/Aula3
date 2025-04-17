using Aula3.Models;
using Microsoft.Data.SqlClient;

string connectionString = "Server=THINKCENTRE\\;Database=SistemaPedidos;Trusted_Connection=True;Column Encryption Setting=enabled;Encrypt=False;";

List<Cliente> clientes = new List<Cliente>();

using SqlConnection connection = new SqlConnection(connectionString);

try
{
    connection.Open();
    Console.WriteLine("Conexão aberta com sucesso!");

    string sql = "SELECT id, Nome, Email FROM Clientes";

    using SqlCommand command = new SqlCommand(sql, connection);
    using SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        Cliente cliente = new Cliente()
        {
            id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Email = reader.GetString(2)
        };
        clientes.Add(cliente);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Erro ao acessar o banco de dados" + ex.Message);
}
finally
{
    connection.Close();
}
foreach (Cliente cliente in clientes)
{
    Console.WriteLine($"Código Identificador do Cliente: {cliente.id}, Nome {cliente.Nome}, E-mail: {cliente.Email}.");
}
Console.ReadKey();