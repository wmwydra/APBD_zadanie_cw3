namespace APBD_cw3;
using System;

public class OverfillException : Exception
{
    public OverfillException() : base("The given load is too heavy for that container.")
    { }

    public OverfillException(string message)
        : base(message)
    { }

    public OverfillException(string message, Exception inner)
        : base(message, inner)
    { }
}

public class DangerException : Exception
{
    public DangerException() : base("This is a dangerous load. You cannot load the whole container.")
    { }

    public DangerException(string message)
        : base(message)
    { }

    public DangerException(string message, Exception inner)
        : base(message, inner)
    { }
}

public class WrongLoadTypeException : Exception
{
    public WrongLoadTypeException() : base("The given load type is wrong.")
    { }

    public WrongLoadTypeException(string message) : base(message)
    { }
    
    public WrongLoadTypeException(string message, Exception inner)
        : base(message, inner)
    { }
}

public class LowTemperatureException : Exception
{
    public LowTemperatureException() : base("The temperature of this container is too low for the load.")
    {
    }
    
    public LowTemperatureException(string message) : base(message)
    { }
    
    public LowTemperatureException(string message, Exception inner)
        : base(message, inner)
    { }
}

public class LoadContradictionException : Exception
{
    public LoadContradictionException() : base("This container is already loaded with a different load.")
    {
    }
    
    public LoadContradictionException(string message) : base(message)
    { }
    
    public LoadContradictionException(string message, Exception inner)
        : base(message, inner)
    { }
}