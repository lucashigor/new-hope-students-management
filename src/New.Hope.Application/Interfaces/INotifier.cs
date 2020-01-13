using System;
using System.Collections.Generic;

namespace New.Hope.Application
{
    public interface INotifier
    {
        List<Notify> Errors { get; }

        List<Notify> Warnings { get; }
    }
}
