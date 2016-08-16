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
        Me.rTBCode = New System.Windows.Forms.RichTextBox()
        Me.btnAna = New System.Windows.Forms.Button()
        Me.dGridLexi = New System.Windows.Forms.ListView()
        Me.dGridError = New System.Windows.Forms.ListView()
        Me.dGridIden = New System.Windows.Forms.ListView()
        Me.dGridBoard = New System.Windows.Forms.ListView()
        Me.lineNum = New System.Windows.Forms.PictureBox()
        Me.Number = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Line = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lexeme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Token = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Attribute = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.lineNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rTBCode
        '
        Me.rTBCode.Location = New System.Drawing.Point(44, 13)
        Me.rTBCode.Name = "rTBCode"
        Me.rTBCode.Size = New System.Drawing.Size(362, 306)
        Me.rTBCode.TabIndex = 2
        Me.rTBCode.Text = ""
        '
        'btnAna
        '
        Me.btnAna.Location = New System.Drawing.Point(691, 285)
        Me.btnAna.Name = "btnAna"
        Me.btnAna.Size = New System.Drawing.Size(103, 34)
        Me.btnAna.TabIndex = 3
        Me.btnAna.Text = "Analyze"
        Me.btnAna.UseVisualStyleBackColor = True
        '
        'dGridLexi
        '
        Me.dGridLexi.BackColor = System.Drawing.Color.SaddleBrown
        Me.dGridLexi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dGridLexi.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Number, Me.Line, Me.Lexeme, Me.Token, Me.Attribute})
        Me.dGridLexi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridLexi.ForeColor = System.Drawing.SystemColors.Window
        Me.dGridLexi.GridLines = True
        Me.dGridLexi.Location = New System.Drawing.Point(422, 13)
        Me.dGridLexi.Name = "dGridLexi"
        Me.dGridLexi.Size = New System.Drawing.Size(304, 158)
        Me.dGridLexi.TabIndex = 4
        Me.dGridLexi.UseCompatibleStateImageBehavior = False
        Me.dGridLexi.View = System.Windows.Forms.View.Details
        '
        'dGridError
        '
        Me.dGridError.BackColor = System.Drawing.Color.SaddleBrown
        Me.dGridError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dGridError.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.dGridError.ForeColor = System.Drawing.Color.White
        Me.dGridError.GridLines = True
        Me.dGridError.Location = New System.Drawing.Point(422, 178)
        Me.dGridError.Name = "dGridError"
        Me.dGridError.Size = New System.Drawing.Size(372, 97)
        Me.dGridError.TabIndex = 5
        Me.dGridError.UseCompatibleStateImageBehavior = False
        Me.dGridError.View = System.Windows.Forms.View.Details
        '
        'dGridIden
        '
        Me.dGridIden.Location = New System.Drawing.Point(12, 422)
        Me.dGridIden.Name = "dGridIden"
        Me.dGridIden.Size = New System.Drawing.Size(381, 97)
        Me.dGridIden.TabIndex = 6
        Me.dGridIden.UseCompatibleStateImageBehavior = False
        '
        'dGridBoard
        '
        Me.dGridBoard.Location = New System.Drawing.Point(422, 422)
        Me.dGridBoard.Name = "dGridBoard"
        Me.dGridBoard.Size = New System.Drawing.Size(157, 97)
        Me.dGridBoard.TabIndex = 7
        Me.dGridBoard.UseCompatibleStateImageBehavior = False
        '
        'lineNum
        '
        Me.lineNum.BackColor = System.Drawing.Color.SaddleBrown
        Me.lineNum.Location = New System.Drawing.Point(-1, 13)
        Me.lineNum.Name = "lineNum"
        Me.lineNum.Size = New System.Drawing.Size(39, 306)
        Me.lineNum.TabIndex = 8
        Me.lineNum.TabStop = False
        '
        'Number
        '
        Me.Number.Text = "Number"
        '
        'Lexeme
        '
        Me.Lexeme.Text = "Lexeme"
        '
        'Token
        '
        Me.Token.Text = "Token"
        '
        'Attribute
        '
        Me.Attribute.Text = "Attribute"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Error no."
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Line"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Description"
        Me.ColumnHeader3.Width = 249
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 531)
        Me.Controls.Add(Me.lineNum)
        Me.Controls.Add(Me.dGridBoard)
        Me.Controls.Add(Me.dGridIden)
        Me.Controls.Add(Me.dGridError)
        Me.Controls.Add(Me.dGridLexi)
        Me.Controls.Add(Me.btnAna)
        Me.Controls.Add(Me.rTBCode)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.lineNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rTBCode As RichTextBox
    Friend WithEvents btnAna As Button
    Friend WithEvents dGridLexi As ListView
    Friend WithEvents dGridError As ListView
    Friend WithEvents dGridIden As ListView
    Friend WithEvents dGridBoard As ListView
    Friend WithEvents lineNum As PictureBox
    Friend WithEvents Number As ColumnHeader
    Friend WithEvents Line As ColumnHeader
    Friend WithEvents Lexeme As ColumnHeader
    Friend WithEvents Token As ColumnHeader
    Friend WithEvents Attribute As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
End Class
