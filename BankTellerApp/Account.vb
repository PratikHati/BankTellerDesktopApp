Imports System.Diagnostics.Eventing.Reader
Imports System.IO

Public Class Account

    Public Property AccountId As String
    Public Property AccountName As String
    Public Property Balance As Decimal
    Public Property FilePath As String
    Public Property ErrorMessage As String
    Public Property Records As List(Of Account)


    Private _totalDeposite As Decimal

    Private _totalWithdraw As Decimal

    Public ReadOnly Property TotalDeposite() As Decimal

        Get
            Return _totalDeposite
        End Get
    End Property

    Public ReadOnly Property TotalWithraw() As Decimal

        Get
            Return _totalWithdraw
        End Get
    End Property

    Public Sub New()
        AccountName = String.Empty
        Balance = 0D
        Records = New List(Of Account)

    End Sub

    Public Function GetData(acctid As String) As Boolean

        Dim infile As StreamReader = Nothing
        ErrorMessage = String.Empty

        Try
            infile = File.OpenText(FilePath)
            While Not infile.EndOfStream
                Dim line As String = infile.ReadLine()

                Dim fields() As String = line.Split(","c)

                If acctid = fields(0) Then
                    AccountId = fields(0)
                    AccountName = fields(1)
                    Balance = CDec(fields(2))
                    _totalDeposite = 0D
                    _totalWithdraw = 0D
                    Return True
                End If
            End While
            ErrorMessage = "Account " + acctid + " Not found"
            Return False
        Catch ex As Exception
            ErrorMessage = ex.Message
            Return False
        Finally
            If infile IsNot Nothing Then
                infile.Close()
            End If
        End Try

    End Function


    Public Function GetData() As Boolean

        Dim infile As StreamReader = Nothing
        ErrorMessage = String.Empty

        Dim fields() As String

        Try
            infile = File.OpenText(FilePath)
            While Not infile.EndOfStream
                Dim line As String = infile.ReadLine()

                fields = line.Split(","c)

                Dim account As Account
                account = New Account
                account.AccountId = fields(0)
                account.AccountName = fields(1)
                account.Balance = CDec(fields(2))

                Records.Add(account)
            End While

            If Records Is Nothing Then
                ErrorMessage = "File Not found"
                Return False
            End If

            Return True
        Catch ex As Exception
            ErrorMessage = ex.Message
            Return False
        Finally
            If infile IsNot Nothing Then
                infile.Close()
            End If
        End Try

    End Function

    Public Sub Deposite(amount As Decimal)
        _totalDeposite += amount
        Balance += amount

    End Sub

    Public Function WithDrwaw(amount As Decimal) As Boolean

        If Balance >= amount Then
            _totalWithdraw += amount
            Balance -= amount
            Return True
        Else
            ErrorMessage = "Balance is too low to withdraw"
            Return False
        End If
    End Function
End Class
