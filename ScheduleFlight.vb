Imports System.Data.SqlClient
Public Class ScheduleFlight

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim dt As New DataTable()

        Dim ct As String = "select * from scheduleFlights where scheduleID=@find"


        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "scheduleID"))
        cmd.Parameters("@find").Value = ScheduleID.Text
        rdr = cmd.ExecuteReader()
        If Not rdr.Read Then
            MsgBox("Sorry ! No Records Found")
            ScheduleID.Text = ""
            ScheduleID.Focus()
        Else
            ScheduleID.Text = rdr.GetString(0)
            FlightNo.Text = rdr.GetString(1)
            FlightDate.Text = rdr.GetString(2)
            FirstClassSeatAvailable.Text = rdr.GetString(3)
            BusinessClassSeatAvailable.Text = rdr.GetString(4)
            EconomyClassSeatAvailable.Text = rdr.GetString(5)

        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.ScheduleID.Enabled = True
        Me.FlightNo.Text = ""
        Me.FlightDate.Text = ""
        Me.FirstClassSeatAvailable.Text = ""
        Me.BusinessClassSeatAvailable.Text = ""
        Me.EconomyClassSeatAvailable.Text = ""
        Me.ScheduleID.Text = ""



        Me.ScheduleID.Focus()
    End Sub

    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click
        Me.FlightNo.Text = ""
        Me.FlightDate.Text = ""
        Me.FirstClassSeatAvailable.Text = ""
        Me.BusinessClassSeatAvailable.Text = ""
        Me.EconomyClassSeatAvailable.Text = ""
        Me.ScheduleID.Text = ""

    End Sub

    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        If Len(Trim(ScheduleID.Text)) = 0 Then
            MessageBox.Show("Please enter Schedule ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(FlightNo.Text)) = 0 Then
            MessageBox.Show("Please select flight No.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(FlightDate.Text)) = 0 Then
            MessageBox.Show("Please select flight date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(FirstClassSeatAvailable.Text)) = 0 Then
            MessageBox.Show("Please enter available seats in 1st class", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(BusinessClassSeatAvailable.Text)) = 0 Then
            MessageBox.Show("Please enter available seats in business class", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(EconomyClassSeatAvailable.Text)) = 0 Then
            MessageBox.Show("Please enter available seats in economy class", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select ScheduleID from scheduleFlights where ScheduleID=@find"

        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "ScheduleId"))
        cmd.Parameters("@find").Value = ScheduleID.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Schedule ID Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ScheduleID.Text = ""

            FlightNo.Text = ""
            FirstClassSeatAvailable.Text = ""
            BusinessClassSeatAvailable.Text = ""
            EconomyClassSeatAvailable.Text = ""




            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else



            Dim ck As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(ck)

            con.Open()

            Dim cp As String = "insert into Scheduleflights(ScheduleID,FlightNo,FlightDate,FirstClassSeatAvailable,BusinessClassSeatAvailable,EconomyClassSeatAvailable) VALUES (@INSERT1,@INSERT2,@INSERT3,@INSERT4,@INSERT5,@INSERT6)"

            cmd =
            New SqlCommand(cp)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@INSERT1", System.Data.SqlDbType.NChar, 10, "ScheduleID"))

            cmd.Parameters.Add(New SqlParameter("@INSERT2", System.Data.SqlDbType.NChar, 10, "FlightNo"))

            cmd.Parameters.Add(New SqlParameter("@INSERT3", System.Data.SqlDbType.NChar, 30, "FlightDate"))

            cmd.Parameters.Add(New SqlParameter("@INSERT4", System.Data.SqlDbType.NChar, 10, "FirstClassSeatAvailable"))

            cmd.Parameters.Add(New SqlParameter("@INSERT5", System.Data.SqlDbType.NChar, 10, "BusinessClassSeatAvailable"))
            cmd.Parameters.Add(New SqlParameter("@INSERT6", System.Data.SqlDbType.NChar, 10, "EconomyClassSeatAvailable"))

            cmd.Parameters("@INSERT1").Value = ScheduleID.Text

            cmd.Parameters("@INSERT2").Value = FlightNo.Text

            cmd.Parameters("@INSERT3").Value = FlightDate.Text
            cmd.Parameters("@INSERT4").Value = FirstClassSeatAvailable.Text
            cmd.Parameters("@INSERT5").Value = BusinessClassSeatAvailable.Text
            cmd.Parameters("@INSERT6").Value = EconomyClassSeatAvailable.Text


            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If

            con.Close()

            MsgBox("Successfully Added")
            Me.FlightNo.Text = ""
            Me.FlightDate.Text = ""
            Me.FirstClassSeatAvailable.Text = ""
            Me.BusinessClassSeatAvailable.Text = ""
            Me.EconomyClassSeatAvailable.Text = ""
            Me.ScheduleID.Text = ""
        End If

    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        Dim RowsAffected As Integer = 0
        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()



        Dim ct As String = "delete from Scheduleflights where ScheduleID=@delete1;"

        cmd =
        New SqlCommand(ct)


        cmd.Connection = con

        cmd.Parameters.Add(
        New SqlParameter("@delete1", System.Data.SqlDbType.NChar, 10, "ScheduleID"))

        cmd.Parameters("@delete1").Value = ScheduleID.Text

        RowsAffected = cmd.ExecuteNonQuery()
        If RowsAffected > 0 Then
            MsgBox("Successfully Deleted")
        Else
            MsgBox("Record Not Found")
        End If


        cmd.ExecuteReader()

        If con.State = ConnectionState.Open Then

            con.Close()

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

        Dim ct As String = "update scheduleflights set FlightNo=@UPDATE2,FlightDate=@UPDATE3,FirstClassSeatAvailable=@UPDATE4,BusinessClassSeatAvailable=@UPDATE5,EconomyClassSeatAvailable=@UPDATE6 where ScheduleID=@UPDATE1"

        cmd =
        New SqlCommand(ct)

        cmd.Connection = con

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE1", System.Data.SqlDbType.NChar, 10, "ScheduleID"))

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE2", System.Data.SqlDbType.NChar, 10, "FlightNo"))

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE3", System.Data.SqlDbType.NChar, 30, "FlightDate"))

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE4", System.Data.SqlDbType.NChar, 10, "FirstClassSeatAvailable"))

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE5", System.Data.SqlDbType.NChar, 10, "BusinessClassSeatAvailable"))
        cmd.Parameters.Add(
        New SqlParameter("@UPDATE6", System.Data.SqlDbType.NChar, 10, "EconomyClassSeatAvailable"))

        cmd.Parameters(
        "@UPDATE1").Value = ScheduleID.Text

        cmd.Parameters(
        "@UPDATE2").Value = FlightNo.Text

        cmd.Parameters(
        "@UPDATE3").Value = FlightDate.Text
        cmd.Parameters(
        "@UPDATE4").Value = FirstClassSeatAvailable.Text
        cmd.Parameters(
        "@UPDATE5").Value = BusinessClassSeatAvailable.Text
        cmd.Parameters(
        "@UPDATE6").Value = EconomyClassSeatAvailable.Text



        cmd.ExecuteReader()

        If con.State = ConnectionState.Open Then

        End If

        con.Close()
        Me.FlightNo.Text = ""
        Me.FlightDate.Text = ""
        Me.FirstClassSeatAvailable.Text = ""
        Me.BusinessClassSeatAvailable.Text = ""
        Me.EconomyClassSeatAvailable.Text = ""
        Me.ScheduleID.Text = ""

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
        Dim SelectQry = "SELECT * FROM ScheduleFlights "
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
        DataGridView1.Font = New Font("Century Schoolbook", 8, FontStyle.Bold)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        ADMIN_Page.Show()

    End Sub
    Private Sub Flights_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ScheduleID.Focus()
        DataGridView1.Visible = False
        Dim rdr As SqlDataReader = Nothing
        Dim con As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "select FlightNo from Flights "

        cmd = New SqlCommand(ct)
        cmd.Connection = con

        rdr = cmd.ExecuteReader()

        While rdr.Read
            FlightNo.Items.Add(rdr(0))
        End While
        con.Close()




    End Sub
    Private Sub FirstClasssSeatAvailable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FirstClassSeatAvailable.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If

    End Sub

    Private Sub BusinessClasssSeatAvailable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BusinessClassSeatAvailable.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If

    End Sub

    Private Sub EconomyClasssSeatAvailable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EconomyClassSeatAvailable.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If

    End Sub
    Public Sub PKExists()
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select ScheduleID from ScheduleFlights where ScheduleID=@find"

        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "ScheduleId"))
        cmd.Parameters("@find").Value = ScheduleID.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Schedule ID Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ScheduleID.Text = ""
            FlightNo.Text = ""
            FlightNo.Text = ""
            FlightDate.Text = ""
            FirstClassSeatAvailable.Text = ""
            BusinessClassSeatAvailable.Text = ""
            EconomyClassSeatAvailable.Text = ""
            Close()

        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

    End Sub





    Private Sub FlightNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlightNo.SelectedIndexChanged
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()


        Dim ct As String = "select FirstClassSeats,BusinessClassSeats,EconomyClassSeats from aircraft,Flights where Aircraft.AircraftTypeID=Flights.AircraftTypeID and FlightNo='" & FlightNo.Text & "'"


        cmd = New SqlCommand(ct)
        cmd.Connection = con

        rdr = cmd.ExecuteReader()
        If rdr.Read Then

            FirstClassSeatAvailable.Text = rdr.GetString(0)
            BusinessClassSeatAvailable.Text = rdr.GetString(1)
            EconomyClassSeatAvailable.Text = rdr.GetString(2)

        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
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
        ToolTip1.SetToolTip(Submit, "get record related to ScheduleID in other textboxes by entering that particular ScheduleID")
    End Sub

    Private Sub Cancel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Cancel, "to cancel entered ScheduleID in textbox")
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
        ToolTip1.SetToolTip(Button2, "for Exit")
    End Sub

End Class