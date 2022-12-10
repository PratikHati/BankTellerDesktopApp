Imports System.IO

Public Class frmBankTellerApp

    Private currentAccount As Account
    Private ReadOnly filePath As String = "../../accounts.dat"


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If currentAccount.GetData() Then
            Using writer As New StreamWriter(filePath, False)
                For i As Integer = 0 To currentAccount.Records.Count - 1
                    If currentAccount.AccountId = currentAccount.Records(i).AccountId Then
                        writer.WriteLine(currentAccount.AccountId & "," & currentAccount.AccountName & "," & currentAccount.Balance.ToString())
                    Else
                        writer.WriteLine(currentAccount.Records(i).AccountId & "," & currentAccount.Records(i).AccountName & "," & currentAccount.Records(i).Balance.ToString())
                    End If

                Next
            End Using
        Else
            MessageBox.Show(currentAccount.ErrorMessage, "Error")
            Clear()
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        currentAccount = New Account()
        currentAccount.FilePath = filePath

        If currentAccount.GetData(txtAccountNum.Text) Then
            lblAccountName.Text = currentAccount.AccountName
            lblBalance.Text = currentAccount.Balance.ToString("c")
            btnDeposit.Enabled = True
            btnWithdraw.Enabled = True
        Else
            MessageBox.Show(currentAccount.ErrorMessage, "Error")
            Clear()
        End If
    End Sub

    Private Sub Clear()
        lblAccountName.Text = String.Empty
        lblBalance.Text = String.Empty
        btnDeposit.Enabled = False
        btnWithdraw.Enabled = False
    End Sub

    Private Sub btnDeposit_Click(sender As Object, e As EventArgs) Handles btnDeposit.Click
        Try
            currentAccount.Deposite(CDec(txtAmount.Text))
            lblBalance.Text = currentAccount.Balance.ToString("c")
        Catch ex As Exception
            MessageBox.Show("Please enter a numeric amount", "Error")

        End Try
    End Sub

    Private Sub btnWithdraw_Click(sender As Object, e As EventArgs) Handles btnWithdraw.Click
        Try
            If currentAccount.WithDrwaw(CDec(txtAmount.Text)) Then
                lblBalance.Text = currentAccount.Balance.ToString("c")
            Else
                MessageBox.Show(currentAccount.ErrorMessage, "Error")

            End If

        Catch ex As Exception
            MessageBox.Show(currentAccount.ErrorMessage, "Error")

        End Try
    End Sub

    Private Sub btnTotals_Click(sender As Object, e As EventArgs) Handles btnTotals.Click
        MessageBox.Show($"Total deposites = {currentAccount.TotalDeposite}" &
                        $"Total withdrawals = {currentAccount.TotalWithraw}")

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub


End Class
