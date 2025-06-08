namespace GameDataHub
{
    using Newtonsoft.Json.Linq;
    using ScottPlot.WinForms;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing.Printing;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml.Linq;

    public partial class Form1 : Form
    {
        private string connectionDB = @"Server=LUX_ALAN\SQLEXPRESS;Database=Game_Library;Trusted_Connection=True;TrustServerCertificate=True";
        // private string connectionDB = @"Server=ALANAZASUS\MSSQLSERVER02;Database=Game_Library;Trusted_Connection=True;TrustServerCertificate=True";
        //private string connectionDB = @"Data Source=192.168.1.15\MSSQLserver02,1433;Database=Game_Library;User Id=Lux;Password=1234567890;TrustServerCertificate=True";
        private string clientId = "s87stzlrar3716fqqtfyao1wtaf0b6";
        private string accessToken;
        private string clientSecret = "0iptgu744ucm2s3fi2g8dnehnuiktr";
        private DateTime tokenExpiration;

        public Form1()
        {
            InitializeComponent();
        }


        //Section 1

        private async void BtnSearchName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                MessageBox.Show("Ingresa un nombre para buscar.");
                return;
            }

            try
            {
                accessToken = await ObtenerTokenAsync();
                var juegos = await BuscarJuegosAsync(TextBoxName.Text);

                // Limpiar resultados anteriores
                PictureBoxGameIcon.Image = null;

                foreach (var juego in juegos)
                {
                    int rowIndex = DataGrideShowData.Rows.Add(
                         juego.id,
                         juego.name,
                         juego.genre,
                         juego.developer,
                         juego.platform,
                         juego.imageUrl
                    );
                    DataGrideShowData.Rows[rowIndex].Tag = juego;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnDelet_Click(object sender, EventArgs e)
        {
            // clear the row selected in the datagridview
            if (DataGrideShowData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DataGrideShowData.SelectedRows)
                {
                    if (!row.IsNewRow) // Asegurarse de no eliminar la fila nueva
                    {
                        DataGrideShowData.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para eliminar.");
            }
        }
        private void DataGrideShowData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que no se está haciendo clic en el encabezado
            if (e.RowIndex >= 0)
            {
                var fila = DataGrideShowData.Rows[e.RowIndex];

                if (fila.Tag is Games juego && !string.IsNullOrEmpty(juego.imageUrl))
                {
                    try
                    {
                        // Asegúrate de que tenga el prefijo correcto
                        string url = juego.imageUrl;
                        if (!url.StartsWith("http"))
                        {
                            url = "https:" + url;
                        }

                        using (var wc = new System.Net.WebClient())
                        {
                            byte[] bytes = wc.DownloadData(url);
                            using (var ms = new System.IO.MemoryStream(bytes))
                            {
                                PictureBoxGameIcon.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen: " + ex.Message);
                        PictureBoxGameIcon.Image = null;
                    }
                }
                else
                {
                    PictureBoxGameIcon.Image = null;
                }
            }
        }

        private void BtnSaveData_Click(object sender, EventArgs e)
        {
            string selection = ComBoxFormat.SelectedItem?.ToString();
            try
            {
                switch (selection)
                {
                    case "CSV":
                        StringBuilder csvContent = new StringBuilder();
                        // Agregar encabezados
                        csvContent.AppendLine("ID,Name,Genre,Developer,Platform,ImageUrl");
                        // Agregar filas
                        foreach (DataGridViewRow row in DataGrideShowData.Rows)
                        {
                            if (row.IsNewRow) continue; // Ignorar la fila nueva
                            var game = row.Tag as Games;
                            if (game != null)
                            {
                                csvContent.AppendLine($"\"{game.id}\",\"{game.name}\",\"{game.genre}\",\"{game.developer}\",\"{game.platform}\",\"{game.imageUrl}\"");
                            }
                        }
                        // Guardar el contenido CSV en un archivo
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                                MessageBox.Show("Datos guardados exitosamente en formato CSV.");
                            }
                        }
                        break;
                    case "TXT":
                        //sace the datagridview data to a txt file
                        if (DataGrideShowData.Rows.Count <= 1)
                        {
                            MessageBox.Show("No hay datos para guardar.");
                            return;
                        }
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    StringBuilder sb = new StringBuilder();
                                    foreach (DataGridViewRow row in DataGrideShowData.Rows)
                                    {
                                        if (row.Tag is Games juego)
                                        {
                                            sb.AppendLine($"\"{juego.id}\",\"{juego.name}\",\"{juego.genre}\",\"{juego.developer}\",\"{juego.platform}\",\"{juego.imageUrl}\"");
                                        }
                                    }
                                    File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                                    MessageBox.Show("Datos guardados correctamente.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                                }
                            }
                        }
                        break;

                    case "XML":
                        //save the datagridview data to a xml file
                        if (DataGrideShowData.Rows.Count <= 1)
                        {
                            MessageBox.Show("No hay datos para guardar.");
                            return;
                        }
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    var xmlDoc = new XDocument(new XElement("Games"));
                                    foreach (DataGridViewRow row in DataGrideShowData.Rows)
                                    {
                                        if (row.Tag is Games juego)
                                        {
                                            xmlDoc.Root.Add(new XElement("Game",
                                                new XElement("id", juego.id),
                                                new XElement("name", juego.name),
                                                new XElement("genre", juego.genre),
                                                new XElement("developer", juego.developer),
                                                new XElement("platform", juego.platform),
                                                new XElement("imageUrl", juego.imageUrl)
                                            ));
                                        }
                                    }
                                    xmlDoc.Save(saveFileDialog.FileName);
                                    MessageBox.Show("Datos guardados correctamente.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                                }
                            }
                        }
                        break;

                    case "JSON":
                        //save the datagridview data to a json file
                        if (DataGrideShowData.Rows.Count <= 1)
                        {
                            MessageBox.Show("No hay datos para guardar.");
                            return;
                        }
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    var juegos = new JArray();
                                    foreach (DataGridViewRow row in DataGrideShowData.Rows)
                                    {
                                        if (row.Tag is Games juego)
                                        {
                                            var juegoJson = new JObject
                                            {
                                                ["id"] = juego.id,
                                                ["name"] = juego.name,
                                                ["genre"] = juego.genre,
                                                ["developer"] = juego.developer,
                                                ["platform"] = juego.platform,
                                                ["imageUrl"] = juego.imageUrl
                                            };
                                            juegos.Add(juegoJson);
                                        }
                                    }
                                    File.WriteAllText(saveFileDialog.FileName, juegos.ToString());

                                    MessageBox.Show("Datos guardados correctamente.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                                }
                            }
                        }
                        break;
                    case "PDF":
                        // Guardar el contenido del DataGridView en un archivo PDF
                        if (DataGrideViewShowData.Rows.Count <= 0)
                        {
                            MessageBox.Show("No hay datos para guardar.");
                            return;
                        }

                        using (SaveFileDialog saveDialog = new SaveFileDialog())
                        {
                            saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                            saveDialog.FileName = "Exportado";

                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    ExportarDataGridViewAPDF(DataGrideShowData, saveDialog.FileName);
                                    MessageBox.Show("PDF guardado correctamente.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al guardar el PDF: " + ex.Message);
                                }
                            }
                        }
                        break;

                    default:
                        MessageBox.Show("Selecciona un formato válido para guardar los datos.");
                        break;
                }

            }

            catch { MessageBox.Show("selecciona un formato para guardar los datos"); }



        }



        //Secction 2

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //if the datagridview is empty, show a message
            if (DataGrideViewShowData.Rows.Count <= 1)
            {
                MessageBox.Show("No hay datos para guardar.");
                return;
            }

            string selection = ComBoxFormat_Ver.SelectedItem?.ToString();

            switch (selection)
            {
                case "CSV":
                    // if the file exists, save the data to a csv file, but if it doesn't exist, create a new file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                StringBuilder csvContent = new StringBuilder();
                                // Agregar encabezados
                                csvContent.AppendLine("ID,Name,Genre,Developer,Platform,ImageUrl");
                                // Agregar filas
                                foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
                                {
                                    if (row.IsNewRow) continue; // Ignorar la fila nueva
                                    var game = row.Tag as Games;
                                    if (game != null)
                                    {
                                        csvContent.AppendLine($"{game.id},{game.name},{game.genre},{game.developer},{game.platform},{game.imageUrl}");
                                    }
                                }
                                // Guardar el contenido CSV en un archivo
                                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                                MessageBox.Show("Datos guardados exitosamente en formato CSV.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                            }
                        }
                    }

                    break;
                case "TXT":
                    //if the txt file exists, save the data to a txt file, but if it doesn't exist, create a new file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
                                {
                                    if (row.Tag is Games juego)
                                    {
                                        sb.AppendLine($"{juego.id},{juego.name},{juego.genre},{juego.developer},{juego.platform},{juego.imageUrl}");
                                    }
                                }
                                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                                MessageBox.Show("Datos guardados correctamente.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                            }
                        }
                    }
                    break;

                case "XML":
                    //if the xml file exists, save the data to a xml file, but if it doesn't exist, create a new file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                var xmlDoc = new XDocument(new XElement("Games"));
                                foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
                                {
                                    if (row.Tag is Games juego)
                                    {
                                        xmlDoc.Root.Add(new XElement("Game",
                                            new XElement("id", juego.id),
                                            new XElement("name", juego.name),
                                            new XElement("genre", juego.genre),
                                            new XElement("developer", juego.developer),
                                            new XElement("platform", juego.platform),
                                            new XElement("imageUrl", juego.imageUrl)
                                        ));
                                    }
                                }
                                xmlDoc.Save(saveFileDialog.FileName);
                                MessageBox.Show("Datos guardados correctamente.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                            }
                        }
                    }
                    break;

                case "JSON":
                    //if the json file exists, save the data to a json file, but if it doesn't exist, create a new file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                var juegos = new JArray();
                                foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
                                {
                                    if (row.Tag is Games juego)
                                    {
                                        var juegoJson = new JObject
                                        {
                                            ["id"] = juego.id,
                                            ["name"] = juego.name,
                                            ["genre"] = juego.genre,
                                            ["developer"] = juego.developer,
                                            ["platform"] = juego.platform,
                                            ["imageUrl"] = juego.imageUrl
                                        };
                                        juegos.Add(juegoJson);
                                    }
                                }
                                File.WriteAllText(saveFileDialog.FileName, juegos.ToString());
                                MessageBox.Show("Datos guardados correctamente.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                            }
                        }
                    }
                    break;

                default:
                    MessageBox.Show("Selecciona un formato válido para guardar los datos.");
                    break;
            }

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            //open file dialog to select a file,  CSV, TXT, XML or JSON
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|XML files (*.xml)|*.xml|JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string fileExtension = Path.GetExtension(filePath).ToLower();

                        // Limpiar columnas antes de cargar nuevo archivo
                        DataGrideViewShowData.Columns.Clear();

                        switch (fileExtension)
                        {
                            case ".csv":
                                LoadCsv(filePath, DataGrideViewShowData);
                                break;
                            case ".txt":
                                LoadTxt(filePath, DataGrideViewShowData);
                                break;
                            case ".xml":
                                LoadXml(filePath, DataGrideViewShowData);
                                break;
                            case ".json":
                                LoadJson(filePath, DataGrideViewShowData);
                                break;
                            default:
                                MessageBox.Show("Formato de archivo no soportado.");
                                return;
                        }

                        if (DataGrideViewShowData.Rows.Count > 0)
                        {
                            // Graficar por género (columna 2)
                            var datosAgrupados = ObtenerFrecuenciasDeColumna(DataGrideViewShowData, 2);
                            GraficarPieScottPlot5(FromPlotGenre, datosAgrupados);

                            // Graficar por plataforma (columna 4)
                            datosAgrupados = ObtenerFrecuenciasDeColumna(DataGrideViewShowData, 4);
                            GraficarPieScottPlot5(FomPlotPlatform, datosAgrupados);
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para graficar.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar el archivo: " + ex.Message);
                    }
                }
            }

        }

        private void BtnSeend_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF (*.pdf)|*.pdf|CSV (*.csv)|*.csv|Texto (*.txt)|*.txt|JSON (*.json)|*.json|XML (*.xml)|*.xml";
            try
            {
                saveDialog.FileName = "Tabla de juegos";
                try
                {
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string extension = Path.GetExtension(saveDialog.FileName).ToLower();

                        try
                        {
                            switch (extension)
                            {
                                case ".pdf":
                                    if (DataGrideViewShowData.Rows.Count <= 1)
                                    {
                                        MessageBox.Show("No hay datos para exportar.");
                                        return;
                                    }

                                    string tempPath = Path.Combine(Path.GetTempPath(), "Exportado.pdf");

                                    try
                                    {
                                        ExportarDataGridViewAPDF(DataGrideViewShowData, tempPath);
                                        EnviarArchivoPorCorreo(tempPath, "Exportado.pdf");
                                        MessageBox.Show("PDF enviado por correo.");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error al generar o enviar el PDF: " + ex.Message);
                                    }
                                    break;
                                case ".csv":
                                    ExportarDataGridViewACSV(saveDialog.FileName);
                                    break;
                                case ".txt":
                                    ExportarDataGridViewATxt(saveDialog.FileName);
                                    break;
                                case ".json":
                                    ExportarDataGridViewAJson(saveDialog.FileName);
                                    break;
                                case ".xml":
                                    ExportarDataGridViewAXml(saveDialog.FileName);
                                    break;
                                default:
                                    MessageBox.Show("Formato no soportado.");
                                    return;
                            }

                            EnviarArchivoPorCorreo(saveDialog.FileName, Path.GetFileName(saveDialog.FileName));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al exportar el archivo: " + ex.Message);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el archivo: " + ex.Message);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al establecer el nombre del archivo: " + ex.Message);
                return;
            }



        }

        //section 3

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            //load the data of the a document (xml,csv, jason and txt) in the datagridview
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|XML files (*.xml)|*.xml|JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string fileExtension = Path.GetExtension(filePath).ToLower();
                        switch (fileExtension)
                        {
                            case ".csv":
                                LoadCsv(filePath, DataGrideShowSql);
                                break;
                            case ".txt":
                                LoadTxt(filePath, DataGrideShowSql);
                                break;
                            case ".xml":
                                LoadXml(filePath, DataGrideShowSql);
                                break;
                            case ".json":
                                LoadJson(filePath, DataGrideShowSql);
                                break;
                            default:
                                MessageBox.Show("Formato de archivo no soportado.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar el archivo: " + ex.Message);
                    }
                }
            }
        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            //receive data the sql database and show it in the datagridview
            using (SqlConnection connection = new SqlConnection(connectionDB))
            {
                string consulta = "SELECT * FROM games";

                SqlDataAdapter adapter = new SqlDataAdapter(consulta, connection);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);  // Llenamos el DataTable con los datos
                    DataGrideShowSql.DataSource = dt;  // Asignamos el DataTable como fuente de datos
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            //send data datagridview to the sql database
            using (SqlConnection connection = new SqlConnection(connectionDB))
            {
                try
                {
                    connection.Open();

                    foreach (DataGridViewRow row in DataGrideShowSql.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Armar la lista de columnas y parámetros
                        List<string> columnas = new List<string>();
                        List<string> parametros = new List<string>();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;

                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            string columnName = DataGrideShowSql.Columns[i].Name; // Asegúrate que los nombres coincidan con los de SQL
                            string paramName = "@param" + i;

                            columnas.Add(columnName);
                            parametros.Add(paramName);

                            object value = row.Cells[i].Value ?? DBNull.Value;
                            cmd.Parameters.AddWithValue(paramName, value);
                        }

                        string query = $"INSERT INTO games ({string.Join(",", columnas)}) VALUES ({string.Join(",", parametros)})";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Datos enviados correctamente a la base de datos.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar datos: " + ex.Message);
                }
            }
        }

        //METHODS

        private async Task<string> ObtenerTokenAsync()
        {
            // Si el token es válido y no expiró, regresarlo
            if (!string.IsNullOrEmpty(accessToken) && DateTime.Now < tokenExpiration)
            {
                return accessToken;
            }

            using (var client = new HttpClient())
            {
                var url = $"https://id.twitch.tv/oauth2/token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials";

                var response = await client.PostAsync(url, null);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("No se pudo obtener el token de acceso.");
                }

                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);

                accessToken = data["access_token"].ToString();

                // Guardamos la expiración sumando los segundos que dura el token
                int expiresIn = data["expires_in"].ToObject<int>();
                tokenExpiration = DateTime.Now.AddSeconds(expiresIn - 60); // -60 para renovar 1 minuto antes

                return accessToken;
            }
        }

        private async Task<List<Games>> BuscarJuegosAsync(string nombre)
        {
            var juegos = new List<Games>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Client-ID", clientId);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                string query = $@"fields id, name, genres.name, platforms.name, involved_companies.company.name, cover.url; search ""{nombre}"";limit 1;";

                var content = new StringContent(query, Encoding.UTF8, "text/plain");
                var response = await client.PostAsync("https://api.igdb.com/v4/games", content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la API IGDB: {response.StatusCode}");
                }

                string json = await response.Content.ReadAsStringAsync();
                var data = JArray.Parse(json);

                foreach (var item in data)
                {
                    string genres = item["genres"] != null
                        ? string.Join(", ", item["genres"].Select(g => g["name"].ToString()))
                        : "Desconocido";

                    string platforms = item["platforms"] != null
                        ? string.Join(", ", item["platforms"].Select(p => p["name"].ToString()))
                        : "Desconocido";

                    string developer = item["involved_companies"] != null
                        ? string.Join(", ", item["involved_companies"].Select(c => c["company"]?["name"]?.ToString()))
                        : "Desconocido";

                    string imageUrl = item["cover"]?["url"]?.ToString();
                    if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.StartsWith("http"))
                    {
                        imageUrl = "https:" + imageUrl.Replace("t_thumb", "t_cover_big");
                    }

                    juegos.Add(new Games
                    {
                        id = item["id"]?.ToString(),
                        name = item["name"]?.ToString(),
                        genre = genres,
                        platform = platforms,
                        developer = developer,
                        imageUrl = imageUrl
                    });
                }

                return juegos;
            }

        }


        public void LoadCsv(string filePath, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true;
                List<string> headers = null;

                while ((line = reader.ReadLine()) != null)
                {
                    var values = ParseCsvLine(line); // Este método debe dividir por ',' y considerar comillas si hay

                    // Reemplazar celdas vacías o con solo espacios por "n/a"
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(values[i]))
                        {
                            values[i] = "n/a";
                        }
                    }

                    if (isFirstLine)
                    {
                        headers = values;
                        isFirstLine = false;

                        // Crear columnas solo si no existen
                        if (dataGridView.Columns.Count == 0)
                        {
                            foreach (var header in headers)
                            {
                                dataGridView.Columns.Add(header, header);
                            }
                        }

                        continue; // No cargar los encabezados como datos
                    }

                    // Asegurar que tenga al menos tantas columnas como se esperan
                    if (values.Count >= dataGridView.Columns.Count)
                    {
                        int rowIndex = dataGridView.Rows.Add(values.ToArray());

                        // Asignar al objeto Game si es necesario
                        var game = new Games
                        {
                            id = values[0],
                            name = values[1],
                            genre = values[2],
                            developer = values[3],
                            platform = values[4],
                            imageUrl = values[5]
                        };

                        dataGridView.Rows[rowIndex].Tag = game;
                    }
                }
            }
        }


        public void LoadTxt(string filePath, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true;
                List<string> headers = null;

                while ((line = reader.ReadLine()) != null)
                {
                    var values = ParseCsvLine(line); // Asegúrate de adaptar ParseCsvLine si usas tabulaciones en vez de comas

                    // Reemplazar valores vacíos o con solo espacios por "n/a"
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(values[i]))
                        {
                            values[i] = "n/a";
                        }
                    }

                    if (isFirstLine)
                    {
                        headers = values;
                        isFirstLine = false;

                        if (dataGridView.Columns.Count == 0)
                        {
                            foreach (var header in headers)
                            {
                                dataGridView.Columns.Add(header, header);
                            }
                        }

                        continue; // Saltar encabezado como fila de datos
                    }

                    if (values.Count >= dataGridView.Columns.Count)
                    {
                        int rowIndex = dataGridView.Rows.Add(values.ToArray());

                        // Vincular el objeto Game como Tag (si se requiere)
                        var game = new Games
                        {
                            id = values[0],
                            name = values[1],
                            genre = values[2],
                            developer = values[3],
                            platform = values[4],
                            imageUrl = values[5]
                        };

                        dataGridView.Rows[rowIndex].Tag = game;
                    }
                }
            }
        }




        public void LoadXml(string filePath, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            var xmlDoc = XDocument.Load(filePath);
            var gameElements = xmlDoc.Descendants("Game").ToList();

            if (!gameElements.Any())
                return;

            // Crear columnas solo si no existen
            if (dataGridView.Columns.Count == 0)
            {
                var firstGame = gameElements.First();
                foreach (var element in firstGame.Elements())
                {
                    dataGridView.Columns.Add(element.Name.LocalName, element.Name.LocalName);
                }
            }

            foreach (var gameElement in gameElements)
            {
                // Obtener valores con "n/a" si están vacíos
                var values = dataGridView.Columns
                    .Cast<DataGridViewColumn>()
                    .Select(col =>
                    {
                        string value = gameElement.Element(col.Name)?.Value ?? "";
                        return string.IsNullOrWhiteSpace(value) ? "n/a" : value;
                    })
                    .ToArray();

                int rowIndex = dataGridView.Rows.Add(values);

                // Asociar objeto Game, usando también "n/a" para campos vacíos
                var game = new Games
                {
                    id = string.IsNullOrWhiteSpace(gameElement.Element("id")?.Value) ? "n/a" : gameElement.Element("id")?.Value,
                    name = string.IsNullOrWhiteSpace(gameElement.Element("name")?.Value) ? "n/a" : gameElement.Element("name")?.Value,
                    genre = string.IsNullOrWhiteSpace(gameElement.Element("genre")?.Value) ? "n/a" : gameElement.Element("genre")?.Value,
                    developer = string.IsNullOrWhiteSpace(gameElement.Element("developer")?.Value) ? "n/a" : gameElement.Element("developer")?.Value,
                    platform = string.IsNullOrWhiteSpace(gameElement.Element("platform")?.Value) ? "n/a" : gameElement.Element("platform")?.Value,
                    imageUrl = string.IsNullOrWhiteSpace(gameElement.Element("imageUrl")?.Value) ? "n/a" : gameElement.Element("imageUrl")?.Value
                };

                dataGridView.Rows[rowIndex].Tag = game;
            }
        }



        public void LoadJson(string filePath, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            var json = File.ReadAllText(filePath);
            var juegos = JArray.Parse(json);

            if (juegos.Count == 0)
                return;

            // Crear columnas automáticamente SOLO si no existen
            if (dataGridView.Columns.Count == 0)
            {
                foreach (JProperty prop in juegos[0])
                {
                    dataGridView.Columns.Add(prop.Name, prop.Name);
                }
            }

            foreach (var item in juegos)
            {
                List<string> rowData = new List<string>();

                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    string value = item[col.Name]?.ToString() ?? "";
                    rowData.Add(string.IsNullOrWhiteSpace(value) ? "n/a" : value);
                }

                int rowIndex = dataGridView.Rows.Add(rowData.ToArray());

                // Asignar al objeto Game con validación de campos vacíos
                string GetSafeValue(string key) =>
                    string.IsNullOrWhiteSpace(item[key]?.ToString()) ? "n/a" : item[key]?.ToString();

                var game = new Games
                {
                    id = GetSafeValue("id"),
                    name = GetSafeValue("name"),
                    genre = GetSafeValue("genre"),
                    developer = GetSafeValue("developer"),
                    platform = GetSafeValue("platform"),
                    imageUrl = GetSafeValue("imageUrl")
                };

                dataGridView.Rows[rowIndex].Tag = game;
            }
        }


        private List<string> ParseCsvLine(string line)
        {
            var values = new List<string>();
            bool inQuotes = false;
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        // Revisa si es una comilla escapada ("")
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            value.Append('"');
                            i++; // Saltar la siguiente comilla
                        }
                        else
                        {
                            inQuotes = false; // Finaliza comillas
                        }
                    }
                    else
                    {
                        value.Append(c);
                    }
                }
                else
                {
                    if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else if (c == ',')
                    {
                        values.Add(value.ToString());
                        value.Clear();
                    }
                    else
                    {
                        value.Append(c);
                    }
                }
            }

            values.Add(value.ToString()); // Último valor
            return values;
        }



        //grafica en forma de pastel la columna de genero de los juegos en un fromplot
        public void GraficarPieScottPlot5(FormsPlot plot, Dictionary<string, int> datosAgrupados)
        {
            plot.Plot.Clear();

            // Ordenar por frecuencia descendente
            var ordenado = datosAgrupados.OrderByDescending(kv => kv.Value).ToList();

            // Separar valores y etiquetas
            double[] values = ordenado.Select(kv => (double)kv.Value).ToArray();
            string[] labels = ordenado.Select(kv => kv.Key).ToArray();

            // Crear gráfico
            var pie = plot.Plot.Add.Pie(values);

            pie.ExplodeFraction = 0.1;
            pie.SliceLabelDistance = 0.5;

            double total = values.Sum();

            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].Label = $"{labels[i]}"; // Etiqueta que aparece en el gráfico
                pie.Slices[i].LegendText = $"{labels[i]} ({values[i] / total:P1})"; // Texto de la leyenda
                pie.Slices[i].LabelFontSize = 16;
            }

            // Opcional: estilo visual
            plot.Plot.Axes.Frameless();
            plot.Plot.HideGrid();

            // Mostrar
            plot.Refresh();
        }


        public Dictionary<string, int> ObtenerFrecuenciasDeColumna(DataGridView dgv, int columna)
        {
            Dictionary<string, int> frecuencias = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow && fila.Cells[columna].Value != null)
                {
                    string valorCelda = fila.Cells[columna].Value.ToString();

                    // Separar por comas y procesar cada uno
                    var elementos = valorCelda.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var elemento in elementos)
                    {
                        string limpio = elemento.Trim(); // Quita espacios extra

                        if (frecuencias.ContainsKey(limpio))
                            frecuencias[limpio]++;
                        else
                            frecuencias[limpio] = 1;
                    }
                }
            }

            return frecuencias;
        }
        private void EnviarArchivoPorCorreo(string archivoRuta, string archivoNombre)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("meliodassama242@gmail.com");
                correo.To.Add(TextBoxUser.Text);
                correo.Subject = "Archivo exportado desde la app";
                correo.Body = "Se adjunta el archivo generado.";

                correo.Attachments.Add(new Attachment(archivoRuta));

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("meliodassama242@gmail.com", "lerc shaf ekeu ahen");
                smtp.EnableSsl = true;

                smtp.Send(correo);

                MessageBox.Show("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        private void ExportarDataGridViewAPDF(DataGridView gridView, string rutaArchivo)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = rutaArchivo;

            pd.PrintPage += (sender, ev) =>
            {
                int x = 20;
                int y = 20;
                int anchoColumna = 100;
                int altoFila = 25;
                Font font = new Font("Arial", 10);
                Pen pen = Pens.Black;
                Brush brush = Brushes.Black;

                int totalColumnas = gridView.Columns.Count;
                int totalFilas = gridView.Rows.Count - 1; // Omitir última fila vacía

                // Dibujar encabezados
                for (int col = 0; col < totalColumnas; col++)
                {
                    Rectangle rect = new Rectangle(x, y, anchoColumna, altoFila);
                    ev.Graphics.DrawRectangle(pen, rect);
                    ev.Graphics.DrawString(gridView.Columns[col].HeaderText, font, brush, rect,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    x += anchoColumna;
                }

                y += altoFila;
                x = 20;

                // Dibujar filas
                for (int fila = 0; fila < totalFilas; fila++)
                {
                    for (int col = 0; col < totalColumnas; col++)
                    {
                        Rectangle rect = new Rectangle(x, y, anchoColumna, altoFila);
                        ev.Graphics.DrawRectangle(pen, rect);
                        string texto = gridView.Rows[fila].Cells[col].Value?.ToString() ?? "n/a";
                        ev.Graphics.DrawString(texto, font, brush, rect,
                            new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        x += anchoColumna;
                    }
                    y += altoFila;
                    x = 20;

                    if (y + altoFila > ev.MarginBounds.Bottom)
                    {
                        ev.HasMorePages = true;
                        return;
                    }
                }

                ev.HasMorePages = false;
            };

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir como PDF: " + ex.Message);
            }
        }


        private void ExportarDataGridViewAJson(string filePath)
        {
            JArray array = new JArray();

            foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
            {
                if (row.IsNewRow) continue;

                JObject obj = new JObject();
                foreach (DataGridViewColumn col in DataGrideViewShowData.Columns)
                {
                    string key = col.HeaderText;
                    string value = row.Cells[col.Index].Value?.ToString() ?? "";
                    obj[key] = string.IsNullOrWhiteSpace(value) ? "n/a" : value;
                }

                array.Add(obj);
            }

            File.WriteAllText(filePath, array.ToString());
        }

        private void ExportarDataGridViewAXml(string filePath)
        {
            XElement root = new XElement("Games");

            foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
            {
                if (row.IsNewRow) continue;

                XElement game = new XElement("Game");

                foreach (DataGridViewColumn col in DataGrideViewShowData.Columns)
                {
                    string key = col.HeaderText;
                    string value = row.Cells[col.Index].Value?.ToString() ?? "n/a";
                    game.Add(new XElement(key, string.IsNullOrWhiteSpace(value) ? "n/a" : value));
                }

                root.Add(game);
            }

            root.Save(filePath);
        }

        private void ExportarDataGridViewATxt(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Encabezados
                var headers = DataGrideViewShowData.Columns
                    .Cast<DataGridViewColumn>()
                    .Select(col => col.HeaderText);
                writer.WriteLine(string.Join("\t", headers)); // Usa tabulación

                // Filas
                foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var values = row.Cells
                            .Cast<DataGridViewCell>()
                            .Select(cell => cell.Value?.ToString() ?? "");
                        writer.WriteLine(string.Join("\t", values));
                    }
                }
            }
        }

        private void ExportarDataGridViewACSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Encabezados
                var headers = DataGrideViewShowData.Columns
                    .Cast<DataGridViewColumn>()
                    .Select(col => col.HeaderText);
                writer.WriteLine(string.Join(",", headers));

                // Filas
                foreach (DataGridViewRow row in DataGrideViewShowData.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var values = row.Cells
                            .Cast<DataGridViewCell>()
                            .Select(cell => "\"" + (cell.Value?.ToString() ?? "") + "\"");
                        writer.WriteLine(string.Join(",", values));
                    }
                }
            }
        }
        private void AplicarFiltro(DataGridView dgv)
        {
            string texto = TxtFilter.Text.Trim();
            int columna = ComBoxFiltrer.SelectedIndex;               // 0?based

            // Si la caja está vacía, muestra todo
            if (string.IsNullOrEmpty(texto))
            {
                foreach (DataGridViewRow fila in dgv.Rows)
                    fila.Visible = true;
                return;
            }

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (fila.IsNewRow) continue;                 // omite fila de edición
                string valorCelda = fila.Cells[columna].Value?.ToString() ?? "";

                // Visible solo si contiene el texto (ignora mayúsc/minúsc)
                fila.Visible = valorCelda.IndexOf(
                    texto, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        private void BtnFillTreeView_Click(object sender, EventArgs e)
        {
            TreeViewSql.Nodes.Clear();

            // Índices de las columnas que usarás (ajusta según tu DataGridView)
            int genreColIndex = DataGrideShowData.Columns["genre"]?.Index ?? 2;  // ejemplo
            int nameColIndex = DataGrideShowData.Columns["name"]?.Index ?? 1;

            // Diccionario para evitar duplicados de géneros
            Dictionary<string, TreeNode> genreNodes = new Dictionary<string, TreeNode>();

            foreach (DataGridViewRow row in DataGrideShowData.Rows)
            {
                if (row.IsNewRow) continue;

                string genre = row.Cells[genreColIndex].Value?.ToString() ?? "Sin Género";
                string name = row.Cells[nameColIndex].Value?.ToString() ?? "Sin Nombre";

                // Crear nodo género si no existe
                if (!genreNodes.ContainsKey(genre))
                {
                    TreeNode genreNode = new TreeNode(genre);
                    genreNodes.Add(genre, genreNode);
                    TreeViewSql.Nodes.Add(genreNode);
                }

                // Añadir juego bajo el género
                TreeNode gameNode = new TreeNode(name);
                genreNodes[genre].Nodes.Add(gameNode);
            }

            TreeViewSql.ExpandAll();
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro(DataGrideViewShowData);
        }

        private void ComBoxFiltrer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro(DataGrideViewShowData);
        }

    }

}