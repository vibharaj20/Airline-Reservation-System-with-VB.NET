Imports System.Data.SqlClient
Public Class Refund
    Dim rdr As SqlDataReader = Nothing

    Dim con As SqlConnection = Nothing

    Dim cmd As SqlCommand = Nothing

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Font = New Font("Century Schoolbook", 10, FontStyle.Bold)
        Dim rdr As SqlDataReader = Nothing

        Dim con As SqlConnection = Nothing

        Dim cmd As SqlCommand = Nothing
        con = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")

        con.Open()
        cmd = New SqlCommand("select * from Refunds where Date between @date And @date1", con)
        cmd.Parameters.Add("@date", SqlDbType.NChar, 30, "date").Value = DateTimePicker1.Text
        cmd.Parameters.Add("@date1", SqlDbType.NChar, 30, "date").Value = DateTimePicker2.Text






        Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)

        Dim myDataSet As DataSet = New DataSet()

        myDA.Fill(myDataSet, "Refunds")

        DataGridView1.DataSource = myDataSet.Tables("Refunds").DefaultView
        Dim sum As Double = 0

        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            sum = sum + r.Cells(2).Value

            TextBox1.Text = sum

        Next

        Label3.Text = DataGridView1.RowCount - 1

        con.Close()
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Dim RowsAffected As Integer = 0

        Dim cb As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"

        con = New SqlConnection(cb)

        con.Open()

        cmd = New SqlCommand("delete from Refunds where Date between @date And @date1", con)
        cmd.Parameters.Add("@date", SqlDbType.NChar, 30, "date").Value = DateTimePicker1.Text
        cmd.Parameters.Add("@date1", SqlDbType.NChar, 30, "date").Value = DateTimePicker2.Text



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

    Private Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button1, "to get data between two dates")
    End Sub

    Private Sub Collections_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Delete_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Delete.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Delete, "to delete the records")
    End Sub





    Private Sub Button3_MouseCaptureChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseCaptureChanged
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button3, "for Exit")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        ADMIN_Page.Show()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class