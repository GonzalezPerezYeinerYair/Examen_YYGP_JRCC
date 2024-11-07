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
        string SqlConnection = "server=localhost; port=3306; Database=Examenpractico2; UID=root; Pwd=;";

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
                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Tiempo de espera en la lectura de datos del Arduino.");
                }
            }
        }

        private void mostrarDatos(string data)
        {
            // Actualizar el Label de manera segura desde el hilo de la interfaz de usuario
            if (Temperatura.InvokeRequired)
            {
                Temperatura.Invoke(new Action(() =>
                {
                    Temperatura.Text = data + "°F";
                }));
            }
            else
            {
                Temperatura.Text = data + "°F";
            }
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
                    // Verificación más detallada para asegurarse de que el valor es numérico
                    temperatura = temperatura.Replace("°F", "").Trim();  // Remueve °F si está presente

                    if (float.TryParse(temperatura, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float tempValue))
                    {
                        command.Parameters.AddWithValue("@temperatura", tempValue);
                        command.Parameters.AddWithValue("@fecha", fecha);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo convertir la temperatura a un valor numérico.");
                    }
                }
            }
        }

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
                // Guarda el usuario y la fecha en la base de datos
                insertarUsuario(usuario, fecha);

                // Extrae la temperatura del label 'Temperatura' para insertarla en la base de datos
                string temperaturaTexto = Temperatura.Text.Replace("°F", "").Trim();

                // Inserta la temperatura en la base de datos, si está disponible
                if (!string.IsNullOrEmpty(temperaturaTexto))
                {
                    insertarTemperatura(temperaturaTexto, DateTime.Now);
                }
                else
                {
                    MessageBox.Show("La temperatura no se ha leído correctamente. Asegúrate de que el Arduino esté enviando los datos.", "Error");
                }

                MessageBox.Show("Datos guardados correctamente.");
            }
            else
            {
                MessageBox.Show("Fecha no válida. Por favor ingresa una fecha correcta.", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Temperatura_Click(object sender, EventArgs e)
        {

        }
    }
}