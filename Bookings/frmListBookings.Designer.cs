namespace VehicleRentalManagmentSystem.Bookings
{
    partial class frmListBookings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListBookings));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCustomerInfo = new System.Windows.Forms.Panel();
            this.dgvAllBookings = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBookingFilterValue = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnAddNewBooking = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtFilterValue = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnAddNewCustomer = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.View = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(38, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bookings";
            // 
            // pnlCustomerInfo
            // 
            this.pnlCustomerInfo.Controls.Add(this.dgvAllBookings);
            this.pnlCustomerInfo.Controls.Add(this.bunifuSeparator2);
            this.pnlCustomerInfo.Controls.Add(this.panel1);
            this.pnlCustomerInfo.Controls.Add(this.txtFilterValue);
            this.pnlCustomerInfo.Controls.Add(this.btnAddNewCustomer);
            this.pnlCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomerInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomerInfo.Name = "pnlCustomerInfo";
            this.pnlCustomerInfo.Size = new System.Drawing.Size(1135, 622);
            this.pnlCustomerInfo.TabIndex = 8;
            // 
            // dgvAllBookings
            // 
            this.dgvAllBookings.AllowCustomTheming = true;
            this.dgvAllBookings.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvAllBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAllBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllBookings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllBookings.ColumnHeadersHeight = 40;
            this.dgvAllBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.View,
            this.Delete});
            this.dgvAllBookings.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvAllBookings.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvAllBookings.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvAllBookings.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvAllBookings.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAllBookings.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvAllBookings.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvAllBookings.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.dgvAllBookings.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvAllBookings.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAllBookings.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.dgvAllBookings.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAllBookings.CurrentTheme.Name = null;
            this.dgvAllBookings.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllBookings.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvAllBookings.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvAllBookings.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvAllBookings.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllBookings.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllBookings.EnableHeadersVisualStyles = false;
            this.dgvAllBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvAllBookings.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.dgvAllBookings.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvAllBookings.HeaderForeColor = System.Drawing.Color.White;
            this.dgvAllBookings.Location = new System.Drawing.Point(44, 207);
            this.dgvAllBookings.Name = "dgvAllBookings";
            this.dgvAllBookings.ReadOnly = true;
            this.dgvAllBookings.RowHeadersVisible = false;
            this.dgvAllBookings.RowTemplate.Height = 40;
            this.dgvAllBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBookings.Size = new System.Drawing.Size(1069, 374);
            this.dgvAllBookings.TabIndex = 7;
            this.dgvAllBookings.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dgvAllBookings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllBookings_CellClick);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator2.BackgroundImage")));
            this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(44, 168);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator2.Size = new System.Drawing.Size(1069, 14);
            this.bunifuSeparator2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBookingFilterValue);
            this.panel1.Controls.Add(this.btnAddNewBooking);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 622);
            this.panel1.TabIndex = 8;
            // 
            // txtBookingFilterValue
            // 
            this.txtBookingFilterValue.AcceptsReturn = false;
            this.txtBookingFilterValue.AcceptsTab = false;
            this.txtBookingFilterValue.AnimationSpeed = 200;
            this.txtBookingFilterValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBookingFilterValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBookingFilterValue.BackColor = System.Drawing.Color.Transparent;
            this.txtBookingFilterValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBookingFilterValue.BackgroundImage")));
            this.txtBookingFilterValue.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtBookingFilterValue.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtBookingFilterValue.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtBookingFilterValue.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtBookingFilterValue.BorderRadius = 35;
            this.txtBookingFilterValue.BorderThickness = 1;
            this.txtBookingFilterValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBookingFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBookingFilterValue.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookingFilterValue.DefaultText = "";
            this.txtBookingFilterValue.FillColor = System.Drawing.Color.White;
            this.txtBookingFilterValue.HideSelection = true;
            this.txtBookingFilterValue.IconLeft = global::VehicleRentalManagmentSystem.Properties.Resources.search_interface_symbol;
            this.txtBookingFilterValue.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBookingFilterValue.IconPadding = 10;
            this.txtBookingFilterValue.IconRight = null;
            this.txtBookingFilterValue.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBookingFilterValue.Lines = new string[0];
            this.txtBookingFilterValue.Location = new System.Drawing.Point(44, 110);
            this.txtBookingFilterValue.MaxLength = 32767;
            this.txtBookingFilterValue.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBookingFilterValue.Modified = false;
            this.txtBookingFilterValue.Multiline = false;
            this.txtBookingFilterValue.Name = "txtBookingFilterValue";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBookingFilterValue.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBookingFilterValue.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBookingFilterValue.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBookingFilterValue.OnIdleState = stateProperties4;
            this.txtBookingFilterValue.Padding = new System.Windows.Forms.Padding(3);
            this.txtBookingFilterValue.PasswordChar = '\0';
            this.txtBookingFilterValue.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBookingFilterValue.PlaceholderText = "Full Name, License No.";
            this.txtBookingFilterValue.ReadOnly = false;
            this.txtBookingFilterValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBookingFilterValue.SelectedText = "";
            this.txtBookingFilterValue.SelectionLength = 0;
            this.txtBookingFilterValue.SelectionStart = 0;
            this.txtBookingFilterValue.ShortcutsEnabled = true;
            this.txtBookingFilterValue.Size = new System.Drawing.Size(327, 39);
            this.txtBookingFilterValue.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtBookingFilterValue.TabIndex = 1;
            this.txtBookingFilterValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBookingFilterValue.TextMarginBottom = 0;
            this.txtBookingFilterValue.TextMarginLeft = 3;
            this.txtBookingFilterValue.TextMarginTop = 0;
            this.txtBookingFilterValue.TextPlaceholder = "Full Name, License No.";
            this.txtBookingFilterValue.UseSystemPasswordChar = false;
            this.txtBookingFilterValue.WordWrap = true;
            // 
            // btnAddNewBooking
            // 
            this.btnAddNewBooking.AllowAnimations = true;
            this.btnAddNewBooking.AllowMouseEffects = true;
            this.btnAddNewBooking.AllowToggling = false;
            this.btnAddNewBooking.AnimationSpeed = 200;
            this.btnAddNewBooking.AutoGenerateColors = false;
            this.btnAddNewBooking.AutoRoundBorders = false;
            this.btnAddNewBooking.AutoSizeLeftIcon = true;
            this.btnAddNewBooking.AutoSizeRightIcon = true;
            this.btnAddNewBooking.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewBooking.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddNewBooking.BackgroundImage")));
            this.btnAddNewBooking.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewBooking.ButtonText = "New";
            this.btnAddNewBooking.ButtonTextMarginLeft = 0;
            this.btnAddNewBooking.ColorContrastOnClick = 45;
            this.btnAddNewBooking.ColorContrastOnHover = 45;
            this.btnAddNewBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAddNewBooking.CustomizableEdges = borderEdges1;
            this.btnAddNewBooking.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddNewBooking.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddNewBooking.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewBooking.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddNewBooking.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAddNewBooking.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewBooking.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBooking.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewBooking.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewBooking.IconLeftPadding = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnAddNewBooking.IconMarginLeft = 11;
            this.btnAddNewBooking.IconPadding = 10;
            this.btnAddNewBooking.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewBooking.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewBooking.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddNewBooking.IconSize = 35;
            this.btnAddNewBooking.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.IdleBorderRadius = 35;
            this.btnAddNewBooking.IdleBorderThickness = 1;
            this.btnAddNewBooking.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.IdleIconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewBooking.IdleIconRightImage = null;
            this.btnAddNewBooking.IndicateFocus = false;
            this.btnAddNewBooking.Location = new System.Drawing.Point(960, 110);
            this.btnAddNewBooking.Name = "btnAddNewBooking";
            this.btnAddNewBooking.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddNewBooking.OnDisabledState.BorderRadius = 35;
            this.btnAddNewBooking.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewBooking.OnDisabledState.BorderThickness = 1;
            this.btnAddNewBooking.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewBooking.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddNewBooking.OnDisabledState.IconLeftImage = null;
            this.btnAddNewBooking.OnDisabledState.IconRightImage = null;
            this.btnAddNewBooking.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.onHoverState.BorderRadius = 35;
            this.btnAddNewBooking.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewBooking.onHoverState.BorderThickness = 1;
            this.btnAddNewBooking.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBooking.onHoverState.IconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewBooking.onHoverState.IconRightImage = null;
            this.btnAddNewBooking.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.OnIdleState.BorderRadius = 35;
            this.btnAddNewBooking.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewBooking.OnIdleState.BorderThickness = 1;
            this.btnAddNewBooking.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBooking.OnIdleState.IconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewBooking.OnIdleState.IconRightImage = null;
            this.btnAddNewBooking.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.OnPressedState.BorderRadius = 35;
            this.btnAddNewBooking.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewBooking.OnPressedState.BorderThickness = 1;
            this.btnAddNewBooking.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewBooking.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBooking.OnPressedState.IconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewBooking.OnPressedState.IconRightImage = null;
            this.btnAddNewBooking.Size = new System.Drawing.Size(153, 39);
            this.btnAddNewBooking.TabIndex = 2;
            this.btnAddNewBooking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNewBooking.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddNewBooking.TextMarginLeft = 0;
            this.btnAddNewBooking.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAddNewBooking.UseDefaultRadiusAndThickness = true;
            this.btnAddNewBooking.Click += new System.EventHandler(this.btnAddNewBooking_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.AcceptsReturn = false;
            this.txtFilterValue.AcceptsTab = false;
            this.txtFilterValue.AnimationSpeed = 200;
            this.txtFilterValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtFilterValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtFilterValue.BackColor = System.Drawing.Color.Transparent;
            this.txtFilterValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtFilterValue.BackgroundImage")));
            this.txtFilterValue.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtFilterValue.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtFilterValue.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtFilterValue.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtFilterValue.BorderRadius = 35;
            this.txtFilterValue.BorderThickness = 1;
            this.txtFilterValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.FillColor = System.Drawing.Color.White;
            this.txtFilterValue.HideSelection = true;
            this.txtFilterValue.IconLeft = global::VehicleRentalManagmentSystem.Properties.Resources.search_interface_symbol;
            this.txtFilterValue.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.IconPadding = 10;
            this.txtFilterValue.IconRight = null;
            this.txtFilterValue.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.Lines = new string[0];
            this.txtFilterValue.Location = new System.Drawing.Point(44, 110);
            this.txtFilterValue.MaxLength = 32767;
            this.txtFilterValue.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFilterValue.Modified = false;
            this.txtFilterValue.Multiline = false;
            this.txtFilterValue.Name = "txtFilterValue";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFilterValue.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtFilterValue.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFilterValue.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtFilterValue.OnIdleState = stateProperties8;
            this.txtFilterValue.Padding = new System.Windows.Forms.Padding(3);
            this.txtFilterValue.PasswordChar = '\0';
            this.txtFilterValue.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtFilterValue.PlaceholderText = "Full Name, License No.";
            this.txtFilterValue.ReadOnly = false;
            this.txtFilterValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.SelectionLength = 0;
            this.txtFilterValue.SelectionStart = 0;
            this.txtFilterValue.ShortcutsEnabled = true;
            this.txtFilterValue.Size = new System.Drawing.Size(327, 39);
            this.txtFilterValue.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtFilterValue.TabIndex = 1;
            this.txtFilterValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFilterValue.TextMarginBottom = 0;
            this.txtFilterValue.TextMarginLeft = 3;
            this.txtFilterValue.TextMarginTop = 0;
            this.txtFilterValue.TextPlaceholder = "Full Name, License No.";
            this.txtFilterValue.UseSystemPasswordChar = false;
            this.txtFilterValue.WordWrap = true;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.AllowAnimations = true;
            this.btnAddNewCustomer.AllowMouseEffects = true;
            this.btnAddNewCustomer.AllowToggling = false;
            this.btnAddNewCustomer.AnimationSpeed = 200;
            this.btnAddNewCustomer.AutoGenerateColors = false;
            this.btnAddNewCustomer.AutoRoundBorders = false;
            this.btnAddNewCustomer.AutoSizeLeftIcon = true;
            this.btnAddNewCustomer.AutoSizeRightIcon = true;
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddNewCustomer.BackgroundImage")));
            this.btnAddNewCustomer.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewCustomer.ButtonText = "New";
            this.btnAddNewCustomer.ButtonTextMarginLeft = 0;
            this.btnAddNewCustomer.ColorContrastOnClick = 45;
            this.btnAddNewCustomer.ColorContrastOnHover = 45;
            this.btnAddNewCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnAddNewCustomer.CustomizableEdges = borderEdges2;
            this.btnAddNewCustomer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddNewCustomer.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddNewCustomer.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewCustomer.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddNewCustomer.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAddNewCustomer.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewCustomer.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewCustomer.IconLeftPadding = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnAddNewCustomer.IconMarginLeft = 11;
            this.btnAddNewCustomer.IconPadding = 10;
            this.btnAddNewCustomer.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewCustomer.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewCustomer.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddNewCustomer.IconSize = 35;
            this.btnAddNewCustomer.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.IdleBorderRadius = 35;
            this.btnAddNewCustomer.IdleBorderThickness = 1;
            this.btnAddNewCustomer.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.IdleIconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewCustomer.IdleIconRightImage = null;
            this.btnAddNewCustomer.IndicateFocus = false;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(960, 110);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddNewCustomer.OnDisabledState.BorderRadius = 35;
            this.btnAddNewCustomer.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewCustomer.OnDisabledState.BorderThickness = 1;
            this.btnAddNewCustomer.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewCustomer.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddNewCustomer.OnDisabledState.IconLeftImage = null;
            this.btnAddNewCustomer.OnDisabledState.IconRightImage = null;
            this.btnAddNewCustomer.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.onHoverState.BorderRadius = 35;
            this.btnAddNewCustomer.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewCustomer.onHoverState.BorderThickness = 1;
            this.btnAddNewCustomer.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.onHoverState.IconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewCustomer.onHoverState.IconRightImage = null;
            this.btnAddNewCustomer.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.OnIdleState.BorderRadius = 35;
            this.btnAddNewCustomer.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewCustomer.OnIdleState.BorderThickness = 1;
            this.btnAddNewCustomer.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.OnIdleState.IconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewCustomer.OnIdleState.IconRightImage = null;
            this.btnAddNewCustomer.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.OnPressedState.BorderRadius = 35;
            this.btnAddNewCustomer.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddNewCustomer.OnPressedState.BorderThickness = 1;
            this.btnAddNewCustomer.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnAddNewCustomer.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.OnPressedState.IconLeftImage = global::VehicleRentalManagmentSystem.Properties.Resources.add__5_;
            this.btnAddNewCustomer.OnPressedState.IconRightImage = null;
            this.btnAddNewCustomer.Size = new System.Drawing.Size(153, 39);
            this.btnAddNewCustomer.TabIndex = 2;
            this.btnAddNewCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNewCustomer.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddNewCustomer.TextMarginLeft = 0;
            this.btnAddNewCustomer.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAddNewCustomer.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(44, 168);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(1069, 14);
            this.bunifuSeparator1.TabIndex = 7;
            // 
            // View
            // 
            this.View.FillWeight = 58.36425F;
            this.View.HeaderText = "";
            this.View.Image = global::VehicleRentalManagmentSystem.Properties.Resources.view;
            this.View.Name = "View";
            this.View.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 152.2843F;
            this.Delete.HeaderText = "";
            this.Delete.Image = global::VehicleRentalManagmentSystem.Properties.Resources.delete;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // frmListBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1135, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlCustomerInfo);
            this.Controls.Add(this.bunifuSeparator1);
            this.Name = "frmListBookings";
            this.Text = "frmListBookings";
            this.Load += new System.EventHandler(this.frmListBookings_Load);
            this.pnlCustomerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCustomerInfo;
        private Bunifu.UI.WinForms.BunifuTextBox txtFilterValue;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAddNewCustomer;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvAllBookings;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuTextBox txtBookingFilterValue;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAddNewBooking;
        private System.Windows.Forms.DataGridViewImageColumn View;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}