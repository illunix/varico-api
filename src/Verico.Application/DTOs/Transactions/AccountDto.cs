﻿namespace Verico.Application.DTOs.Transactions;

public sealed record AccountDto(
    Guid ReferenceId,
    string FullName
);