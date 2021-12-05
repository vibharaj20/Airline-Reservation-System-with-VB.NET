Imports System.Data.SqlClient
Public Class Form1

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ADMIN_LOGIN.Show()

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("USER")
        ComboBox1.Items.Add("ADMIN")
        ComboBox1.Text = "SELECT"


    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        ADMIN_LOGIN.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub TextBox6_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ComboBox1.Text = "USER" Then
            Dim mno As String
            mno = TextBox10.Text
            Dim ono As String
            ono = TextBox11.Text



            Dim cnPodaci As New SqlConnection
            cnPodaci.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sharv\Desktop\VIBHA\airline_reservation_system_vb.net__0\Airline Reservation System VB.Net\airline\AirlineReservationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            cnPodaci.Open()
            Dim cm As New SqlCommand
            cm.CommandText = "SELECT * FROM users where UserName = '" & mno & "' And Password = '" & ono & "'"
            cm.Connection = cnPodaci
            Dim dr As SqlDataReader
            dr = cm.ExecuteReader

            If dr.HasRows Then


                MsgBox(" succsessfully logged ")
                TextBox10.Text = ""
                TextBox11.Text = ""
                Me.Hide()

                Home.Show()

                dr.Close()
            Else
                Beep()
                MessageBox.Show("Your username Or password is not match", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox10.Text = ""
                TextBox11.Text = ""

                TextBox10.Focus()


            End If
            cnPodaci.Close()
        ElseIf ComboBox1.Text = "ADMIN" Then
           

            If TextBox10.Text = "lokesh " Or TextBox11.Text = "password" Then
                Beep()
                Beep()
                MsgBox("You are successfully logged.")
                TextBox10.Text = ""
                TextBox11.Text = ""
                ADMIN_Page.Show()
                Me.Hide()

            Else

                Beep()
                MessageBox.Show("Your username Or password is not match", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox10.Text = ""
                TextBox11.Text = ""

                TextBox10.Focus()


            End If

        Else
            MessageBox.Show("Select your choice", "ADMIN or USER", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox10.Text = ""
        TextBox11.Text = ""

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        signup.Show()

    End Sub
End Class
