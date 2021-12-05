<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADMIN_Page
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CancellationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GeneralEnqueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AircraftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlightsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AirlineScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AirlineTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReservationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(763, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 18)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(665, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Time  :"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogOutToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(91, 27)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(665, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Date  :"
        '
        'CancellationToolStripMenuItem
        '
        Me.CancellationToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.CancellationToolStripMenuItem.Image = Global.airline.My.Resources.Resources._988120305
        Me.CancellationToolStripMenuItem.Name = "CancellationToolStripMenuItem"
        Me.CancellationToolStripMenuItem.Size = New System.Drawing.Size(169, 28)
        Me.CancellationToolStripMenuItem.Text = "Refund"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralEnqueryToolStripMenuItem, Me.AirlineScheduleToolStripMenuItem, Me.AirlineTicketToolStripMenuItem, Me.LogOutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1370, 31)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GeneralEnqueryToolStripMenuItem
        '
        Me.GeneralEnqueryToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GeneralEnqueryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AircraftToolStripMenuItem, Me.SectorToolStripMenuItem, Me.FlightsToolStripMenuItem})
        Me.GeneralEnqueryToolStripMenuItem.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralEnqueryToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.GeneralEnqueryToolStripMenuItem.Name = "GeneralEnqueryToolStripMenuItem"
        Me.GeneralEnqueryToolStripMenuItem.Size = New System.Drawing.Size(173, 27)
        Me.GeneralEnqueryToolStripMenuItem.Text = "Add Airline Detail"
        '
        'AircraftToolStripMenuItem
        '
        Me.AircraftToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.AircraftToolStripMenuItem.Image = Global.airline.My.Resources.Resources._988120305
        Me.AircraftToolStripMenuItem.Name = "AircraftToolStripMenuItem"
        Me.AircraftToolStripMenuItem.Size = New System.Drawing.Size(152, 28)
        Me.AircraftToolStripMenuItem.Text = "Aircraft"
        '
        'SectorToolStripMenuItem
        '
        Me.SectorToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.SectorToolStripMenuItem.Image = Global.airline.My.Resources.Resources._988120305
        Me.SectorToolStripMenuItem.Name = "SectorToolStripMenuItem"
        Me.SectorToolStripMenuItem.Size = New System.Drawing.Size(152, 28)
        Me.SectorToolStripMenuItem.Text = "Sector"
        '
        'FlightsToolStripMenuItem
        '
        Me.FlightsToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.FlightsToolStripMenuItem.Image = Global.airline.My.Resources.Resources._988120305
        Me.FlightsToolStripMenuItem.Name = "FlightsToolStripMenuItem"
        Me.FlightsToolStripMenuItem.Size = New System.Drawing.Size(152, 28)
        Me.FlightsToolStripMenuItem.Text = "Flights"
        '
        'AirlineScheduleToolStripMenuItem
        '
        Me.AirlineScheduleToolStripMenuItem.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirlineScheduleToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AirlineScheduleToolStripMenuItem.Name = "AirlineScheduleToolStripMenuItem"
        Me.AirlineScheduleToolStripMenuItem.Size = New System.Drawing.Size(205, 27)
        Me.AirlineScheduleToolStripMenuItem.Text = "Add Airline Schedule"
        '
        'AirlineTicketToolStripMenuItem
        '
        Me.AirlineTicketToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AirlineTicketToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReservationToolStripMenuItem, Me.CancellationToolStripMenuItem})
        Me.AirlineTicketToolStripMenuItem.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirlineTicketToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AirlineTicketToolStripMenuItem.Name = "AirlineTicketToolStripMenuItem"
        Me.AirlineTicketToolStripMenuItem.Size = New System.Drawing.Size(140, 27)
        Me.AirlineTicketToolStripMenuItem.Text = "Airline Ticket"
        '
        'ReservationToolStripMenuItem
        '
        Me.ReservationToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.ReservationToolStripMenuItem.Image = Global.airline.My.Resources.Resources._988120305
        Me.ReservationToolStripMenuItem.Name = "ReservationToolStripMenuItem"
        Me.ReservationToolStripMenuItem.Size = New System.Drawing.Size(169, 28)
        Me.ReservationToolStripMenuItem.Text = "Collection"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(763, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Monotype Corsiva", 36.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(361, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(186, 57)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ADMIN"
        '
        'ADMIN_Page
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BackgroundImage = Global.airline.My.Resources.Resources._1280x1024_sydney
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1370, 730)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ADMIN_Page"
        Me.Text = "ADMIN PAGE"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CancellationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GeneralEnqueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AircraftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlightsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AirlineScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AirlineTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReservationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
