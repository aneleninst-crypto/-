public class Account //в самом начале лучше объявить enum для выбора счета BankCard и GooglePay
//еще класс будто снова нарушует принцип SRP и берет на себя одного слишком много 
// можно и без enum сделать отдельный класс Account и отдельный класс с денежными операциями. 
//класс Account может в себе содержать два публичных после BankCard и GooglePay, чтобы мы смогли к ним свободно обращаться
// А в классе с денежными операциями содержались бы методы, которыми мы бы смогли оперировать в ходе наших денежных манипуляциями
{
    private decimal _bankCardAmountInRub = 0; // Здесь можно объявить Dictionary где первое будет название enum, а второе вид счета
    private decimal _googlePayAmount = 0;
    public void Deposit(bool isBankCard, decimal amount)
    {
        if (isBankCard)
        {
            _bankCardAmountInRub += amount; 
        }
        else   // нет никакой ошибки, если пополнение отрицательное 
        {
            _googlePayAmount += amount; 
        }
    }
    public void Withdraw(bool isBankCard, decimal amount) // в данном методе всё как-то дублируется, выглядит странно 
    {
        if (isBankCard)
        {
            ThrowIfNotEnoughMoney(_bankCardAmountInRub, amount);
            _bankCardAmountInRub -= amount;
        }
        else
        {
            ThrowIfNotEnoughMoney(_googlePayAmount, amount);
            _googlePayAmount -= amount;
        }
    }
    public decimal GetAccountMoneyInRub(bool isBankCard) => isBankCard ?
        _bankCardAmountInRub : _googlePayAmount;
    private static void ThrowIfNotEnoughMoney(decimal accountAmountMoney, decimal
        tryToWithdraw)
    {
        if (accountAmountMoney - tryToWithdraw < 0)
        {
            throw new ArgumentException("Can't withdraw more than money on account");
        }
    }
}