using System;
using System.Collections.Generic;

namespace New.Hope.Application
{
    public class Notifier : INotifier
    {
        public Notifier()
        {
            Errors = new List<Notify>();
            Warnings = new List<Notify>();
        }

        public List<Notify> Errors { get; private set; }

        public List<Notify> Warnings { get; private set; }
    }
}
