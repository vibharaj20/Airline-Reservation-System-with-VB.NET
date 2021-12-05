Imports System.Data.SqlClient
Imports System.Data
Public Class Aircraft
    Dim con As New SqlConnection
    Dim dt As New DataTable
    Dim adp As SqlDataAdapter
    Private Const ConnectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
    Private ReadOnly Property Connection() As SqlConnection
        Get
            Dim ConnectionToFetch As New SqlConnection(ConnectionString)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property
    Public Function GetData() As DataView
        Dim SelectQry = "SELECT * FROM AIRCRAFT "
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

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cs)

        con.Open()


        Dim ct As String = "select * from aircraft where AircraftTypeID=@find"


        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "AirCraftTypeId"))
        cmd.Parameters("@find").Value = AircraftTypeId.Text
        rdr = cmd.ExecuteReader()
        If Not rdr.Read Then
            MsgBox("Sorry ! No Records Found")
            AircraftTypeId.Text = ""
            AircraftTypeId.Focus()
        Else
            AircraftTypeId.Text = rdr.GetString(0)
            AirlineName.Text = rdr.GetString(1)
            FirstClassSeats.Text = rdr.GetString(2)
            BusinessClassSeats.Text = rdr.GetString(3)
            EconomyClassSeats.Text = rdr.GetString(4)

        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

    End Sub
    Private Sub FirstClassSeats_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FirstClassSeats.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub

    Private Sub EconomyClassSeats_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EconomyClassSeats.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub

    Private Sub BusinessClassSeats_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BusinessClassSeats.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        AircraftTypeId.Text = ""
    End Sub
    Sub populateAirline()
        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cs)
        con.Open()

        adp = New SqlDataAdapter("select distinct airlinename from aircraft ", con)
        adp.Fill(dt)
        AirlineName1.DataSource = dt
        AirlineName1.DisplayMember = "AirlineName"
        AirlineName1.SelectedIndex = -1
        AirlineName1.Text = "select"
    End Sub

    Private Sub Aircraft_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        AircraftTypeId.Focus()

        populateAirline()
        Dim con As New SqlConnection
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        Dim da As New SqlDataAdapter("select * from Aircraft", con)
        da.Fill(dt)
        Dim r As DataRow
        AirlineName.AutoCompleteCustomSource.Clear()
        For Each r In dt.Rows
            AirlineName.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        Next
        con.Close()


    End Sub

    Private Sub AirlineName1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AirlineName1.SelectedIndexChanged
        DataGridView1.Font = New Font("Century Schoolbook", 8, FontStyle.Bold)
        Dim con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        con.Open()

        dt = New DataTable


        adp = New SqlDataAdapter("select * from aircraft where airlineName='" & AirlineName1.Text & "'", con)

        adp.Fill(dt)

        DataGridView1.DataSource = dt
    End Sub
    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click
        Me.AircraftTypeId.Text = ""
        Me.AirlineName.Text = ""
        Me.FirstClassSeats.Text = ""
        Me.BusinessClassSeats.Text = ""
        Me.EconomyClassSeats.Text = ""

    End Sub

    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        If Len(Trim(AircraftTypeId.Text)) = 0 Then
            MessageBox.Show("Please enter Aircraft Type ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(AirlineName.Text)) = 0 Then
            MessageBox.Show("Please enter Airline Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(FirstClassSeats.Text)) = 0 Then
            MessageBox.Show("Please enter the number of first class seats", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(BusinessClassSeats.Text)) = 0 Then
            MessageBox.Show("Please enter the number of business class seats", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(EconomyClassSeats.Text)) = 0 Then
            MessageBox.Show("Please enter the number of economy class seats", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing

        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select AircraftTypeID from aircraft where AircraftTypeID=@find"

        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "AirCraftTypeId"))
        cmd.Parameters("@find").Value = AircraftTypeId.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Aircraft Type ID Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AircraftTypeId.Text = ""
            AirlineName.Text = ""
            FirstClassSeats.Text = ""
            BusinessClassSeats.Text = ""
            EconomyClassSeats.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else



            Dim ck As String = " Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            con = New SqlConnection(ck)

            con.Open()

            Dim cb As String = "insert into aircraft(AirCraftTypeId,AirlineName,FirstClassSeats,BusinessClassSeats,EconomyClassSeats) VALUES (@INSERT1,@INSERT2,@INSERT3,@INSERT4,@INSERT5)"

            cmd =
            New SqlCommand(cb)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@INSERT1", System.Data.SqlDbType.NChar, 10, "AirCraftTypeId"))

            cmd.Parameters.Add(New SqlParameter("@INSERT2", System.Data.SqlDbType.VarChar, 20, "AirlineName"))

            cmd.Parameters.Add(New SqlParameter("@INSERT3", System.Data.SqlDbType.NChar, 10, "FirstClassSeats"))

            cmd.Parameters.Add(New SqlParameter("@INSERT4", System.Data.SqlDbType.NChar, 10, "BusinessClassSeat"))

            cmd.Parameters.Add(New SqlParameter("@INSERT5", System.Data.SqlDbType.NChar, 10, "EconomyClassSeats"))

            cmd.Parameters("@INSERT1").Value = AircraftTypeId.Text

            cmd.Parameters("@INSERT2").Value = AirlineName.Text

            cmd.Parameters("@INSERT3").Value = FirstClassSeats.Text

            cmd.Parameters("@INSERT4").Value = BusinessClassSeats.Text

            cmd.Parameters("@INSERT5").Value = EconomyClassSeats.Text

            cmd.ExecuteReader()



            If con.State = ConnectionState.Open Then
                con.Close()
            End If





            con.Close()

            MessageBox.Show("Successfully added", "Aircraft", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.AircraftTypeId.Text = ""
            Me.AirlineName.Text = ""
            Me.FirstClassSeats.Text = ""
            Me.BusinessClassSeats.Text = ""
            Me.EconomyClassSeats.Text = ""


        End If

    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        Dim cz As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cz)

        con.Open()
        Dim cd As String = "select AirlineName from Flights,aircraft where Aircraft.AircraftTypeID=Flights.AircraftTypeID and AirlineName= '" & AirlineName.Text & "'"


        cmd = New SqlCommand(cd)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AircraftTypeId.Text = ""
            AirlineName.Text = ""
            FirstClassSeats.Text = ""
            BusinessClassSeats.Text = ""
            EconomyClassSeats.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cp As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cp)

        con.Open()
        Dim cl As String = "select FirstClassSeats from Flights,aircraft where Aircraft.AircraftTypeID=Flights.AircraftTypeID and FirstClassSeats= '" & FirstClassSeats.Text & "'"


        cmd = New SqlCommand(cl)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AircraftTypeId.Text = ""
            AirlineName.Text = ""
            FirstClassSeats.Text = ""
            BusinessClassSeats.Text = ""
            EconomyClassSeats.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cr As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cr)

        con.Open()
        Dim cf As String = "select BusinessClassSeats from Flights,aircraft where Aircraft.AircraftTypeID=Flights.AircraftTypeID and BusinessClassSeats= '" & BusinessClassSeats.Text & "'"


        cmd = New SqlCommand(cf)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AircraftTypeId.Text = ""
            AirlineName.Text = ""
            FirstClassSeats.Text = ""
            BusinessClassSeats.Text = ""
            EconomyClassSeats.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cj As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cj)

        con.Open()
        Dim cu As String = "select EconomyClassSeats from Flights,aircraft where Aircraft.AircraftTypeID=Flights.AircraftTypeID and EconomyClassSeats= '" & EconomyClassSeats.Text & "'"


        cmd = New SqlCommand(cu)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AircraftTypeId.Text = ""
            AirlineName.Text = ""
            FirstClassSeats.Text = ""
            BusinessClassSeats.Text = ""
            EconomyClassSeats.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If

        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select AircraftTypeID from Flights where AircraftTypeID=@find"


        cmd = New SqlCommand(ct)

        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "AirCraftTypeId"))


        cmd.Parameters("@find").Value = AircraftTypeId.Text


        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            AircraftTypeId.Text = ""
            AirlineName.Text = ""
            FirstClassSeats.Text = ""
            BusinessClassSeats.Text = ""
            EconomyClassSeats.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else

            Dim RowsAffected As Integer = 0

            Dim ch As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            con = New SqlConnection(cp)

            con.Open()


            Dim cq As String = "delete from aircraft where AirCraftTypeId=@DELETE1;delete from aircraft where AirlineName=@dELETE2;delete from aircraft where FirstClassSeats=@DELETE3;delete from aircraft where BusinessClassSeats=@DELETE4;delete from aircraft where EconomyClassSeats=@DELETE5;"


            cmd = New SqlCommand(cq)

            cmd.Connection = con

            cmd.Parameters.Add(New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "AirCraftTypeId"))
            cmd.Parameters.Add(
            New SqlParameter("@DELETE2", System.Data.SqlDbType.VarChar, 20, "AirlineName"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE3", System.Data.SqlDbType.NChar, 10, "FirstClassSeats"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE4", System.Data.SqlDbType.NChar, 10, "BusinessClassSeats"))

            cmd.Parameters.Add(
           New SqlParameter("@DELETE5", System.Data.SqlDbType.NChar, 10, "EconomyClassSeats"))



            cmd.Parameters("@DELETE1").Value = AircraftTypeId.Text
            cmd.Parameters(
            "@DELETE2").Value = AirlineName.Text

            cmd.Parameters(
            "@DELETE3").Value = FirstClassSeats.Text

            cmd.Parameters(
            "@DELETE4").Value = BusinessClassSeats.Text

            cmd.Parameters(
           "@DELETE5").Value = EconomyClassSeats.Text
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then

                MessageBox.Show("Successfully deleted", "Aircraft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.AircraftTypeId.Text = ""
                Me.AirlineName.Text = ""
                Me.FirstClassSeats.Text = ""
                Me.BusinessClassSeats.Text = ""
                Me.EconomyClassSeats.Text = ""

            Else

                MessageBox.Show("no records found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.AircraftTypeId.Text = ""
                Me.AirlineName.Text = ""
                Me.FirstClassSeats.Text = ""
                Me.BusinessClassSeats.Text = ""
                Me.EconomyClassSeats.Text = ""
            End If


            cmd.ExecuteReader()
            If con.State = ConnectionState.Open Then

                con.Close()
            End If

            con.Close()
        End If
    End Sub

    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing



        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(cs)

        con.Open()

        Dim ct As String = "update aircraft set AirlineName=@UPDATE2,FirstClassSeats=@UPDATE3,BusinessClassSeats=@UPDATE4,EconomyClassSeats=@UPDATE5 where AirCraftTypeId=@UPDATE1"

        cmd =
        New SqlCommand(ct)

        cmd.Connection = con

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE1", System.Data.SqlDbType.NChar, 10, "AirCraftTypeId"))

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE2", System.Data.SqlDbType.VarChar, 20, "AirlineName"))

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE3", System.Data.SqlDbType.NChar, 10, "FirstClassSeats"))

        cmd.Parameters.Add(
        New SqlParameter("@UPDATE4", System.Data.SqlDbType.NChar, 10, "BusinessClassSeats"))

        cmd.Parameters.Add(
       New SqlParameter("@UPDATE5", System.Data.SqlDbType.NChar, 10, "EconomyClassSeats"))

        cmd.Parameters(
        "@UPDATE1").Value = AircraftTypeId.Text

        cmd.Parameters(
        "@UPDATE2").Value = AirlineName.Text

        cmd.Parameters(
        "@UPDATE3").Value = FirstClassSeats.Text

        cmd.Parameters(
        "@UPDATE4").Value = BusinessClassSeats.Text

        cmd.Parameters(
       "@UPDATE5").Value = EconomyClassSeats.Text





        cmd.ExecuteReader()

        If con.State = ConnectionState.Open Then

            con.Close()

        End If
        Me.AircraftTypeId.Text = ""
        Me.AirlineName.Text = ""
        Me.FirstClassSeats.Text = ""
        Me.BusinessClassSeats.Text = ""
        Me.EconomyClassSeats.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.DataSource = GetData()
        DataGridView1.Font = New Font("Century Schoolbook", 8, FontStyle.Bold)
        DataGridView1.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        ADMIN_Page.Show()

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
        ToolTip1.SetToolTip(Submit, "get record related to AircraftTypeID in other textboxes by entering that particular AircraftTypeID")
    End Sub

    Private Sub Cancel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Cancel, "to cancel entered AircraftTypeID in textbox")
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