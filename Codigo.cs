using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string connectionString = "Data Source=(local);Initial Catalog=LibreriaLosLectores;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Insertar un nuevo cliente
            string insertCliente = "INSERT INTO Clientes (Nombre, Genero) VALUES (@Nombre, @Genero)";
            using (SqlCommand command = new SqlCommand(insertCliente, connection))
            {
                command.Parameters.AddWithValue("@Nombre", textBox1.Text);
                command.Parameters.AddWithValue("@Genero", textBox2.Text);

                command.ExecuteNonQuery();
            }

            // Registrar una venta
            string registrarVenta = "INSERT INTO Ventas (ClienteID, LibroID, Cantidad, ImporteBruto, Descuento) VALUES (@ClienteID, @LibroID, @Cantidad, @ImporteBruto, @Descuento)";
            using (SqlCommand command = new SqlCommand(registrarVenta, connection))
            {
                command.Parameters.AddWithValue("@ClienteID", 1);
                command.Parameters.AddWithValue("@LibroID", 1);
                command.Parameters.AddWithValue("@Cantidad", 3);
                command.Parameters.AddWithValue("@ImporteBruto", 270); // 3 libros de ficción a S/. 90.00 cada uno
                command.Parameters.AddWithValue("@Descuento", 16.2); // 6% de descuento por comprar 3 libros de ficción

                command.ExecuteNonQuery();
            }
        }
    }
}
