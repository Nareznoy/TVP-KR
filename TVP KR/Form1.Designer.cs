namespace TVP_KR
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
      this.pictureBoxPetriNet = new System.Windows.Forms.PictureBox();
      this.btnAddVertex = new System.Windows.Forms.Button();
      this.btnRemoveVertex = new System.Windows.Forms.Button();
      this.btnAddTransition = new System.Windows.Forms.Button();
      this.radBtnVertical = new System.Windows.Forms.RadioButton();
      this.radBtnHorizontal = new System.Windows.Forms.RadioButton();
      this.btnAddPosition = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.btnAddEdge = new System.Windows.Forms.Button();
      this.lblTransitionInfo = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnSimulate = new System.Windows.Forms.Button();
      this.btnRemoveTransition = new System.Windows.Forms.Button();
      this.btnDoStep = new System.Windows.Forms.Button();
      this.btnExport = new System.Windows.Forms.Button();
      this.btnImport = new System.Windows.Forms.Button();
      this.btnRemovePosition = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPetriNet)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBoxPetriNet
      // 
      this.pictureBoxPetriNet.BackColor = System.Drawing.SystemColors.Window;
      this.pictureBoxPetriNet.Location = new System.Drawing.Point(12, 12);
      this.pictureBoxPetriNet.Name = "pictureBoxPetriNet";
      this.pictureBoxPetriNet.Size = new System.Drawing.Size(851, 666);
      this.pictureBoxPetriNet.TabIndex = 0;
      this.pictureBoxPetriNet.TabStop = false;
      this.pictureBoxPetriNet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPetriNet_MouseClick);
      // 
      // btnAddVertex
      // 
      this.btnAddVertex.Location = new System.Drawing.Point(1025, 12);
      this.btnAddVertex.Name = "btnAddVertex";
      this.btnAddVertex.Size = new System.Drawing.Size(111, 23);
      this.btnAddVertex.TabIndex = 1;
      this.btnAddVertex.Text = "Add Vertex";
      this.btnAddVertex.UseVisualStyleBackColor = true;
      this.btnAddVertex.Click += new System.EventHandler(this.btnAddVertex_Click);
      // 
      // btnRemoveVertex
      // 
      this.btnRemoveVertex.Location = new System.Drawing.Point(1025, 41);
      this.btnRemoveVertex.Name = "btnRemoveVertex";
      this.btnRemoveVertex.Size = new System.Drawing.Size(111, 23);
      this.btnRemoveVertex.TabIndex = 2;
      this.btnRemoveVertex.Text = "Remove Vertex";
      this.btnRemoveVertex.UseVisualStyleBackColor = true;
      this.btnRemoveVertex.Click += new System.EventHandler(this.btnRemoveVertex_Click);
      // 
      // btnAddTransition
      // 
      this.btnAddTransition.Location = new System.Drawing.Point(1025, 80);
      this.btnAddTransition.Name = "btnAddTransition";
      this.btnAddTransition.Size = new System.Drawing.Size(111, 23);
      this.btnAddTransition.TabIndex = 3;
      this.btnAddTransition.Text = "Add Transition";
      this.btnAddTransition.UseVisualStyleBackColor = true;
      this.btnAddTransition.Click += new System.EventHandler(this.btnAddTransition_Click);
      // 
      // radBtnVertical
      // 
      this.radBtnVertical.AutoSize = true;
      this.radBtnVertical.Location = new System.Drawing.Point(1137, 93);
      this.radBtnVertical.Name = "radBtnVertical";
      this.radBtnVertical.Size = new System.Drawing.Size(60, 17);
      this.radBtnVertical.TabIndex = 4;
      this.radBtnVertical.Text = "Vertical";
      this.radBtnVertical.UseVisualStyleBackColor = true;
      // 
      // radBtnHorizontal
      // 
      this.radBtnHorizontal.AutoSize = true;
      this.radBtnHorizontal.Checked = true;
      this.radBtnHorizontal.Location = new System.Drawing.Point(1137, 70);
      this.radBtnHorizontal.Name = "radBtnHorizontal";
      this.radBtnHorizontal.Size = new System.Drawing.Size(72, 17);
      this.radBtnHorizontal.TabIndex = 5;
      this.radBtnHorizontal.TabStop = true;
      this.radBtnHorizontal.Text = "Horizontal";
      this.radBtnHorizontal.UseVisualStyleBackColor = true;
      this.radBtnHorizontal.CheckedChanged += new System.EventHandler(this.radBtnHorizontal_CheckedChanged);
      // 
      // btnAddPosition
      // 
      this.btnAddPosition.Location = new System.Drawing.Point(869, 12);
      this.btnAddPosition.Name = "btnAddPosition";
      this.btnAddPosition.Size = new System.Drawing.Size(134, 52);
      this.btnAddPosition.TabIndex = 6;
      this.btnAddPosition.Text = "Добавить позицию";
      this.btnAddPosition.UseVisualStyleBackColor = true;
      this.btnAddPosition.Click += new System.EventHandler(this.btnAddPosition_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(869, 70);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(134, 52);
      this.button2.TabIndex = 8;
      this.button2.Text = "Граф достижимости";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // btnAddEdge
      // 
      this.btnAddEdge.Location = new System.Drawing.Point(1025, 211);
      this.btnAddEdge.Name = "btnAddEdge";
      this.btnAddEdge.Size = new System.Drawing.Size(111, 23);
      this.btnAddEdge.TabIndex = 9;
      this.btnAddEdge.Text = "Add Edge";
      this.btnAddEdge.UseVisualStyleBackColor = true;
      this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
      // 
      // lblTransitionInfo
      // 
      this.lblTransitionInfo.AutoSize = true;
      this.lblTransitionInfo.Location = new System.Drawing.Point(986, 266);
      this.lblTransitionInfo.Name = "lblTransitionInfo";
      this.lblTransitionInfo.Size = new System.Drawing.Size(0, 13);
      this.lblTransitionInfo.TabIndex = 11;
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(1025, 269);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(111, 23);
      this.btnClear.TabIndex = 12;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnSimulate
      // 
      this.btnSimulate.BackColor = System.Drawing.Color.LightGreen;
      this.btnSimulate.Location = new System.Drawing.Point(869, 135);
      this.btnSimulate.Name = "btnSimulate";
      this.btnSimulate.Size = new System.Drawing.Size(134, 52);
      this.btnSimulate.TabIndex = 13;
      this.btnSimulate.Text = "Старт";
      this.btnSimulate.UseVisualStyleBackColor = false;
      this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
      // 
      // btnRemoveTransition
      // 
      this.btnRemoveTransition.Location = new System.Drawing.Point(1025, 109);
      this.btnRemoveTransition.Name = "btnRemoveTransition";
      this.btnRemoveTransition.Size = new System.Drawing.Size(111, 23);
      this.btnRemoveTransition.TabIndex = 14;
      this.btnRemoveTransition.Text = "Remove Transition";
      this.btnRemoveTransition.UseVisualStyleBackColor = true;
      this.btnRemoveTransition.Click += new System.EventHandler(this.btnRemoveTransition_Click);
      // 
      // btnDoStep
      // 
      this.btnDoStep.BackColor = System.Drawing.Color.PaleGoldenrod;
      this.btnDoStep.Location = new System.Drawing.Point(869, 193);
      this.btnDoStep.Name = "btnDoStep";
      this.btnDoStep.Size = new System.Drawing.Size(134, 52);
      this.btnDoStep.TabIndex = 15;
      this.btnDoStep.Text = "Шаг";
      this.btnDoStep.UseVisualStyleBackColor = false;
      this.btnDoStep.Click += new System.EventHandler(this.btnDoStep_Click);
      // 
      // btnExport
      // 
      this.btnExport.Location = new System.Drawing.Point(1025, 240);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new System.Drawing.Size(75, 23);
      this.btnExport.TabIndex = 16;
      this.btnExport.Text = "Export";
      this.btnExport.UseVisualStyleBackColor = true;
      this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
      // 
      // btnImport
      // 
      this.btnImport.Location = new System.Drawing.Point(1106, 240);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new System.Drawing.Size(75, 23);
      this.btnImport.TabIndex = 17;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
      // 
      // btnRemovePosition
      // 
      this.btnRemovePosition.Location = new System.Drawing.Point(1025, 182);
      this.btnRemovePosition.Name = "btnRemovePosition";
      this.btnRemovePosition.Size = new System.Drawing.Size(111, 23);
      this.btnRemovePosition.TabIndex = 7;
      this.btnRemovePosition.Text = "Remove Position";
      this.btnRemovePosition.UseVisualStyleBackColor = true;
      this.btnRemovePosition.Click += new System.EventHandler(this.btnRemovePosition_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1221, 690);
      this.Controls.Add(this.btnImport);
      this.Controls.Add(this.btnExport);
      this.Controls.Add(this.btnDoStep);
      this.Controls.Add(this.btnRemoveTransition);
      this.Controls.Add(this.btnSimulate);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.lblTransitionInfo);
      this.Controls.Add(this.btnAddEdge);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btnRemovePosition);
      this.Controls.Add(this.btnAddPosition);
      this.Controls.Add(this.radBtnHorizontal);
      this.Controls.Add(this.radBtnVertical);
      this.Controls.Add(this.btnAddTransition);
      this.Controls.Add(this.btnRemoveVertex);
      this.Controls.Add(this.btnAddVertex);
      this.Controls.Add(this.pictureBoxPetriNet);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPetriNet)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.PictureBox pictureBoxPetriNet;
    private System.Windows.Forms.Button btnAddVertex;
    private System.Windows.Forms.Button btnRemoveVertex;
    private System.Windows.Forms.Button btnAddTransition;
    private System.Windows.Forms.RadioButton radBtnVertical;
    private System.Windows.Forms.RadioButton radBtnHorizontal;
    private System.Windows.Forms.Button btnAddPosition;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button btnAddEdge;
    private System.Windows.Forms.Label lblTransitionInfo;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnSimulate;
    private System.Windows.Forms.Button btnRemoveTransition;
    private System.Windows.Forms.Button btnDoStep;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.Button btnImport;
    private System.Windows.Forms.Button btnRemovePosition;
  }
}

