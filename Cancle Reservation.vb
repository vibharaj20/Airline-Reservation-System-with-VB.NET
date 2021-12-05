Imports System.Data.SqlClient
Public Class Cancle_Reservation
    Dim frmRefundTicket As New print_cancle_ticket
    Dim rdr As SqlDataReader = Nothing

    Dim con As SqlConnection = Nothing

    Dim cmd As SqlCommand = Nothing
    Dim RowsAffected As Integer = 0
    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        If Len(Trim(PnrNo.Text)) = 0 Then
            MessageBox.Show("Please enter the PNR Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Trim(RStatus.Text) = "Cancelled" Then
            MessageBox.Show("This ticket is already cancelled", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error)
            clear()

        Else
            Dim cop As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cop)

            con.Open()
            If Trim(AirwayClass.Text) = "First Class" And Trim(RStatus.Text) = "Confirmed" Then

                Dim cpp As String = "update scheduleFlights set FirstClassSeatAvailable=FirstClassSeatAvailable + 1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(cpp)
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



            If Trim(AirwayClass.Text) = "Business Class" And Trim(RStatus.Text) = "Confirmed" Then

                Dim cm As String = "update scheduleFlights set BusinessClassSeatAvailable=BusinessClassSeatAvailable + 1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(cm)
                cmd.Connection = con

                cmd.ExecuteNonQuery()

                If con.State = ConnectionState.Open Then

                    con.Close()

                End If

                con.Close()
            End If



            If Trim(AirwayClass.Text) = "Economy Class" And Trim(RStatus.Text) = "Confirmed" Then
                Dim cl As String = "update scheduleFlights set EconomyClassSeatAvailable=EconomyClassSeatAvailable + 1 where scheduleflights.FlightNo = '" & FlightNo.Text & "' and FlightDate = '" & TravelDate.Text & "'"



                cmd = New SqlCommand(cl)
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



            Dim ct As String = "insert into CancelReservation(PnrNo,FirstName,LastName,RefundAmount,date) values(@INSERT1,@INSERT2,@INSERT3,@INSERT4,@INSERT5)"

            cmd =
            New SqlCommand(ct)


            cmd.Connection = con

            cmd.Parameters.Add(
            New SqlParameter("@INSERT1", System.Data.SqlDbType.NChar, 10, "PnrNo"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT2", System.Data.SqlDbType.NChar, 20, "Firstname"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT3", System.Data.SqlDbType.NChar, 20, "LastName"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT4", System.Data.SqlDbType.NChar, 10, "RefundAmount"))

            cmd.Parameters.Add(
           New SqlParameter("@INSERT5", System.Data.SqlDbType.NChar, 30, "date"))






            cmd.Parameters(
           "@INSERT1").Value = PnrNo.Text
            cmd.Parameters(
           "@INSERT2").Value = Fname.Text
            cmd.Parameters(
           "@INSERT3").Value = Lname.Text
            cmd.Parameters(
           "@INSERT4").Value = AmtRefund.Text
            cmd.Parameters(
           "@INSERT5").Value = DateTime.Now



            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If


            con.Close()


            Dim cd As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(cd)

            con.Open()



            Dim coz As String = "insert into Refunds(PnrNo,Date,RefundAmount) VALUES (@INSERT1,@INSERT2,@INSERT3)"

            cmd =
            New SqlCommand(coz)


            cmd.Connection = con

            cmd.Parameters.Add(
            New SqlParameter("@INSERT1", System.Data.SqlDbType.NChar, 10, "PnrNo"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT2", System.Data.SqlDbType.NChar, 30, "date"))

            cmd.Parameters.Add(
            New SqlParameter("@INSERT3", System.Data.SqlDbType.NChar, 10, "RefundAmount"))







            cmd.Parameters("@INSERT1").Value = PnrNo.Text
            cmd.Parameters("@INSERT2").Value = Today
            cmd.Parameters("@INSERT3").Value = AmtRefund.Text



            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If


            con.Close()





            Dim ck As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

            con = New SqlConnection(ck)

            con.Open()

            Dim co As String = "Update Reservations set RStatus = 'Cancelled' where PnrNo ='" & PnrNo.Text & "'"


            cmd =
            New SqlCommand(co)

            cmd.Connection = con
            cmd.Parameters.Add(
            New SqlParameter("Cancelled", System.Data.SqlDbType.NChar, 10, "RStatus"))
            cmd.Parameters(
            "cancelled").Value = RStatus.Text



            cmd.ExecuteReader()

            If con.State = ConnectionState.Open Then

                con.Close()

            End If
            con.Close()







            MessageBox.Show("Cancelled", "Airline reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            FlightNo.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Gender.Text = ""
            TravelDate.Text = ""
            AirwayClass.Text = ""
            RStatus.Text = ""
            Fare.Text = ""
            AmtRefund.Text = ""
            Source.Text = ""
            Destination.Text = ""
        End If


    End Sub


    Sub clear()
        PnrNo.Text = ""
        FlightNo.Text = ""
        Fname.Text = ""
        Lname.Text = ""
        Age.Text = ""
        Gender.Text = ""
        TravelDate.Text = ""
        AirwayClass.Text = ""
        RStatus.Text = ""
        Fare.Text = ""
        AmtRefund.Text = ""
        Source.Text = ""
        Destination.Text = ""
    End Sub
    Private Sub RefundTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefundTicket.Click
        'Refund Ticket
        If RStatus.Text = "cancelled" Then
            frmRefundTicket.strPnrNo = PnrNo.Text

            frmRefundTicket.strFlightNo = FlightNo.Text

            frmRefundTicket.strName = Trim(Fname.Text) & " " & Trim(Lname.Text)
            frmRefundTicket.strClass = AirwayClass.Text
            frmRefundTicket.strDate = TravelDate.Text
            frmRefundTicket.Source = Source.Text
            frmRefundTicket.Destination = Destination.Text
            frmRefundTicket.Fare = Fare.Text


            frmRefundTicket.strStatus = RStatus.Text


            frmRefundTicket.dRefundAmt = AmtRefund.Text

            frmRefundTicket.ShowDialog()
        Else

            MessageBox.Show("Cancel your ticket then print", "Airline reservation", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Cancel_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Cancel, "cancel the reservation")
    End Sub

    Private Sub GetDetails_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetDetails.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(GetDetails, "get details related to entered PNR No.")
    End Sub

    Private Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button1, "clear PNR No. textbox ")
    End Sub

    Private Sub button3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles button3.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(button3, "for Exit")
    End Sub

    Private Sub RefundTicket_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles RefundTicket.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(RefundTicket, "to print refund receipt")
    End Sub



    Private Sub CancelReservation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PnrNo.Focus()

    End Sub

    Private Sub GetDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetDetails.Click
        If Len(Trim(PnrNo.Text)) = 0 Then
            MessageBox.Show("Please enter the PNR Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PnrNo.Text = ""
            TextBox1.Text = ""
            FlightNo.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Gender.Text = ""
            TravelDate.Text = ""
            AirwayClass.Text = ""
            RStatus.Text = ""
            Fare.Text = ""
            AmtRefund.Text = ""
            PnrNo.Focus()
            Exit Sub
        End If
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Please enter the Security Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            TextBox1.Text = ""
            FlightNo.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Gender.Text = ""
            TravelDate.Text = ""
            AirwayClass.Text = ""
            RStatus.Text = ""
            Fare.Text = ""
            AmtRefund.Text = ""
            PnrNo.Focus()
            Exit Sub
        End If



        Dim cs As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cs)

        con.Open()
        Dim dt As New DataTable()

        Dim ct As String = "select pnrno, flightno, Source, Destination, FName, LName, Age, Gender,TravelDate, class, RStatus, Fare  from reservations where PnrNo=@find And SePassword=@find1"


        cmd = New SqlCommand(ct)
        cmd.Connection = con
        cmd.Parameters.Add(
       New SqlParameter("@find", System.Data.SqlDbType.NChar, 10, "PnrNo"))
        cmd.Parameters("@find").Value = PnrNo.Text
        cmd.Parameters.Add(
       New SqlParameter("@find1", System.Data.SqlDbType.NChar, 10, "SePassword"))
        cmd.Parameters("@find1").Value = TextBox1.Text
        rdr = cmd.ExecuteReader()
        If Not rdr.Read Then
            MsgBox("Sorry ! No Records Found")
            PnrNo.Text = ""
            TextBox1.Text = ""
            FlightNo.Text = ""
            Source.Text = ""
            Destination.Text = ""
            Fname.Text = ""
            Lname.Text = ""
            Age.Text = ""
            Gender.Text = ""
            TravelDate.Text = ""
            AirwayClass.Text = ""
            RStatus.Text = ""
            Fare.Text = ""
            AmtRefund.Text = ""
            PnrNo.Focus()
        Else
            TextBox1.Text = ""
            PnrNo.Text = rdr.GetString(0)
            FlightNo.Text = rdr.GetString(1)
            Source.Text = rdr.GetString(2)
            Destination.Text = rdr.GetString(3)
            Fname.Text = rdr.GetString(4)
            Lname.Text = rdr.GetString(5)
            Age.Text = rdr.GetString(6)
            Gender.Text = rdr.GetString(7)
            TravelDate.Text = rdr.GetString(8)
            AirwayClass.Text = rdr.GetString(9)
            RStatus.Text = rdr.GetString(10)
            Fare.Text = rdr.GetString(11)
            CalculateRefundAmt()



        End If

        If Not rdr Is Nothing Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        PnrNo.Text = ""
        FlightNo.Text = ""
        Fname.Text = ""
        Lname.Text = ""
        Age.Text = ""
        Gender.Text = ""
        TravelDate.Text = ""
        AirwayClass.Text = ""
        RStatus.Text = ""
        Fare.Text = ""
        AmtRefund.Text = ""
        Source.Text = ""
        Destination.Text = ""

    End Sub

    Private Sub CalculateRefundAmt()
        If Trim(RStatus.Text) = "waiting list" Then
            AmtRefund.Text = Fare.Text
        Else
            Dim dtDate As Date
            dtDate = TravelDate.Text
            Dim dtTravelDate As New DateTime(dtDate.Year, dtDate.Month, dtDate.Day)
            Dim intNumDays As Integer
            intNumDays = dtTravelDate.Subtract(Today.Date).Days
            If intNumDays <= 1 Then
                AmtRefund.Text = CStr(CDec(Fare.Text) * 0.9)
            Else
                AmtRefund.Text = Fare.Text
            End If
        End If
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        Me.Close()
        Home.Show()

    End Sub
End Class