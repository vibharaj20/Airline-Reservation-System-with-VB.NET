Imports System.Drawing.Printing
Public Class print_cancle_ticket
    Friend strPnrNo, strName, dRefundAmt, strStatus, strFlightNo, strClass, strDate, Source, Destination, Fare As String

    Private Sub print_cancle_ticket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPrint.BackColor = Color.WhiteSmoke
        txtPrint.Text = "                                                 INDIAN AIRWAYS                                "
        txtPrint.Text &= Chr(13) & "                                                    "
        txtPrint.Text &= Chr(13) & "                                                     "
        txtPrint.Text &= Chr(13) & "                                                    Ticket Refund Receipt"
        txtPrint.Text &= Chr(13) & "      ----------------------------------------------------------------------------------------------------------------"
        txtPrint.Text &= Chr(13) & "                                                                                   Issued On: " & DateTime.Now
        txtPrint.Text &= Chr(13) & "             NOT TRANSFERABLE" & Chr(13) & Chr(13)
        txtPrint.Text &= Chr(13) & Chr(13) & "   PNR No. : " & strPnrNo & "                                            Passenger Name: " & strName
        txtPrint.Text &= Chr(13) & Chr(13) & "   Flight No: " & strFlightNo
        txtPrint.Text &= Chr(13) & Chr(13) & "   Class : " & strClass
        txtPrint.Text &= Chr(13) & Chr(13) & "   Travel Date : " & strDate
        txtPrint.Text &= Chr(13) & Chr(13) & "   Source Location : " & Source
        txtPrint.Text &= Chr(13) & Chr(13) & "   Destination Location : " & Destination
        txtPrint.Text &= Chr(13) & "             Status :" & strStatus
        txtPrint.Text &= Chr(13) & Chr(13) & "   Fare Amount :" & Fare & "                                             Refund Amount : " & dRefundAmt
        txtPrint.Text &= Chr(13) & "---------------------------------------------------HAVE A GOOD DAY----------------------------------------------------"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        prndlgPrintTicket.Document = prndocPrintTicket
        Dim result As DialogResult = prndlgPrintTicket.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            prndocPrintTicket.Print()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Cancle_Reservation.Show()

    End Sub

    Private Sub prndocPrintTicket_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prndocPrintTicket.PrintPage
        e.Graphics.DrawString(txtPrint.Text, New Font("Century Schoolbook", 10, FontStyle.Bold), Brushes.Red, 150, 125)


    End Sub
End Class