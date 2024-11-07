using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Examen_YYGP_JRCC
{
    public partial class Form1 : Form
    {
        string SqlConnection = "server=localhost; port=3306; Database=Examenpractico2; UID=root; Pwd=5002y;";

        delegate void SetTextDelegate(String Value);
        public SerialPort ArduinoPort { get; }

        public Form1()
        {
            InitializeComponent();
            tbNombre.TextChanged += validarUsuario;
            tbFecha.Leave += validarFecha;
            
            // Inicializar el puerto serial Arduino
            ArduinoPort = new SerialPort();
            ArduinoPort.PortName = "COM5";  // Configurar el puerto del Arduino
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.DataBits = 8;
            ArduinoPort.ReadTimeout = 1000;
            ArduinoPort.WriteTimeout = 1000;
            ArduinoPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            this.btnEncenderC.Click += btnEncenderC_Click;
            
            ArduinoPort.Open(); // Abre el puerto serial
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (ArduinoPort.IsOpen)
            {
                try
                {
                    string data = ArduinoPort.ReadLine(); // Leer la línea de datos recibidos
                    mostrarDatos(data);
                    //Invoke(new Action(() => mostrarDatos(data))); // Llama a mostrarDatos 
                }
                catch (TimeoutException) 
                {
                    MessageBox.Show("Tiempo de espera en la lectura de datos del Arduino.");
                }
            }
        }

        private void mostrarDatos(string data)
        {
            string temperatura = data;
            Temperatura.Text = $"Temperatura: {temperatura} °C";  
            insertarTemperatura(temperatura, DateTime.Now);
        }

        private void insertarUsuario(string nombre, DateTime fecha)
        {
            using (MySqlConnection conection = new MySqlConnection(SqlConnection))
            {
                conection.Open();

                string insertQuery = "INSERT INTO Usuarios (usuario, fecha) VALUES (@usuario, @fecha)";
                using (MySqlCommand command = new MySqlCommand(insertQuery, conection))
                {
                    command.Parameters.AddWithValue("@usuario", nombre);
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void insertarTemperatura(string temperatura, DateTime fecha)
        {
            using (MySqlConnection conection = new MySqlConnection(SqlConnection))
            {
                conection.Open();

                string insertQuery = "INSERT INTO Registro_Temperatura (temperatura, fecha) VALUES (@temperatura, @fecha)";
                using (MySqlCommand command = new MySqlCommand(insertQuery, conection))
                {
                    
                    if (float.TryParse(temperatura, out float tempValue))
                    {
                        command.Parameters.AddWithValue("@temperatura", tempValue);
                        command.Parameters.AddWithValue("@fecha", fecha);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        // Manejo de errores si la conversión falla
                        MessageBox.Show("Error: No se pudo convertir la temperatura a un valor numérico.");
                    }
                }
            }
        }

        /*  private void insertarTemperatura(string temperatura, DateTime fecha)
          {
              using (MySqlConnection conection = new MySqlConnection(SqlConnection))
              {
                  conection.Open();

                  string insertQuery = "INSERT INTO Registro_Temperatura (temperatura, fecha) VALUES (@temperatura, @fecha)";
                  using (MySqlCommand command = new MySqlCommand(insertQuery, conection))
                  {
                      command.Parameters.AddWithValue("@temperatura", temperatura);
                      command.Parameters.AddWithValue("@fecha", fecha); 
                      command.ExecuteNonQuery();
                  }
              }
          }*/

        private bool esTexto(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private void validarUsuario(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!esTexto(textbox.Text))
            {
                MessageBox.Show("Error en el usuario, solo se permiten letras.", "Error");
                textbox.Clear();
            }
        }

        private void validarFecha(object sender, EventArgs e)
        {
            if (DateTime.TryParse(tbFecha.Text, out DateTime fecha))
            {
                // No hacer nada si la fecha es válida
            }
            else
            {
                MessageBox.Show("Formato de fecha no válido. Use un formato válido (dd/mm/aaaa).", "Error");
                tbFecha.Clear();
                tbFecha.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = tbNombre.Text;
            if (DateTime.TryParse(tbFecha.Text, out DateTime fecha))
            {
                insertarUsuario(usuario, fecha);

                MessageBox.Show("Datos guardados correctamente.");
            }
            else
            {
                MessageBox.Show("Fecha no válida. Por favor ingresa una fecha correcta.", "Error");
            }
        }
    }
}
