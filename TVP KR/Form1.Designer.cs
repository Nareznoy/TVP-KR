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
      this.btnRemovePosition = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.btnAddEdge = new System.Windows.Forms.Button();
      this.btnCreatePTNet = new System.Windows.Forms.Button();
      this.lblTransitionInfo = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPetriNet)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBoxPetriNet
      // 
      this.pictureBoxPetriNet.BackColor = System.Drawing.SystemColors.Window;
      this.pictureBoxPetriNet.Location = new System.Drawing.Point(12, 12);
      this.pictureBoxPetriNet.Name = "pictureBoxPetriNet";
      this.pictureBoxPetriNet.Size = new System.Drawing.Size(851, 567);
      this.pictureBoxPetriNet.TabIndex = 0;
      this.pictureBoxPetriNet.TabStop = false;
      this.pictureBoxPetriNet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPetriNet_MouseClick);
      // 
      // btnAddVertex
      // 
      this.btnAddVertex.Location = new System.Drawing.Point(869, 12);
      this.btnAddVertex.Name = "btnAddVertex";
      this.btnAddVertex.Size = new System.Drawing.Size(111, 23);
      this.btnAddVertex.TabIndex = 1;
      this.btnAddVertex.Text = "Add Vertex";
      this.btnAddVertex.UseVisualStyleBackColor = true;
      this.btnAddVertex.Click += new System.EventHandler(this.btnAddVertex_Click);
      // 
      // btnRemoveVertex
      // 
      this.btnRemoveVertex.Location = new System.Drawing.Point(869, 41);
      this.btnRemoveVertex.Name = "btnRemoveVertex";
      this.btnRemoveVertex.Size = new System.Drawing.Size(111, 23);
      this.btnRemoveVertex.TabIndex = 2;
      this.btnRemoveVertex.Text = "Remove Vertex";
      this.btnRemoveVertex.UseVisualStyleBackColor = true;
      this.btnRemoveVertex.Click += new System.EventHandler(this.btnRemoveVertex_Click);
      // 
      // btnAddTransition
      // 
      this.btnAddTransition.Location = new System.Drawing.Point(869, 80);
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
      this.radBtnVertical.Location = new System.Drawing.Point(981, 93);
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
      this.radBtnHorizontal.Location = new System.Drawing.Point(981, 70);
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
      this.btnAddPosition.Location = new System.Drawing.Point(869, 121);
      this.btnAddPosition.Name = "btnAddPosition";
      this.btnAddPosition.Size = new System.Drawing.Size(111, 23);
      this.btnAddPosition.TabIndex = 6;
      this.btnAddPosition.Text = "Add Position";
      this.btnAddPosition.UseVisualStyleBackColor = true;
      this.btnAddPosition.Click += new System.EventHandler(this.btnAddPosition_Click);
      // 
      // btnRemovePosition
      // 
      this.btnRemovePosition.Location = new System.Drawing.Point(869, 150);
      this.btnRemovePosition.Name = "btnRemovePosition";
      this.btnRemovePosition.Size = new System.Drawing.Size(111, 23);
      this.btnRemovePosition.TabIndex = 7;
      this.btnRemovePosition.Text = "Remove Position";
      this.btnRemovePosition.UseVisualStyleBackColor = true;
      this.btnRemovePosition.Click += new System.EventHandler(this.btnRemovePosition_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(890, 331);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(111, 23);
      this.button2.TabIndex = 8;
      this.button2.Text = "Reachability Graph";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // btnAddEdge
      // 
      this.btnAddEdge.Location = new System.Drawing.Point(869, 179);
      this.btnAddEdge.Name = "btnAddEdge";
      this.btnAddEdge.Size = new System.Drawing.Size(111, 23);
      this.btnAddEdge.TabIndex = 9;
      this.btnAddEdge.Text = "Add Edge";
      this.btnAddEdge.UseVisualStyleBackColor = true;
      this.btnAddEdge.Click += new System.EventHandler(this.btnAddEdge_Click);
      // 
      // btnCreatePTNet
      // 
      this.btnCreatePTNet.Location = new System.Drawing.Point(869, 230);
      this.btnCreatePTNet.Name = "btnCreatePTNet";
      this.btnCreatePTNet.Size = new System.Drawing.Size(111, 23);
      this.btnCreatePTNet.TabIndex = 10;
      this.btnCreatePTNet.Text = "Create Petri Net";
      this.btnCreatePTNet.UseVisualStyleBackColor = true;
      this.btnCreatePTNet.Click += new System.EventHandler(this.btnCreatePTNet_Click);
      // 
      // lblTransitionInfo
      // 
      this.lblTransitionInfo.AutoSize = true;
      this.lblTransitionInfo.Location = new System.Drawing.Point(986, 235);
      this.lblTransitionInfo.Name = "lblTransitionInfo";
      this.lblTransitionInfo.Size = new System.Drawing.Size(0, 13);
      this.lblTransitionInfo.TabIndex = 11;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1112, 591);
      this.Controls.Add(this.lblTransitionInfo);
      this.Controls.Add(this.btnCreatePTNet);
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
    private System.Windows.Forms.Button btnRemovePosition;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button btnAddEdge;
    private System.Windows.Forms.Button btnCreatePTNet;
    private System.Windows.Forms.Label lblTransitionInfo;
  }
}

