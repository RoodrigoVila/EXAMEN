using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(local);Initial Catalog=LibreriaLosLectores;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Insertar un nuevo cliente
            string insertCliente = "INSERT INTO Clientes (Nombre, Genero) VALUES (@Nombre, @Genero)";
            using (SqlCommand command = new SqlCommand(insertCliente, connection))
            {
                command.Parameters.AddWithValue("@Nombre", "Juan");
                command.Parameters.AddWithValue("@Genero", "Masculino");

                command.ExecuteNonQuery();
            }

            // Registrar una venta
            string registrarVenta = "INSERT INTO Ventas (ClienteID, LibroID, Cantidad, ImporteBruto, Descuento) VALUES (@ClienteID, @LibroID, @Cantidad, @ImporteBruto, @Descuento)";
            using (SqlCommand command = new SqlCommand(registrarVenta, connection))
            {
                int ClienteID = 1;
                int LibroID = 1;
                int Cantidad = 3;

                // Obtener el precio del libro
                string getPrecio = "SELECT Precio FROM Libros WHERE ID = @LibroID";
                SqlCommand getPrecioCommand = new SqlCommand(getPrecio, connection);
                getPrecioCommand.Parameters.AddWithValue("@LibroID", LibroID);
                decimal Precio = (decimal)getPrecioCommand.ExecuteScalar();

                // Calcular el importe bruto
                decimal ImporteBruto = Cantidad * Precio;

                // Calcular el descuento
                decimal Descuento = 0;
                if (Cantidad >= 3 && Cantidad <= 6)
                {
                    Descuento = ImporteBruto * 0.06m; // 6% de descuento
                }
                else if (Cantidad > 6)
                {
                    Descuento = ImporteBruto * 0.08m; // 8% de descuento
                }

                command.Parameters.AddWithValue("@ClienteID", ClienteID);
                command.Parameters.AddWithValue("@LibroID", LibroID);
                command.Parameters.AddWithValue("@Cantidad", Cantidad);
                command.Parameters.AddWithValue("@ImporteBruto", ImporteBruto);
                command.Parameters.AddWithValue("@Descuento", Descuento);

                command.ExecuteNonQuery();
            }
        }
    }
}


