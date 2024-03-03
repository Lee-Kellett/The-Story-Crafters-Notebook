<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnCreateEntry = New System.Windows.Forms.Button()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txbNotes = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.cbxCategories = New System.Windows.Forms.ComboBox()
        Me.lsbDisplay = New System.Windows.Forms.ListBox()
        Me.dtpOccurrence = New System.Windows.Forms.DateTimePicker()
        Me.lblPrivacyInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("High Tower Text", 22.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(93, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(408, 34)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "The Story Crafters Notebook"
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnLoad.Font = New System.Drawing.Font("High Tower Text", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnLoad.Location = New System.Drawing.Point(287, 343)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(180, 40)
        Me.btnLoad.TabIndex = 16
        Me.btnLoad.Text = "Load Entry List"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnCreateEntry
        '
        Me.btnCreateEntry.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnCreateEntry.Font = New System.Drawing.Font("High Tower Text", 12.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnCreateEntry.Location = New System.Drawing.Point(42, 366)
        Me.btnCreateEntry.Name = "btnCreateEntry"
        Me.btnCreateEntry.Size = New System.Drawing.Size(120, 33)
        Me.btnCreateEntry.TabIndex = 15
        Me.btnCreateEntry.Text = "Create Entry"
        Me.btnCreateEntry.UseVisualStyleBackColor = False
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.BackColor = System.Drawing.Color.Transparent
        Me.lblNotes.Font = New System.Drawing.Font("High Tower Text", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblNotes.Location = New System.Drawing.Point(29, 154)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(113, 18)
        Me.lblNotes.TabIndex = 14
        Me.lblNotes.Text = "Additional Notes:"
        '
        'txbNotes
        '
        Me.txbNotes.BackColor = System.Drawing.SystemColors.Control
        Me.txbNotes.Font = New System.Drawing.Font("Kristen ITC", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txbNotes.Location = New System.Drawing.Point(29, 175)
        Me.txbNotes.MaxLength = 84
        Me.txbNotes.Multiline = True
        Me.txbNotes.Name = "txbNotes"
        Me.txbNotes.Size = New System.Drawing.Size(143, 176)
        Me.txbNotes.TabIndex = 13
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("High Tower Text", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDate.Location = New System.Drawing.Point(29, 102)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(133, 18)
        Me.lblDate.TabIndex = 12
        Me.lblDate.Text = "Date of Occurrence:"
        '
        'cbxCategories
        '
        Me.cbxCategories.BackColor = System.Drawing.SystemColors.Control
        Me.cbxCategories.Font = New System.Drawing.Font("Kristen ITC", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cbxCategories.FormattingEnabled = True
        Me.cbxCategories.Items.AddRange(New Object() {"Towns", "Characters", "Players", "Quests", "General", "Environment", "★Important"})
        Me.cbxCategories.Location = New System.Drawing.Point(29, 69)
        Me.cbxCategories.Name = "cbxCategories"
        Me.cbxCategories.Size = New System.Drawing.Size(143, 30)
        Me.cbxCategories.TabIndex = 10
        Me.cbxCategories.Text = "Categories"
        '
        'lsbDisplay
        '
        Me.lsbDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.lsbDisplay.Font = New System.Drawing.Font("High Tower Text", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lsbDisplay.FormattingEnabled = True
        Me.lsbDisplay.HorizontalScrollbar = True
        Me.lsbDisplay.ItemHeight = 18
        Me.lsbDisplay.Location = New System.Drawing.Point(210, 69)
        Me.lsbDisplay.Name = "lsbDisplay"
        Me.lsbDisplay.ScrollAlwaysVisible = True
        Me.lsbDisplay.Size = New System.Drawing.Size(342, 256)
        Me.lsbDisplay.TabIndex = 9
        '
        'dtpOccurrence
        '
        Me.dtpOccurrence.Font = New System.Drawing.Font("Kristen ITC", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.dtpOccurrence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOccurrence.Location = New System.Drawing.Point(29, 123)
        Me.dtpOccurrence.Name = "dtpOccurrence"
        Me.dtpOccurrence.Size = New System.Drawing.Size(143, 28)
        Me.dtpOccurrence.TabIndex = 18
        '
        'lblPrivacyInfo
        '
        Me.lblPrivacyInfo.AutoSize = True
        Me.lblPrivacyInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblPrivacyInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblPrivacyInfo.Location = New System.Drawing.Point(239, 387)
        Me.lblPrivacyInfo.Name = "lblPrivacyInfo"
        Me.lblPrivacyInfo.Size = New System.Drawing.Size(284, 15)
        Me.lblPrivacyInfo.TabIndex = 19
        Me.lblPrivacyInfo.Text = "Click on this line of text for details about the program"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(597, 411)
        Me.Controls.Add(Me.lblPrivacyInfo)
        Me.Controls.Add(Me.dtpOccurrence)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnCreateEntry)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txbNotes)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.cbxCategories)
        Me.Controls.Add(Me.lsbDisplay)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnCreateEntry As Button
    Friend WithEvents lblNotes As Label
    Friend WithEvents txbNotes As TextBox
    Friend WithEvents lblDate As Label
    Friend WithEvents cbxCategories As ComboBox
    Friend WithEvents lsbDisplay As ListBox
    Friend WithEvents dtpOccurrence As DateTimePicker
    Friend WithEvents lblPrivacyInfo As Label
End Class
