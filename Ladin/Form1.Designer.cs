private void InitializeComponent()
{
    this.tabControl1 = new System.Windows.Forms.TabControl();
    this.tabPage1 = new System.Windows.Forms.TabPage();
    this.panelGroupHeader = new System.Windows.Forms.Panel();
    this.lblGroup = new System.Windows.Forms.Label();
    this.cmbGroups = new System.Windows.Forms.ComboBox();
    this.btnNewGroup = new System.Windows.Forms.Button();
    this.panelStudents = new System.Windows.Forms.Panel();
    this.lstStudents = new System.Windows.Forms.ListBox();
    this.panelStudentActions = new System.Windows.Forms.Panel();
    this.lblStudentName = new System.Windows.Forms.Label();
    this.txtStudentName = new System.Windows.Forms.TextBox();
    this.btnAddStudent = new System.Windows.Forms.Button();
    this.btnEditStudent = new System.Windows.Forms.Button();
    this.btnDeleteStudent = new System.Windows.Forms.Button();
    this.btnSaveGroup = new System.Windows.Forms.Button();
    this.tabPage2 = new System.Windows.Forms.TabPage();
    this.lstCommonList = new System.Windows.Forms.ListBox();
    this.panelCommonActions = new System.Windows.Forms.Panel();
    this.btnCreateCommonList = new System.Windows.Forms.Button();
    this.btnSaveCommonList = new System.Windows.Forms.Button();
    this.lblCommonInfo = new System.Windows.Forms.Label();
    this.tabControl1.SuspendLayout();
    this.tabPage1.SuspendLayout();
    this.panelGroupHeader.SuspendLayout();
    this.panelStudents.SuspendLayout();
    this.panelStudentActions.SuspendLayout();
    this.tabPage2.SuspendLayout();
    this.panelCommonActions.SuspendLayout();
    this.SuspendLayout();

    // 
    // tabControl1
    // 
    this.tabControl1.Controls.Add(this.tabPage1);
    this.tabControl1.Controls.Add(this.tabPage2);
    this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
    this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
    this.tabControl1.ItemSize = new System.Drawing.Size(240, 36);
    this.tabControl1.Location = new System.Drawing.Point(0, 0);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.Padding = new System.Drawing.Point(12, 8);
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new System.Drawing.Size(1044, 681);
    this.tabControl1.TabIndex = 0;

    // 
    // tabPage1
    // 
    this.tabPage1.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
    this.tabPage1.Controls.Add(this.panelGroupHeader);
    this.tabPage1.Controls.Add(this.panelStudents);
    this.tabPage1.Controls.Add(this.panelStudentActions);
    this.tabPage1.Controls.Add(this.btnSaveGroup);
    this.tabPage1.Location = new System.Drawing.Point(4, 40);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new System.Windows.Forms.Padding(16);
    this.tabPage1.Size = new System.Drawing.Size(1036, 637);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "📁  Управление группой";

    // 
    // panelGroupHeader
    // 
    this.panelGroupHeader.BackColor = System.Drawing.Color.White;
    this.panelGroupHeader.Controls.Add(this.lblGroup);
    this.panelGroupHeader.Controls.Add(this.cmbGroups);
    this.panelGroupHeader.Controls.Add(this.btnNewGroup);
    this.panelGroupHeader.Dock = System.Windows.Forms.DockStyle.Top;
    this.panelGroupHeader.Location = new System.Drawing.Point(16, 16);
    this.panelGroupHeader.Name = "panelGroupHeader";
    this.panelGroupHeader.Padding = new System.Windows.Forms.Padding(16);
    this.panelGroupHeader.Size = new System.Drawing.Size(1004, 100);
    this.panelGroupHeader.TabIndex = 10;

    // 
    // lblGroup
    // 
    this.lblGroup.AutoSize = true;
    this.lblGroup.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.lblGroup.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
    this.lblGroup.Location = new System.Drawing.Point(16, 16);
    this.lblGroup.Name = "lblGroup";
    this.lblGroup.Size = new System.Drawing.Size(140, 21);
    this.lblGroup.TabIndex = 0;
    this.lblGroup.Text = "Выберите группу:";

    // 
    // cmbGroups
    // 
    this.cmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    this.cmbGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.cmbGroups.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
    this.cmbGroups.Location = new System.Drawing.Point(16, 45);
    this.cmbGroups.Name = "cmbGroups";
    this.cmbGroups.Size = new System.Drawing.Size(280, 33);
    this.cmbGroups.TabIndex = 1;
    this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);

    // 
    // btnNewGroup
    // 
    this.btnNewGroup.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
    this.btnNewGroup.FlatAppearance.BorderSize = 0;
    this.btnNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.btnNewGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.btnNewGroup.ForeColor = System.Drawing.Color.White;
    this.btnNewGroup.Location = new System.Drawing.Point(320, 42);
    this.btnNewGroup.Name = "btnNewGroup";
    this.btnNewGroup.Size = new System.Drawing.Size(200, 40);
    this.btnNewGroup.TabIndex = 2;
    this.btnNewGroup.Text = "➕  Новая группа";
    this.btnNewGroup.UseVisualStyleBackColor = false;
    this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);

    // 
    // panelStudents
    // 
    this.panelStudents.BackColor = System.Drawing.Color.White;
    this.panelStudents.Controls.Add(this.lstStudents);
    this.panelStudents.Dock = System.Windows.Forms.DockStyle.Left;
    this.panelStudents.Location = new System.Drawing.Point(16, 116);
    this.panelStudents.Name = "panelStudents";
    this.panelStudents.Padding = new System.Windows.Forms.Padding(12);
    this.panelStudents.Size = new System.Drawing.Size(494, 445);
    this.panelStudents.TabIndex = 11;

    // 
    // lstStudents
    // 
    this.lstStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.lstStudents.Dock = System.Windows.Forms.DockStyle.Fill;
    this.lstStudents.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
    this.lstStudents.ItemHeight = 28;
    this.lstStudents.Location = new System.Drawing.Point(12, 12);
    this.lstStudents.Name = "lstStudents";
    this.lstStudents.Size = new System.Drawing.Size(470, 421);
    this.lstStudents.TabIndex = 3;
    this.lstStudents.SelectedIndexChanged += new System.EventHandler(this.lstStudents_SelectedIndexChanged);

    // 
    // panelStudentActions
    // 
    this.panelStudentActions.BackColor = System.Drawing.Color.White;
    this.panelStudentActions.Controls.Add(this.lblStudentName);
    this.panelStudentActions.Controls.Add(this.txtStudentName);
    this.panelStudentActions.Controls.Add(this.btnAddStudent);
    this.panelStudentActions.Controls.Add(this.btnEditStudent);
    this.panelStudentActions.Controls.Add(this.btnDeleteStudent);
    this.panelStudentActions.Dock = System.Windows.Forms.DockStyle.Right;
    this.panelStudentActions.Location = new System.Drawing.Point(530, 116);
    this.panelStudentActions.Name = "panelStudentActions";
    this.panelStudentActions.Padding = new System.Windows.Forms.Padding(24);
    this.panelStudentActions.Size = new System.Drawing.Size(490, 445);
    this.panelStudentActions.TabIndex = 12;

    // 
    // lblStudentName
    // 
    this.lblStudentName.AutoSize = true;
    this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
    this.lblStudentName.Location = new System.Drawing.Point(24, 24);
    this.lblStudentName.Name = "lblStudentName";
    this.lblStudentName.Size = new System.Drawing.Size(129, 21);
    this.lblStudentName.TabIndex = 4;
    this.lblStudentName.Text = "ФИО студента:";

    // 
    // txtStudentName
    // 
    this.txtStudentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.txtStudentName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
    this.txtStudentName.Location = new System.Drawing.Point(24, 55);
    this.txtStudentName.Name = "txtStudentName";
    this.txtStudentName.Size = new System.Drawing.Size(442, 32);
    this.txtStudentName.TabIndex = 5;

    // 
    // btnAddStudent
    // 
    this.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
    this.btnAddStudent.FlatAppearance.BorderSize = 0;
    this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.btnAddStudent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.btnAddStudent.ForeColor = System.Drawing.Color.White;
    this.btnAddStudent.Location = new System.Drawing.Point(24, 110);
    this.btnAddStudent.Name = "btnAddStudent";
    this.btnAddStudent.Size = new System.Drawing.Size(200, 42);
    this.btnAddStudent.TabIndex = 6;
    this.btnAddStudent.Text = "➕  Добавить";
    this.btnAddStudent.UseVisualStyleBackColor = false;
    this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);

    // 
    // btnEditStudent
    // 
    this.btnEditStudent.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
    this.btnEditStudent.FlatAppearance.BorderSize = 0;
    this.btnEditStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.btnEditStudent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.btnEditStudent.ForeColor = System.Drawing.Color.White;
    this.btnEditStudent.Location = new System.Drawing.Point(240, 110);
    this.btnEditStudent.Name = "btnEditStudent";
    this.btnEditStudent.Size = new System.Drawing.Size(226, 42);
    this.btnEditStudent.TabIndex = 7;
    this.btnEditStudent.Text = "✏️  Редактировать";
    this.btnEditStudent.UseVisualStyleBackColor = false;
    this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);

    // 
    // btnDeleteStudent
    // 
    this.btnDeleteStudent.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
    this.btnDeleteStudent.FlatAppearance.BorderSize = 0;
    this.btnDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.btnDeleteStudent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.btnDeleteStudent.ForeColor = System.Drawing.Color.White;
    this.btnDeleteStudent.Location = new System.Drawing.Point(24, 170);
    this.btnDeleteStudent.Name = "btnDeleteStudent";
    this.btnDeleteStudent.Size = new System.Drawing.Size(200, 42);
    this.btnDeleteStudent.TabIndex = 8;
    this.btnDeleteStudent.Text = "🗑  Удалить";
    this.btnDeleteStudent.UseVisualStyleBackColor = false;
    this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);

    // 
    // btnSaveGroup
    // 
    this.btnSaveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
    this.btnSaveGroup.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
    this.btnSaveGroup.FlatAppearance.BorderSize = 0;
    this.btnSaveGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.btnSaveGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.btnSaveGroup.ForeColor = System.Drawing.Color.White;
    this.btnSaveGroup.Location = new System.Drawing.Point(16, 577);
    this.btnSaveGroup.Name = "btnSaveGroup";
    this.btnSaveGroup.Size = new System.Drawing.Size(1004, 45);
    this.btnSaveGroup.TabIndex = 9;
    this.btnSaveGroup.Text = "💾  Сохранить изменения в группе";
    this.btnSaveGroup.UseVisualStyleBackColor = false;
    this.btnSaveGroup.Click += new System.EventHandler(this.btnSaveGroup_Click);

    // 
    // tabPage2
    // 
    this.tabPage2.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
    this.tabPage2.Controls.Add(this.lstCommonList);
    this.tabPage2.Controls.Add(this.panelCommonActions);
    this.tabPage2.Controls.Add(this.lblCommonInfo);
    this.tabPage2.Location = new System.Drawing.Point(4, 40);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Padding = new System.Windows.Forms.Padding(16);
    this.tabPage2.Size = new System.Drawing.Size(1036, 637);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "📊  Общий список курса";

    // 
    // lstCommonList
    // 
    this.lstCommonList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.lstCommonList.Dock = System.Windows.Forms.DockStyle.Fill;
    this.lstCommonList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
    this.lstCommonList.ItemHeight = 28;
    this.lstCommonList.Location = new System.Drawing.Point(16, 116);
    this.lstCommonList.Name = "lstCommonList";
    this.lstCommonList.Size = new System.Drawing.Size(1004, 449);
    this.lstCommonList.TabIndex = 0;

    // 
    // panelCommonActions
    // 
    this.panelCommonActions.BackColor = System.Drawing.Color.White;
    this.panelCommonActions.Controls.Add(this.btnCreateCommonList);
    this.panelCommonActions.Controls.Add(this.btnSaveCommonList);
    this.panelCommonActions.Dock = System.Windows.Forms.DockStyle.Top;
    this.panelCommonActions.Location = new System.Drawing.Point(16, 16);
    this.panelCommonActions.Name = "panelCommonActions";
    this.panelCommonActions.Padding = new System.Windows.Forms.Padding(16);
    this.panelCommonActions.Size = new System.Drawing.Size(1004, 100);
    this.panelCommonActions.TabIndex = 4;

    // 
    // btnCreateCommonList
    // 
    this.btnCreateCommonList.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
    this.btnCreateCommonList.FlatAppearance.BorderSize = 0;
    this.btnCreateCommonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.btnCreateCommonList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.btnCreateCommonList.ForeColor = System.Drawing.Color.White;
    this.btnCreateCommonList.Location = new System.Drawing.Point(16, 30);
    this.btnCreateCommonList.Name = "btnCreateCommonList";
    this.btnCreateCommonList.Size = new System.Drawing.Size(300, 40);
    this.btnCreateCommonList.TabIndex = 1;
    this.btnCreateCommonList.Text = "📋  Создать общий список";
    this.btnCreateCommonList.UseVisualStyleBackColor = false;
    this.btnCreateCommonList.Click += new System.EventHandler(this.btnCreateCommonList_Click);

    // 
    // btnSaveCommonList
    // 
    this.btnSaveCommonList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
    this.btnSaveCommonList.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
    this.btnSaveCommonList.FlatAppearance.BorderSize = 0;
    this.btnSaveCommonList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
    this.btnSaveCommonList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
    this.btnSaveCommonList.ForeColor = System.Drawing.Color.White;
    this.btnSaveCommonList.Location = new System.Drawing.Point(688, 30);
    this.btnSaveCommonList.Name = "btnSaveCommonList";
    this.btnSaveCommonList.Size = new System.Drawing.Size(300, 40);
    this.btnSaveCommonList.TabIndex = 3;
    this.btnSaveCommonList.Text = "💾  Сохранить список";
    this.btnSaveCommonList.UseVisualStyleBackColor = false;
    this.btnSaveCommonList.Click += new System.EventHandler(this.btnSaveCommonList_Click);

    // 
    // lblCommonInfo
    // 
    this.lblCommonInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
    this.lblCommonInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
    this.lblCommonInfo.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
    this.lblCommonInfo.Location = new System.Drawing.Point(16, 565);
    this.lblCommonInfo.Name = "lblCommonInfo";
    this.lblCommonInfo.Padding = new System.Windows.Forms.Padding(8, 8, 0, 8);
    this.lblCommonInfo.Size = new System.Drawing.Size(1004, 56);
    this.lblCommonInfo.TabIndex = 2;
    this.lblCommonInfo.Text = "Нажмите «Создать общий список» для отображения данных";
    this.lblCommonInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

    // 
    // Form1
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
    this.ClientSize = new System.Drawing.Size(1044, 681);
    this.Controls.Add(this.tabControl1);
    this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
    this.Name = "Form1";
    this.Text = "Ladin – Управление студентами";
    this.tabControl1.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    this.panelGroupHeader.ResumeLayout(false);
    this.panelGroupHeader.PerformLayout();
    this.panelStudents.ResumeLayout(false);
    this.panelStudentActions.ResumeLayout(false);
    this.panelStudentActions.PerformLayout();
    this.tabPage2.ResumeLayout(false);
    this.panelCommonActions.ResumeLayout(false);
    this.ResumeLayout(false);
}