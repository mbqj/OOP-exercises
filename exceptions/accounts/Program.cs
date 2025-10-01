//T1 Marcus

int[] accounts = {903, 716, 67};

int GetAccountNumber()
{
    Console.WriteLine("Enter an account number: ");

    //This Convert.ToInt32 may throw an exception, if the string cannot be converted to a number!
    //We do not handle this exception here, so it will escape this function!
    return Convert.ToInt32(Console.ReadLine());
}

void PrintAccountState(int accountId)
{
    //Try catch used to handle the exception that could happen, if a number is outside the bounds of our array
    try {
        Console.WriteLine("Account "+ accountId+ " contains "+ accounts[accountId]);
    }
    catch (Exception e) {
        Console.WriteLine("Account ID not recognized!\n");
    }
}

while (true)
{
    //Try catch used to handle the exception that escapes the GetAccountNumber method!
    try {
        int accountId = GetAccountNumber();
        PrintAccountState(accountId);
    }
    catch (Exception e) {
        Console.WriteLine("Bad input!");
    }
}
