# BankTellerDesktopApp
A windows desktop application to deposite and withdraw amount. Also save the data in a .dat file.
Bank Teller App

1. Existing Account information (ID, account name, and account balance) will be stored in a data file.
2. The user must be able to input an account number and initiate a search for a matching account. If the account is found in the data file, the application will retrieve the name of the account holder and the account balance.
3. The user must be able to enter an amount of money to deposit or withdraw. The application will show the updated account balance.
4. The user should be able to view total Deposits and Withdrawal for the account.

                                              Accounts.dat file
                                              AcctNumber,Name,Balance
                                              11111,Sarah Connor,825.50
                                              22222,Pavol Almasi,1000000
                                              33333,Guy Poor,3
                                              44444,Guy Rich,123456789
                                              55555,Bob Sponge,515
                                              66666,Marie Currie,88


Form elements:
• Find—opens the account data file and searches for a record containing a
matching account number. If a match is found, this method copies the account name and balance to Label controls on the form.
• Deposit—reads the deposit amount from a TextBox control and passes it to
the AccountDeposit method. Displays the account’s updated balance in a Label.
• Withdraw—reads the withdrawal amount from a TextBox control and
passes it to the Account.Withdraw method. If the latter method returns True, this
method displays the account’s updated balance in a Label. If the Withdraw method
returns False, an error message is displayed in a Label.
• Totals—displays totals of Deposits and Withdrawals
• Save—saves new balance into Accounts.dat file
