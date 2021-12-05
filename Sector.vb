Imports System.Data.SqlClient
Imports System.Data
Public Class Sector

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()



        Dim ct As String = "select * from sector where sectorID=@find"


        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "SectorId"))
        cmd.Parameters("@find").Value = SectorID.Text
        rdr = cmd.ExecuteReader()
        If Not rdr.Read Then
            MsgBox("Sorry ! No Records Found")
            SectorID.Text = ""
            SectorID.Focus()
        Else
            SectorID.Text = rdr.GetString(0)
            Source.Text = rdr.GetString(1)
            Destination.Text = rdr.GetString(2)

            WeekDays.Text = rdr.GetString(3)

            FirstClassFare.Text = rdr.GetString(4)
            BusinessClassFare.Text = rdr.GetString(5)
            EconomyClassFare.Text = rdr.GetString(6)
        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.SectorID.Enabled = True
        Me.SectorID.Text = ""
        Me.Source.Text = ""
        Me.Destination.Text = ""
        Me.WeekDays.Text = ""

        Me.FirstClassFare.Text = ""
        Me.BusinessClassFare.Text = ""
        Me.EconomyClassFare.Text = ""



        Me.SectorID.Focus()
    End Sub


    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click
        Me.SectorID.Text = ""
        Me.Source.Text = ""
        Me.Destination.Text = ""
        Me.WeekDays.Text = ""

        Me.FirstClassFare.Text = ""
        Me.BusinessClassFare.Text = ""
        Me.EconomyClassFare.Text = ""

    End Sub

    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        If Len(Trim(SectorID.Text)) = 0 Then
            MessageBox.Show("Please enter the Sector ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(Source.Text)) = 0 Then
            MessageBox.Show("Please enter the Source Location", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(Destination.Text)) = 0 Then
            MessageBox.Show("Please enter the Source Location", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(Source.Text)) = 0 Then
            MessageBox.Show("Please enter the Destination Location", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(WeekDays.Text)) = 0 Then
            MessageBox.Show("Please select the 1st week day", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(WeekDays.Text)) = 0 Then
            MessageBox.Show("Please select the week days", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Len(Trim(FirstClassFare.Text)) = 0 Then
            MessageBox.Show("Please enter the 1st class fare", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(BusinessClassFare.Text)) = 0 Then
            MessageBox.Show("Please enter the business class fare", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(EconomyClassFare.Text)) = 0 Then
            MessageBox.Show("Please enter the economy class fare", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select SectorID from sector where SectorID=@find"

        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "SectorId"))
        cmd.Parameters("@find").Value = SectorID.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Sector ID Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SectorID.Text = ""
            Source.Text = ""
            Destination.Text = ""
            WeekDays.Text = ""

            FirstClassFare.Text = ""
            BusinessClassFare.Text = ""
            EconomyClassFare.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else



            Dim ck As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(ck)

            con.Open()

            Dim cm As String = "insert into sector(SectorID,Source,Destination,WeekDays,FirstClassFare,BusinessClassFare,EconomyClassFare) VALUES (@INSERT1,@INSERT2,@INSERT3,@INSERT4,@INSERT5,@INSERT6,@INSERT7)"

            cmd =
            New SqlCommand(cm)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@INSERT1", System.Data.SqlDbType.NChar, 10, "SectorID"))

            cmd.Parameters.Add(New SqlParameter("@INSERT2", System.Data.SqlDbType.NChar, 20, "Source"))
            cmd.Parameters.Add(New SqlParameter("@INSERT3", System.Data.SqlDbType.NChar, 20, "Destination"))
            cmd.Parameters.Add(New SqlParameter("@INSERT4", System.Data.SqlDbType.VarChar, 80, "WeekDays"))





            cmd.Parameters.Add(New SqlParameter("@INSERT5", System.Data.SqlDbType.NChar, 10, "FirstClassFare"))
            cmd.Parameters.Add(New SqlParameter("@INSERT6", System.Data.SqlDbType.NChar, 10, "BusinessClassFare"))

            cmd.Parameters.Add(New SqlParameter("@INSERT7", System.Data.SqlDbType.NChar, 10, "EconomyClassFare"))

            cmd.Parameters("@INSERT1").Value = SectorID.Text

            cmd.Parameters("@INSERT2").Value = Source.Text
            cmd.Parameters("@INSERT3").Value = Destination.Text
            cmd.Parameters("@INSERT4").Value = WeekDays.Text




            cmd.Parameters("@INSERT5").Value = FirstClassFare.Text



            cmd.Parameters("@INSERT6").Value = BusinessClassFare.Text

            cmd.Parameters("@INSERT7").Value = EconomyClassFare.Text
            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If

            con.Close()
            MsgBox("Successfully Added")
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""
        End If


    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        Dim cz As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cz)

        con.Open()
        Dim cd As String = "select Source from Flights,Sector where Sector.SectorID=Flights.SectorID and Source= '" & Source.Text & "'"


        cmd = New SqlCommand(cd)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cv As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cv)

        con.Open()
        Dim ch As String = "select Destination from Flights,Sector where Sector.SectorID=Flights.SectorID and Destination= '" & Destination.Text & "'"

        cmd = New SqlCommand(ch)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim coz As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(coz)

        con.Open()
        Dim cxd As String = "select weekdays from Flights,Sector where Sector.SectorID=Flights.SectorID and weekday1= '" & WeekDays.Text & "'"

        cmd = New SqlCommand(cxd)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""


            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If

        Dim csf As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(csf)

        con.Open()
        Dim cdf As String = "select FirstClassFare from Flights,Sector where Sector.SectorID=Flights.SectorID and FirstClassFare= '" & FirstClassFare.Text & "'"

        cmd = New SqlCommand(cdf)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cza As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cza)

        con.Open()
        Dim cda As String = "select BusinessClassFare from Flights,Sector where Sector.SectorID=Flights.SectorID and BusinessClassFare= '" & BusinessClassFare.Text & "'"


        cmd = New SqlCommand(cda)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""




            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim czq As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(czq)

        con.Open()
        Dim cdw As String = "select EconomyClassFare from Flights,Sector where Sector.SectorID=Flights.SectorID and EconomyClassFare= '" & EconomyClassFare.Text & "'"


        cmd = New SqlCommand(cdw)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If



        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select SectorID from  Flights where SectorID=@find"


        cmd = New SqlCommand(ct)

        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "SectorID"))


        cmd.Parameters("@find").Value = SectorID.Text


        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.SectorID.Text = ""
            Me.Source.Text = ""
            Me.Destination.Text = ""
            Me.WeekDays.Text = ""

            Me.FirstClassFare.Text = ""
            Me.BusinessClassFare.Text = ""
            Me.EconomyClassFare.Text = ""


            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else

            Dim RowsAffected As Integer = 0

            Dim cf As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cf)

            con.Open()


            Dim cl As String = "delete from sector where SectorID=@DELETE1;delete from sector where Source=@DELETE2;delete from sector where Destination=@DELETE3;delete from sector where WeekDays=@DELETE4;delete from sector where FirstClassFare=@DELETE5;delete from sector where BusinessClassFare=@DELETE6;delete from sector where EconomyClassFare=@DELETE7"


            cmd = New SqlCommand(cl)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "SectorID"))
            cmd.Parameters.Add(
            New SqlParameter("@DELETE2", System.Data.SqlDbType.NChar, 20, "Source"))
            cmd.Parameters.Add(
            New SqlParameter("@DELETE3", System.Data.SqlDbType.NChar, 20, "Destination"))


            cmd.Parameters.Add(
            New SqlParameter("@DELETE4", System.Data.SqlDbType.VarChar, 100, "WeekDays"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE5", System.Data.SqlDbType.NChar, 10, "FirstClassFare"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE6", System.Data.SqlDbType.NChar, 10, "BusinessClassFare"))

            cmd.Parameters.Add(
           New SqlParameter("@DELETE7", System.Data.SqlDbType.NChar, 10, "EconomyClassFare"))



            cmd.Parameters("@DELETE1").Value = SectorID.Text
            cmd.Parameters(
            "@DELETE2").Value = Source.Text
            cmd.Parameters(
            "@DELETE3").Value = Destination.Text

            cmd.Parameters(
            "@DELETE4").Value = WeekDays.Text



            cmd.Parameters(
           "@DELETE5").Value = FirstClassFare.Text
            cmd.Parameters(
           "@DELETE6").Value = BusinessClassFare.Text
            cmd.Parameters(
           "@DELETE7").Value = EconomyClassFare.Text
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MsgBox("Successfully Deleted")
                Me.SectorID.Text = ""
                Me.Source.Text = ""
                Me.Destination.Text = ""
                Me.WeekDays.Text = ""

                Me.FirstClassFare.Text = ""
                Me.BusinessClassFare.Text = ""
                Me.EconomyClassFare.Text = ""

            Else
                MsgBox("Record Not Found")
                Me.SectorID.Text = ""
                Me.Source.Text = ""
                Me.Destination.Text = ""
                Me.WeekDays.Text = ""

                Me.FirstClassFare.Text = ""
                Me.BusinessClassFare.Text = ""
                Me.EconomyClassFare.Text = ""

            End If

            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then

                con.Close()
            End If

        End If
        con.Close()
    End Sub

    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()

        Dim ct As String = "update sector set Source=@UPDATE2,Destination=@UPDATE3,WeekDays=@UPDATE4,FirstClassFare=@UPDATE5,BusinessClassFare=@UPDATE6,EconomyClassFare=@UPDATE7 where SectorID=@UPDATE1 "

        cmd =
        New SqlCommand(ct)

        cmd.Connection = con

        cmd.Parameters.Add(New SqlParameter("@UPDATE1", System.Data.SqlDbType.NChar, 10, "SectorID"))


        cmd.Parameters.Add(New SqlParameter("@UPDATE2", System.Data.SqlDbType.NChar, 20, "Source"))
        cmd.Parameters.Add(New SqlParameter("@UPDATE3", System.Data.SqlDbType.NChar, 20, "Destination"))
        cmd.Parameters.Add(New SqlParameter("@UPDATE4", System.Data.SqlDbType.VarChar, 100, "WeekDays"))





        cmd.Parameters.Add(New SqlParameter("@UPDATE5", System.Data.SqlDbType.NChar, 10, "FirstClassFare"))

        cmd.Parameters.Add(New SqlParameter("@UPDATE6", System.Data.SqlDbType.NChar, 10, "BusinessClassFare"))

        cmd.Parameters.Add(New SqlParameter("@UPDATE7", System.Data.SqlDbType.NChar, 10, "EconomyClassFare"))

        cmd.Parameters("@UPDATE1").Value = SectorID.Text

        cmd.Parameters("@UPDATE2").Value = Source.Text
        cmd.Parameters("@UPDATE3").Value = Destination.Text
        cmd.Parameters("@UPDATE4").Value = WeekDays.Text




        cmd.Parameters("@UPDATE5").Value = FirstClassFare.Text



        cmd.Parameters("@UPDATE6").Value = BusinessClassFare.Text

        cmd.Parameters("@UPDATE7").Value = EconomyClassFare.Text
        cmd.ExecuteReader()

        If con.State = ConnectionState.Open Then

            con.Close()

        End If

        con.Close()
        Me.SectorID.Text = ""
        Me.Source.Text = ""
        Me.Destination.Text = ""
        Me.WeekDays.Text = ""

        Me.FirstClassFare.Text = ""
        Me.BusinessClassFare.Text = ""
        Me.EconomyClassFare.Text = ""

    End Sub
    Private Const ConnectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim ConnectionToFetch As New SqlConnection(ConnectionString)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property
    Public Function GetData() As DataView
        Dim SelectQry = "SELECT * FROM SECTOR "
        Dim SampleSource As New DataSet
        Dim TableView As DataView
        Try
            Dim SampleCommand As New SqlCommand()
            Dim SampleDataAdapter = New SqlDataAdapter()
            SampleCommand.CommandText = SelectQry
            SampleCommand.Connection = Connection
            SampleDataAdapter.SelectCommand = SampleCommand
            SampleDataAdapter.Fill(SampleSource)
            TableView = SampleSource.Tables(0).DefaultView
        Catch ex As Exception
            Throw ex
        End Try
        Return TableView

    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Visible = True
        DataGridView1.DataSource = GetData()
        DataGridView1.Font = New Font("Century Schoolbook", 8, FontStyle.Regular)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        ADMIN_Page.Show()

    End Sub
    Private Sub Source_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Source.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub


    Private Sub Destination_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Destination.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub

    Private Sub Sector_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Visible = False
        SectorID.Focus()


    End Sub

    Private Sub FirstClassFare_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FirstClassFare.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If
    End Sub

    Private Sub BusinessClassFare_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BusinessClassFare.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If
    End Sub

    Private Sub EconomyClassFare_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EconomyClassFare.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ListBox1.Visible = True
        ListBox1.SelectedIndex = -1
    End Sub




    Private Sub FirstClassFare_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstClassFare.TextChanged
        ListBox1.Visible = False
    End Sub


    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then

            Me.WeekDays.Text = ""
            For Each lstbxitem As Object In Me.ListBox1.SelectedItems
                Me.WeekDays.Text += lstbxitem
            Next
            ListBox1.Visible = False
        End If

    End Sub
    Private Sub NewRecord_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewRecord.MouseHover



        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(NewRecord, "Enter new records")


    End Sub

    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Add.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Add, "save new records")
    End Sub

    Private Sub Edit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Edit.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Edit, "update the records")
    End Sub

    Private Sub Submit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Submit, "get record related to SectorID in other textboxes by entering that particular SectorID")
    End Sub

    Private Sub Cancel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Cancel, "to cancel entered SectorID in textbox")
    End Sub

    Private Sub Delete_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Delete.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Delete, "to delete the records")
    End Sub

    Private Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button1, "to show all the records using datagridview")
    End Sub

    Private Sub Button2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button2, "For Exit")
    End Sub

    Private Sub Button5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button5, "select day(s)")
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub WeekDays_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeekDays.TextChanged

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class