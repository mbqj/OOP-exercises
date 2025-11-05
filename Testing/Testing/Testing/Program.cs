public class Pin
{
    const int CRITICAL_AMOUNT = 350;
    const int MAX_TRANSACTIONS = 4;
    private int time2pin = MAX_TRANSACTIONS;
    public bool Expend (int amount) {
        if (time2pin==0 || amount>CRITICAL_AMOUNT) {
            time2pin = MAX_TRANSACTIONS;
        }
        return amount > CRITICAL_AMOUNT || --time2pin == 0;
    }
    public static void Main (string[] args) {
        Pin pin = new Pin();
        for (int i=0 ; i<20 ; i++) {
            bool give_pin = pin.Expend(42);
            Console.WriteLine(i + ": 42 -> " + give_pin);
        }
    }
}
