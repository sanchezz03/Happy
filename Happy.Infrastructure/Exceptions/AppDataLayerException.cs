﻿using Happy.Common.Enums;
using Happy.Common.Exceptions;

namespace Happy.Infrastructure.Exceptions;

public class AppDataLayerException : AppBaseException
{
    public AppDataLayerException()
        : base()
    {
    }

    public AppDataLayerException(string? message)
        : base(message)
    {
    }

    public AppDataLayerException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public AppDataLayerException(string? message, EDataAccessOperationType operationType)
        : this($"DL-OPERATION-TYPE [{operationType}] - {message}")
    {
    }

    public AppDataLayerException(string? message, Exception? innerException, EDataAccessOperationType operationType)
        : base($"DL-OPERATION-TYPE [{operationType}] - {message}", innerException)
    {
    }
}
