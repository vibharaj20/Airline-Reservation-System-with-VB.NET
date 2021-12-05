Public Class ADMIN_Page

    Private Sub ReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationToolStripMenuItem.Click
        Me.Hide()
        COLLECTION.Show()

    End Sub

    Private Sub AircraftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AircraftToolStripMenuItem.Click
        Me.Hide()
        Aircraft.Show()

    End Sub

    Private Sub FlightsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlightsToolStripMenuItem.Click
        Me.Hide()
        Flights.Show()


    End Sub

    Private Sub SectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SectorToolStripMenuItem.Click
        Me.Hide()
        Sector.Show()

    End Sub

    Private Sub AirlineScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AirlineScheduleToolStripMenuItem.Click
        ScheduleFlight.Show()
        Me.Hide()

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub CancellationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancellationToolStripMenuItem.Click
        Me.Hide()
        Refund.Show()

    End Sub

    Private Sub ADMIN_Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label3.Text = Format(Now, "dd-MMM-yyyy")
        Me.Label4.Text = Format(Now, "hh:mm")
    End Sub
End Class