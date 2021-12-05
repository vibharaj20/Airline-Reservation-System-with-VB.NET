Imports System.Data.SqlClient
Public Class Reservation
    Dim frmPrintTicket As New Print_ticket

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        
        If Len(Trim(FlightNo.Text)) = 0 Then
            MessageBox.Show("Please Specify the flightNo", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(AirwayClass.Text)) = 0 Then
            MessageBox.Show("Please Specify the Class Preference of the passenger", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        If (AirwayClass.Text) = "First Class" Then

            Dim ct As String = "SELECT  Sector.Source, Sector.Destination, Sector.FirstClassFare  from sector,flights where Flights.SectorID = Sector.SectorID and FlightNo=@FIND"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "FlightNo"))
            cmd.Parameters("@find").Value = FlightNo.Text
            rdr = cmd.ExecuteReader()
            If rdr.Read Then


                Source.Text = rdr.GetString(0)
                Destination.Text = rdr.GetString(1)
                Fare.Text = rdr.GetString(2)
            End If

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End If
        If (AirwayClass.Text) = "Business Class" Then

            Dim ct As String = "SELECT  Sector.Source, Sector.Destination, Sector.BusinessClassFare FROM  sector INNER JOIN flights ON Flights.SectorID = Sector.SectorID and FlightNo=@FIND"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "FlightNo"))
            cmd.Parameters("@find").Value = FlightNo.Text
            rdr = cmd.ExecuteReader()
            If rdr.Read Then


                Source.Text = rdr.GetString(0)
                Destination.Text = rdr.GetString(1)
                Fare.Text = rdr.GetString(2)
            End If

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End If
        If (AirwayClass.Text) = "Economy Class" Then

            Dim ct As String = "SELECT  Sector.Source, Sector.Destination, Sector.EconomyClassFare FROM  sector INNER JOIN flights ON Flights.SectorID = Sector.SectorID and FlightNo=@FIND"


            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "FlightNo"))
            cmd.Parameters("@find").Value = FlightNo.Text
            rdr = cmd.ExecuteReader()
            If rdr.Read Then


                Source.Text = rdr.GetString(0)
                Destination.Text = rdr.GetString(1)
                Fare.Text = rdr.GetString(2)
            End If

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Len(Trim(PnrNo.Text)) = 0 Then
            MessageBox.Show("Please enter the PNR No.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Please enter the Security Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim dt As New DataTable()

        Dim ct As String = "select * from reservations where PnrNo=@find And SePassword=@find1"


        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "PnrNo"))
        cmd.Parameters("@find").Value = PnrNo.Text
        cmd.Parameters.Add(
      New SqlParameter("@find1", System.Data.SqlDbType.NChar, 10, "SePassword"))
        cmd.Parameters("@find1").Value = TextBox2.Text
        rdr = cmd.ExecuteReader()
        If Not rdr.Read Then
            MsgBox("Sorry ! No Records Found")
            PnrNo.Text = ""
            TextBox2.Text = ""
            PnrNo.Focus()
        Else
            TextBox2.Text = ""
            PnrNo.Text = rdr.GetString(0)
            FlightNo.Text = rdr.GetString(1)
            TravelDate.Text = rdr.GetString(2)
            Fname.Text = rdr.GetString(3)
            Lname.Text = rdr.GetString(4)
            Age.Text = rdr.GetString(5)
            Gender.Text = rdr.GetString(6)

            AirwayClass.Text = rdr.GetString(7)
            SeatPref.Text = rdr.GetString(8)

            MealPref.Text = rdr.GetString(9)

            SSR.Text = rdr.GetString(10)
            Fare.Text = rdr.GetString(11)
            Source.Text = rdr.GetString(12)
            Destination.Text = rdr.GetString(13)
            Rstatus.Text = rdr.GetString(14)



        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        FlightNo.Text = ""
        AirwayClass.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Fare.Text = ""
        Fname.Text = ""
        Lname.Text = ""
        Age.Text = ""
        Source.Text = ""
        Destination.Text = ""
        Rstatus.Text = ""

        PnrNo.Text = ""

        SSR.Text = ""
        Gender.Text = ""
        MealPref.Text = ""
        SeatPref.Text = ""
    End Sub

    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click

        Save.Enabled = True
        FlightNo.Text = ""

        AirwayClass.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Fare.Text = ""
        Fname.Text = ""
        Lname.Text = ""
        Age.Text = ""
        Source.Text = ""
        Destination.Text = ""
        Rstatus.Text = ""

        PnrNo.Text = ""

        SSR.Text = ""
        Gender.Text = ""
        MealPref.Text = ""
        SeatPref.Text = ""

    End Sub


    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        If Len(Trim(TextBox5.Text)) = 0 Then
            MessageBox.Show("Please Create a Security Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(TextBox4.Text)) = 0 Then
            MessageBox.Show("Please Re-Enter  Security Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(AirwayClass.Text)) = 0 Then
            MessageBox.Show("Please specify the class of travel", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(Fname.Text)) = 0 Or Len(Trim(Lname.Text)) = 0 Then
            MessageBox.Show("Please enter the full name of the passenger", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(Age.Text)) = 0 Then
            MessageBox.Show("Please enter the age of the passenger", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Len(Trim(Gender.Text)) = 0 Then
            MessageBox.Show("Please specify the gender of the passenger", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(SeatPref.Text)) = 0 Then
            MessageBox.Show("Please specify the seat preference of the passenger", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(MealPref.Text)) = 0 Then
            MessageBox.Show("Please specify the meal preference of the passenger", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
        Catch ex As Exception
            MessageBox.Show("The 'Age' field can contain only a numeric value", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If TextBox3.Text = "Match" Then

            Dim rdr As SqlDataReader = Nothing

            Dim con As SqlConnection = Nothing

            Dim cmd As SqlCommand = Nothing
            Dim cm As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cm)

            con.Open()
            If AirwayClass.Text = "First Class" Then
                Dim ck As String = "select FirstClassSeatAvailable from scheduleflights where FirstClassSeatAvailable > 0 and scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(ck)
                cmd.Connection = con

                rdr = cmd.ExecuteReader()
                If rdr.Read Then

                    Rstatus.Text = "Confirmed"
                Else
                    Rstatus.Text = "waiting list"
                End If

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If
            Dim ca As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(ca)

            con.Open()
            If AirwayClass.Text = "Economy Class" Then
                Dim ck As String = "select EconomyClassSeatAvailable from scheduleflights where EconomyClassSeatAvailable > 0 and scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(ck)
                cmd.Connection = con

                rdr = cmd.ExecuteReader()
                If rdr.Read Then

                    Rstatus.Text = "Confirmed"
                Else
                    Rstatus.Text = "waiting list"
                End If

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If
            Dim cp As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cp)

            con.Open()
            If AirwayClass.Text = "Business Class" Then
                Dim ck As String = "select BusinessClassSeatAvailable from scheduleflights where BusinessClassSeatAvailable > 0 and scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(ck)
                cmd.Connection = con

                rdr = cmd.ExecuteReader()
                If rdr.Read Then

                    Rstatus.Text = "Confirmed"
                Else
                    Rstatus.Text = "waiting list"
                End If

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If

            Dim cop As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cop)

            con.Open()
            If AirwayClass.Text = "First Class" Then
                Dim ck As String = "update scheduleFlights set FirstClassSeatAvailable=FirstClassSeatAvailable -1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(ck)
                cmd.Connection = con

                cmd.ExecuteNonQuery()

                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If
            If AirwayClass.Text = "Business Class" Then
                Dim ck As String = "update scheduleFlights set BusinessClassSeatAvailable=BusinessClassSeatAvailable -1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(ck)
                cmd.Connection = con

                cmd.ExecuteNonQuery()

                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If
            If AirwayClass.Text = "Economy Class" Then
                Dim ck As String = "update scheduleFlights set EconomyClassSeatAvailable=EconomyClassSeatAvailable -1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(ck)
                cmd.Connection = con
                cmd.ExecuteNonQuery()

                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If
            Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cs)

            con.Open()



            Dim ct As String = "insert into Reservations(PnrNo,FlightNo,TravelDate,Fname,Lname,Age,Gender,Class,SeatPref,MealPref,SSR,Fare,Source,Destination,Rstatus,SePassword) VALUES (@INSERT1,@INSERT2,@INSERT3,@INSERT4,@INSERT5,@INSERT6,@INSERT7,@INSERT8,@INSERT9,@INSERT10,@INSERT11,@INSERT12,@INSERT13,@INSERT14,@INSERT15,@INSERT16)"

            cmd =
            New SqlCommand(ct)


            cmd.Connection = con

            cmd.Parameters.Add(
            New SqlParameter("@INSERT1", System.Data.SqlDbType.NChar, 10, "PnrNo"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT2", System.Data.SqlDbType.NChar, 10, "FlightNo"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT3", System.Data.SqlDbType.NChar, 30, "TravelDate"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT4", System.Data.SqlDbType.VarChar, 20, "Fname"))

            cmd.Parameters.Add(
           New SqlParameter("@INSERT5", System.Data.SqlDbType.VarChar, 20, "Lname"))
            cmd.Parameters.Add(
            New SqlParameter("@INSERT6", System.Data.SqlDbType.NChar, 10, "Age"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT7", System.Data.SqlDbType.NChar, 10, "Gender"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT8", System.Data.SqlDbType.NChar, 20, "Class"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT9", System.Data.SqlDbType.NChar, 10, "SeatPref"))

            cmd.Parameters.Add(
           New SqlParameter("@INSERT10", System.Data.SqlDbType.NChar, 10, "MealPref"))


            cmd.Parameters.Add(
            New SqlParameter("@INSERT11", System.Data.SqlDbType.VarChar, 50, "SSR"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT16", System.Data.SqlDbType.NChar, 10, "SePassword"))



            cmd.Parameters.Add(
            New SqlParameter("@INSERT12", System.Data.SqlDbType.NChar, 10, "Fare"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT13", System.Data.SqlDbType.NChar, 20, "Source"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT14", System.Data.SqlDbType.NChar, 20, "Destination"))
            cmd.Parameters.Add(
          New SqlParameter("@INSERT15", System.Data.SqlDbType.NChar, 20, "Rstatus"))

            AutoGenerate()



            cmd.Parameters(
           "@INSERT1").Value = PnrNo.Text
            cmd.Parameters(
           "@INSERT2").Value = FlightNo.Text
            cmd.Parameters(
           "@INSERT3").Value = TravelDate.Text
            cmd.Parameters(
           "@INSERT4").Value = Fname.Text
            cmd.Parameters(
           "@INSERT5").Value = Lname.Text
            cmd.Parameters(
           "@INSERT6").Value = Age.Text
            cmd.Parameters(
           "@INSERT7").Value = Gender.Text
            cmd.Parameters(
           "@INSERT8").Value = AirwayClass.Text
            cmd.Parameters(
           "@INSERT9").Value = SeatPref.Text
            cmd.Parameters(
           "@INSERT10").Value = MealPref.Text

            cmd.Parameters(
           "@INSERT11").Value = SSR.Text


            cmd.Parameters(
           "@INSERT12").Value = Fare.Text
            cmd.Parameters(
           "@INSERT13").Value = Source.Text
            cmd.Parameters(
           "@INSERT14").Value = Destination.Text
            cmd.Parameters(
           "@INSERT15").Value = Rstatus.Text
            cmd.Parameters(
           "@INSERT16").Value = TextBox5.Text

            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If


            con.Close()
            MessageBox.Show("SUCCESSFULLY Reserved", "Airline Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim cz As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cz)

            con.Open()



            Dim coz As String = "insert into Collections(PnrNo,Date,Collection) VALUES (@INSERT1,@INSERT2,@INSERT3)"

            cmd =
            New SqlCommand(coz)


            cmd.Connection = con

            cmd.Parameters.Add(
            New SqlParameter("@INSERT1", System.Data.SqlDbType.NChar, 10, "PnrNo"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT2", System.Data.SqlDbType.NChar, 30, "date"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT3", System.Data.SqlDbType.NChar, 10, "collection"))







            cmd.Parameters("@INSERT1").Value = PnrNo.Text
            cmd.Parameters("@INSERT2").Value = TravelDate.Text
            cmd.Parameters("@INSERT3").Value = Fare.Text



            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If
            TextBox1.Text = " YOUR PNR No. "
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            con.Close()
        Else
            MessageBox.Show("Re-Enter Password is Not Match", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""


        End If
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        Dim cz As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cz)

        con.Open()
        Dim cd As String = "select FlightNo from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and FlightNo= '" & FlightNo.Text & "'"


        cmd = New SqlCommand(cd)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cp As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cp)

        con.Open()
        Dim cl As String = "select TravelDate from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and TravelDate= '" & TravelDate.Text & "'"


        cmd = New SqlCommand(cl)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cr As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cr)

        con.Open()
        Dim cf As String = "select Class from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Class= '" & AirwayClass.Text & "'"


        cmd = New SqlCommand(cf)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""




            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cj As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cj)

        con.Open()
        Dim cu As String = "select Source from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Source= '" & Source.Text & "'"


        cmd = New SqlCommand(cu)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs1 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs1)

        con.Open()
        Dim cu1 As String = "select Destination from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Destination= '" & Destination.Text & "'"


        cmd = New SqlCommand(cu1)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs2 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs2)

        con.Open()
        Dim cu2 As String = "select Fare from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Fare= '" & Fare.Text & "'"


        cmd = New SqlCommand(cu2)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs3 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs3)

        con.Open()
        Dim cu3 As String = "select Fname from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Fname= '" & Fname.Text & "'"


        cmd = New SqlCommand(cu3)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs4 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs4)

        con.Open()
        Dim cu4 As String = "select Lname from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Lname= '" & Lname.Text & "'"


        cmd = New SqlCommand(cu4)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs5 As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\AirlineReservationSystem.mdf; User Instance=true;"

        con = New SqlConnection(cs5)

        con.Open()
        Dim cu5 As String = "select Age from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Age= '" & Age.Text & "'"


        cmd = New SqlCommand(cu5)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs6 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs6)

        con.Open()
        Dim cu6 As String = "select gender from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and gender= '" & Gender.Text & "'"


        cmd = New SqlCommand(cu6)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs7 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs7)

        con.Open()
        Dim cu7 As String = "select seatpref from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Seatpref= '" & SeatPref.Text & "'"


        cmd = New SqlCommand(cu7)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs8 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs8)

        con.Open()
        Dim cu8 As String = "select MealPref from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and mealpref= '" & MealPref.Text & "'"


        cmd = New SqlCommand(cu8)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs9 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs9)

        con.Open()
        Dim cu9 As String = "select SSR from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and SSR= '" & SSR.Text & "'"


        cmd = New SqlCommand(cu9)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs10 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs10)

        con.Open()
        Dim cu10 As String = "select Rstatus from Reservations,cancelreservation where Reservations.PnrNo=CancelReservation.PnrNo and Rstatus= '" & Rstatus.Text & "'"


        cmd = New SqlCommand(cu10)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cz1 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cz1)

        con.Open()
        Dim cd1 As String = "select FlightNo from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and FlightNo= '" & FlightNo.Text & "'"


        cmd = New SqlCommand(cd1)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cp1 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cp1)

        con.Open()
        Dim cl1 As String = "select TravelDate from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and TravelDate= '" & TravelDate.Text & "'"


        cmd = New SqlCommand(cl1)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cr1 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cr1)

        con.Open()
        Dim cf1 As String = "select Class from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and Class= '" & AirwayClass.Text & "'"


        cmd = New SqlCommand(cf1)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""




            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cj1 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cj1)

        con.Open()
        Dim cu12 As String = "select Source from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and Source= '" & Source.Text & "'"


        cmd = New SqlCommand(cu12)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs12 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs12)

        con.Open()
        Dim cu13 As String = "select Destination from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo  and Destination= '" & Destination.Text & "'"


        cmd = New SqlCommand(cu13)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs21 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs21)

        con.Open()
        Dim cu21 As String = "select Fare from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo  and Fare= '" & Fare.Text & "'"


        cmd = New SqlCommand(cu21)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs31 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs31)

        con.Open()
        Dim cu31 As String = "select Fname from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and Fname= '" & Fname.Text & "'"


        cmd = New SqlCommand(cu31)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs41 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs41)

        con.Open()
        Dim cu41 As String = "select Lname from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo  and Lname= '" & Lname.Text & "'"


        cmd = New SqlCommand(cu41)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs51 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs51)

        con.Open()
        Dim cu51 As String = "select Age from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and Age= '" & Age.Text & "'"


        cmd = New SqlCommand(cu51)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs61 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs61)

        con.Open()
        Dim cu61 As String = "select gender from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo  and gender= '" & Gender.Text & "'"


        cmd = New SqlCommand(cu61)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs71 As String = "Data Source=.\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\AirlineReservationSystem.mdf; User Instance=true;"

        con = New SqlConnection(cs71)

        con.Open()
        Dim cu71 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"


        cmd = New SqlCommand(cu71)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs81 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs81)

        con.Open()
        Dim cu81 As String = "select MealPref from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and mealpref= '" & MealPref.Text & "'"


        cmd = New SqlCommand(cu81)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs91 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs91)

        con.Open()
        Dim cu91 As String = "select SSR from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo  and SSR= '" & SSR.Text & "'"


        cmd = New SqlCommand(cu91)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs101 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs101)

        con.Open()
        Dim cu101 As String = "select Rstatus from Reservations,Collections where Reservations.PnrNo=Collections.PnrNo and Rstatus= '" & Rstatus.Text & "'"


        cmd = New SqlCommand(cu101)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cz12 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cz12)

        con.Open()
        Dim cd12 As String = "select FlightNo from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and FlightNo= '" & FlightNo.Text & "'"


        cmd = New SqlCommand(cd12)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cp12 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cp12)

        con.Open()
        Dim cl12 As String = "select TravelDate from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and TravelDate= '" & TravelDate.Text & "'"


        cmd = New SqlCommand(cl12)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cr12 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cr12)

        con.Open()
        Dim cf12 As String = "select Class from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and Class= '" & AirwayClass.Text & "'"


        cmd = New SqlCommand(cf12)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""




            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cj12 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cj12)

        con.Open()
        Dim cu14 As String = "select Source from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and Source= '" & Source.Text & "'"


        cmd = New SqlCommand(cu14)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs13 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs13)

        con.Open()
        Dim cu01 As String = "select Destination from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo  and Destination= '" & Destination.Text & "'"


        cmd = New SqlCommand(cu01)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs22 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs22)

        con.Open()
        Dim cu012 As String = "select Fare from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo  and Fare= '" & Fare.Text & "'"


        cmd = New SqlCommand(cu012)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs32 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs32)

        con.Open()
        Dim cu013 As String = "select Fname from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and Fname= '" & Fname.Text & "'"


        cmd = New SqlCommand(cu013)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs42 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs42)

        con.Open()
        Dim cu014 As String = "select Lname from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo  and Lname= '" & Lname.Text & "'"


        cmd = New SqlCommand(cu014)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs52 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs52)

        con.Open()
        Dim cu015 As String = "select Age from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and Age= '" & Age.Text & "'"


        cmd = New SqlCommand(cu015)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs62 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs62)

        con.Open()
        Dim cu016 As String = "select gender from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo  and gender= '" & Gender.Text & "'"


        cmd = New SqlCommand(cu016)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs72 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs72)

        con.Open()
        Dim cu017 As String = "select seatpref from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and Seatpref= '" & SeatPref.Text & "'"


        cmd = New SqlCommand(cu017)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs82 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs82)

        con.Open()
        Dim cu018 As String = "select MealPref from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and mealpref= '" & MealPref.Text & "'"


        cmd = New SqlCommand(cu018)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs92 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs92)

        con.Open()
        Dim cu019 As String = "select SSR from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo  and SSR= '" & SSR.Text & "'"


        cmd = New SqlCommand(cu019)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs102 As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs102)

        con.Open()
        Dim cu102 As String = "select Rstatus from Reservations,Refunds where Reservations.PnrNo=Refunds.PnrNo and Rstatus= '" & Rstatus.Text & "'"


        cmd = New SqlCommand(cu102)

        cmd.Connection = con



        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""



            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            Exit Sub
        End If
        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select PnrNo from CancelReservation where PnrNo=@find"


        cmd = New SqlCommand(ct)

        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "PnrNo"))


        cmd.Parameters("@find").Value = PnrNo.Text


        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FlightNo.Text = ""
            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""
            PnrNo.Text = ""
            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""




            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        Else



            Dim RowsAffected As Integer = 0


            Dim cx As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cx)

            con.Open()
            Dim cV As String = "Delete from Reservations where PnrNo=@DELETE1;Delete from Reservations where FlightNo=@DELETE2;Delete from Reservations where TravelDate=@DELETE3;Delete from Reservations where Fname=@DELETE4;Delete from Reservations where Lname=@DELETE5;Delete from Reservations where Age=@DELETE6;Delete from Reservations where Gender=@DELETE7;Delete from Reservations where Class=@DELETE8;Delete from Reservations where SeatPref=@DELETE9;Delete from Reservations where MealPref=@DELETE10;Delete from Reservations where SSR=@DELETE11;Delete from Reservations where Fare=@DELETE12;Delete from Reservations where Source=@DELETE13;Delete from Reservations where Destination=@DELETE14;Delete from Reservations where Rstatus=@DELETE15"

            cmd =
            New SqlCommand(cV)

            cmd.Connection = con

            cmd.Parameters.Add(
            New SqlParameter("@DELETE1", System.Data.SqlDbType.NChar, 10, "PnrNo"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE2", System.Data.SqlDbType.NChar, 10, "FlightNo"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE3", System.Data.SqlDbType.NChar, 30, "TravelDate"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE4", System.Data.SqlDbType.VarChar, 20, "Fname"))

            cmd.Parameters.Add(
           New SqlParameter("@DELETE5", System.Data.SqlDbType.VarChar, 20, "Lname"))
            cmd.Parameters.Add(
            New SqlParameter("@DELETE6", System.Data.SqlDbType.NChar, 10, "Age"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE7", System.Data.SqlDbType.NChar, 10, "Gender"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE8", System.Data.SqlDbType.NChar, 20, "Class"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE9", System.Data.SqlDbType.NChar, 10, "SeatPref"))

            cmd.Parameters.Add(
           New SqlParameter("@DELETE10", System.Data.SqlDbType.NChar, 10, "MealPref"))


            cmd.Parameters.Add(
            New SqlParameter("@DELETE11", System.Data.SqlDbType.VarChar, 50, "SSR"))



            cmd.Parameters.Add(
            New SqlParameter("@DELETE12", System.Data.SqlDbType.NChar, 10, "Fare"))
            cmd.Parameters.Add(
            New SqlParameter("@DELETE13", System.Data.SqlDbType.NChar, 20, "Source"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE14", System.Data.SqlDbType.NChar, 20, "Destination"))

            cmd.Parameters.Add(
            New SqlParameter("@DELETE15", System.Data.SqlDbType.NChar, 20, "Rstatus"))
            cmd.Parameters(
           "@DELETE1").Value = PnrNo.Text
            cmd.Parameters(
           "@DELETE2").Value = FlightNo.Text
            cmd.Parameters(
           "@DELETE3").Value = TravelDate.Text
            cmd.Parameters(
           "@DELETE4").Value = Fname.Text
            cmd.Parameters(
           "@DELETE5").Value = Lname.Text
            cmd.Parameters(
           "@DELETE6").Value = Age.Text
            cmd.Parameters(
           "@DELETE7").Value = Gender.Text
            cmd.Parameters(
           "@DELETE8").Value = AirwayClass.Text
            cmd.Parameters(
           "@DELETE9").Value = SeatPref.Text
            cmd.Parameters(
           "@DELETE10").Value = MealPref.Text

            cmd.Parameters(
           "@DELETE11").Value = SSR.Text


            cmd.Parameters(
           "@DELETE12").Value = Fare.Text
            cmd.Parameters(
           "@DELETE13").Value = Source.Text
            cmd.Parameters(
           "@DELETE14").Value = Destination.Text
            cmd.Parameters(
           "@DELETE15").Value = Rstatus.Text

            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MsgBox("Successfully Deleted")
                FlightNo.Text = ""

                AirwayClass.Text = ""
                Fare.Text = ""
                Fname.Text = ""
                Lname.Text = ""
                Age.Text = ""
                Source.Text = ""
                Destination.Text = ""
                Rstatus.Text = ""

                PnrNo.Text = ""

                SSR.Text = ""
                Gender.Text = ""
                MealPref.Text = ""
                SeatPref.Text = ""

            Else
                MsgBox("Record Not Found")
                FlightNo.Text = ""

                AirwayClass.Text = ""
                Fare.Text = ""
                Fname.Text = ""
                Lname.Text = ""
                Age.Text = ""
                Source.Text = ""
                Destination.Text = ""
                Rstatus.Text = ""

                PnrNo.Text = ""

                SSR.Text = ""
                Gender.Text = ""
                MealPref.Text = ""
                SeatPref.Text = ""

            End If


            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If

            con.Close()

        End If

    End Sub

    Private Sub confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Len(Trim(PnrNo.Text)) = 0 Then
            MessageBox.Show("Please enter the PNR No.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Trim(Rstatus.Text) = "Confirmed" Then
            MessageBox.Show("This ticket is already confirmed", "Airline ticket", MessageBoxButtons.OK, MessageBoxIcon.Error)
            initializecontrols()
        ElseIf Trim(Rstatus.Text) = "Cancelled" Then
            MessageBox.Show("not possible..please reserve new ticket", "Airline ticket", MessageBoxButtons.OK, MessageBoxIcon.Error)
            initializecontrols()
        Else
            Dim rdr As SqlDataReader = Nothing

            Dim con As SqlConnection = Nothing

            Dim cmd As SqlCommand = Nothing


            Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cs)

            con.Open()

            Dim ct As String = "Update Reservations set traveldate= '" & TravelDate.Text & "' where PnrNo ='" & PnrNo.Text & "'"
            Dim cp As String = "Update Reservations set Rstatus='Confirmed' where PnrNo ='" & PnrNo.Text & "'"

            cmd =
            New SqlCommand(ct)
            cmd.Connection = con


            cmd.ExecuteNonQuery()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If
            con.Close()
            con.Open()

            cmd =
           New SqlCommand(cp)
            cmd.Connection = con


            cmd.ExecuteNonQuery()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If
            con.Close()




            Dim cop As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cop)

            con.Open()
            If Trim(AirwayClass.Text) = "First Class" Then

                Dim ck As String = "update scheduleFlights set FirstClassSeatAvailable=FirstClassSeatAvailable - 1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(ck)
                cmd.Connection = con

                cmd.ExecuteNonQuery()


                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If



            If Trim(AirwayClass.Text) = "Business Class" Then

                Dim cm As String = "update scheduleFlights set BusinessClassSeatAvailable=BusinessClassSeatAvailable - 1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(cm)
                cmd.Connection = con

                cmd.ExecuteNonQuery()

                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If



            If Trim(AirwayClass.Text) = "Economy Class" Then
                Dim cl As String = "update scheduleFlights set EconomyClassSeatAvailable=EconomyClassSeatAvailable - 1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(cl)
                cmd.Connection = con

                cmd.ExecuteNonQuery()

                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()

            End If

            MessageBox.Show("Confirmed", "Airline reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            FlightNo.Text = ""

            AirwayClass.Text = ""
            Fare.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Rstatus.Text = ""

            PnrNo.Text = ""

            SSR.Text = ""
            Gender.Text = ""
            MealPref.Text = ""
            SeatPref.Text = ""




        End If

    End Sub

    Private Sub PrintTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintTicket.Click

        'Print Ticket

        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing


        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim ct As String = "select AirlineName,arrivalTime,departureTime from flights,aircraft where aircraft.aircraftTypeId=flights.aircraftTypeId and flightNo=@find"



        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "FlightNo"))
        cmd.Parameters("@find").Value = FlightNo.Text
        rdr = cmd.ExecuteReader()

        If rdr.Read Then
            Aircraft.AirlineName.Text = rdr.GetString(0)
            Flights.ArrivalTime.Text = rdr.GetString(1)
            Flights.DepartureTime.Text = rdr.GetString(2)

            frmPrintTicket.strFlightNo = FlightNo.Text
            frmPrintTicket.strPNRNo = PnrNo.Text
            frmPrintTicket.strArrTime = Flights.ArrivalTime.Text
            frmPrintTicket.strDepTime = Flights.DepartureTime.Text
            frmPrintTicket.strAirlineName = Aircraft.AirlineName.Text
            frmPrintTicket.strName = Trim(Fname.Text) & " " & Trim(Lname.Text)

            frmPrintTicket.strClass = AirwayClass.Text
            frmPrintTicket.strDate = TravelDate.Value.Day & "/" & TravelDate.Value.Month & "/" & TravelDate.Value.Year
            frmPrintTicket.Source = Source.Text
            frmPrintTicket.Destination = Destination.Text
            frmPrintTicket.Fare = Fare.Text
            frmPrintTicket.Status = Rstatus.Text
            frmPrintTicket.ShowDialog()


        Else


        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then

            con.Close()

        End If


    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Home.Show()

    End Sub
    Sub PopulateFlightNo()

        Dim conn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")


        conn.Open()

        Dim sql As New SqlCommand("Select FlightNo from flights", conn)
        sql.CommandType = CommandType.Text

        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = sql
        adapt.SelectCommand.ExecuteNonQuery()

        Dim dset As New DataSet
        adapt.Fill(dset, "flights")

        conn.Close()
        FlightNo.DataSource = dset.Tables("flights")
        FlightNo.DisplayMember = "FlightNo"
        FlightNo.ValueMember = "FlightNo"
        FlightNo.SelectedIndex = -1
    End Sub

    Private Sub Reservations_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FlightNo.Focus()
        PopulateFlightNo()
        populateSource()
        populateDestination()

        Source.Text = "select"
        Destination.Text = "select"
        AirwayClass.Items.Add("First Class")
        AirwayClass.Items.Add("Business Class")
        AirwayClass.Items.Add("Economy Class")
        Gender.Items.Add("Male")

        Gender.Items.Add("Female")
        Gender.Text = "select"
        SeatPref.Items.Add("Aisle")
        SeatPref.Items.Add("Window")
        SeatPref.Text = "select"

        MealPref.Items.Add("Veg")
        MealPref.Items.Add("Non-Veg")
        MealPref.Text = "select"



    End Sub



    Sub initializecontrols()
        FlightNo.Text = ""

        AirwayClass.Text = ""
        Fare.Text = ""
        Fname.Text = ""
        Lname.Text = ""
        Age.Text = ""
        Source.Text = ""
        Destination.Text = ""
        Rstatus.Text = ""
        PnrNo.Text = ""
        Gender.Text = ""
        MealPref.Text = ""
        SeatPref.Text = ""
        SSR.Text = ""

    End Sub
    Private Sub CheckSeatAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSeatAvailability.Click
        If Len(Trim(FlightNo.Text)) = 0 Then
            MessageBox.Show("Please specify the flight No.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(TravelDate.Text)) = 0 Then
            MessageBox.Show("Please specify the date of travel", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Len(Trim(AirwayClass.Text)) = 0 Then
            MessageBox.Show("Please specify the class of travel", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If TravelDate.Value.Date.Subtract(Today.Date).Days > 30 Then
            MessageBox.Show("Reservations for a flight commence 30 days before the date of the flight.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"



        Dim cs As String = "SELECT * FROM ScheduleFlights "

        Dim myConnection As SqlConnection
        Dim myCommand As SqlCommand
        Dim myAdapter As SqlDataAdapter

        Dim myDataSet As DataSet


        Dim rdr As SqlDataReader


        MessageBox.Show(TravelDate.Value, "Travel Date", MessageBoxButtons.OK, MessageBoxIcon.Information)




        'Instantiate the Connection object
        myConnection = New SqlConnection(connectionString)

        'Instantiate the Command object
        myCommand = New SqlCommand(cs, myConnection)

        myConnection.Open()

        'Instantiate  DataSet object
        myDataSet = New DataSet()

        'Instantiate  DataAdapter object
        myAdapter = New SqlDataAdapter()

        'Set DataAdapter command properties
        myAdapter.SelectCommand = myCommand

        'Populate the Dataset
        myAdapter.Fill(myDataSet, "ScheduleFlights")

        If (myDataSet.Tables("ScheduleFlights").Rows.Count = 0) Then
            MessageBox.Show("Record not found in the ScheduledFlights table.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf AirwayClass.Text = "First Class" Then
            Dim ca As String = "select FirstClassSeatAvailable from scheduleflights where FirstClassSeatAvailable > 0 and scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



            myCommand = New SqlCommand(ca)
            myCommand.Connection = myConnection

            rdr = myCommand.ExecuteReader()
            If rdr.Read Then

                MessageBox.Show("First class Seats available", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No first class seats available for the specified flight number, travel date, and class", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        ElseIf AirwayClass.Text = "Economy Class" Then
            Dim ct As String = "select EconomyClassSeatAvailable from scheduleflights where EconomyClassSeatAvailable > 0 and scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"


            myCommand = New SqlCommand(ct)
            myCommand.Connection = myConnection

            rdr = myCommand.ExecuteReader()
            If rdr.Read Then

                MessageBox.Show("Economy class Seats available", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No economy seats available for the specified flight number, travel date, and class", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


            If Not rdr Is Nothing Then
                rdr.Close()
            End If

        ElseIf AirwayClass.Text = "Business Class" Then
            Dim ct As String = "select BusinessClassSeatAvailable from scheduleflights where BusinessClassSeatAvailable > 0 and scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



            myCommand = New SqlCommand(ct)
            myCommand.Connection = myConnection

            rdr = myCommand.ExecuteReader()
            If rdr.Read Then

                MessageBox.Show("Business class Seats available", "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No seats available for the specified flight number, travel date, and class", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


            If Not rdr Is Nothing Then
                rdr.Close()
            End If
        End If

    End Sub
    Sub AutoGenerate()
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        Dim count As Integer

        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()

        Dim ct As String = "select count(*) from Reservations"

        cmd = New SqlCommand(ct)
        cmd.Connection = con


        count = Convert.ToInt32(cmd.ExecuteScalar()) + 1
        PnrNo.Text = "P000" + count.ToString()
        con.Close()

    End Sub
    Private Sub Age_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Age.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If
    End Sub

    Private Sub Fare_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Fare.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True
        End If
    End Sub
   

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
   

   
    Sub populateSource()
        Dim conn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")


        conn.Open()

        Dim sql As New SqlCommand("Select distinct Source from Sector", conn)
        sql.CommandType = CommandType.Text

        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = sql
        adapt.SelectCommand.ExecuteNonQuery()

        Dim dset As New DataSet
        adapt.Fill(dset, "Sector")

        conn.Close()
        Source.DataSource = dset.Tables("Sector")
        Source.DisplayMember = "Source"
        Source.ValueMember = "Source"
    End Sub

    Sub populateDestination()
        Dim conn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")


        conn.Open()

        Dim sql As New SqlCommand("Select distinct Destination from Sector", conn)
        sql.CommandType = CommandType.Text

        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = sql
        adapt.SelectCommand.ExecuteNonQuery()

        Dim dset As New DataSet
        adapt.Fill(dset, "Sector")

        conn.Close()
        Destination.DataSource = dset.Tables("Sector")
        Destination.DisplayMember = "Destination"
        Destination.ValueMember = "Destination"
    End Sub

   


    Private Sub FlightNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FlightNo.KeyPress
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        If Len(Trim(AirwayClass.Text)) = 0 Then
            MessageBox.Show("Please Specify the Class Preference of the passenger", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If (AirwayClass.Text) = "First Class" Then

                Dim ct As String = "SELECT  Sector.Source, Sector.Destination, Sector.FirstClassFare FROM  Flights INNER JOIN Sector ON Flights.SectorID = Sector.SectorID and FlightNo=@FIND"


                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.Add(
           New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "FlightNo"))
                cmd.Parameters("@find").Value = FlightNo.Text
                rdr = cmd.ExecuteReader()
                If rdr.Read Then


                    Source.Text = rdr.GetString(0)
                    Destination.Text = rdr.GetString(1)
                    Fare.Text = rdr.GetString(2)
                End If

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
            If (AirwayClass.Text) = "Business Class" Then

                Dim ct As String = "SELECT  Sector.Source, Sector.Destination, Sector.BusinessClassFare FROM  Flights INNER JOIN Sector ON Flights.SectorID = Sector.SectorID and FlightNo=@FIND"


                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.Add(
           New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "FlightNo"))
                cmd.Parameters("@find").Value = FlightNo.Text
                rdr = cmd.ExecuteReader()
                If rdr.Read Then


                    Source.Text = rdr.GetString(0)
                    Destination.Text = rdr.GetString(1)
                    Fare.Text = rdr.GetString(2)
                End If

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
            If (AirwayClass.Text) = "Economy Class" Then

                Dim ct As String = "SELECT  Sector.Source, Sector.Destination, Sector.EconomyClassFare FROM  Flights INNER JOIN Sector ON Flights.SectorID = Sector.SectorID and FlightNo=@FIND"


                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.Add(
           New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "FlightNo"))
                cmd.Parameters("@find").Value = FlightNo.Text
                rdr = cmd.ExecuteReader()
                If rdr.Read Then


                    Source.Text = rdr.GetString(0)
                    Destination.Text = rdr.GetString(1)
                    Fare.Text = rdr.GetString(2)
                End If

                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        End If
    End Sub


   
    Private Sub NewRecord_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewRecord.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(NewRecord, "to enter new record")
    End Sub

    Private Sub CheckSeatAvailability_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSeatAvailability.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(CheckSeatAvailability, "to check seat availability in different classes of different flights")
    End Sub

    Private Sub Save_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Save.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Save, "to save the record")
    End Sub

    
    

    Private Sub PrintTicket_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintTicket.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(PrintTicket, "to print airline ticket")
    End Sub

    Private Sub cmdExit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExit.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(cmdExit, "to close the form")
    End Sub

    Private Sub Button3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button3, "to get details related to entered PNR No.")
    End Sub

    Private Sub Button2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button2, "to cancel entered PNR No.")
    End Sub

    Private Sub Button4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button4, "to get source location, destination location and fare related to selected Flight No.")
    End Sub

    Private Sub SeatPref_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeatPref.SelectedIndexChanged

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub FlightNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlightNo.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If TextBox5.Text = TextBox4.Text Then
            TextBox3.Text = "Match"
            TextBox3.ForeColor = Color.Green

        Else
            TextBox3.Text = "Not match"
            TextBox3.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub

    Private Sub Age_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Age.TextChanged

    End Sub
End Class