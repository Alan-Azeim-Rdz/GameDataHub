namespace GameDataHub
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabControlOption = new TabControl();
            TabPageArchive = new TabPage();
            BtnDelet = new Button();
            label5 = new Label();
            label4 = new Label();
            ComBoxFormat = new ComboBox();
            BtnSaveData = new Button();
            PictureBoxGameIcon = new PictureBox();
            label3 = new Label();
            BtnSearchName = new Button();
            DataGrideShowData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            label2 = new Label();
            TextBoxName = new TextBox();
            TabPageView = new TabPage();
            label7 = new Label();
            TextBoxUser = new TextBox();
            BtnSeend = new Button();
            TxtFilter = new TextBox();
            label11 = new Label();
            label10 = new Label();
            FomPlotPlatform = new ScottPlot.WinForms.FormsPlot();
            FromPlotGenre = new ScottPlot.WinForms.FormsPlot();
            label9 = new Label();
            button2 = new Button();
            label1 = new Label();
            ComBoxTypeExport = new ComboBox();
            BtnExport = new Button();
            label6 = new Label();
            ComBoxFormat_Ver = new ComboBox();
            DataGrideViewShowData = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            BtnSave = new Button();
            BtnLoad = new Button();
            TabPageSQL = new TabPage();
            TreeViewSql = new TreeView();
            BtnSend = new Button();
            BtnReceive = new Button();
            BtnUpload = new Button();
            DataGrideShowSql = new DataGridView();
            BtnFillTreeView = new Button();
            TabControlOption.SuspendLayout();
            TabPageArchive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxGameIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGrideShowData).BeginInit();
            TabPageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrideViewShowData).BeginInit();
            TabPageSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrideShowSql).BeginInit();
            SuspendLayout();
            // 
            // TabControlOption
            // 
            TabControlOption.Controls.Add(TabPageArchive);
            TabControlOption.Controls.Add(TabPageView);
            TabControlOption.Controls.Add(TabPageSQL);
            TabControlOption.Dock = DockStyle.Fill;
            TabControlOption.Location = new Point(0, 0);
            TabControlOption.Margin = new Padding(3, 2, 3, 2);
            TabControlOption.Name = "TabControlOption";
            TabControlOption.SelectedIndex = 0;
            TabControlOption.Size = new Size(1481, 672);
            TabControlOption.TabIndex = 0;
            // 
            // TabPageArchive
            // 
            TabPageArchive.Controls.Add(BtnDelet);
            TabPageArchive.Controls.Add(label5);
            TabPageArchive.Controls.Add(label4);
            TabPageArchive.Controls.Add(ComBoxFormat);
            TabPageArchive.Controls.Add(BtnSaveData);
            TabPageArchive.Controls.Add(PictureBoxGameIcon);
            TabPageArchive.Controls.Add(label3);
            TabPageArchive.Controls.Add(BtnSearchName);
            TabPageArchive.Controls.Add(DataGrideShowData);
            TabPageArchive.Controls.Add(label2);
            TabPageArchive.Controls.Add(TextBoxName);
            TabPageArchive.Location = new Point(4, 24);
            TabPageArchive.Margin = new Padding(3, 2, 3, 2);
            TabPageArchive.Name = "TabPageArchive";
            TabPageArchive.Padding = new Padding(3, 2, 3, 2);
            TabPageArchive.Size = new Size(1473, 644);
            TabPageArchive.TabIndex = 0;
            TabPageArchive.Text = "Archivo";
            TabPageArchive.UseVisualStyleBackColor = true;
            // 
            // BtnDelet
            // 
            BtnDelet.Location = new Point(274, 50);
            BtnDelet.Margin = new Padding(3, 2, 3, 2);
            BtnDelet.Name = "BtnDelet";
            BtnDelet.Size = new Size(82, 22);
            BtnDelet.TabIndex = 13;
            BtnDelet.Text = "Borrar";
            BtnDelet.UseVisualStyleBackColor = true;
            BtnDelet.Click += BtnDelet_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(168, 105);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 12;
            label5.Text = "Guardar Datos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 142);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 11;
            label4.Text = "Formato";
            // 
            // ComBoxFormat
            // 
            ComBoxFormat.FormattingEnabled = true;
            ComBoxFormat.Items.AddRange(new object[] { "CSV", "TXT", "XML", "JSON" });
            ComBoxFormat.Location = new Point(74, 140);
            ComBoxFormat.Name = "ComBoxFormat";
            ComBoxFormat.Size = new Size(133, 23);
            ComBoxFormat.TabIndex = 10;
            // 
            // BtnSaveData
            // 
            BtnSaveData.Location = new Point(262, 134);
            BtnSaveData.Margin = new Padding(3, 2, 3, 2);
            BtnSaveData.Name = "BtnSaveData";
            BtnSaveData.Size = new Size(94, 31);
            BtnSaveData.TabIndex = 9;
            BtnSaveData.Text = "guardar";
            BtnSaveData.UseVisualStyleBackColor = true;
            BtnSaveData.Click += BtnSaveData_Click;
            // 
            // PictureBoxGameIcon
            // 
            PictureBoxGameIcon.Location = new Point(67, 207);
            PictureBoxGameIcon.Margin = new Padding(3, 2, 3, 2);
            PictureBoxGameIcon.Name = "PictureBoxGameIcon";
            PictureBoxGameIcon.Size = new Size(330, 289);
            PictureBoxGameIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBoxGameIcon.TabIndex = 8;
            PictureBoxGameIcon.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(188, 182);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Juego";
            // 
            // BtnSearchName
            // 
            BtnSearchName.Location = new Point(274, 13);
            BtnSearchName.Margin = new Padding(3, 2, 3, 2);
            BtnSearchName.Name = "BtnSearchName";
            BtnSearchName.Size = new Size(82, 22);
            BtnSearchName.TabIndex = 5;
            BtnSearchName.Text = "Buscar";
            BtnSearchName.UseVisualStyleBackColor = true;
            BtnSearchName.Click += BtnSearchName_Click;
            // 
            // DataGrideShowData
            // 
            DataGrideShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrideShowData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            DataGrideShowData.Dock = DockStyle.Right;
            DataGrideShowData.Location = new Point(688, 2);
            DataGrideShowData.Margin = new Padding(3, 2, 3, 2);
            DataGrideShowData.MultiSelect = false;
            DataGrideShowData.Name = "DataGrideShowData";
            DataGrideShowData.ReadOnly = true;
            DataGrideShowData.RowHeadersWidth = 51;
            DataGrideShowData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGrideShowData.Size = new Size(782, 640);
            DataGrideShowData.TabIndex = 4;
            DataGrideShowData.CellContentClick += DataGrideShowData_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Nombre";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Genero";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Desarrolladora";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Plataforma";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "URL Imagen";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 125;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 16);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(74, 14);
            TextBoxName.Margin = new Padding(3, 2, 3, 2);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(133, 23);
            TextBoxName.TabIndex = 2;
            // 
            // TabPageView
            // 
            TabPageView.Controls.Add(label7);
            TabPageView.Controls.Add(TextBoxUser);
            TabPageView.Controls.Add(BtnSeend);
            TabPageView.Controls.Add(TxtFilter);
            TabPageView.Controls.Add(label11);
            TabPageView.Controls.Add(label10);
            TabPageView.Controls.Add(FomPlotPlatform);
            TabPageView.Controls.Add(FromPlotGenre);
            TabPageView.Controls.Add(label9);
            TabPageView.Controls.Add(button2);
            TabPageView.Controls.Add(label1);
            TabPageView.Controls.Add(ComBoxTypeExport);
            TabPageView.Controls.Add(BtnExport);
            TabPageView.Controls.Add(label6);
            TabPageView.Controls.Add(ComBoxFormat_Ver);
            TabPageView.Controls.Add(DataGrideViewShowData);
            TabPageView.Controls.Add(BtnSave);
            TabPageView.Controls.Add(BtnLoad);
            TabPageView.Location = new Point(4, 24);
            TabPageView.Margin = new Padding(3, 2, 3, 2);
            TabPageView.Name = "TabPageView";
            TabPageView.Padding = new Padding(3, 2, 3, 2);
            TabPageView.Size = new Size(1473, 644);
            TabPageView.TabIndex = 1;
            TabPageView.Text = "Ver";
            TabPageView.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 125);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 27;
            label7.Text = "Correo";
            // 
            // TextBoxUser
            // 
            TextBoxUser.Location = new Point(100, 122);
            TextBoxUser.Name = "TextBoxUser";
            TextBoxUser.Size = new Size(180, 23);
            TextBoxUser.TabIndex = 26;
            // 
            // BtnSeend
            // 
            BtnSeend.Location = new Point(310, 122);
            BtnSeend.Name = "BtnSeend";
            BtnSeend.Size = new Size(120, 28);
            BtnSeend.TabIndex = 25;
            BtnSeend.Text = "Enviar";
            BtnSeend.UseVisualStyleBackColor = true;
            BtnSeend.Click += BtnSeend_Click;
            // 
            // TxtFilter
            // 
            TxtFilter.Location = new Point(100, 95);
            TxtFilter.Name = "TxtFilter";
            TxtFilter.Size = new Size(180, 23);
            TxtFilter.TabIndex = 24;
            TxtFilter.TextChanged += TxtFilter_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 168);
            label11.Name = "label11";
            label11.Size = new Size(45, 15);
            label11.TabIndex = 23;
            label11.Text = "Genero";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 382);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 22;
            label10.Text = "Plataforma";
            // 
            // FomPlotPlatform
            // 
            FomPlotPlatform.DisplayScale = 1F;
            FomPlotPlatform.Dock = DockStyle.Bottom;
            FomPlotPlatform.Location = new Point(3, 400);
            FomPlotPlatform.Name = "FomPlotPlatform";
            FomPlotPlatform.Size = new Size(685, 242);
            FomPlotPlatform.TabIndex = 21;
            // 
            // FromPlotGenre
            // 
            FromPlotGenre.DisplayScale = 1F;
            FromPlotGenre.Location = new Point(3, 186);
            FromPlotGenre.Name = "FromPlotGenre";
            FromPlotGenre.Size = new Size(679, 193);
            FromPlotGenre.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 103);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 19;
            label9.Text = "Filtro";
            // 
            // button2
            // 
            button2.Location = new Point(310, 94);
            button2.Name = "button2";
            button2.Size = new Size(120, 22);
            button2.TabIndex = 17;
            button2.Text = "Filtrar";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 59);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 16;
            label1.Text = "Tipo de Archivo";
            // 
            // ComBoxTypeExport
            // 
            ComBoxTypeExport.FormattingEnabled = true;
            ComBoxTypeExport.Items.AddRange(new object[] { "CSV", "TXT", "XML", "JSON" });
            ComBoxTypeExport.Location = new Point(119, 56);
            ComBoxTypeExport.Name = "ComBoxTypeExport";
            ComBoxTypeExport.Size = new Size(133, 23);
            ComBoxTypeExport.TabIndex = 15;
            // 
            // BtnExport
            // 
            BtnExport.Location = new Point(266, 55);
            BtnExport.Name = "BtnExport";
            BtnExport.Size = new Size(120, 22);
            BtnExport.TabIndex = 14;
            BtnExport.Text = "Exportar";
            BtnExport.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 17);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 13;
            label6.Text = "Formato";
            // 
            // ComBoxFormat_Ver
            // 
            ComBoxFormat_Ver.FormattingEnabled = true;
            ComBoxFormat_Ver.Items.AddRange(new object[] { "CSV", "TXT", "XML", "JSON" });
            ComBoxFormat_Ver.Location = new Point(119, 17);
            ComBoxFormat_Ver.Name = "ComBoxFormat_Ver";
            ComBoxFormat_Ver.Size = new Size(133, 23);
            ComBoxFormat_Ver.TabIndex = 12;
            // 
            // DataGrideViewShowData
            // 
            DataGrideViewShowData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrideViewShowData.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            DataGrideViewShowData.Dock = DockStyle.Right;
            DataGrideViewShowData.Location = new Point(688, 2);
            DataGrideViewShowData.Margin = new Padding(3, 2, 3, 2);
            DataGrideViewShowData.MultiSelect = false;
            DataGrideViewShowData.Name = "DataGrideViewShowData";
            DataGrideViewShowData.RowHeadersWidth = 51;
            DataGrideViewShowData.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DataGrideViewShowData.Size = new Size(782, 640);
            DataGrideViewShowData.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Genero";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Desarrolladora";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Plataforma";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "URL Imagen";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(266, 18);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(120, 22);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Guardar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnLoad
            // 
            BtnLoad.Location = new Point(495, 17);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(120, 46);
            BtnLoad.TabIndex = 1;
            BtnLoad.Text = "Abrir";
            BtnLoad.UseVisualStyleBackColor = true;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // TabPageSQL
            // 
            TabPageSQL.Controls.Add(BtnFillTreeView);
            TabPageSQL.Controls.Add(TreeViewSql);
            TabPageSQL.Controls.Add(BtnSend);
            TabPageSQL.Controls.Add(BtnReceive);
            TabPageSQL.Controls.Add(BtnUpload);
            TabPageSQL.Controls.Add(DataGrideShowSql);
            TabPageSQL.Location = new Point(4, 24);
            TabPageSQL.Margin = new Padding(3, 2, 3, 2);
            TabPageSQL.Name = "TabPageSQL";
            TabPageSQL.Padding = new Padding(3, 2, 3, 2);
            TabPageSQL.Size = new Size(1473, 644);
            TabPageSQL.TabIndex = 2;
            TabPageSQL.Text = "SQL";
            TabPageSQL.UseVisualStyleBackColor = true;
            // 
            // TreeViewSql
            // 
            TreeViewSql.Location = new Point(6, 237);
            TreeViewSql.Name = "TreeViewSql";
            TreeViewSql.Size = new Size(423, 399);
            TreeViewSql.TabIndex = 19;
            // 
            // BtnSend
            // 
            BtnSend.Location = new Point(242, 103);
            BtnSend.Margin = new Padding(3, 2, 3, 2);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(115, 35);
            BtnSend.TabIndex = 18;
            BtnSend.Text = "Enviar a Sql";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // BtnReceive
            // 
            BtnReceive.Location = new Point(242, 38);
            BtnReceive.Margin = new Padding(3, 2, 3, 2);
            BtnReceive.Name = "BtnReceive";
            BtnReceive.Size = new Size(115, 35);
            BtnReceive.TabIndex = 17;
            BtnReceive.Text = "Cargar de SQl";
            BtnReceive.UseVisualStyleBackColor = true;
            BtnReceive.Click += BtnReceive_Click;
            // 
            // BtnUpload
            // 
            BtnUpload.Location = new Point(74, 38);
            BtnUpload.Margin = new Padding(3, 2, 3, 2);
            BtnUpload.Name = "BtnUpload";
            BtnUpload.Size = new Size(115, 35);
            BtnUpload.TabIndex = 16;
            BtnUpload.Text = "Cargar Archivo";
            BtnUpload.UseVisualStyleBackColor = true;
            BtnUpload.Click += BtnUpload_Click;
            // 
            // DataGrideShowSql
            // 
            DataGrideShowSql.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrideShowSql.Dock = DockStyle.Right;
            DataGrideShowSql.Location = new Point(435, 2);
            DataGrideShowSql.Margin = new Padding(3, 2, 3, 2);
            DataGrideShowSql.MultiSelect = false;
            DataGrideShowSql.Name = "DataGrideShowSql";
            DataGrideShowSql.ReadOnly = true;
            DataGrideShowSql.RowHeadersWidth = 51;
            DataGrideShowSql.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DataGrideShowSql.Size = new Size(1035, 640);
            DataGrideShowSql.TabIndex = 5;
            // 
            // BtnFillTreeView
            // 
            BtnFillTreeView.Location = new Point(74, 103);
            BtnFillTreeView.Margin = new Padding(3, 2, 3, 2);
            BtnFillTreeView.Name = "BtnFillTreeView";
            BtnFillTreeView.Size = new Size(115, 35);
            BtnFillTreeView.TabIndex = 20;
            BtnFillTreeView.Text = "Graficar Arbol";
            BtnFillTreeView.UseVisualStyleBackColor = true;
            BtnFillTreeView.Click += BtnFillTreeView_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 672);
            Controls.Add(TabControlOption);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            TabControlOption.ResumeLayout(false);
            TabPageArchive.ResumeLayout(false);
            TabPageArchive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxGameIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGrideShowData).EndInit();
            TabPageView.ResumeLayout(false);
            TabPageView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGrideViewShowData).EndInit();
            TabPageSQL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGrideShowSql).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControlOption;
        private TabPage TabPageArchive;
        private TabPage TabPageView;
        private TabPage TabPageSQL;
        private DataGridView DataGrideShowData;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Label label2;
        private TextBox TextBoxName;
        private PictureBox PictureBoxGameIcon;
        private Label label3;
        private Button BtnSearchName;
        private DataGridViewTextBoxColumn Column6;
        private DataGridView DataGrideViewShowData;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Button BtnSave;
        private Button BtnLoad;
        private Button BtnSaveData;
        private Label label5;
        private Label label4;
        private ComboBox ComBoxFormat;
        private Label label6;
        private ComboBox ComBoxFormat_Ver;
        private Button BtnDelet;
        private Label label1;
        private ComboBox ComBoxTypeExport;
        private Button BtnExport;
        private DataGridView DataGrideShowSql;
        private Button BtnUpload;
        private Label label11;
        private Label label10;
        private ScottPlot.WinForms.FormsPlot FomPlotPlatform;
        private ScottPlot.WinForms.FormsPlot FromPlotGenre;
        private Label label9;
        private Button button2;
        private TreeView TreeViewSql;
        private Button BtnSend;
        private Button BtnReceive;
        private TextBox TxtFilter;
        private Label label7;
        private TextBox TextBoxUser;
        private Button BtnSeend;
        private Button BtnFillTreeView;
    }
}
