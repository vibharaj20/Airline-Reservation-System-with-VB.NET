Imports System.Drawing.Printing
Public Class Print_ticket
    Friend strPNRNo, strName, strSector, strFlightNo, strClass, strDate, strDepTime, strArrTime, Status, Fare, Source, Destination, strAirlineName As String


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        prndlgPrintTicket.Document = prndocPrintTicket
        Dim result As DialogResult = prndlgPrintTicket.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            prndocPrintTicket.Print()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Reservation.Show()


    End Sub

    Private Sub Print_ticket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPrint.BackColor = Color.WhiteSmoke
        txtPrint.Text = "                                                 INDIAN AIRWAYS                                "
        txtPrint.Text &= Chr(13) & "                                                    "
        txtPrint.Text &= Chr(13) & "                                                     "
        txtPrint.Text &= Chr(13) & "                                                    Passenger Ticket"
        txtPrint.Text &= Chr(13) & "      ----------------------------------------------------------------------------------------------------------------"
        txtPrint.Text &= Chr(13) & "                                                                                         Issued On: " & DateTime.Now
        txtPrint.Text &= Chr(13) & "             NOT TRANSFERABLE" & Chr(13) & Chr(13)
        txtPrint.Text &= Chr(13) & Chr(13) & "   PNR No. : " & strPNRNo & "                                            Passenger Name: " & strName
        txtPrint.Text &= Chr(13) & Chr(13) & "   Airline Name: " & strAirlineName
        txtPrint.Text &= Chr(13) & Chr(13) & "   Flight No: " & strFlightNo
        txtPrint.Text &= Chr(13) & Chr(13) & "   Class : " & strClass
        txtPrint.Text &= Chr(13) & Chr(13) & "   Arrival Time : " & strArrTime & "                                     Departure Time : " & strDepTime

        txtPrint.Text &= Chr(13) & Chr(13) & "   Travel Date : " & strDate
        txtPrint.Text &= Chr(13) & Chr(13) & "   Source Location : " & Source
        txtPrint.Text &= Chr(13) & Chr(13) & "   Destination Location : " & Destination
        txtPrint.Text &= Chr(13) & Chr(13) & "   Status :" & Status & "                                                     Fare :" & Fare
        txtPrint.Text &= Chr(13) & "  ------------------------------WISH YOU HAPPY JOURNEY--------------------------------------------------------------"
    End Sub
    Private Sub prndocPrintTicket_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prndocPrintTicket.PrintPage
        e.Graphics.DrawString(txtPrint.Text, New Font("Century Schoolbook", 10, FontStyle.Bold), Brushes.Black, 150, 125)

    End Sub
    Private Sub txtPrint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrint.TextChanged

    End Sub
End Class