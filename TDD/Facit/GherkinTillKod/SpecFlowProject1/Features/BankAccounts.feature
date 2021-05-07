Feature: BankAccounts
	The user wants to transfer money between two accounts
	to buy pizza... FFS!

@BankTransfers
Scenario: The user wants to transfer money to buy a freaking pizza!
	Given the bank account has 10532.00 SEK
	And the card account contains less than 120
	When transfering the amount missing on the card account
	Then the card account should have 120 SEK

@BankTransfers
	Scenario: Blah blah blah bank account
	Given account is 10532.00 SEK
	And card has less than 10
	Then card has 120 SEK
