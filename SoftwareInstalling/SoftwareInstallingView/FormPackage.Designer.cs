
namespace SoftwareInstallingView
{
    partial class FormPackage
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
			this.LabelName = new System.Windows.Forms.Label();
			this.labelPrice = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.labelComponents = new System.Windows.Forms.Label();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.buttonRef = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// LabelName
			// 
			this.LabelName.AutoSize = true;
			this.LabelName.Location = new System.Drawing.Point(83, 18);
			this.LabelName.Name = "LabelName";
			this.LabelName.Size = new System.Drawing.Size(63, 13);
			this.LabelName.TabIndex = 0;
			this.LabelName.Text = "Название: ";
			// 
			// labelPrice
			// 
			this.labelPrice.AutoSize = true;
			this.labelPrice.Location = new System.Drawing.Point(83, 54);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(39, 13);
			this.labelPrice.TabIndex = 1;
			this.labelPrice.Text = "Цена: ";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(171, 15);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(144, 20);
			this.textBoxName.TabIndex = 2;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(171, 54);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(73, 20);
			this.textBoxPrice.TabIndex = 3;
			// 
			// dataGridView
			// 
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.Count});
			this.dataGridView.Location = new System.Drawing.Point(6, 19);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(448, 260);
			this.dataGridView.TabIndex = 4;
			// 
			// Component
			// 
			this.Component.HeaderText = "Компонент";
			this.Component.Name = "Component";
			this.Component.Width = 280;
			// 
			// Count
			// 
			this.Count.HeaderText = "Количество";
			this.Count.Name = "Count";
			this.Count.Width = 130;
			// 
			// labelComponents
			// 
			this.labelComponents.AutoSize = true;
			this.labelComponents.Location = new System.Drawing.Point(83, 84);
			this.labelComponents.Name = "labelComponents";
			this.labelComponents.Size = new System.Drawing.Size(74, 13);
			this.labelComponents.TabIndex = 5;
			this.labelComponents.Text = "Компоненты:";
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.buttonRef);
			this.groupBox.Controls.Add(this.dataGridView);
			this.groupBox.Controls.Add(this.buttonDel);
			this.groupBox.Controls.Add(this.buttonAdd);
			this.groupBox.Controls.Add(this.buttonUpd);
			this.groupBox.Location = new System.Drawing.Point(86, 103);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(558, 284);
			this.groupBox.TabIndex = 8;
			this.groupBox.TabStop = false;
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(477, 172);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(75, 23);
			this.buttonRef.TabIndex = 12;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(477, 127);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(75, 23);
			this.buttonDel.TabIndex = 11;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(477, 44);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 9;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(477, 86);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(75, 23);
			this.buttonUpd.TabIndex = 10;
			this.buttonUpd.Text = "Изменить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(465, 394);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 13;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(563, 394);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 14;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormPackage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 429);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.labelComponents);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.LabelName);
			this.Name = "FormPackage";
			this.Text = "Пакет";
			this.Load += new System.EventHandler(this.FormProduct_Load);
			this.Click += new System.EventHandler(this.FormProduct_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.groupBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelComponents;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridViewTextBoxColumn Component;
		private System.Windows.Forms.DataGridViewTextBoxColumn Count;
	}
}