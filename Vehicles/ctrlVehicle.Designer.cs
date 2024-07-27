namespace VehicleRentalManagmentSystem.Vehicles
{
    partial class ctrlVehicle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlVehicle));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.pnlVehicle = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.lblPricePerDay = new System.Windows.Forms.Label();
            this.btnSelect = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.lblVehicleName = new System.Windows.Forms.Label();
            this.pbVehicleImage = new System.Windows.Forms.PictureBox();
            this.pnlVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlVehicle
            // 
            this.pnlVehicle.BackColor = System.Drawing.Color.Transparent;
            this.pnlVehicle.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.pnlVehicle.BorderRadius = 1;
            this.pnlVehicle.BorderThickness = 1;
            this.pnlVehicle.Controls.Add(this.lblPricePerDay);
            this.pnlVehicle.Controls.Add(this.btnSelect);
            this.pnlVehicle.Controls.Add(this.lblVehicleName);
            this.pnlVehicle.Controls.Add(this.pbVehicleImage);
            this.pnlVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVehicle.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
            this.pnlVehicle.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
            this.pnlVehicle.Location = new System.Drawing.Point(0, 0);
            this.pnlVehicle.Name = "pnlVehicle";
            this.pnlVehicle.PanelColor = System.Drawing.Color.WhiteSmoke;
            this.pnlVehicle.PanelColor2 = System.Drawing.Color.WhiteSmoke;
            this.pnlVehicle.ShadowColor = System.Drawing.Color.DarkGray;
            this.pnlVehicle.ShadowDept = 2;
            this.pnlVehicle.ShadowDepth = 5;
            this.pnlVehicle.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
            this.pnlVehicle.ShadowTopLeftVisible = false;
            this.pnlVehicle.Size = new System.Drawing.Size(190, 260);
            this.pnlVehicle.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
            this.pnlVehicle.TabIndex = 0;
            // 
            // lblPricePerDay
            // 
            this.lblPricePerDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPricePerDay.AutoSize = true;
            this.lblPricePerDay.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPricePerDay.Location = new System.Drawing.Point(48, 188);
            this.lblPricePerDay.Name = "lblPricePerDay";
            this.lblPricePerDay.Size = new System.Drawing.Size(95, 18);
            this.lblPricePerDay.TabIndex = 20;
            this.lblPricePerDay.Text = "Price Per Day";
            this.lblPricePerDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelect
            // 
            this.btnSelect.AllowAnimations = true;
            this.btnSelect.AllowMouseEffects = true;
            this.btnSelect.AllowToggling = false;
            this.btnSelect.AnimationSpeed = 200;
            this.btnSelect.AutoGenerateColors = false;
            this.btnSelect.AutoRoundBorders = false;
            this.btnSelect.AutoSizeLeftIcon = true;
            this.btnSelect.AutoSizeRightIcon = true;
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelect.BackgroundImage")));
            this.btnSelect.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSelect.ButtonText = "Select";
            this.btnSelect.ButtonTextMarginLeft = 0;
            this.btnSelect.ColorContrastOnClick = 45;
            this.btnSelect.ColorContrastOnHover = 45;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnSelect.CustomizableEdges = borderEdges2;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSelect.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSelect.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSelect.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSelect.IconLeftPadding = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnSelect.IconMarginLeft = 11;
            this.btnSelect.IconPadding = 10;
            this.btnSelect.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSelect.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSelect.IconSize = 35;
            this.btnSelect.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(191)))), ((int)(((byte)(202)))));
            this.btnSelect.IdleBorderRadius = 30;
            this.btnSelect.IdleBorderThickness = 1;
            this.btnSelect.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnSelect.IdleIconLeftImage = null;
            this.btnSelect.IdleIconRightImage = null;
            this.btnSelect.IndicateFocus = false;
            this.btnSelect.Location = new System.Drawing.Point(35, 215);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSelect.OnDisabledState.BorderRadius = 30;
            this.btnSelect.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSelect.OnDisabledState.BorderThickness = 1;
            this.btnSelect.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSelect.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSelect.OnDisabledState.IconLeftImage = null;
            this.btnSelect.OnDisabledState.IconRightImage = null;
            this.btnSelect.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnSelect.onHoverState.BorderRadius = 30;
            this.btnSelect.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSelect.onHoverState.BorderThickness = 1;
            this.btnSelect.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnSelect.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSelect.onHoverState.IconLeftImage = null;
            this.btnSelect.onHoverState.IconRightImage = null;
            this.btnSelect.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(191)))), ((int)(((byte)(202)))));
            this.btnSelect.OnIdleState.BorderRadius = 30;
            this.btnSelect.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSelect.OnIdleState.BorderThickness = 1;
            this.btnSelect.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnSelect.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSelect.OnIdleState.IconLeftImage = null;
            this.btnSelect.OnIdleState.IconRightImage = null;
            this.btnSelect.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnSelect.OnPressedState.BorderRadius = 30;
            this.btnSelect.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSelect.OnPressedState.BorderThickness = 1;
            this.btnSelect.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.btnSelect.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSelect.OnPressedState.IconLeftImage = null;
            this.btnSelect.OnPressedState.IconRightImage = null;
            this.btnSelect.Size = new System.Drawing.Size(114, 31);
            this.btnSelect.TabIndex = 19;
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelect.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSelect.TextMarginLeft = 0;
            this.btnSelect.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSelect.UseDefaultRadiusAndThickness = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblVehicleName
            // 
            this.lblVehicleName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVehicleName.AutoSize = true;
            this.lblVehicleName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleName.Location = new System.Drawing.Point(38, 128);
            this.lblVehicleName.MaximumSize = new System.Drawing.Size(120, 0);
            this.lblVehicleName.Name = "lblVehicleName";
            this.lblVehicleName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVehicleName.Size = new System.Drawing.Size(115, 19);
            this.lblVehicleName.TabIndex = 1;
            this.lblVehicleName.Text = "VehicleName";
            this.lblVehicleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbVehicleImage
            // 
            this.pbVehicleImage.Location = new System.Drawing.Point(40, 24);
            this.pbVehicleImage.Name = "pbVehicleImage";
            this.pbVehicleImage.Size = new System.Drawing.Size(100, 80);
            this.pbVehicleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVehicleImage.TabIndex = 0;
            this.pbVehicleImage.TabStop = false;
            // 
            // ctrlVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlVehicle);
            this.Name = "ctrlVehicle";
            this.Size = new System.Drawing.Size(190, 260);
            this.pnlVehicle.ResumeLayout(false);
            this.pnlVehicle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuShadowPanel pnlVehicle;
        private System.Windows.Forms.Label lblPricePerDay;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSelect;
        private System.Windows.Forms.Label lblVehicleName;
        private System.Windows.Forms.PictureBox pbVehicleImage;
    }
}
