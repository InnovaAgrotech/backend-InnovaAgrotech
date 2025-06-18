﻿namespace InnatAPP.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SalvarAsync(CancellationToken ct = default);
    }
}