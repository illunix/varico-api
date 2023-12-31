﻿namespace Varico.Core.ValueObjects;

public sealed record AccountBalance
{
    public decimal Value { get; }

    public AccountBalance(decimal value)
        => Value = value;

    public AccountBalance Subtract(TransactionAmount transactionAmount)
        => new(Value - transactionAmount);

    public static implicit operator decimal(AccountBalance transactionAmount)
        => transactionAmount.Value;

    public static implicit operator AccountBalance(decimal transactionAmount)
        => new(transactionAmount);
}